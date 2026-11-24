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

        public FormCheckOut(int userId)
        {
            InitializeComponent();
            _db = new AppDbContext();
            _currentUserId = userId;
            _currentShiftId = FindShiftId();

            InitializeData();
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
            btnLoadLostCard.Click += (s, e) => LoadLostCardFromGrid();
            dgvParkedVehicles.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) LoadLostCardFromGrid(); };
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
                LoadLostCardFromGrid();
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

        private void LoadLostCardFromGrid()
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
                BindTicketToUI(ticket, isLostCard: true);
            }
        }

        private void BindTicketToUI(Ticket ticket, bool isLostCard)
        {
            _activeTicket = ticket;
            _isLostCardMode = isLostCard;

            txtCardCodeOut.Text = ticket.TicketCode;
            txtLicensePlateRecorded.Text = ticket.Vehicle?.LicensePlate??"";
            txtLicensePlateOut.Clear();

            decimal fee = CalculateParkingFee(ticket, isLostCard);
            lblFee.Text = ticket.IsMonthly
                ? "0 VNĐ (VÉ THÁNG)"
                : string.Format(_viCulture, "{0:N0} VNĐ", fee);

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
                var confirm = MessageBox.Show(
                    $"Biển số nhập vào [{txtLicensePlateOut.Text}] KHÔNG KHỚP với lúc vào [{_activeTicket.Vehicle?.LicensePlate}].\nXác nhận cho xe xuất bến?",
                    "Cảnh báo lệch biển số",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                {
                    txtLicensePlateOut.SelectAll();
                    txtLicensePlateOut.Focus();
                    return;
                }
            }

            DateTime checkOutTime = DateTime.Now;
            decimal totalAmount = CalculateParkingFee(_activeTicket, _isLostCardMode);

            _activeTicket.ExitTime = checkOutTime;
            _activeTicket.Status = TicketStatus.CheckedOut;

            if (_activeTicket.ParkingSlot != null)
            {
                _activeTicket.ParkingSlot.IsOccupied = false;
                _activeTicket.ParkingSlot.CurrentVehicleID = null;
            }
            if (_currentShiftId == -1) 
            {
                MessageBox.Show("Đang ở ngoài ca trực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var invoice = new Invoice
            {
                TicketId = _activeTicket.TicketId,
                LicensePlate = _activeTicket.Vehicle.LicensePlate,
                CheckInTime = _activeTicket.EntryTime,
                CheckOutTime = checkOutTime,
                PaymentMethod = PaymantMethodType.Cash,
                CreatedBy = _currentUserId,
                ShiftId = _currentShiftId,
                TotalAmount = totalAmount,
                PaymentDate = checkOutTime,
                IsMonthlyFree = _activeTicket.IsMonthly
            };
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
        private static string VehicleName(VehicleType? type) =>
            type == VehicleType.Car ? "Ô tô" : type == VehicleType.Motorbike ? "Xe máy" : "";
        
    }
}