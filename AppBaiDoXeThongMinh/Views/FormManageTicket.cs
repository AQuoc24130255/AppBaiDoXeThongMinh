using System.Text.RegularExpressions;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;
/*24130255 Tran Anh Quoc
 Quản lý vé: thống kê, xem danh sách, thêm, khóa, xóa vé*/

public partial class FormManageTicket : Form
{
    public FormManageTicket()
    {
        InitializeComponent();
        SetupUi();
        Load += (_, _) => RefreshAll();
    }

    // ------------------------------------------------------------
    //  Thiết lập ban đầu
    // ------------------------------------------------------------
    private void SetupUi()
    {
        cbFilter.SelectedIndex = 0;
        cbVehicleType.SelectedIndex = 0;
        grbOwner.Enabled = false;   // chỉ bật khi tick "vé tháng"

        colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colMonthly.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        chkMonthly.CheckedChanged += (_, _) => grbOwner.Enabled = chkMonthly.Checked;

        btSearch.Click += (_, _) => LoadTickets();
        cbFilter.SelectedIndexChanged += (_, _) => LoadTickets();
        txtSearch.KeyDown += (_, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            LoadTickets();
        };

        btAdd.Click += BtAdd_Click;
        btClear.Click += (_, _) => ClearForm();
        btLock.Click += BtLock_Click;
        btDelete.Click += BtDelete_Click;
        btRefresh.Click += (_, _) => RefreshAll();
    }

