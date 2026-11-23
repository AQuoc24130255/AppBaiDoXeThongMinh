using System.Drawing.Printing;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.ControlUser;

public partial class UcTicketFullDetail : UserControl
{
    public event EventHandler? CloseRequested;

    private Ticket? _currentTicket;
    private Invoice? _currentInvoice;
    private User? _currentCreator;

    public UcTicketFullDetail()
    {
        InitializeComponent();
        btnClose.Click += (_, _) => CloseRequested?.Invoke(this, EventArgs.Empty);
        btnPrintInvoice.Click += BtnPrintInvoice_Click;
    }

    public void LoadData(Ticket t, Invoice? inv, User? creator)
    {
        _currentTicket = t;
        _currentInvoice = inv;
        _currentCreator = creator;

        // Chỉ cho phép in khi đã có hóa đơn thanh toán
        btnPrintInvoice.Enabled = inv != null;
        btnPrintInvoice.BackColor = inv != null
            ? Color.FromArgb(40, 145, 75)
            : Color.LightGray;

        DateTime end = t.ExitTime ?? DateTime.Now;
        TimeSpan dur = end - t.EntryTime;

        // 1. Vé gửi xe
        lblTicketCode.Text = $"Mã vé: {t.TicketCode}";
        lblTicketStatus.Text = $"Trạng thái: {GetStatusText(t.Status)}";
        lblTicketType.Text = $"Loại vé: {(t.IsMonthly ? "Vé tháng" : "Vé lượt")}";
        lblSlotInfo.Text = t.ParkingSlot != null
            ? $"Vị trí đỗ: {t.ParkingSlot.SlotName} (Khu {t.ParkingSlot.Zone})"
            : "Vị trí đỗ: Đã trả chỗ / Không rõ";
        lblEntryTime.Text = $"Giờ vào: {t.EntryTime:dd/MM/yyyy HH:mm:ss}";
        lblExitTime.Text = t.ExitTime.HasValue
            ? $"Giờ ra: {t.ExitTime.Value:dd/MM/yyyy HH:mm:ss}"
            : "Giờ ra: Chưa ra khỏi bãi";
        lblDuration.Text = $"Thời gian gửi: {(int)dur.TotalHours} giờ {dur.Minutes} phút";

        // 2. Phương tiện & Chủ xe
        string vType = t.Vehicle?.VehicleType == VehicleType.Car ? "Ô tô" : "Xe máy";
        lblPlate.Text = $"Biển số: {t.Vehicle?.LicensePlate ?? "—"}";
        lblVType.Text = $"Loại xe: {vType}";
        lblBrandColor.Text = $"Hãng / Màu sắc: {Dash(t.Vehicle?.Brand)} / {Dash(t.Vehicle?.Color)}";
        lblOwner.Text = $"Chủ xe: {Dash(t.Vehicle?.OwerName)}";
        lblPhone.Text = $"Số điện thoại: {Dash(t.Vehicle?.PhoneNumber)}";

        // 3. Hóa đơn
        if (inv != null)
        {
            lblInvoiceId.Text = $"Mã hóa đơn: {inv.InvoiceId}";
            lblTotalAmount.Text = $"Tổng tiền: {inv.TotalAmount:N0} VNĐ";
            lblTotalAmount.ForeColor = Color.FromArgb(40, 120, 60);
            lblTotalAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            lblPayMethod.Text = $"Hình thức TT: {(inv.PaymentMethod == "Cash" ? "Tiền mặt" : "Chuyển khoản / Thẻ")}";
            lblPayDate.Text = $"Thời điểm TT: {inv.PaymentDate:dd/MM/yyyy HH:mm:ss}";
            lblCreator.Text = creator != null
                ? $"Người lập: {creator.FullName} (ID: {creator.UserId})"
                : $"Người lập: ID {inv.CreatedBy}";
            lblShift.Text = $"Ca trực: Ca #{inv.ShiftId}";
        }
        else
        {
            lblInvoiceId.Text = "Mã hóa đơn: Chưa lập hóa đơn";
            lblTotalAmount.Text = "Tổng tiền: Chưa thanh toán";
            lblTotalAmount.ForeColor = Color.DimGray;
            lblTotalAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            lblPayMethod.Text = "Hình thức TT: —";
            lblPayDate.Text = "Thời điểm TT: —";
            lblCreator.Text = "Người lập: —";
            lblShift.Text = "Ca trực: —";
        }
    }

