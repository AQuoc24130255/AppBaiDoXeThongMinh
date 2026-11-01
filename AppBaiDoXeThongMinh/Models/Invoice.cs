namespace AppBaiDoXeThongMinh.Models;

public class Invoice
{
    public string InvoiceId  { get; set; } = Guid.NewGuid().ToString();
    public string TicketId   { get; set; } 
    public string LicensePlate   { get; set; }
    public DateTime CheckInTime   { get; set; }
    public DateTime CheckOutTime  { get; set; }
    public decimal TotalAmounnt { get; set; }
    public string PaymantMethod  { get; set; }
    public DateTime PaymantDate  { get; set; }
    public string CreatedBy  { get; set; }
    public bool IsPaid { get; set; } = true;
}
}
