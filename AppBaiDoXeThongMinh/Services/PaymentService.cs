using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Services;

public class PaymentService
{
    //Giả lập cơ sở dữ liệu
    private static readonly List<Invoice> Invoices = new();
    private static readonly List<MonthlySubscriber> Subcribers = new();


    #region --- QUẢN LÝ HÓA ĐƠN ---
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
    #endregion

    #region --- QUẢN LÝ VÉ THÁNG ---

    ///Đăng ký vé tháng mới
    public bool RegsisterSubscribber(MonthlySubscriber subscriber)
    {
        if (subscriber== null || string.IsNullOrEmpty(subscriber.LicensePlate)) return  false;
        
        var existing = Subcribers.FirstOrDefault(s => s.LicensePlate.Equals(subscriber.LicensePlate, StringComparison.OrdinalIgnoreCase) && s.IsActive);
        if (existing != null)
        {
            return false;
        }
        Subcribers.Add(subscriber);
        return  true;
    }

    ///gia hạn vé tháng và tự động tạo hóa dơn
    public Invoice? RenewSubcription(string subcriberId, int months, string paymentMethod, string staffName)
    {
        var subscriber = Subcribers.FirstOrDefault(s => s.SubcriberId == subcriberId);
        if (subscriber == null) return null;
        
        subscriber.ExtendSubscription(months);
        decimal totalFee = subscriber.MonthlyFee * months;
        var invoice = CreateInvoice(
            ticketId: $"SUB-{subscriber.SubcriberId}",
            licensePlate: subscriber.LicensePlate,
            checkIn: DateTime.Now,
            checkOut: DateTime.Now,
            amount: totalFee,
            paymentMethod: paymentMethod,
            createdBy: staffName
        );
        return invoice;
    }

    /// kiểm tra biển số xem có vé tháng hợp lệ
    public MonthlySubscriber? GetValidSubscriberByLicensePlate(string licensePlate)
    {
        return Subcribers.FirstOrDefault(s  => s.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase) && s.IsActive && s.EndDate >= DateTime.Now);
    }

    ///lấy danh sách vé tháng còn hiệu lực
    public List<MonthlySubscriber> GeActiveSubscribers()
    {
        return Subcribers.Where(s => s.IsVaid()).ToList();
    }

    ///tìm kiếm vé tháng theo tên khách hàng mã vé hoặc biển số xe
    public List<MonthlySubscriber> SearchSubscribers(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return Subcribers;

        return Subcribers.Where(s => s.SubcriberId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     s.LicensePlate.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     s.PhoneNumber.Contains(keyword)).ToList();


    }

    #endregion
  
}