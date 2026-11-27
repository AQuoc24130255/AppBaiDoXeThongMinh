using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views
{
    public partial class FormCheckOut : Form
    {
        private readonly AppDbContext _db;
        private readonly CultureInfo _viCulture = new CultureInfo("vi-VN");
        private readonly int _currentUserId;
        private readonly int _currentShiftId;
        private Ticket _activeTicket;
        private bool _isLostCardMode;
        private readonly RadioButton _rdoCash = new();
        private readonly RadioButton _rdoTransfer = new();
        private string _paymentMethod = "Tiền mặt";

        public FormCheckOut(int userId)
        {
            InitializeComponent();
            _db = new AppDbContext();
            _currentUserId = userId;
            _currentShiftId = FindShiftId();

            InitializeData();
            SetupPaymentMethodButtons();
            RegisterEvents();
        }

        private int FindShiftId()
        {
            var activeShift = _db.Shifts
                .Where(s => s.UserId == _currentUserId && (s.EndDate == null || s.EndDate == DateTime.MinValue))
                .OrderByDescending(s => s.StartDate)
                .FirstOrDefault();

            return activeShift != null ? activeShift.ShiftId : -1;
        }

        private void InitializeData()
        {
            dgvParkedVehicles.AutoGenerateColumns = false;
            LoadParkedVehicles();
            UpdateStatistics();
            ResetCheckOutLane();

            tmrClock.Interval = 1000;
            tmrClock.Start();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            txtCardCodeOut.Focus();
        }

        private void RegisterEvents()
        {
            tmrClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");

            txtCardCodeOut.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FindTicketByCardCode();
                    e.SuppressKeyPress = true;
                }
            };

            txtLicensePlateOut.TextChanged += (s, e) => VerifyLicensePlate();
            txtLicensePlateOut.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteCheckOut();
                    e.SuppressKeyPress = true;
                }
            };

            btnCheckOut.Click += (s, e) => ExecuteCheckOut();
            btnLoadLostCard.Click += (s, e) => LoadTicketFromGrid(isLostCard: true);
            dgvParkedVehicles.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) LoadTicketFromGrid(isLostCard: false); };
            txtSearch.TextChanged += (s, e) => LoadParkedVehicles(txtSearch.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                ExecuteCheckOut();
                return true;
            }
            if (keyData == Keys.F5)
            {
                LoadTicketFromGrid(isLostCard: true);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FindTicketByCardCode()
        {
            string cardCode = txtCardCodeOut.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(cardCode)) return;

            var ticket = _db.Tickets
                .Include(t => t.Vehicle)
                .Include(t => t.PriceConfig)
                .Include(t => t.ParkingSlot)
                .FirstOrDefault(t => t.TicketCode == cardCode && t.Status == TicketStatus.Inparking);

            if (ticket == null)
            {
                MessageBox.Show($"Không tìm thấy xe đang gửi với mã thẻ [{cardCode}]!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetCheckOutLane();
                return;
            }

            BindTicketToUI(ticket, isLostCard: false);
        }
        
        private void LoadTicketFromGrid(bool isLostCard)
        {
            if (dgvParkedVehicles.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một xe trong danh sách bên dưới!", "Chưa chọn xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var cellValue = dgvParkedVehicles.CurrentRow.Cells["colId"].Value;
            if (cellValue == null || cellValue == DBNull.Value || !int.TryParse(cellValue.ToString(), out int ticketId))
            {
                MessageBox.Show("Dòng được chọn không hợp lệ!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var ticket = _db.Tickets
                .Include(t => t.Vehicle)
                .Include(t => t.PriceConfig)
                .Include(t => t.ParkingSlot)
                .FirstOrDefault(t => t.TicketId == ticketId);

            if (ticket != null)
            {
                BindTicketToUI(ticket, isLostCard: isLostCard);
            }
        }

        private void BindTicketToUI(Ticket ticket, bool isLostCard)
        {
            _activeTicket = ticket;
            _isLostCardMode = isLostCard;

            txtCardCodeOut.Text = ticket.TicketCode;
            txtLicensePlateRecorded.Text = ticket.Vehicle?.LicensePlate ?? "";
            txtLicensePlateOut.Clear();

            decimal fee = CalculateParkingFee(ticket, isLostCard);
            
            if (ticket.IsMonthly && !isLostCard)
            {
                lblFee.Text = "0 VNĐ (VÉ THÁNG)";
            }
            else if (isLostCard)
            {
                lblFee.Text = string.Format(_viCulture, "{0:N0} VNĐ ", fee);
            }
            else
            {
                lblFee.Text = string.Format(_viCulture, "{0:N0} VNĐ", fee);
            }

            bool needPayment = fee > 0;
            _rdoCash.Enabled = needPayment;
            _rdoTransfer.Enabled = needPayment;
            if (!needPayment) _rdoCash.Checked = true;

            lblMatchStatus.Text = isLostCard
                ? "CHẾ ĐỘ MẤT THẺ – GÕ BIỂN SỐ ĐỂ XÁC MINH!"
                : "GÕ BIỂN SỐ XE RA ĐỂ ĐỐI CHIẾU!";
            lblMatchStatus.BackColor = Color.Gold;
            lblMatchStatus.ForeColor = Color.Black;

            txtLicensePlateOut.Focus();
        }

        private string NormalizePlate(string? plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return string.Empty;
            return Regex.Replace(plate, @"[^a-zA-Z0-9]", "").ToUpper();
        }

        private bool VerifyLicensePlate()
        {
            if (_activeTicket == null) return false;

            string recordedPlate = NormalizePlate(_activeTicket.Vehicle?.LicensePlate);
            string enteredPlate = NormalizePlate(txtLicensePlateOut.Text);

            if (string.IsNullOrEmpty(enteredPlate))
            {
                lblMatchStatus.Text = "VUI LÒNG GÕ BIỂN SỐ XE RA!";
                lblMatchStatus.BackColor = Color.Gold;
                lblMatchStatus.ForeColor = Color.Black;
                return false;
            }

            if (recordedPlate == enteredPlate)
            {
                lblMatchStatus.Text = "KHỚP BIỂN SỐ – NHẤN ENTER HOẶC F2 ĐỂ MỞ BARRIER!";
                lblMatchStatus.BackColor = Color.FromArgb(40, 167, 69);
                lblMatchStatus.ForeColor = Color.White;
                return true;
            }

            lblMatchStatus.Text = "BIỂN SỐ KHÔNG KHỚP VỚI LÚC VÀO!";
            lblMatchStatus.BackColor = Color.Crimson;
            lblMatchStatus.ForeColor = Color.White;
            return false;
        }

        private decimal CalculateParkingFee(Ticket ticket, bool isLostCard)
        {
            if (ticket.IsMonthly) return 0m;
            decimal basePrice = ticket.PriceConfig?.DayPrice ?? 5000m;
            decimal lostCardFee = isLostCard ? (ticket.PriceConfig?.LostTicketFee ?? 0m) : 0m;
            return basePrice + lostCardFee;
        }
        private void ExecuteCheckOut() 
        { 
            if (_activeTicket == null) 
            {
                MessageBox.Show("Chưa có thông tin xe ở Làn Ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                txtCardCodeOut.Focus(); 
                return; 
            }
            
            if (!VerifyLicensePlate()) 
            { 
                MessageBox.Show(
                    $"Biển số nhập vào [{txtLicensePlateOut.Text}] KHÔNG KHỚP với lúc vào [{_activeTicket.Vehicle?.LicensePlate}].\nKhông được phép mở barrier cho xe ra!",
                    "Từ chối xuất bến",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtLicensePlateOut.SelectAll();
                txtLicensePlateOut.Focus();
                return;
            } 
            
            
            if (_currentShiftId == -1) 
            { 
                MessageBox.Show("Đang ở ngoài ca trực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return; 
            }
            
            DateTime checkOutTime = DateTime.Now; 
            decimal totalAmount = CalculateParkingFee(_activeTicket, _isLostCardMode);
            
            if (_paymentMethod == "Chuyển khoản" && totalAmount > 0) 
            { 
                if (!ShowTransferQrDialog(totalAmount, _activeTicket.TicketCode))
                    return;
            }
            
            _activeTicket.ExitTime = checkOutTime; 
            _activeTicket.Status = TicketStatus.CheckedOut;
            
            if (_activeTicket.ParkingSlot != null) 
            { 
                _activeTicket.ParkingSlot.IsOccupied = false; 
                _activeTicket.ParkingSlot.CurrentVehicleID = null; 
            }
            
            PaymantMethodType selectedMethod = _paymentMethod == "Tiền mặt" 
                ? PaymantMethodType.Cash 
                : Enum.GetValues(typeof(PaymantMethodType))
                    .Cast<PaymantMethodType>()
                    .FirstOrDefault(m => m != PaymantMethodType.Cash);


            var invoice = new Invoice 
            { 
                TicketId = _activeTicket.TicketId, 
                LicensePlate = _activeTicket.Vehicle.LicensePlate, 
                CheckInTime = _activeTicket.EntryTime, 
                CheckOutTime = checkOutTime, 
                PaymentMethod = selectedMethod, 
                CreatedBy = _currentUserId,
                ShiftId = _currentShiftId, 
                TotalAmount = totalAmount, 
                PaymentDate = checkOutTime, 
                IsMonthlyFree = _activeTicket.IsMonthly 
            };
            if (_paymentMethod == "Chuyển khoản" && totalAmount > 0)
            {
                if (!ShowTransferQrDialog(totalAmount, _activeTicket.TicketCode))
                    return;
            }
            
            _activeTicket.TotalAmount = totalAmount; 
            _activeTicket.InvoiceId = invoice.InvoiceId; 
            _db.Invoices.Add(invoice); 
            _db.SaveChanges();
            
            LoadParkedVehicles(txtSearch.Text); 
            UpdateStatistics(); 
            ResetCheckOutLane(); 
            txtCardCodeOut.Focus(); 
        }

        

        private void ResetCheckOutLane()
        {
            _activeTicket = null;
            _isLostCardMode = false;
            txtCardCodeOut.Clear();
            txtLicensePlateRecorded.Clear();
            txtLicensePlateOut.Clear();
            lblFee.Text = "0 VNĐ";
            lblMatchStatus.Text = "SẴN SÀNG QUẸT THẺ RA";
            lblMatchStatus.BackColor = Color.LightGray;
            lblMatchStatus.ForeColor = Color.Black;
            _rdoCash.Checked = true;
            _rdoCash.Enabled = true;
            _rdoTransfer.Enabled = true;
            _rdoCash.Checked = true;
        }

        private void LoadParkedVehicles(string keyword = "")
        {
            var query = _db.Tickets
                .Where(t => t.Status == TicketStatus.Inparking)
                .OrderByDescending(t => t.EntryTime)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string key = keyword.Trim().ToUpper();
                query = query.Where(t => t.TicketCode.Contains(key) || t.Vehicle.LicensePlate.Contains(key));
            }

            dgvParkedVehicles.DataSource = query.Select(t => new
            {
                t.TicketId,
                t.TicketCode,
                t.Vehicle.LicensePlate,
                VehicleType = t.Vehicle != null ? (VehicleType?)t.Vehicle.VehicleType : null,
                t.EntryTime
            })
            .AsEnumerable()
            .Select(t => new
            {
                Id = t.TicketId,
                CardCode = t.TicketCode,
                t.LicensePlate,
                VehicleType = VehicleName(t.VehicleType),
                CheckInTime = t.EntryTime.ToString("dd/MM/yyyy HH:mm")
            })
            .ToList();
        }

        private void UpdateStatistics()
        {
            int parkedCount = _db.Tickets.Count(t => t.Status == TicketStatus.Inparking);
            decimal todayRevenue = _db.Invoices
                .Where(i => i.PaymentDate.Date == DateTime.Today)
                .Sum(i => (decimal?)i.TotalAmount) ?? 0m;

            lblStats.Text = string.Format(_viCulture, "Đang gửi: {0} xe | Doanh thu: {1:N0} đ", parkedCount, todayRevenue);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }
        private void SetupPaymentMethodButtons()
        {
            // Nút Tiền mặt 
            _rdoCash.Appearance = Appearance.Button;
            _rdoCash.Text = "Tiền mặt";
            _rdoCash.TextAlign = ContentAlignment.MiddleCenter;
            _rdoCash.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _rdoCash.Size = new Size(140, 34);
            _rdoCash.Location = new Point(560, 212);
            _rdoCash.FlatStyle = FlatStyle.Flat;
            _rdoCash.Cursor = Cursors.Hand;
            _rdoCash.Checked = true;

            // Nút Chuyển khoản
            _rdoTransfer.Appearance = Appearance.Button;
            _rdoTransfer.Text = "Chuyển khoản";
            _rdoTransfer.TextAlign = ContentAlignment.MiddleCenter;
            _rdoTransfer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _rdoTransfer.Size = new Size(155, 34);
            _rdoTransfer.Location = new Point(706, 212);
            _rdoTransfer.FlatStyle = FlatStyle.Flat;
            _rdoTransfer.Cursor = Cursors.Hand;

            void UpdateButtonStyle()
            {
                if (_rdoCash.Checked)
                {
                    _paymentMethod = "Tiền mặt";
                    _rdoCash.BackColor = Color.FromArgb(40, 167, 69);
                    _rdoCash.ForeColor = Color.White;
                    _rdoTransfer.BackColor = Color.FromArgb(229, 231, 235);
                    _rdoTransfer.ForeColor = Color.FromArgb(55, 65, 81);
                }
                else
                {
                    _paymentMethod = "Chuyển khoản";
                    _rdoTransfer.BackColor = Color.FromArgb(0, 102, 204);
                    _rdoTransfer.ForeColor = Color.White;
                    _rdoCash.BackColor = Color.FromArgb(229, 231, 235);
                    _rdoCash.ForeColor = Color.FromArgb(55, 65, 81);
                }
            }

            _rdoCash.CheckedChanged += (s, e) => UpdateButtonStyle();
            _rdoTransfer.CheckedChanged += (s, e) => UpdateButtonStyle();
            UpdateButtonStyle();

            this.Controls.Add(_rdoCash);
            this.Controls.Add(_rdoTransfer);
            _rdoCash.BringToFront();
            _rdoTransfer.BringToFront();
        } 
        private bool ShowTransferQrDialog(decimal amount, string ticketCode) 
        { 
            using var qrForm = new Form 
            { 
                Text = "Thanh toán chuyển khoản",
                Size = new Size(360, 470),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false, 
                MinimizeBox = false, 
                BackColor = Color.White 
            };
            
            var lblTitle = new Label
            { 
                Text = "QUÉT MÃ QR ĐỂ THANH TOÁN", 
                Font = new Font("Segoe UI", 11F, FontStyle.Bold), 
                ForeColor = Color.FromArgb(0, 102, 204),
                TextAlign = ContentAlignment.MiddleCenter, 
                Dock = DockStyle.Top, 
                Height = 42 
            };
            
            var picQr = new PictureBox 
            { 
                Size = new Size(210, 210), 
                Location = new Point(67, 48), 
                SizeMode = PictureBoxSizeMode.Zoom, 
                BorderStyle = BorderStyle.FixedSingle, 
                Image = System.IO.File.Exists("qr_bank.png") 
                    ? Image.FromFile("qr_bank.png") 
                    : CreateSampleQrBitmap(200) 
            };
            
            var lblAmount = new Label 
            { 
                Text = string.Format(_viCulture, "Số tiền: {0:N0} VNĐ", amount), 
                Font = new Font("Segoe UI", 12F, FontStyle.Bold), 
                ForeColor = Color.Crimson, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(15, 268), 
                Size = new Size(315, 28) 
            };
            
            var lblBankInfo = new Label 
            { 
                Text = $"Ngân hàng: Vietcombank - STK: 9999888868\nChủ TK: BAI DO XE THONG MINH\nNội dung: TT {ticketCode}", 
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), 
                ForeColor = Color.FromArgb(55, 65, 81), 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(15, 300), 
                Size = new Size(315, 62) 
            };
            
            var btnConfirmPaid = new Button 
            { 
                Text = "Đã nhận chuyển khoản", 
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), 
                BackColor = Color.FromArgb(40, 167, 69), 
                ForeColor = Color.White, 
                FlatStyle = FlatStyle.Flat, 
                Size = new Size(185, 38), 
                Location = new Point(22, 375), 
                Cursor = Cursors.Hand, 
                DialogResult = DialogResult.OK 
            };
            
            var btnCancel = new Button 
            { 
                Text = "Hủy", 
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular), 
                BackColor = Color.FromArgb(229, 231, 235), 
                ForeColor = Color.Black, 
                FlatStyle = FlatStyle.Flat, 
                Size = new Size(105, 38), 
                Location = new Point(215, 375), 
                Cursor = Cursors.Hand, 
                DialogResult = DialogResult.Cancel 
            };
            
            qrForm.Controls.AddRange(new Control[] { lblTitle, picQr, lblAmount, lblBankInfo, btnConfirmPaid, btnCancel }); 
            qrForm.AcceptButton = btnConfirmPaid; 
            qrForm.CancelButton = btnCancel;
            return qrForm.ShowDialog(this) == DialogResult.OK; 
        }
        
        private static Bitmap CreateSampleQrBitmap(int size = 200) 
        { 
            const int modules = 25; 
            int cellSize = size / modules; 
            int actualSize = cellSize * modules; 
            var bmp = new Bitmap(actualSize, actualSize);
            
            using var g = Graphics.FromImage(bmp); 
            g.Clear(Color.White);
            
            bool[,] matrix = new bool[modules, modules];
            
            void DrawFinder(int startRow, int startCol) 
            { 
                for (int r = 0; r < 7; r++)
                {
                    for (int c = 0; c < 7; c++)
                    { 
                        bool isBorder = r == 0 || r == 6 || c == 0 || c == 6;
                        bool isCenter = r >= 2 && r <= 4 && c >= 2 && c <= 4;
                        matrix[startRow + r, startCol + c] = isBorder || isCenter;
                    }
                }
            }
            
            DrawFinder(0, 0); 
            DrawFinder(0, modules - 7); 
            DrawFinder(modules - 7, 0);
            
            var rand = new Random(2026); 
            for (int r = 0; r < modules; r++) 
            { 
                for (int c = 0; c < modules; c++) 
                { 
                    bool inFinder = (r < 8 && c < 8) || (r < 8 && c >= modules - 8) || (r >= modules - 8 && c < 8);
                    if (!inFinder) 
                        matrix[r, c] = rand.Next(2) == 0; 
                } 
            }
            
            for (int r = 0; r < modules; r++) 
            {
                for (int c = 0; c < modules; c++) 
                { 
                    if (matrix[r, c]) 
                        g.FillRectangle(Brushes.Black, c * cellSize, r * cellSize, cellSize, cellSize); 
                } 
            }
            
            return bmp; 
        }
        
        private static string VehicleName(VehicleType? type) =>
            type == VehicleType.Car ? "Ô tô" : type == VehicleType.Motorbike ? "Xe máy" : "";
        
    }
}