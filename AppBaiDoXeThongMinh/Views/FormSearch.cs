using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using AppBaiDoXeThongMinh.ControlUser;
using Microsoft.EntityFrameworkCore;
using VType = AppBaiDoXeThongMinh.Models.VehicleType;

namespace AppBaiDoXeThongMinh.Views;
/*24130255 Tran Anh Quoc*/
public partial class FormSearch : Form
{
    private readonly User? _currentUser;

    private readonly UcTicketFullDetail _ucFullDetail = new UcTicketFullDetail();
    
    public FormSearch()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => SearchTickets();
    }

    
    public FormSearch(User user) : this()
    {
        _currentUser = user;
    }

    
    private void SetupUi()
    {
        AcceptButton = btSearch;
        
        _ucFullDetail.Dock = DockStyle.None;
        _ucFullDetail.Visible = false;
        Controls.Add(_ucFullDetail);
        _ucFullDetail.CloseRequested += (_, _) => _ucFullDetail.Visible = false;

        btSearch.Click += (_, _) =>
        {
            SearchTickets();
        };
        dataGridViewSummary.SelectionChanged += (_, _) => ShowSelectedDetails();
        dataGridViewSummary.CellContentClick += DataGridViewSummary_CellContentClick;
        buttonLockTicket.Click += BtLockCard_Click;
        buttonCalculate.Click += BtCalculate_Click;

        ClearDetails();
    }

    private void SearchTickets()
    {
        try
        {
            using var db = new AppDbContext();

            var query = db.Tickets.AsNoTracking().Include(t => t.Vehicle).AsQueryable();

            if (dateTimePickerSearch.Checked)
            {
                DateTime day = dateTimePickerSearch.Value.Date;
                DateTime nextDay = day.AddDays(1);
                query = query.Where(t => t.EntryTime >= day && t.EntryTime < nextDay);
            }

            if (comboBoxStatusSearch.SelectedIndex == 1)
                query = query.Where(t => t.Status == TicketStatus.Inparking);
            else if (comboBoxStatusSearch.SelectedIndex == 2)
                query = query.Where(t => t.Status == TicketStatus.CheckedOut);

            var list = query.OrderByDescending(t => t.EntryTime).ToList();

            string keyword = textBoxSearch.Text.Trim();
            if (keyword.Length > 0)
            {
                string keyPlate = NormalizePlate(keyword);
                list = list.Where(t =>
                        (keyPlate.Length > 0 && NormalizePlate(t.Vehicle?.LicensePlate).Contains(keyPlate))
                        || t.TicketCode.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dataGridViewSummary.Rows.Clear();
            int stt = 1;
            foreach (var t in list)
            {
                TimeSpan duration = (t.ExitTime ?? DateTime.Now) - t.EntryTime;
                int index = dataGridViewSummary.Rows.Add(
                    stt++,
                    t.Vehicle?.LicensePlate ?? "Không rõ",
                    t.TicketCode,
                    t.EntryTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    $"{(int)duration.TotalHours}h {duration.Minutes}m",
                    VehicleName(t.Vehicle?.VehicleType));
                dataGridViewSummary.Rows[index].Tag = t.TicketId;
            }

            if (dataGridViewSummary.Rows.Count == 0)
                ClearDetails("Không tìm thấy phương tiện phù hợp.");
            else
                ShowSelectedDetails();
        }
        catch (Exception ex)
        {
            ShowError("Không thể tìm kiếm", ex);
        }
    }

    private void DataGridViewSummary_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != Action.Index) return;
        dataGridViewSummary.ClearSelection();
        dataGridViewSummary.Rows[e.RowIndex].Selected = true;
        dataGridViewSummary.CurrentCell = dataGridViewSummary.Rows[e.RowIndex].Cells[0];
        ShowSelectedDetails();
        
        if (dataGridViewSummary.Rows[e.RowIndex].Tag is int ticketId)
        {
            OpenFullDetailUserControl(ticketId);
        }
    }

    private void OpenFullDetailUserControl(int ticketId)
    {
        try
        {
            using var db = new AppDbContext();
            var ticket = db.Tickets.AsNoTracking()
                .Include(t => t.Vehicle)
                .Include(t => t.ParkingSlot)
                .Include(t => t.PriceConfig)
                .FirstOrDefault(t => t.TicketId == ticketId);

            if (ticket == null) return;

            Invoice? invoice = null;
            User? creator = null;

            if (!string.IsNullOrEmpty(ticket.InvoiceId))
            {
                invoice = db.Invoices.AsNoTracking()
                    .FirstOrDefault(i => i.InvoiceId == ticket.InvoiceId);
            }
            else
            {
                invoice = db.Invoices.AsNoTracking()
                    .FirstOrDefault(i => i.TicketId == ticket.TicketId);
            }

            if (invoice != null)
            {
                creator = db.Users.AsNoTracking()
                    .FirstOrDefault(u => u.UserId == invoice.CreatedBy);
            }

            _ucFullDetail.LoadData(ticket, invoice, creator);
            
            Point gridPosOnForm = PointToClient(dataGridViewSummary.Parent!.PointToScreen(dataGridViewSummary.Location));
            _ucFullDetail.Location = gridPosOnForm;
            _ucFullDetail.Size = dataGridViewSummary.Size;
            _ucFullDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            
            _ucFullDetail.Visible = true;
            _ucFullDetail.BringToFront();
        }
        catch (Exception ex)
        {
            ShowError("Không thể mở thông tin chi tiết", ex);
        }
    }

    private int? GetSelectedTicketId()
    {
        if (dataGridViewSummary.CurrentRow?.Tag is int id) return id;
        return null;
    }

    private void ShowSelectedDetails()
    {
        int? id = GetSelectedTicketId();
        if (id == null)
        {
            ClearDetails();
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var t = db.Tickets.AsNoTracking()
                .Include(x => x.Vehicle)
                .Include(x => x.PriceConfig)
                .FirstOrDefault(x => x.TicketId == id.Value);

            if (t == null)
            {
                ClearDetails("Không tìm thấy vé.");
                return;
            }

            DateTime end = t.ExitTime ?? DateTime.Now;
            TimeSpan duration = end - t.EntryTime;

            lbName.Text = $"Vé xe: {t.TicketCode}";
            lbLicensePlate.Text = $"Biển số: {t.Vehicle?.LicensePlate}";
            lbTimeIn.Text = $"Giờ vào: {t.EntryTime:dd/MM/yyyy HH:mm}";
            lbStatusTicket.Text = $"Trạng thái: {StatusName(t.Status)}";
            lbVehicleInfo.Text = $"Loại xe: {VehicleName(t.Vehicle?.VehicleType)}" +
                                  (t.IsMonthly ? " (vé tháng)" : "");
            lbOwnerInfo.Text = $"Chủ xe: {Dash(t.Vehicle?.OwerName)} - {Dash(t.Vehicle?.PhoneNumber)}";
            lbDurationInfo.Text = $"Đã gửi: {(int)duration.TotalHours}h {duration.Minutes}m";

            if (t.Status == TicketStatus.CheckedOut)
            {
                lbFeeInfo.Text = $"Đã thu: {(t.TotalAmount ?? 0):N0} VNĐ";
            }
            else
            {
                decimal fee = EstimateFee(t);
                lbFeeInfo.Text = $"Phí tạm tính: {fee:N0} VNĐ";
            }

            buttonLockTicket.Enabled = t.Status == TicketStatus.Inparking;
            buttonCalculate.Enabled = t.Status == TicketStatus.Inparking || t.Status == TicketStatus.Lost;
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải chi tiết vé", ex);
        }
    }

    private void ClearDetails(string message = "")
    {
        lbName.Text = message.Length > 0 ? message : "Vé xe: —";
        lbLicensePlate.Text = "Biển số: —";
        lbTimeIn.Text = "Giờ vào: —";
        lbStatusTicket.Text = "Trạng thái: —";
        lbVehicleInfo.Text = "Loại xe: —";
        lbOwnerInfo.Text = "Chủ xe: —";
        lbDurationInfo.Text = "Đã gửi: —";
        lbFeeInfo.Text = "Phí tạm tính: —";
        buttonLockTicket.Enabled = false;
        buttonCalculate.Enabled = false;
    }
    
    private static decimal EstimateFee(Ticket t)
    {
        if (t.PriceConfig == null) return 0;
        decimal parking = t.IsMonthly ? 0 : Invoice.CalculateParkingFee(t.EntryTime, DateTime.Now, t.PriceConfig);
        decimal lost = t.Status == TicketStatus.Lost ? t.PriceConfig.LostTicketFee : 0;
        return parking + lost;
    }

    private void BtLockCard_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedTicketId();
        if (id == null) return;

        try
        {
            using var db = new AppDbContext();
            var ticket = db.Tickets.Include(t => t.Vehicle).FirstOrDefault(t => t.TicketId == id.Value);
            if (ticket == null) return;

            if (ticket.Status != TicketStatus.Inparking)
            {
                MessageBox.Show("Chỉ có thể khóa thẻ của xe đang trong bãi.",
                    "Không thể khóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var answer = MessageBox.Show(
                $"Khóa thẻ {ticket.TicketCode} (biển số {ticket.Vehicle?.LicensePlate}) vì bị mất?\n" +
                "Thẻ sẽ không dùng được nữa; khi cho xe ra sẽ tính thêm phí mất vé.",
                "Xác nhận khóa thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            ticket.Status = TicketStatus.Lost;
            db.SaveChanges();

            SearchTickets();
            SelectTicket(id.Value);

            if (_ucFullDetail.Visible)
            {
                OpenFullDetailUserControl(id.Value);
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể khóa thẻ", ex);
        }
    }

    private void BtCalculate_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedTicketId();
        if (id == null) return;

        if (_currentUser == null)
        {
            MessageBox.Show("Không xác định được người dùng đang đăng nhập nên không thể lập hóa đơn.\n" +
                            "Hãy mở màn hình này từ FormMain: new FormSearch(_currentUser).",
                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var db = new AppDbContext();
            var ticket = db.Tickets
                .Include(t => t.Vehicle)
                .Include(t => t.PriceConfig)
                .Include(t => t.ParkingSlot)
                .FirstOrDefault(t => t.TicketId == id.Value);
            if (ticket == null) return;

            if (ticket.Status == TicketStatus.CheckedOut)
            {
                MessageBox.Show("Xe này đã ra khỏi bãi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ticket.PriceConfig == null)
            {
                MessageBox.Show("Vé chưa có cấu hình giá nên không thể tính phí.", "Thiếu cấu hình giá",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime now = DateTime.Now;
            int userId = _currentUser.UserId;
            var shift = db.Shifts.Where(s => s.UserId == userId && s.StartDate <= now && s.EndDate >= now).FirstOrDefault()
                        ?? db.Shifts.Where(s => s.UserId == userId).OrderByDescending(s => s.StartDate).FirstOrDefault()
                        ?? db.Shifts.OrderByDescending(s => s.StartDate).FirstOrDefault();
            if (shift == null)
            {
                MessageBox.Show("Chưa có ca trực nào trong database nên không thể lập hóa đơn.", "Thiếu ca trực",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal parkingFee = ticket.IsMonthly
                ? 0
                : Invoice.CalculateParkingFee(ticket.EntryTime, now, ticket.PriceConfig);
            decimal lostFee = ticket.Status == TicketStatus.Lost ? ticket.PriceConfig.LostTicketFee : 0;
            decimal total = parkingFee + lostFee;

            TimeSpan duration = now - ticket.EntryTime;
            var answer = MessageBox.Show(
                $"Biển số: {ticket.Vehicle?.LicensePlate}\n" +
                $"Thời gian gửi: {(int)duration.TotalHours}h {duration.Minutes}m\n" +
                $"Phí gửi xe: {parkingFee:N0} VNĐ{(ticket.IsMonthly ? " (vé tháng)" : "")}\n" +
                $"Phí mất vé: {lostFee:N0} VNĐ\n" +
                $"TỔNG THU: {total:N0} VNĐ\n\n" +
                "Xác nhận đã thu tiền (tiền mặt) và cho xe ra?",
                "Tính phí", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            var invoice = new Invoice(ticket.TicketId, ticket.Vehicle?.LicensePlate ?? "", ticket.EntryTime, now,
                total, PaymantMethodType.Cash, now, userId, true, ticket.IsMonthly, shift.ShiftId);
            db.Invoices.Add(invoice);

            ticket.Status = TicketStatus.CheckedOut;
            ticket.ExitTime = now;
            ticket.TotalAmount = total;
            ticket.InvoiceId = invoice.InvoiceId;

            if (ticket.ParkingSlot != null)
            {
                ticket.ParkingSlot.IsOccupied = false;
                ticket.ParkingSlot.CurrentVehicleID = null;
            }

            db.SaveChanges();

            MessageBox.Show($"Đã thu {total:N0} VNĐ.\nBarie đã mở, xe có thể ra.",
                "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SearchTickets();
            SelectTicket(id.Value);

            if (_ucFullDetail.Visible)
            {
                OpenFullDetailUserControl(id.Value);
            }
        }
        catch (Exception ex)
        {
            ShowError("Không thể tính phí / lập hóa đơn", ex);
        }
    }

    private void SelectTicket(int ticketId)
    {
        foreach (DataGridViewRow row in dataGridViewSummary.Rows)
        {
            if (row.Tag is int id && id == ticketId)
            {
                dataGridViewSummary.ClearSelection();
                row.Selected = true;
                dataGridViewSummary.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private static string NormalizePlate(string? plate) =>
        new string((plate ?? "").Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();

    private static string VehicleName(VType? type) =>
        type == VType.Car ? "Ô tô" : type == VType.Motorbike ? "Xe máy" : "";

    private static string StatusName(TicketStatus status) => status switch
    {
        TicketStatus.Inparking => "Đang trong bãi",
        TicketStatus.CheckedOut => "Đã ra khỏi bãi",
        TicketStatus.Lost => "Thẻ bị mất (đã khóa)",
        _ => status.ToString()
    };

    private static string Dash(string? value) => string.IsNullOrWhiteSpace(value) ? "—" : value;

    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


