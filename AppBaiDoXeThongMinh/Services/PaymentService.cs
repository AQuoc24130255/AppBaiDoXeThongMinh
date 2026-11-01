using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Services;

public class PaymentService
{
    /// tính tiền gửi xe
    public decimal CalculateFee(DateTime CheckIn, DateTime CheckOut, PriceConfig priceConfig)
    {
        TimeSpan duration = CheckOut - CheckIn;
        double hours = Math.Ceiling(duration.TotalHours);

        decimal hourlyRate = priceConfig != null ? priceConfig.Price : 10000;
        return (decimal)hours * hourlyRate;

    }
}