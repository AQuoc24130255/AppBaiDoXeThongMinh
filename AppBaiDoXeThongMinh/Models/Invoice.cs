namespace AppBaiDoXeThongMinh.Models;
/*24130288 Phan Tiền Thành*/
public class Invoice
{
    public string InvoiceId { get; set; } = Guid.NewGuid().ToString(); //mã hóa đơn 
    public string TicketId   { get; set; }  //mã vé liên quan (Nếu có)
    public string LicensePlate   { get; set; } //biển số xe 
    public DateTime CheckInTime   { get; set; } // thời gian vào 
    public DateTime CheckOutTime  { get; set; } // thời gian ra 
    public decimal TotalAmounnt { get; set; } // tổng tiền thanh toán 
    public string PaymantMethod  { get; set; } // tiền mặt / chuyẻn khoản
    public DateTime PaymantDate  { get; set; } // thời điểm thành toán 
    public string CreatedBy  { get; set; } //nhân viên/Admin thực hiện
    public bool IsPaid { get; set; } = true; //trạng thái thanh toán 
}

