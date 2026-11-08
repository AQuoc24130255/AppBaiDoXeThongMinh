using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Services;

public class PaymentService
{
    //Giả lập cơ sở dữ liệu
    private static readonly List<Invoice> Invoices = new();
    private static readonly List<MonthlySubscriber> Subcribers = new();
    
    
    
    /// tính tiền gửi xe theo thời gian
    public decimal CalculateParkingFee(DateTime checkInTime, DateTime checkOutTime, PriceConfig config)
    {
        if (checkInTime <= checkOutTime || config == null) return 0;
        TimeSpan duration = checkOutTime - checkInTime;
        double totalHours = Math.Ceiling(duration.TotalHours);
        decimal totalAmount = config.Price;
        if (totalHours > 1)
        {
            decimal extraHours = (decimal)(totalHours - 1);
            totalAmount += extraHours * config.OverTimePricePerHour;
        }
        return totalAmount;
    }

    /// tọa và lưu hóa đơn
    public Invoice CreateInvoice(string ticketId, string licensePlate, DateTime checkIn, DateTime checkOut,
        decimal amount, string paymentMethod, string createdBy)
    {
        var invoice = new Invoice
        {
            InvoiceId = Guid.NewGuid().ToString(),
            TicketId = ticketId,
            LicensePlate = licensePlate,
            CheckInTime = checkIn,
            CheckOutTime = checkOut,
            TotalAmount = amount,
            PaymentMethod = paymentMethod,
            PaymentDate = DateTime.Now,
            CreatedBy = createdBy,
            IsPaid = true
        };
        Invoices.Add(invoice);
        return invoice;
        
    }

    /// tra cứu hóa đơn theo mã
    public Invoice? GetInvoice(string invoiceId)
    {
        return  Invoices.FirstOrDefault(i => i.InvoiceId.Equals(invoiceId, StringComparison.OrdinalIgnoreCase));
    }

    /// lấy danh sách hóa đơn theo khoảng thời gian 
    public List<Invoice> GetInvoicesByDate(DateTime formDate, DateTime toDate)
    {
        return Invoices.Where(i => i.PaymentDate >= formDate && i.PaymentDate <= toDate).ToList();
    }
    /// lấy toàn bộ hóa đơn
    public List<Invoice> GetAllInvoices() => Invoices;
  
}