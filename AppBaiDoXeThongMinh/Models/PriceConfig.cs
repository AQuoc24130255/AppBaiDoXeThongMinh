namespace AppBaiDoXeThongMinh.Models;
/*24130255 Trần Anh Quốc
lop cau hinh bieu phi do xe*/
public class PriceConfig
{
    // id cau hinh gia cho loai xe
    public string ConfigId { get; set; }
    // ten loai xe
    public string VehicleType { get; set; }
    // gia tien co ban
    public decimal Price { get; set; }
    // thoi gian tinh phi block dau tien
    public string TimeUnit { get; set; }
    // gia tien cong them cho moi block tiep theo
    public decimal OverTimePricePerHour { get; set; }
    
}