namespace AppBaiDoXeThongMinh.Models;

public enum TicketStatus
{
    Inparking,
    CheckedOut,
    Lost
}

public class Ticket
{
    // Mã vé gửi xe
    public int TicketId { get; set; }

    // Mã vé hiển thị
    public string TicketCode { get; set; } = string.Empty;

    // Mã phương tiện
    public int VehicleId { get; set; }

    // Mã vị trí đỗ xe
    public int? ParkingSlotId { get; set; }

    // Mã cấu hình giá
    public int PriceConfigId { get; set; }

    // Thời gian xe vào bãi
    public DateTime EntryTime { get; set; }

    // Thời gian xe ra bãi
    public DateTime? ExitTime { get; set; }

    // Tổng tiền gửi xe
    public decimal? TotalAmount { get; set; }

    // Trạng thái vé
    public TicketStatus Status { get; set; } = TicketStatus.Inparking;

    // Là vé xe tháng?
    public bool IsMonthly { get; set; }

    // Mã hóa đơn
    public string? InvoiceId { get; set; }

    // Liên kết đến phương tiện
    public virtual Vehicle Vehicle { get; set; } = null!;

    // Liên kết đến cấu hình giá
    public virtual PriceConfig PriceConfig { get; set; } = null!;

    // Liên kết đến vị trí đỗ xe
    public virtual ParkingSlot? ParkingSlot { get; set; }

    
}