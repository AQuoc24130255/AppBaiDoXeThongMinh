using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBaiDoXeThongMinh.Views;

/// <summary>
/// Màn hình thống kê doanh thu: 4 biểu đồ vẽ bằng GDI+ (System.Drawing.Drawing2D)
///  1) Cột chồng doanh thu theo ngày (ca sáng + ca đêm)
///  2) Vòng (donut) cơ cấu theo loại xe
///  3) Vùng/đường doanh thu theo giờ trong ngày
///  4) Thanh ngang theo hình thức thanh toán
/// Rê chuột lên biểu đồ để xem chi tiết.
/// </summary>
public partial class FormRevenueChart : Form
{
    // ------------------------------------------------------------
    //  Màu sắc, font
    // ------------------------------------------------------------
    private static readonly CultureInfo Vi = new("vi-VN");
    private static readonly Color BlueC = Color.FromArgb(47, 111, 168);
    private static readonly Color NavyC = Color.FromArgb(22, 48, 75);
    private static readonly Color OrangeC = Color.FromArgb(240, 150, 90);
    private static readonly Color GreenC = Color.FromArgb(46, 158, 107);
    private static readonly Color PurpleC = Color.FromArgb(142, 94, 190);
    private static readonly Color GreyC = Color.FromArgb(107, 114, 128);
    private static readonly Color DarkC = Color.FromArgb(31, 41, 55);
    private static readonly Color[] Palette = { BlueC, GreenC, OrangeC, PurpleC };

    private static readonly Font TitleFont = new("Segoe UI", 11F, FontStyle.Bold);
    private static readonly Font SmallFont = new("Segoe UI", 8.5F);
    private static readonly Font BoldSmallFont = new("Segoe UI", 9F, FontStyle.Bold);
    private static readonly Font CenterFont = new("Segoe UI", 12F, FontStyle.Bold);

    // ------------------------------------------------------------
    //  Dữ liệu
    // ------------------------------------------------------------
    private sealed record Item(DateTime PaidAt, bool IsNight, VehicleType Type, decimal Amount, string Method);

    private sealed record DayRow(DateTime Day, int Count, decimal DayAmount, decimal NightAmount)
    {
        public decimal Total => DayAmount + NightAmount;
    }

    private sealed record TypeRow(string Name, decimal Amount, int Count, Color Color);
    private sealed record MethodRow(string Name, decimal Amount, int Count);

    /// <summary>Vùng có thể rê chuột + nội dung tooltip.</summary>
    private sealed record Hit(RectangleF Rect, string Text);

    /// <summary>Một cung của biểu đồ vòng (góc tính theo chiều kim đồng hồ từ 12 giờ).</summary>
    private sealed record Segment(float StartCw, float Sweep, string Text);

    private List<DayRow> _days = new();
    private readonly decimal[] _hourly = new decimal[24];
    private readonly int[] _hourlyCount = new int[24];
    private List<TypeRow> _types = new();
    private List<MethodRow> _methods = new();
    private decimal _total;

    // Hit-test cho tooltip / làm nổi bật khi rê chuột
    private readonly List<Hit> _dailyHits = new();
    private readonly List<Hit> _hourlyHits = new();
    private readonly List<Hit> _methodHits = new();
    private readonly List<Segment> _segments = new();
    private PointF _donutCenter;
    private float _donutOuter;
    private float _donutInner;
    private int _dailyHover = -1;
    private int _hourlyHover = -1;
    private int _methodHover = -1;
    private int _typeHover = -1;

    private readonly ToolTip _tip = new()
    {
        InitialDelay = 0,
        ReshowDelay = 0,
        AutoPopDelay = 8000,
        ShowAlways = true
    };

    // ------------------------------------------------------------
    //  Khởi tạo
    // ------------------------------------------------------------
    public FormRevenueChart() : this(DateTime.Today.AddDays(-6), DateTime.Today, 0, null)
    {
    }