    private void RefreshAll(int? selectTicketId = null)
    {
        LoadStats();
        LoadTickets(selectTicketId);
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
            lbMonthlyValue.Text = db.Tickets.Count(t => t.IsMonthly).ToString("N0");
            lbLockedValue.Text = db.Tickets.Count(t => t.Status == TicketStatus.Lost).ToString("N0");
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải thống kê vé", ex);
        }
    }

    // ------------------------------------------------------------
    //  Danh sách vé
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

            // Lọc từ khóa trong bộ nhớ (bỏ khoảng trắng, '-' và '.' khi so biển số)
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

    private int? GetSelectedTicketId() =>
        dgvTickets.CurrentRow?.Tag is int id ? id : null;

    // ------------------------------------------------------------
    //  Thêm vé
    // ------------------------------------------------------------
    private void BtAdd_Click(object? sender, EventArgs e)
    {
        string plate = txtPlate.Text.Trim().ToUpperInvariant();
        string plateKey = NormalizePlate(plate);
        bool monthly = chkMonthly.Checked;
        var type = cbVehicleType.SelectedIndex == 1 ? VehicleType.Car : VehicleType.Motorbike;

        string ownerName = txtOwnerName.Text.Trim();
        string phone = Regex.Replace(txtPhone.Text, @"[\s.\-]", "");

        // --- Kiểm tra dữ liệu nhập ---
        if (plateKey.Length < 4)
        {
            Warn("Vui lòng nhập biển số xe hợp lệ.", txtPlate);
            return;
        }

        if (monthly)
        {
            // Vé tháng BẮT BUỘC có thông tin chủ sở hữu xe
            if (ownerName.Length == 0)
            {
                Warn("Vé tháng bắt buộc phải có họ tên chủ xe.", txtOwnerName);
                return;
            }
            if (!Regex.IsMatch(phone, @"^\+?\d{9,12}$"))
            {
                Warn("Vé tháng bắt buộc phải có số điện thoại chủ xe hợp lệ (9–12 chữ số).", txtPhone);
                return;
            }
        }

        try
        {
            using var db = new AppDbContext();

            // 1) Tìm hoặc tạo phương tiện theo biển số
            var vehicle = db.Vehicles.ToList().FirstOrDefault(v => NormalizePlate(v.LicensePlate) == plateKey);
            if (vehicle != null && vehicle.VehicleType != type)
            {
                Warn($"Biển số này đã đăng ký là {VehicleName(vehicle.VehicleType)}. Vui lòng chọn lại loại xe.",
                    cbVehicleType);
                return;
            }

            // 2) Xe đang có vé chưa đóng (đang gửi hoặc vé bị khóa) thì không cấp thêm
            if (vehicle != null && db.Tickets.Any(t => t.VehicleId == vehicle.VehicleId &&
                    (t.Status == TicketStatus.Inparking || t.Status == TicketStatus.Lost)))
            {
                Warn("Xe này đang có một vé chưa đóng (đang gửi hoặc bị khóa).", txtPlate);
                return;
            }

            // 3) Vé tháng: không trùng với vé tháng còn hiệu lực
            if (monthly)
            {
                DateTime today = DateTime.Today;
                bool hasActiveSub = db.MonthlySubscribers
                    .Where(s => s.IsActive && s.EndDate >= today)
                    .ToList()
                    .Any(s => NormalizePlate(s.LicensePlate) == plateKey);
                if (hasActiveSub)
                {
                    Warn("Biển số này đã có vé tháng còn hiệu lực.", txtPlate);
                    return;
                }
            }

            // 4) Cấu hình giá và chỗ đỗ trống phù hợp loại xe
            var cfg = db.PriceConfigs.FirstOrDefault(p => p.VehicleType == type);
            if (cfg == null)
            {
                MessageBox.Show($"Chưa có cấu hình giá cho {VehicleName(type)}.", "Thiếu cấu hình giá",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var slot = db.ParkingSlots
                .Where(s => !s.IsOccupied && s.AllowedVehicleType == type)
                .OrderBy(s => s.SlotId)
                .FirstOrDefault();
            if (slot == null)
            {
                MessageBox.Show($"Hiện không còn chỗ đỗ trống cho {VehicleName(type)}.", "Hết chỗ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5) Lưu tất cả trong một transaction
            using var tx = db.Database.BeginTransaction();

            if (vehicle == null)
            {
                vehicle = new Vehicle { LicensePlate = plate, VehicleType = type };
                db.Vehicles.Add(vehicle);
            }
            if (monthly)
            {
                vehicle.OwerName = ownerName;      // (tên field trong model đang viết là "OwerName")
                vehicle.PhoneNumber = phone;
            }
            db.SaveChanges();   // để có VehicleId

            var ticket = new Ticket
            {
                TicketCode = GenerateTicketCode(db, monthly),
                VehicleId = vehicle.VehicleId,
                ParkingSlotId = slot.SlotId,
                PriceConfigId = cfg.ConfigId,
                EntryTime = DateTime.Now,
                Status = TicketStatus.Inparking,
                IsMonthly = monthly
            };
            db.Tickets.Add(ticket);

            slot.IsOccupied = true;
            slot.CurrentVehicleID = vehicle.VehicleId;

            if (monthly)
            {
                db.MonthlySubscribers.Add(new MonthlySubscriber
                {
                    SubcriberId = "MT" + DateTime.Now.ToString("yyMMddHHmmssfff"),
                    FullName = ownerName,
                    PhoneNumber = phone,
                    LicensePlate = plate,
                    VehicleType = type.ToString(),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths((int)nudMonths.Value),
                    IsActive = true,
                    MonthlyFee = nudFee.Value
                });
            }

            db.SaveChanges();
            tx.Commit();

            ClearForm();
            RefreshAll(ticket.TicketId);
            MessageBox.Show(
                $"Đã tạo vé {ticket.TicketCode} cho xe {plate}.\nVị trí đỗ: {slot.SlotName} ({slot.Zone}).",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError("Không thể thêm vé", ex);
        }
    }

    /// <summary>Mã vé duy nhất, tối đa 30 ký tự. Vé tháng bắt đầu bằng "M", vé thường bằng "T".</summary>
    private static string GenerateTicketCode(AppDbContext db, bool monthly)
    {
        string prefix = monthly ? "M" : "T";
        string code = prefix + DateTime.Now.ToString("yyMMddHHmmss");
        int n = 1;
        string candidate = code;
        while (db.Tickets.Any(t => t.TicketCode == candidate))
            candidate = $"{code}-{n++}";
        return candidate;
    }

    // ------------------------------------------------------------
    //  Khóa vé
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
    //  Xóa vé
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

            // Vé đã có hóa đơn thì không xóa để giữ lịch sử doanh thu
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
    private void ClearForm()
    {
        txtPlate.Clear();
        cbVehicleType.SelectedIndex = 0;
        chkMonthly.Checked = false;
        txtOwnerName.Clear();
        txtPhone.Clear();
        nudMonths.Value = 1;
        nudFee.Value = 0;
        txtPlate.Focus();
    }

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

    private static void Warn(string message, Control focus)
    {
        MessageBox.Show(message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }

    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}