    private void BtnPrintInvoice_Click(object? sender, EventArgs e)
    {
        if (_currentTicket == null || _currentInvoice == null)
        {
            MessageBox.Show("Vé này chưa được thanh toán nên chưa có hóa đơn để in.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var printDoc = new PrintDocument();
        printDoc.DocumentName = $"HoaDon_{_currentTicket.TicketCode}";
        printDoc.PrintPage += PrintDoc_PrintPage;

        using var preview = new PrintPreviewDialog
        {
            Document = printDoc,
            Width = 800,
            Height = 600,
            StartPosition = FormStartPosition.CenterParent
        };
        preview.ShowDialog(this);
    }

    private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (e.Graphics == null || _currentTicket == null || _currentInvoice == null) return;

        var g = e.Graphics;
        using var fontTitle = new Font("Segoe UI", 16F, FontStyle.Bold);
        using var fontSub = new Font("Segoe UI", 10F, FontStyle.Italic);
        using var fontBold = new Font("Segoe UI", 10F, FontStyle.Bold);
        using var fontNormal = new Font("Segoe UI", 10F, FontStyle.Regular);
        using var fontTotal = new Font("Segoe UI", 13F, FontStyle.Bold);

        float left = 60;
        float y = 50;
        float lineHeight = 26;

        // Tiêu đề biên lai
        g.DrawString("BÃI ĐỖ XE THÔNG MINH", fontTitle, Brushes.Black, left, y);
        y += 30;
        g.DrawString("HÓA ĐƠN THANH TOÁN PHÍ GỬI XE", fontBold, Brushes.Black, left, y);
        y += 22;
        g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fontSub, Brushes.DimGray, left, y);
        y += 25;
        g.DrawLine(Pens.Black, left, y, left + 450, y);
        y += 15;

        // Nội dung chi tiết
        TimeSpan dur = _currentInvoice.CheckOutTime - _currentInvoice.CheckInTime;
        string vType = _currentTicket.Vehicle?.VehicleType == VehicleType.Car ? "Ô tô" : "Xe máy";
        string payMethod = _currentInvoice.PaymentMethod == "Cash" ? "Tiền mặt" : "Chuyển khoản / Thẻ";
        string staff = _currentCreator?.FullName ?? $"ID {_currentInvoice.CreatedBy}";

        DrawRow(g, "Mã hóa đơn:", _currentInvoice.InvoiceId, fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Mã vé:", _currentTicket.TicketCode, fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Biển số xe:", _currentInvoice.LicensePlate, fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Loại xe:", $"{vType} ({(_currentTicket.IsMonthly ? "Vé tháng" : "Vé lượt")})", fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Thời gian vào:", _currentInvoice.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss"), fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Thời gian ra:", _currentInvoice.CheckOutTime.ToString("dd/MM/yyyy HH:mm:ss"), fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Tổng thời gian:", $"{(int)dur.TotalHours} giờ {dur.Minutes} phút", fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Hình thức TT:", payMethod, fontBold, fontNormal, left, ref y, lineHeight);
        DrawRow(g, "Nhân viên thu:", $"{staff} (Ca #{_currentInvoice.ShiftId})", fontBold, fontNormal, left, ref y, lineHeight);

        y += 10;
        g.DrawLine(Pens.Black, left, y, left + 450, y);
        y += 15;

        // Tổng tiền
        g.DrawString("TỔNG THANH TOÁN:", fontBold, Brushes.Black, left, y + 3);
        g.DrawString($"{_currentInvoice.TotalAmount:N0} VNĐ", fontTotal, Brushes.Black, left + 180, y);
        y += 45;

        g.DrawString("Cảm ơn quý khách và hẹn gặp lại!", fontSub, Brushes.DimGray, left + 90, y);
    }

    private static void DrawRow(Graphics g, string label, string value, Font fLabel, Font fVal, float x, ref float y, float step)
    {
        g.DrawString(label, fLabel, Brushes.Black, x, y);
        g.DrawString(value, fVal, Brushes.Black, x + 150, y);
        y += step;
    }

    private static string GetStatusText(TicketStatus status) => status switch
    {
        TicketStatus.Inparking => "Đang trong bãi",
        TicketStatus.CheckedOut => "Đã ra khỏi bãi",
        TicketStatus.Lost => "Thẻ bị mất (đã khóa)",
        _ => status.ToString()
    };

    private static string Dash(string? text) => string.IsNullOrWhiteSpace(text) ? "—" : text;
}
