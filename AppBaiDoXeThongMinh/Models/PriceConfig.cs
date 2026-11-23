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
    
}