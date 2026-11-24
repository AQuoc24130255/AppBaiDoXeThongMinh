using System.Drawing.Drawing2D;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;
using VType = AppBaiDoXeThongMinh.Models.VehicleType; 


namespace AppBaiDoXeThongMinh.Views;

public partial class FormDashboard : Form
{
    private sealed record RevenueItem(DateTime Day, bool IsNight, VType Type, decimal Amount, double Hours);
    
    private static readonly Color motoColor = Color.FromArgb(66, 133, 200);
    private static readonly Color carColor = Color.FromArgb(240, 150, 90);

    private decimal _pieMoto;
    private decimal _pieCar;
    
    public FormDashboard()
    {
        InitializeComponent();
        SetupUi();
        
        Load +=  (_, _) => RefreshDashboard();
    }

    private void SetupUi()
    {
        btRevenue.Click += (_, _) => RefreshDashboard();
        btDetail.Click += BtDetail_Click;
        
        panelThongke.Paint += PanelThongke_Paint;
        panelThongke.Resize += (_, _) => panelThongke.Invalidate();
        
    }

    private void RefreshDashboard()
    {
        LoadParkingStats();
        LoadRevenueReport();
    }
    
    private void LoadParkingStats()
    {
        try
        {
            using var db = new AppDbContext();
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            // xe đang gửi
            var parked = db.Tickets
                .Where(t => t.Status == TicketStatus.Inparking)
                .Select(t => t.Vehicle.VehicleType)
                .ToList();

            lbtotalParked.Text = parked.Count.ToString("N0");
            lbMotobikeParked.Text = $"Xe Máy: {parked.Count(v => v == VType.Motorbike)}";
            lbCarParked.Text = $"Xe Ô Tô:{parked.Count(v => v == VType.Car)}";

            // tỷ lệ đã lấp đầy chỗ đỗ
            var slots = db.ParkingSlots
                .Select(s => new { s.IsOccupied, s.AllowedVehicleType })
                .ToList();
            int totalSlots = slots.Count;
            int occupied = slots.Count(s => s.IsOccupied);
            double rate = totalSlots == 0 ? 0 : occupied * 100.0 / totalSlots;

            lbTotalOccupancy.Text = $"{rate:0.#}%";
            lbSlotOccupancy.Text = $"Số Chỗ Trống: {totalSlots - occupied}";

            lbTotalSlots.Text = totalSlots.ToString("N0");
            lbMotobikeSlots.Text = $"Xe Máy: {slots.Count(s => s.AllowedVehicleType == VType.Motorbike)}";
            lbCarSlots.Text = $"Xe Ô Tô: {slots.Count(s => s.AllowedVehicleType == VType.Car)}";

            // xe vào bãi hôm nay
            var todayVehicles = db.Tickets
                .Where(t => t.EntryTime >= today && t.EntryTime < tomorrow)
                .Select(t => t.Vehicle.VehicleType)
                .ToList();

            lbTotalToday.Text = todayVehicles.Count.ToString("N0");
            lbMotobikeToday.Text = $"Xe Máy: {todayVehicles.Count(v => v == VType.Motorbike)}";
            lbCarToday.Text = $"Xe Ô Tô: {todayVehicles.Count(v => v == VType.Car)}";

            // xe tháng có hieu lực
            var subscribers = db.MonthlySubscribers
                .Where(s => s.IsActive && s.EndDate >= today)
                .Select(s => s.VehicleType)
                .ToList();
            int subCar = subscribers.Count(v => v == VType.Car);

            lbTotalMonthly.Text = subscribers.Count.ToString("N0");
            lbMotobikeMonthly.Text = $"Xe Máy: {subscribers.Count - subCar}";
            lbCarMonthly.Text = $"Xe Ô Tô: {subCar}";
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải thống kê bãi xe", ex);
        }
    }
    