    /// <param name="shiftFilter">0: tất cả ca, 1: ca sáng, 2: ca đêm.</param>
    /// <param name="vehicleFilter">null: tất cả loại xe.</param>
    public FormRevenueChart(DateTime fromDate, DateTime toDate, int shiftFilter, VehicleType? vehicleFilter)
    {
        InitializeComponent();
        SetupUi(fromDate, toDate, shiftFilter, vehicleFilter);
        Load += (_, _) => LoadData();
    }

    private void SetupUi(DateTime fromDate, DateTime toDate, int shiftFilter, VehicleType? vehicleFilter)
    {
        dtpFrom.Value = fromDate.Date;
        dtpTo.Value = toDate.Date;
        cbShift.SelectedIndex = shiftFilter is >= 0 and <= 2 ? shiftFilter : 0;
        cbVehicle.SelectedIndex = vehicleFilter == VehicleType.Motorbike ? 1
                                : vehicleFilter == VehicleType.Car ? 2 : 0;

        foreach (var panel in new[] { pnlDaily, pnlVehicle, pnlHourly, pnlMethod })
        {
            EnableDoubleBuffer(panel);
            panel.Resize += (_, _) => panel.Invalidate();
        }

        pnlDaily.Paint += PnlDaily_Paint;
        pnlVehicle.Paint += PnlVehicle_Paint;
        pnlHourly.Paint += PnlHourly_Paint;
        pnlMethod.Paint += PnlMethod_Paint;

        pnlDaily.MouseMove += (_, e) => HandleHover(pnlDaily, _dailyHits, ref _dailyHover, e.Location);
        pnlDaily.MouseLeave += (_, _) => ClearHover(pnlDaily, ref _dailyHover);
        pnlHourly.MouseMove += (_, e) => HandleHover(pnlHourly, _hourlyHits, ref _hourlyHover, e.Location);
        pnlHourly.MouseLeave += (_, _) => ClearHover(pnlHourly, ref _hourlyHover);
        pnlMethod.MouseMove += (_, e) => HandleHover(pnlMethod, _methodHits, ref _methodHover, e.Location);
        pnlMethod.MouseLeave += (_, _) => ClearHover(pnlMethod, ref _methodHover);
        pnlVehicle.MouseMove += PnlVehicle_MouseMove;
        pnlVehicle.MouseLeave += (_, _) => ClearHover(pnlVehicle, ref _typeHover);

        btApply.Click += (_, _) => LoadData();
        FormClosed += (_, _) => _tip.Dispose();
    }

