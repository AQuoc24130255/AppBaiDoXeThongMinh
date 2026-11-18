using AppBaiDoXeThongMinh.Control;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;
/*24130255 Tran Anh Quoc
 Quản lý vé: thống kê, xem danh sách, thêm, khóa, xóa vé*/

public partial class FormManageTicket : Form
{
    private bool _isMonthlyMode = false;

    private readonly usercontrolGrbAddRegularMode _ucRegular = new() { Dock = DockStyle.Fill };
    private readonly usercontrolGrbAddMonthlyMode _ucMonthly = new() { Dock = DockStyle.Fill };
    
    public FormManageTicket()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => SwitchMode(false);
    }

    // ------------------------------------------------------------
    //  Thiết lập ban đầu & Chuyển chế độ
    // ------------------------------------------------------------
    private void SetupUi()
    {
        // Gắn 2 User Control vào panel bên phải
        pnlRightHost.Controls.Add(_ucRegular);
        pnlRightHost.Controls.Add(_ucMonthly);

        // Sự kiện từ User Control Vé thường
        _ucRegular.LockClicked += BtLock_Click;
        _ucRegular.Deletelicked += BtDelete_Click;
        _ucRegular.RefreshClicked += (_, _) => RefreshAll();

        // Sự kiện từ User Control Vé tháng
        _ucMonthly.TicketAdded += (_, _) => RefreshAll();
        _ucMonthly.RefreshClicked += (_, _) => RefreshAll();

        // Sự kiện 2 nút chuyển chế độ dưới dgvTickets
        btRegularMode.Click += (_, _) => SwitchMode(false);
        btMonthlyMode.Click += (_, _) => SwitchMode(true);

        // Tìm kiếm & lọc
        btSearch.Click += (_, _) => LoadCurrentList();
        cbFilter.SelectedIndexChanged += (_, _) => LoadCurrentList();
        txtSearch.KeyDown += (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            LoadCurrentList();
        };
    }

    private void SwitchMode(bool isMonthly)
    {
        _isMonthlyMode = isMonthly;

        // Đổi màu nút nhận biết chế độ đang chọn
        btRegularMode.BackColor = !isMonthly ? Color.FromArgb(25, 105, 170) : Color.FromArgb(215, 222, 230);
        btRegularMode.ForeColor = !isMonthly ? Color.White : Color.Black;

        btMonthlyMode.BackColor = isMonthly ? Color.FromArgb(25, 105, 170) : Color.FromArgb(215, 222, 230);
        btMonthlyMode.ForeColor = isMonthly ? Color.White : Color.Black;

        // Cập nhật bộ lọc tìm kiếm theo chế độ
        cbFilter.Items.Clear();
        if (!isMonthly)
        {
            cbFilter.Items.AddRange(new object[] { "Tất cả", "Đang sử dụng", "Đã ra khỏi bãi", "Bị khóa", "Vé tháng" });
            grbList.Text = "Danh sách vé";
        }
        else
        {
            cbFilter.Items.AddRange(new object[] { "Tất cả", "Còn hiệu lực", "Hết hạn / Ngừng" });
            grbList.Text = "Danh sách vé tháng";
        }
        cbFilter.SelectedIndex = 0;

        // Chuyển hiển thị User Control bên phải
        _ucRegular.Visible = !isMonthly;
        _ucMonthly.Visible = isMonthly;

        // Cấu hình cột DataGridView
        ConfigureGridColumns(isMonthly);

        LoadStats();
        LoadCurrentList();
    }

    private void ConfigureGridColumns(bool isMonthly)
    {
        dgvTickets.Rows.Clear();
        dgvTickets.Columns.Clear();

        if (!isMonthly)
        {
            dgvTickets.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", FillWeight = 35F, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Mã vé", FillWeight = 90F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colPlate", HeaderText = "Biển số", FillWeight = 85F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colVType", HeaderText = "Loại xe", FillWeight = 60F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colEntry", HeaderText = "Giờ vào", FillWeight = 105F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colExit", HeaderText = "Giờ ra", FillWeight = 105F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng thái", FillWeight = 85F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colMonthly", HeaderText = "Vé tháng", FillWeight = 55F, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });
        }
        else
        {
            dgvTickets.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colSubId", HeaderText = "ID", FillWeight = 35F, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { Name = "colFullName", HeaderText = "Chủ xe", FillWeight = 110F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Số ĐT", FillWeight = 85F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colPlate", HeaderText = "Biển số", FillWeight = 85F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colVType", HeaderText = "Loại xe", FillWeight = 60F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colStart", HeaderText = "Ngày BĐ", FillWeight = 80F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colEnd", HeaderText = "Ngày HH", FillWeight = 80F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colFee", HeaderText = "Phí/tháng", FillWeight = 80F, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colSubStatus", HeaderText = "Trạng thái", FillWeight = 80F, ReadOnly = true }
            });
        }
    }

    private void RefreshAll(int? selectTicketId = null)
    {
        LoadStats();
        LoadCurrentList(selectTicketId);
    }

    private void LoadCurrentList(int? selectId = null)
    {
        if (_isMonthlyMode)
            LoadMonthlySubscribers();
        else
            LoadTickets(selectId);
    }


    // ------------------------------------------------------------
    //  Thống kê
    // ------------------------------------------------------------
    private void LoadStats()
    {
        try
        {
            using var db = new AppDbContext();
            lbTotalValue.Text = db.Tickets.Count().ToString("N0");
            lbInUseValue.Text = db.Tickets.Count(t => t.Status == TicketStatus.Inparking).ToString("N0");
            lbMonthlyValue.Text = db.MonthlySubscribers.Count(s => s.IsActive && s.EndDate >= DateTime.Today).ToString("N0");
            lbLockedValue.Text = db.Tickets.Count(t => t.Status == TicketStatus.Lost).ToString("N0");
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải thống kê vé", ex);
        }
    }

    // ------------------------------------------------------------
    //  Danh sách vé thường (Tickets)
    // ------------------------------------------------------------
    private void LoadTickets(int? selectTicketId = null)
    {
        try
        {
            using var db = new AppDbContext();
            var query = db.Tickets.AsNoTracking().Include(t => t.Vehicle).AsQueryable();

            switch (cbFilter.SelectedIndex)
            {
                case 1: query = query.Where(t => t.Status == TicketStatus.Inparking); break;
                case 2: query = query.Where(t => t.Status == TicketStatus.CheckedOut); break;
                case 3: query = query.Where(t => t.Status == TicketStatus.Lost); break;
                case 4: query = query.Where(t => t.IsMonthly); break;
            }

            var list = query.OrderByDescending(t => t.EntryTime).ToList();

            string keyword = txtSearch.Text.Trim();
            if (keyword.Length > 0)
            {
                string keyPlate = NormalizePlate(keyword);
                list = list.Where(t =>
                        (keyPlate.Length > 0 && NormalizePlate(t.Vehicle?.LicensePlate).Contains(keyPlate))
                        || t.TicketCode.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvTickets.Rows.Clear();
            foreach (var t in list)
            {
                int index = dgvTickets.Rows.Add(
                    t.TicketId,
                    t.TicketCode,
                    t.Vehicle?.LicensePlate ?? "Không rõ",
                    VehicleName(t.Vehicle?.VehicleType),
                    t.EntryTime.ToString("dd/MM/yyyy HH:mm"),
                    t.ExitTime.HasValue ? t.ExitTime.Value.ToString("dd/MM/yyyy HH:mm") : "—",
                    StatusName(t.Status),
                    t.IsMonthly ? "Có" : "Không");

                var row = dgvTickets.Rows[index];
                row.Tag = t.TicketId;
                if (t.Status == TicketStatus.Lost) row.DefaultCellStyle.ForeColor = Color.Firebrick;
                else if (t.Status == TicketStatus.CheckedOut) row.DefaultCellStyle.ForeColor = Color.Gray;

                if (selectTicketId == t.TicketId)
                {
                    dgvTickets.ClearSelection();
                    row.Selected = true;
                    dgvTickets.CurrentCell = row.Cells[0];
                }
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải danh sách vé", ex);
        }
    }

    // ------------------------------------------------------------
    //  Danh sách vé tháng (MonthlySubscribers)
    // ------------------------------------------------------------
    private void LoadMonthlySubscribers()
    {
        try
        {
            using var db = new AppDbContext();
            var list = db.MonthlySubscribers.AsNoTracking().OrderByDescending(s => s.StartDate).ToList();
            DateTime today = DateTime.Today;
            
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    list = list.Where(s => s.IsActive && s.EndDate >= today).ToList();
                    break;
                case 2:
                    list = list.Where(s => !s.IsActive || s.EndDate < today).ToList();
                    break;
            }
            
            string keyword = txtSearch.Text.Trim();
            if (keyword.Length > 0)
            {
                string keyPlate = NormalizePlate(keyword);
                list = list.Where(s =>
                        (keyPlate.Length > 0 && NormalizePlate(s.LicensePlate).Contains(keyPlate))
                        || s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                        || s.PhoneNumber.Contains(keyword))
                    .ToList();
            }
            
            dgvTickets.Rows.Clear();
            foreach (var s in list)
            {
                bool valid = s.IsActive && s.EndDate >= today;
                string vTypeDisplay = s.VehicleType.Equals("Car", StringComparison.OrdinalIgnoreCase) ? "Ô tô" : "Xe máy";
                
                int index = dgvTickets.Rows.Add(
                    s.SubcriberId,
                    s.FullName,
                    s.PhoneNumber,
                    s.LicensePlate,
                    vTypeDisplay,
                    s.StartDate.ToString("dd/MM/yyyy"),
                    s.EndDate.ToString("dd/MM/yyyy"),
                    s.MonthlyFee.ToString("N0") + " đ",
                    valid ? "Còn hiệu lực" : "Hết hạn");
                var row = dgvTickets.Rows[index];
                row.Tag = s.SubcriberId;
                if (!valid) row.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải danh sách vé tháng", ex);
        }
    }
    
    private int? GetSelectedTicketId() =>
        !_isMonthlyMode && dgvTickets.CurrentRow?.Tag is int id ? id : null;
    
    // ------------------------------------------------------------
//  Khóa vé (chế độ Vé thường)
// ------------------------------------------------------------
    private void BtLock_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedTicketId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn một vé trong danh sách.", "Chưa chọn vé",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        
        try
        {
            using var db = new AppDbContext();
            var ticket = db.Tickets.Include(t => t.Vehicle).FirstOrDefault(t => t.TicketId == id.Value);
            if (ticket == null) { RefreshAll(); return; }
            
            if (ticket.Status != TicketStatus.Inparking)
            {
                MessageBox.Show(
                    ticket.Status == TicketStatus.Lost ? "Vé này đã bị khóa rồi." : "Chỉ có thể khóa vé của xe đang trong bãi.",
                    "Không thể khóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var answer = MessageBox.Show(
                $"Khóa vé {ticket.TicketCode} (biển số {ticket.Vehicle?.LicensePlate})?\n" +
                "Khi xe ra, vé bị khóa sẽ bị tính thêm phí mất vé.",
                "Xác nhận khóa vé", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;
            
            ticket.Status = TicketStatus.Lost;
            db.SaveChanges();
            RefreshAll(id.Value);
        }
        catch (Exception ex)
        {
            ShowError("Không thể khóa vé", ex);
        }
    }
    
    // ------------------------------------------------------------
    //  Xóa vé (chế độ Vé thường)
    // ------------------------------------------------------------
    private void BtDelete_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedTicketId();
        if (id == null)
        {
            MessageBox.Show("Vui lòng chọn một vé trong danh sách.", "Chưa chọn vé",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        
        try
        {
            using var db = new AppDbContext();
            var ticket = db.Tickets
                .Include(t => t.Vehicle)
                .Include(t => t.ParkingSlot)
                .FirstOrDefault(t => t.TicketId == id.Value);
            if (ticket == null) { RefreshAll(); return; }
            
            if (db.Invoices.Any(i => i.TicketId == id.Value))
            {
                MessageBox.Show("Vé này đã có hóa đơn nên không thể xóa (để giữ lịch sử doanh thu).",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            bool stillParked = ticket.Status != TicketStatus.CheckedOut;
            var answer = MessageBox.Show(
                $"Xóa vé {ticket.TicketCode} (biển số {ticket.Vehicle?.LicensePlate})?\n" +
                (stillParked ? "Chỗ đỗ đang giữ cho vé này sẽ được trả lại.\n" : "") +
                "Thao tác này không thể hoàn tác.",
                "Xác nhận xóa vé", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;
            
            if (stillParked && ticket.ParkingSlot != null)
            {
                ticket.ParkingSlot.IsOccupied = false;
                ticket.ParkingSlot.CurrentVehicleID = null;
            }
            
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            RefreshAll();
        }
        catch (DbUpdateException ex)
        {
            ShowError("Không thể xóa vé (dữ liệu đang được tham chiếu ở nơi khác)", ex);
        }
        catch (Exception ex)
        {
            ShowError("Không thể xóa vé", ex);
        }
    }
    
    // ------------------------------------------------------------
    //  Hàm hỗ trợ
    // ------------------------------------------------------------
    private static string NormalizePlate(string? plate) =>
        new string((plate ?? "").Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
    
    private static string VehicleName(VehicleType? type) =>
        type == VehicleType.Car ? "Ô tô" : type == VehicleType.Motorbike ? "Xe máy" : "";
    
    private static string StatusName(TicketStatus status) => status switch
    {
        TicketStatus.Inparking => "Đang sử dụng",
        TicketStatus.CheckedOut => "Đã ra khỏi bãi",
        TicketStatus.Lost => "Bị khóa",
        _ => status.ToString()
    };
    
    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}