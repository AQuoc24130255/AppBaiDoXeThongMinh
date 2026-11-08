namespace AppBaiDoXeThongMinh.Models;
/* 24130288 Phan Tiến Thành */

public class MonthlySubscriber
{
    public int SubcriberId { get; set; }  //mã vé tháng
    public string FullName {  get; set; }  // họ tên khách hàng
    public string PhoneNumber { get; set; } //số điện thoại liên hệ 
    public string LicensePlate  { get; set; } //biển số xe đăng kí
    public VehicleType VehicleType { get; set; } //loại xe
    public DateTime StartDate { get; set; } //ngày đăng kí 
    public DateTime EndDate { get; set; } //ngày hết hạn 
    public bool IsActive { get; set; } // trạng thái thẻ
    public decimal MonthlyFee { get; set; } //phí đăng kí hàng tháng
}
