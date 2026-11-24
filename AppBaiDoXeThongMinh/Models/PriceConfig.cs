using AppBaiDoXeThongMinh.database;

namespace AppBaiDoXeThongMinh.Models;
/*24130255 Trần Anh Quốc
lop cau hinh bieu phi do xe*/
public class PriceConfig
{
    // id cau hinh gia cho loai xe
    public int ConfigId { get; set; }
    // ten loai xe
    public VehicleType VehicleType { get; set; }
    // gia tien ban ngay
    public decimal DayPrice { get; set; }
    // gia tien ban dem
    public decimal NightPrice { get; set; }
    // thoi gian tinh phi block dau tien
    public int TimeUnit { get; set; }
    // thoi gian ban dem bat dau
    public TimeSpan NightStart { get; set; }
    // thoi gian ban dem ket thuc
    public TimeSpan NightEnd { get; set; }
    // phi mat ve
    public decimal LostTicketFee { get; set; }
    public static PriceConfig SetPrice(
        int configId,
        VehicleType? vehicleType = null,
        decimal? dayPrice = null,
        decimal? nightPrice = null,
        int? timeUnit = null,
        TimeSpan? nightStart = null,
        TimeSpan? nightEnd = null,
        decimal? lostTicketFee = null)
    {
        // Kiểm tra tham số (chỉ kiểm tra các giá trị được truyền vào)
        if (configId <= 0)
            throw new ArgumentException("ConfigId là bắt buộc và phải lớn hơn 0.");
        if (dayPrice < 0 || nightPrice < 0 || lostTicketFee < 0)
            throw new ArgumentException("Giá tiền không được âm.");
        if (timeUnit <= 0)
            throw new ArgumentException("Block tính phí (TimeUnit) phải lớn hơn 0 phút.");
        if (!IsValidTimeOfDay(nightStart) || !IsValidTimeOfDay(nightEnd))
            throw new ArgumentException("Giờ bắt đầu/kết thúc ban đêm phải nằm trong khoảng 00:00 – 23:59.");

        using var db = new AppDbContext();

        var config = db.PriceConfigs.FirstOrDefault(p => p.ConfigId == configId);
        

        // Mỗi loại xe chỉ có một cấu hình giá
        bool typeChanges = vehicleType.HasValue && vehicleType.Value != config.VehicleType;
        VehicleType finalType = vehicleType ?? config.VehicleType;
        if (typeChanges && db.PriceConfigs.Any(p => p.ConfigId != configId && p.VehicleType == finalType))
            throw new InvalidOperationException(
                $"Loại xe \"{finalType}\" đã có một cấu hình giá khác.");

        // --- Chỉ ghi đè các giá trị được truyền vào ---
        if (vehicleType.HasValue) config.VehicleType = vehicleType.Value;
        if (dayPrice.HasValue) config.DayPrice = dayPrice.Value;
        if (nightPrice.HasValue) config.NightPrice = nightPrice.Value;
        if (timeUnit.HasValue) config.TimeUnit = timeUnit.Value;
        if (nightStart.HasValue) config.NightStart = nightStart.Value;
        if (nightEnd.HasValue) config.NightEnd = nightEnd.Value;
        if (lostTicketFee.HasValue) config.LostTicketFee = lostTicketFee.Value;

        db.SaveChanges();
        return config;
    }

    private static bool IsValidTimeOfDay(TimeSpan? t) =>
        t == null || (t.Value >= TimeSpan.Zero && t.Value < TimeSpan.FromDays(1));
}