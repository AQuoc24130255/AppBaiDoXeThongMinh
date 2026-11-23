namespace AppBaiDoXeThongMinh.Models;
/*24130216 Võ Thành Nhân
lop quan li ve*/
public enum TicketStatus { Inparking, CheckedOut, Lost}
public class Ticket
{
    // Mã vé gửi xe
    public int TicketId { get; set; }

    // Mã vé hiển thị
    public string TicketCode {get; set; }

    // Mã phương tiện
    public int VehicleId { get; set; }

    // Mã ví trí đỗ xe
    public int ParkingSlotId { get; set; }

    // Mã cấu hình giá
    public int PriceConfigId { get; set; }

    // Thời gian xe vào bãi
    public DateTime EntryTime { get; set; }

    // Thời gian xe ra bãi 
    public DateTime? ExitTime {get; set; }

    // Tổng tiền gửi xe
    public decimal? TotalAmount { get; set; }

    // Trạng thái vé
    public TicketStatus Status { get; set; }
    
    // Là vé xe tháng?
    public bool IsMonthly { get; set; }
    
    // Mã hóa đơn
    public string? InvoiceId { get; set; }
    
    // Liên kết đến phương tiện
    public virtual Vehicle Vehicle { get; set; }

    // Liên kết đến cấu hình giá
    public virtual PriceConfig PriceConfig { get; set; }

    // Liên kết đến vị trí đỗ xe 
    public virtual ParkingSlot ParkingSlot { get; set; }
    
}
