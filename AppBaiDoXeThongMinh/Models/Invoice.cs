namespace AppBaiDoXeThongMinh.Models;
/*24130288 Phan Tiền Thành*/
public class Invoice
{
    public string InvoiceId { get; set; } = Guid.NewGuid().ToString(); //mã hóa đơn 
    public string TicketId   { get; set; }  //mã vé liên quan (Nếu có)
    public string LicensePlate   { get; set; } //biển số xe 
    public DateTime CheckInTime   { get; set; } // thời gian vào 
    public DateTime CheckOutTime  { get; set; } // thời gian ra 
    public decimal TotalAmount { get; set; } // tổng tiền thanh toán 
    public string PaymantMethod  { get; set; } // tiền mặt / chuyẻn khoản
    public DateTime PaymentDate  { get; set; } // thời điểm thành toán 
    public string CreatedBy  { get; set; } //nhân viên/Admin thực hiện
    public bool IsPaid { get; set; } = true; //trạng thái thanh toán 

    public Invoice()
    {
        PaymentDate = DateTime.Now;
    }

    public Invoice(string ticketId, string licensePlate, DateTime checkInTime, DateTime checkOutTime, decimal totalAmount, string paymantMethod, DateTime paymentDate, string createdBy, bool isPaid)
    {
        TicketId = ticketId;
        LicensePlate = licensePlate;
        CheckInTime = checkInTime;
        CheckOutTime = checkOutTime;
        TotalAmount = totalAmount;
        PaymantMethod = paymantMethod;
        PaymentDate = paymentDate;
        CreatedBy = createdBy;
        IsPaid = isPaid;
    }
    //tính tổng thời gian xe gửi
    public TimeSpan CulculateParkingDuration()
    {
        if (CheckOutTime < CheckInTime) return TimeSpan.Zero;
        return (CheckInTime - CheckOutTime).Duration();
      
    }
    
    //xử lý cập nhật trạng thái thanh toán 
    public void ProcessPayment(string paymentMethod, string createdBy, decimal amount)
    {
        PaymantMethod = paymentMethod;
        CreatedBy = createdBy;
        TotalAmount =  amount;
        PaymentDate = DateTime.Now;
        IsPaid = true;
    }
    //trả về chuỗi thông tin chi tiết
    public override string ToString()
    {
        var duration = CulculateParkingDuration();
        return $"[Hóa Đơn] Mã Hóa Đơn: {InvoiceId} | vé: {TicketId} | Biển số: {LicensePlate}  | " +
               $"vào: {CheckInTime:dd/MM/yyyy HH:mm} | Ra: {CheckOutTime:dd/MM/yyyy HH:mm} | " +
               $"Thời gian: {duration.Hours}h {duration.Minutes}m | Tổng tiền: {TotalAmount:N0} VNĐ | " +
               $"HTTT: {PaymantMethod} | Người lập: {CreatedBy}";
    }
   
}