    private void LoadRevenueReport()
    {
        DateTime fromDate = dtpStartDate.Value.Date;
        DateTime toDate = dtpEndDate.Value.Date.AddDays(1);

        if (toDate <= fromDate)
        {
            MessageBox.Show("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu.",
                "Khoảng ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var db = new AppDbContext();

            // Khung giờ đêm lấy từ cấu hình giá (mặc định 18:00 -> 06:00)
            var cfg = db.PriceConfigs.AsNoTracking().FirstOrDefault();
            TimeSpan nightStart = cfg?.NightStart ?? new TimeSpan(18, 0, 0);
            TimeSpan nightEnd = cfg?.NightEnd ?? new TimeSpan(6, 0, 0);

            // Hóa đơn + loại xe (Invoice -> Ticket -> Vehicle).
            // SQLite không SUM được decimal phía server nên lấy về rồi tính trong bộ nhớ.
            var raw = (from i in db.Invoices
                       join t in db.Tickets on i.TicketId equals t.TicketId
                       where i.IsPaid && i.PaymentDate >= fromDate && i.PaymentDate < toDate
                       select new
                       {
                           i.PaymentDate,
                           i.TotalAmount,
                           i.CheckInTime,
                           i.CheckOutTime,
                           VehicleKind = t.Vehicle.VehicleType
                       }).ToList();

            var items = raw.Select(x => new RevenueItem(
                    x.PaymentDate.Date,
                    IsNightTime(x.PaymentDate.TimeOfDay, nightStart, nightEnd),
                    x.VehicleKind,
                    x.TotalAmount,
                    Math.Max(0, (x.CheckOutTime - x.CheckInTime).TotalHours)))
                .ToList();

            // Bộ lọc ca và loại xe
            if (cbShift.SelectedIndex == 1) items = items.Where(x => !x.IsNight).ToList();
            else if (cbShift.SelectedIndex == 2) items = items.Where(x => x.IsNight).ToList();

            if (cbVehicleType.SelectedIndex == 1) items = items.Where(x => x.Type == VType.Motorbike).ToList();
            else if (cbVehicleType.SelectedIndex == 2) items = items.Where(x => x.Type == VType.Car).ToList();

            // Lưới chi tiết: nhóm theo Ngày + Ca + Loại xe
            dataGridViewFilter.Rows.Clear();
            var groups = items
                .GroupBy(x => new { x.Day, x.IsNight, x.Type })
                .OrderBy(g => g.Key.Day).ThenBy(g => g.Key.IsNight).ThenBy(g => g.Key.Type);

            foreach (var g in groups)
            {
                dataGridViewFilter.Rows.Add(
                    g.Key.Day.ToString("dd/MM/yyyy"),       // Date
                    g.Key.IsNight ? "Tối" : "Sáng",         // Shift
                    g.Key.Type == VType.Car ? "Xe Ô Tô" : "Xe Máy", // VehicleType
                    g.Count(),                              // TranSactionCount
                    $"{g.Sum(x => x.Amount):N0}",           // TotalAmount
                    $"{g.Sum(x => x.Hours):0.#}");          // Hours
            }

            // Khung tóm tắt
            lbTotalRevenue.Text = $"{items.Sum(x => x.Amount):N0} VND";
            lbDayTotalAmount.Text = $"{items.Where(x => !x.IsNight).Sum(x => x.Amount):N0} VND";
            lbNightTotalAmount.Text = $"{items.Where(x => x.IsNight).Sum(x => x.Amount):N0} VND";

            _pieMoto = items.Where(x => x.Type == VType.Motorbike).Sum(x => x.Amount);
            _pieCar = items.Where(x => x.Type == VType.Car).Sum(x => x.Amount);
            panelThongke.Invalidate();
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải báo cáo doanh thu", ex);
        }
    }
    
    // ham ve bieu do
    private void PanelThongke_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int size = Math.Min(panelThongke.Height - 8, panelThongke.Width / 2);
        if (size <= 0) return;
        var rect = new Rectangle(4, (panelThongke.Height - size) / 2, size, size);

        decimal total = _pieMoto + _pieCar;
        using var motoBrush = new SolidBrush(motoColor);
        using var carBrush = new SolidBrush(carColor);

        if (total <= 0)
        {
            using var empty = new SolidBrush(Color.FromArgb(215, 218, 222));
            g.FillEllipse(empty, rect);
        }
        else if (_pieCar == 0) g.FillEllipse(motoBrush, rect);
        else if (_pieMoto == 0) g.FillEllipse(carBrush, rect);
        else
        {
            float motoAngle = (float)(360.0 * (double)(_pieMoto / total));
            g.FillPie(motoBrush, rect, -90, motoAngle);
            g.FillPie(carBrush, rect, -90 + motoAngle, 360 - motoAngle);
        }

        // Chú thích bên phải biểu đồ
        int lx = rect.Right + 8;
        int ly = panelThongke.Height / 2 - 20;
        g.FillRectangle(motoBrush, lx, ly + 3, 10, 10);
        TextRenderer.DrawText(g, "Xe máy", Font, new Point(lx + 14, ly), Color.Black);
        g.FillRectangle(carBrush, lx, ly + 27, 10, 10);
        TextRenderer.DrawText(g, "Xe ô tô", Font, new Point(lx + 14, ly + 24), Color.Black);
    }
    
    private void BtDetail_Click(object? sender, EventArgs e)
    {
        VType? vehicleFilter = cbVehicleType.SelectedIndex switch
        {
            1 => VType.Motorbike,
            2 => VType.Car,
            _ => null
        };

        using var form = new FormRevenueChart(
            dtpStartDate.Value.Date,
            dtpEndDate.Value.Date,
            cbShift.SelectedIndex,
            vehicleFilter);

        form.ShowDialog(this);
    }
    
    // ham ho tro
    private static bool IsNightTime(TimeSpan time, TimeSpan nightStart, TimeSpan nightEnd)
    {
        if (nightStart <= nightEnd)
            return time >= nightStart && time < nightEnd;
        return time >= nightStart || time < nightEnd;   // khung vắt qua nửa đêm
    }

    private static void ShowError(string message, Exception ex)
    {
        MessageBox.Show($"{message}.\n\nChi tiết: {ex.Message}",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