    // ------------------------------------------------------------
    //  Nạp & tổng hợp dữ liệu
    // ------------------------------------------------------------
    private void LoadData()
    {
        DateTime start = dtpFrom.Value.Date;
        DateTime endExclusive = dtpTo.Value.Date.AddDays(1);
        if (endExclusive <= start)
        {
            MessageBox.Show("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu.", "Khoảng ngày không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        List<Item> items;
        try
        {
            using var db = new AppDbContext();

            // Khung giờ đêm lấy từ cấu hình giá đầu tiên (giống Dashboard)
            var cfg = db.PriceConfigs.AsNoTracking().FirstOrDefault();
            TimeSpan nightStart = cfg?.NightStart ?? new TimeSpan(18, 0, 0);
            TimeSpan nightEnd = cfg?.NightEnd ?? new TimeSpan(6, 0, 0);

            var raw = (from i in db.Invoices
                       join t in db.Tickets on i.TicketId equals t.TicketId
                       where i.IsPaid && i.PaymentDate >= start && i.PaymentDate < endExclusive
                       select new
                       {
                           i.PaymentDate,
                           i.TotalAmount,
                           i.PaymentMethod,
                           Kind = t.Vehicle.VehicleType
                       }).ToList();

            items = raw.Select(x => new Item(
                    x.PaymentDate,
                    IsNightTime(x.PaymentDate.TimeOfDay, nightStart, nightEnd),
                    x.Kind,
                    x.TotalAmount,
                    x.PaymentMethod.ToString() ?? ""))
                .ToList();
        }
        catch (Exception ex)
        {
            ShowError("Không thể tải dữ liệu thống kê", ex);
            return;
        }

        if (cbShift.SelectedIndex == 1) items = items.Where(x => !x.IsNight).ToList();
        else if (cbShift.SelectedIndex == 2) items = items.Where(x => x.IsNight).ToList();

        if (cbVehicle.SelectedIndex == 1) items = items.Where(x => x.Type == VehicleType.Motorbike).ToList();
        else if (cbVehicle.SelectedIndex == 2) items = items.Where(x => x.Type == VehicleType.Car).ToList();

        // --- Tổng hợp ---
        _total = items.Sum(x => x.Amount);
        int count = items.Count;

        var map = items.GroupBy(x => x.PaidAt.Date)
            .ToDictionary(
                grp => grp.Key,
                grp => new DayRow(grp.Key, grp.Count(),
                    grp.Where(x => !x.IsNight).Sum(x => x.Amount),
                    grp.Where(x => x.IsNight).Sum(x => x.Amount)));

        // Khoảng ngắn: hiện đủ mọi ngày (kể cả ngày không có doanh thu)
        int span = (endExclusive - start).Days;
        _days = span <= 62
            ? Enumerable.Range(0, span)
                .Select(k => start.AddDays(k))
                .Select(d => map.TryGetValue(d, out var row) ? row : new DayRow(d, 0, 0, 0))
                .ToList()
            : map.Values.OrderBy(d => d.Day).ToList();

        Array.Clear(_hourly);
        Array.Clear(_hourlyCount);
        foreach (var it in items)
        {
            _hourly[it.PaidAt.Hour] += it.Amount;
            _hourlyCount[it.PaidAt.Hour]++;
        }

        _types = new List<TypeRow>
        {
            new("Xe máy", items.Where(x => x.Type == VehicleType.Motorbike).Sum(x => x.Amount),
                items.Count(x => x.Type == VehicleType.Motorbike), BlueC),
            new("Ô tô", items.Where(x => x.Type == VehicleType.Car).Sum(x => x.Amount),
                items.Count(x => x.Type == VehicleType.Car), OrangeC)
        };

        _methods = items.GroupBy(x => MethodName(x.Method))
            .Select(grp => new MethodRow(grp.Key, grp.Sum(x => x.Amount), grp.Count()))
            .OrderByDescending(m => m.Amount)
            .ToList();

        // --- Chỉ số tổng quan ---
        lbKpiTotalValue.Text = $"{Money(_total)} VNĐ";
        lbKpiCountValue.Text = count.ToString("N0", Vi);
        lbKpiAvgValue.Text = count == 0 ? "0 VNĐ" : $"{Money(_total / count)} VNĐ";

        var peak = _days.OrderByDescending(d => d.Total).FirstOrDefault();
        lbKpiPeakValue.Text = peak != null && peak.Total > 0
            ? $"{peak.Day:dd/MM/yyyy} · {Compact(peak.Total)}"
            : "—";

        // --- Vẽ lại ---
        _dailyHover = _hourlyHover = _methodHover = _typeHover = -1;
        foreach (var panel in new[] { pnlDaily, pnlVehicle, pnlHourly, pnlMethod })
        {
            _tip.Hide(panel);
            panel.Invalidate();
        }
    }

    // ------------------------------------------------------------
    //  Biểu đồ 1: cột chồng doanh thu theo ngày
    // ------------------------------------------------------------
    private void PnlDaily_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        PrepareGraphics(g);
        _dailyHits.Clear();
        int W = pnlDaily.ClientSize.Width;
        int H = pnlDaily.ClientSize.Height;

        DrawTitle(g, "Doanh thu theo ngày", null, W);

        // Chú thích (góc phải trên)
        float lx = W - 14f;
        foreach (var (name, color) in new[] { ("Ca đêm", NavyC), ("Ca sáng", BlueC) })
        {
            var size = TextRenderer.MeasureText(g, name, SmallFont);
            lx -= size.Width;
            TextRenderer.DrawText(g, name, SmallFont, new Point((int)lx, 13), GreyC);
            lx -= 14f;
            using var legendBrush = new SolidBrush(color);
            g.FillRectangle(legendBrush, lx, 18f, 9f, 9f);
            lx -= 14f;
        }

        if (_days.Count == 0 || _total <= 0)
        {
            DrawEmpty(g, W, H);
            return;
        }

        float plotL = 66f, plotT = 48f, plotR = W - 18f, plotB = H - 34f;
        float plotW = plotR - plotL, plotH = plotB - plotT;
        if (plotW < 40f || plotH < 40f) return;

        decimal niceMax = NiceMax(_days.Max(d => d.Total));
        DrawGrid(g, plotL, plotT, plotR, plotB, niceMax);

        int n = _days.Count;
        float slot = plotW / n;
        float barW = Math.Min(slot * 0.62f, 54f);
        int maxLabels = Math.Max(1, (int)(plotW / 48f));
        int labelStep = (int)Math.Ceiling(n / (double)maxLabels);

        for (int i = 0; i < n; i++)
        {
            var d = _days[i];
            float slotX = plotL + slot * i;
            var slotRect = new RectangleF(slotX, plotT, slot, plotH);

            if (i == _dailyHover)
            {
                using var hoverBrush = new SolidBrush(Color.FromArgb(28, BlueC));
                g.FillRectangle(hoverBrush, slotRect);
            }

            float x = slotX + (slot - barW) / 2f;
            float dayH = (float)(d.DayAmount / niceMax) * plotH;
            float nightH = (float)(d.NightAmount / niceMax) * plotH;
            float totalH = dayH + nightH;

            if (totalH > 0.5f)
            {
                var barRect = new RectangleF(x, plotB - totalH, barW, totalH);
                using var path = RoundedTop(barRect, 5f);

                // Toàn bộ cột tô màu ca sáng (gradient), rồi phủ phần ca đêm lên trên, cắt theo hình cột
                using (var dayBrush = new LinearGradientBrush(barRect, Lighten(BlueC, 45), BlueC, 90f))
                    g.FillPath(dayBrush, path);

                if (nightH > 0.5f)
                {
                    var nightRect = new RectangleF(x, plotB - totalH, barW, nightH);
                    var state = g.Save();
                    g.SetClip(path, CombineMode.Intersect);
                    using (var nightBrush = new LinearGradientBrush(nightRect, Lighten(NavyC, 35), NavyC, 90f))
                        g.FillRectangle(nightBrush, nightRect);
                    g.Restore(state);
                }

                // Nhãn giá trị trên đầu cột (khi còn đủ chỗ)
                if (n <= 16 && barW >= 26f)
                {
                    TextRenderer.DrawText(g, Compact(d.Total), SmallFont,
                        new Rectangle((int)slotX, (int)(plotB - totalH - 18f), (int)slot, 16), DarkC,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }

            if (i % labelStep == 0)
            {
                TextRenderer.DrawText(g, d.Day.ToString("dd/MM", Vi), SmallFont,
                    new Rectangle((int)slotX - 10, (int)plotB + 6, (int)slot + 20, 16), GreyC,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            string tip = $"{d.Day:dd/MM/yyyy}\n" +
                         $"Ca sáng: {Money(d.DayAmount)} VNĐ\n" +
                         $"Ca đêm: {Money(d.NightAmount)} VNĐ\n" +
                         $"Tổng: {Money(d.Total)} VNĐ\n" +
                         $"Giao dịch: {d.Count}";
            _dailyHits.Add(new Hit(slotRect, tip));
        }

        using var axisPen = new Pen(Color.FromArgb(150, 160, 175), 1.5f);
        g.DrawLine(axisPen, plotL, plotB, plotR, plotB);
    }

    // ------------------------------------------------------------
    //  Biểu đồ 2: vòng cơ cấu theo loại xe
    // ------------------------------------------------------------
    private void PnlVehicle_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        PrepareGraphics(g);
        _segments.Clear();
        _donutOuter = 0;
        int W = pnlVehicle.ClientSize.Width;
        int H = pnlVehicle.ClientSize.Height;

        DrawTitle(g, "Cơ cấu theo loại xe", null, W);

        decimal total = _types.Sum(t => t.Amount);
        if (total <= 0)
        {
            DrawEmpty(g, W, H);
            return;
        }

        float legendH = _types.Count * 24f;
        float dia = Math.Min(W - 40f, H - 46f - legendH - 18f);
        if (dia < 60f) return;

        float outer = dia / 2f - 6f;
        float inner = outer * 0.62f;
        var center = new PointF(W / 2f, 46f + dia / 2f);
        _donutCenter = center;
        _donutOuter = outer;
        _donutInner = inner;

        float startCw = 0f;
        int segIndex = 0;
        foreach (var t in _types)
        {
            if (t.Amount <= 0) continue;

            float sweep = (float)(t.Amount / total) * 360f;
            double pct = (double)(t.Amount / total * 100m);
            _segments.Add(new Segment(startCw, sweep,
                $"{t.Name}\n{Money(t.Amount)} VNĐ ({pct:0.0}%)\nGiao dịch: {t.Count}"));

            // Cung đang rê chuột "nở" ra một chút
            float grow = segIndex == _typeHover ? 5f : 0f;
            var outerRect = new RectangleF(center.X - outer - grow, center.Y - outer - grow,
                (outer + grow) * 2f, (outer + grow) * 2f);
            var innerRect = new RectangleF(center.X - inner, center.Y - inner, inner * 2f, inner * 2f);

            using var path = new GraphicsPath();
            float gdiStart = startCw - 90f;   // GDI+ tính góc từ 3 giờ; ta bắt đầu từ 12 giờ
            path.AddArc(outerRect, gdiStart, sweep);
            path.AddArc(innerRect, gdiStart + sweep, -sweep);
            path.CloseFigure();

            using (var brush = new LinearGradientBrush(outerRect, Lighten(t.Color, 40), t.Color, 45f))
                g.FillPath(brush, path);
            using (var separator = new Pen(Color.White, 2f))
                g.DrawPath(separator, path);

            startCw += sweep;
            segIndex++;
        }

        // Chữ ở tâm vòng
        TextRenderer.DrawText(g, Compact(total), CenterFont,
            new Rectangle((int)(center.X - inner), (int)(center.Y - 22), (int)(inner * 2), 24), DarkC,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        TextRenderer.DrawText(g, "tổng doanh thu", SmallFont,
            new Rectangle((int)(center.X - inner), (int)(center.Y + 2), (int)(inner * 2), 18), GreyC,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        // Chú thích phía dưới
        float ly = 46f + dia + 14f;
        foreach (var t in _types)
        {
            double pct = (double)(t.Amount / total * 100m);
            using (var swatchBrush = new SolidBrush(t.Color))
            using (var swatch = RoundedRect(new RectangleF(28f, ly + 5f, 12f, 12f), 3f))
                g.FillPath(swatchBrush, swatch);

            TextRenderer.DrawText(g, t.Name, BoldSmallFont, new Point(48, (int)ly + 2), DarkC);
            TextRenderer.DrawText(g, $"{Money(t.Amount)} VNĐ  ({pct:0.#}%)", SmallFont,
                new Rectangle(110, (int)ly, W - 110 - 24, 22), GreyC,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            ly += 24f;
        }
    }

    private void PnlVehicle_MouseMove(object? sender, MouseEventArgs e)
    {
        int idx = -1;
        if (_donutOuter > 0)
        {
            float dx = e.X - _donutCenter.X;
            float dy = e.Y - _donutCenter.Y;
            float r = MathF.Sqrt(dx * dx + dy * dy);
            if (r >= _donutInner && r <= _donutOuter + 6f)
            {
                // Góc theo chiều kim đồng hồ tính từ 12 giờ
                float angle = MathF.Atan2(dx, -dy) * 180f / MathF.PI;
                if (angle < 0) angle += 360f;
                for (int k = 0; k < _segments.Count; k++)
                {
                    if (angle >= _segments[k].StartCw && angle < _segments[k].StartCw + _segments[k].Sweep)
                    {
                        idx = k;
                        break;
                    }
                }
            }
        }

        if (idx == _typeHover) return;
        _typeHover = idx;
        pnlVehicle.Invalidate();
        if (idx >= 0) _tip.Show(_segments[idx].Text, pnlVehicle, e.X + 14, e.Y + 18);
        else _tip.Hide(pnlVehicle);
    }

    // ------------------------------------------------------------
    //  Biểu đồ 3: doanh thu theo giờ trong ngày (vùng + đường)
    // ------------------------------------------------------------
    private void PnlHourly_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        PrepareGraphics(g);
        _hourlyHits.Clear();
        int W = pnlHourly.ClientSize.Width;
        int H = pnlHourly.ClientSize.Height;

        decimal maxHour = _hourly.Max();
        string? subtitle = null;
        if (maxHour > 0)
        {
            int peakHour = Array.IndexOf(_hourly, maxHour);
            subtitle = $"Cao điểm: {peakHour}h – {Compact(maxHour)} VNĐ";
        }
        DrawTitle(g, "Doanh thu theo giờ trong ngày", subtitle, W);

        if (maxHour <= 0)
        {
            DrawEmpty(g, W, H);
            return;
        }

        float plotL = 66f, plotT = 48f, plotR = W - 18f, plotB = H - 34f;
        float plotW = plotR - plotL, plotH = plotB - plotT;
        if (plotW < 40f || plotH < 40f) return;

        decimal niceMax = NiceMax(maxHour);
        DrawGrid(g, plotL, plotT, plotR, plotB, niceMax);

        float slot = plotW / 24f;
        var pts = new PointF[24];
        for (int h = 0; h < 24; h++)
        {
            float x = plotL + slot * (h + 0.5f);
            float y = plotB - (float)(_hourly[h] / niceMax) * plotH;
            pts[h] = new PointF(x, y);
        }

        // Vùng tô gradient dưới đường
        var polygon = new List<PointF> { new(pts[0].X, plotB) };
        polygon.AddRange(pts);
        polygon.Add(new PointF(pts[^1].X, plotB));
        using (var areaBrush = new LinearGradientBrush(new RectangleF(plotL, plotT, plotW, plotH),
                   Color.FromArgb(120, GreenC), Color.FromArgb(10, GreenC), 90f))
            g.FillPolygon(areaBrush, polygon.ToArray());

        // Đường rê chuột (dọc)
        if (_hourlyHover >= 0)
        {
            using var guide = new Pen(Color.FromArgb(120, GreenC), 1.2f) { DashStyle = DashStyle.Dash };
            g.DrawLine(guide, pts[_hourlyHover].X, plotT, pts[_hourlyHover].X, plotB);
        }

        using (var linePen = new Pen(GreenC, 2.5f) { LineJoin = LineJoin.Round })
            g.DrawLines(linePen, pts);

        // Chấm tại từng giờ có doanh thu
        for (int h = 0; h < 24; h++)
        {
            if (_hourly[h] <= 0) continue;
            float r = h == _hourlyHover ? 5.5f : 3.5f;
            using var dotFill = new SolidBrush(Color.White);
            using var dotPen = new Pen(GreenC, 2f);
            g.FillEllipse(dotFill, pts[h].X - r, pts[h].Y - r, r * 2, r * 2);
            g.DrawEllipse(dotPen, pts[h].X - r, pts[h].Y - r, r * 2, r * 2);
        }

        for (int h = 0; h < 24; h++)
        {
            if (h % 3 == 0)
            {
                TextRenderer.DrawText(g, $"{h}h", SmallFont,
                    new Rectangle((int)(pts[h].X - 16), (int)plotB + 6, 32, 16), GreyC,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            var slotRect = new RectangleF(plotL + slot * h, plotT, slot, plotH);
            string tip = $"{h:00}:00 – {h + 1:00}:00\n" +
                         $"Doanh thu: {Money(_hourly[h])} VNĐ\n" +
                         $"Giao dịch: {_hourlyCount[h]}";
            _hourlyHits.Add(new Hit(slotRect, tip));
        }

        using var axisPen = new Pen(Color.FromArgb(150, 160, 175), 1.5f);
        g.DrawLine(axisPen, plotL, plotB, plotR, plotB);
    }

    // ------------------------------------------------------------
    //  Biểu đồ 4: thanh ngang theo hình thức thanh toán
    // ------------------------------------------------------------
    private void PnlMethod_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        PrepareGraphics(g);
        _methodHits.Clear();
        int W = pnlMethod.ClientSize.Width;
        int H = pnlMethod.ClientSize.Height;

        DrawTitle(g, "Doanh thu theo hình thức thanh toán", null, W);

        if (_methods.Count == 0 || _total <= 0)
        {
            DrawEmpty(g, W, H);
            return;
        }

        const float top = 54f, labelW = 112f, valueW = 124f;
        float rowH = Math.Min(46f, (H - top - 16f) / _methods.Count);
        float barL = 14f + labelW;
        float barR = W - 14f - valueW;
        float barMaxW = barR - barL;
        if (barMaxW < 30f || rowH < 18f) return;

        decimal max = _methods.Max(m => m.Amount);
        for (int i = 0; i < _methods.Count; i++)
        {
            var m = _methods[i];
            float y = top + rowH * i;
            float cy = y + rowH / 2f;
            var rowRect = new RectangleF(8f, y, W - 16f, rowH);

            if (i == _methodHover)
            {
                using var hoverBrush = new SolidBrush(Color.FromArgb(24, BlueC));
                g.FillRectangle(hoverBrush, rowRect);
            }

            TextRenderer.DrawText(g, m.Name, BoldSmallFont,
                new Rectangle(14, (int)(cy - 10f), (int)labelW, 20), DarkC,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            float thick = Math.Min(18f, rowH * 0.5f);

            // Nền thanh
            var track = new RectangleF(barL, cy - thick / 2f, barMaxW, thick);
            using (var trackPath = RoundedRect(track, thick / 2f))
            using (var trackBrush = new SolidBrush(Color.FromArgb(236, 240, 245)))
                g.FillPath(trackBrush, trackPath);

            // Thanh giá trị
            float w = max > 0 ? (float)(m.Amount / max) * barMaxW : 0f;
            if (m.Amount > 0) w = Math.Max(w, thick);
            if (w > 0f)
            {
                var color = Palette[i % Palette.Length];
                var bar = new RectangleF(barL, cy - thick / 2f, w, thick);
                using var barPath = RoundedRect(bar, thick / 2f);
                using var barBrush = new LinearGradientBrush(bar, Lighten(color, 45), color, 0f);
                g.FillPath(barBrush, barPath);
            }

            double pct = (double)(m.Amount / _total * 100m);
            TextRenderer.DrawText(g, $"{Compact(m.Amount)} ({pct:0.#}%)", SmallFont,
                new Rectangle((int)barR + 6, (int)(cy - 10f), (int)valueW - 6, 20), GreyC,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            _methodHits.Add(new Hit(rowRect,
                $"{m.Name}\n{Money(m.Amount)} VNĐ ({pct:0.0}%)\nGiao dịch: {m.Count}"));
        }
    }

    // ------------------------------------------------------------
    //  Tooltip khi rê chuột
    // ------------------------------------------------------------
    private void HandleHover(Panel panel, List<Hit> hits, ref int hoverIndex, Point pt)
    {
        int idx = -1;
        for (int k = 0; k < hits.Count; k++)
        {
            if (hits[k].Rect.Contains(pt))
            {
                idx = k;
                break;
            }
        }

        if (idx == hoverIndex) return;
        hoverIndex = idx;
        panel.Invalidate();
        if (idx >= 0) _tip.Show(hits[idx].Text, panel, pt.X + 14, pt.Y + 18);
        else _tip.Hide(panel);
    }

    private void ClearHover(Panel panel, ref int hoverIndex)
    {
        if (hoverIndex == -1) return;
        hoverIndex = -1;
        panel.Invalidate();
        _tip.Hide(panel);
    }

    // ------------------------------------------------------------
    //  Hàm vẽ dùng chung (Drawing2D)
    // ------------------------------------------------------------
    private static void PrepareGraphics(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    }

    private static void DrawTitle(Graphics g, string title, string? subtitle, int width)
    {
        TextRenderer.DrawText(g, title, TitleFont, new Point(14, 10), NavyC);
        if (!string.IsNullOrEmpty(subtitle))
        {
            var size = TextRenderer.MeasureText(g, subtitle, SmallFont);
            TextRenderer.DrawText(g, subtitle, SmallFont, new Point(width - size.Width - 14, 15), GreyC);
        }
    }

    private static void DrawEmpty(Graphics g, int width, int height)
    {
        TextRenderer.DrawText(g, "Không có dữ liệu trong khoảng đã chọn", SmallFont,
            new Rectangle(0, 0, width, height), GreyC,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    /// <summary>Lưới ngang nét đứt + nhãn trục tung.</summary>
    private static void DrawGrid(Graphics g, float plotL, float plotT, float plotR, float plotB, decimal niceMax)
    {
        float plotH = plotB - plotT;
        using var gridPen = new Pen(Color.FromArgb(226, 231, 237)) { DashStyle = DashStyle.Dash };
        for (int k = 0; k <= 4; k++)
        {
            float y = plotB - plotH * k / 4f;
            g.DrawLine(gridPen, plotL, y, plotR, y);
            TextRenderer.DrawText(g, Compact(niceMax * k / 4m), SmallFont,
                new Rectangle(0, (int)y - 8, (int)plotL - 6, 16), GreyC,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
        }
    }

    /// <summary>Hình chữ nhật bo tròn hai góc trên (cho đầu cột).</summary>
    private static GraphicsPath RoundedTop(RectangleF r, float radius)
    {
        var path = new GraphicsPath();
        float d = Math.Min(radius * 2f, Math.Min(r.Width, r.Height * 2f));
        if (d < 1f)
        {
            path.AddRectangle(r);
            return path;
        }

        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddLine(r.Right, r.Y + d / 2f, r.Right, r.Bottom);
        path.AddLine(r.Right, r.Bottom, r.X, r.Bottom);
        path.CloseFigure();
        return path;
    }

    /// <summary>Hình chữ nhật bo tròn bốn góc.</summary>
    private static GraphicsPath RoundedRect(RectangleF r, float radius)
    {
        var path = new GraphicsPath();
        float d = Math.Min(radius * 2f, Math.Min(r.Width, r.Height));
        if (d < 1f)
        {
            path.AddRectangle(r);
            return path;
        }

        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    private static Color Lighten(Color c, int amount) =>
        Color.FromArgb(c.A, Math.Min(255, c.R + amount), Math.Min(255, c.G + amount), Math.Min(255, c.B + amount));

    // ------------------------------------------------------------
    //  Hàm hỗ trợ
    // ------------------------------------------------------------
    /// <summary>Bật double-buffer cho Panel (thuộc tính protected) để biểu đồ không nhấp nháy.</summary>
    private static void EnableDoubleBuffer(Panel panel)
    {
        typeof(System.Windows.Forms.Control)
            .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(panel, true);
    }

    private static string Money(decimal value) => value.ToString("N0", Vi);

    /// <summary>Số rút gọn cho trục và nhãn: 1,2tr / 50k / 800.</summary>
    private static string Compact(decimal value)
    {
        if (value >= 1_000_000m) return (value / 1_000_000m).ToString("0.##", Vi) + "tr";
        if (value >= 1_000m) return (value / 1_000m).ToString("0.#", Vi) + "k";
        return value.ToString("0", Vi);
    }

    /// <summary>Làm tròn lên mốc "đẹp" (1, 2, 5 × 10^n) cho trục tung.</summary>
    private static decimal NiceMax(decimal value)
    {
        if (value <= 0) return 1;
        double v = (double)value;
        double pow = Math.Pow(10, Math.Floor(Math.Log10(v)));
        double n = v / pow;
        double nice = n <= 1 ? 1 : n <= 2 ? 2 : n <= 5 ? 5 : 10;
        return (decimal)(nice * pow);
    }

    private static string MethodName(string method) => method switch
    {
        "Cash" => "Tiền mặt",
        "CreditCard" => "Thẻ tín dụng",
        "" => "Khác",
        _ => method
    };

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