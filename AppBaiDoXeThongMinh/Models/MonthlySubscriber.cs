namespace AppBaiDoXeThongMinh.Models;
/* 24130288 Phan Tiến Thành */
public class MonthlySubscriber
{
    public string SubcriberId { get; set; }  //mã vé tháng
    public string FullName {  get; set; }  // họ tên khách hàng
    public string PhoneNumber { get; set; } //số điện thoại liên hệ 
    public string LicensePlate  { get; set; } //biển số xe đăng kí
    public string VehicleType { get; set; } //loại xe
    public DateTime StartDate { get; set; } //ngày đăng kí 
    public DateTime EndDate { get; set; } //ngày hết hạn 
    public bool IsActive { get; set; } // trạng thái thẻ
    public decimal MonthlyFee { get; set; } //phí đăng kí hàng tháng

    public MonthlySubscriber()
    {
        IsActive = true;
    }

    public MonthlySubscriber(string subcriberId, string fullName, string phoneNumber, string licensePlate, string vehicleType, DateTime startDate, DateTime endDate, bool isActive, decimal monthlyFee, int duration = 1)
    {
        SubcriberId = subcriberId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        LicensePlate = licensePlate;
        VehicleType = vehicleType;
        StartDate = DateTime.Now;
        EndDate = StartDate.AddMonths(duration);
        IsActive = true;
        MonthlyFee = monthlyFee;
    }
    //kiểm tra vé
    public bool IsVaid()
    {
        return IsActive && DateTime.Now <= EndDate;
    }
    
    //gia hạn vé 
    public void ExtendSubscription(int months)
    {
        if (DateTime.Now > EndDate)
        {
            StartDate = DateTime.Now;
            EndDate = StartDate.AddMonths(months);
        }
        else
        {
            EndDate = EndDate.AddMonths(months);
        }
        IsActive = true;
    }
    //tính số ngày còn lại của vé
    public int GetRemainingDays()
    {
        if (!IsVaid()) return 0;
        return (EndDate.Date - DateTime.Now.Date).Days;
    }
    //khóa hoặc vô hiệu vé 
    public void Deactivate()
    {
        IsActive = false;
    }
    //trả về chuỗi 
    public override string ToString()
    {
        string status = IsVaid() ? "còn hạn" : "Hết hạn / Khóa";
        return $"[Vé Tháng] Mã: {SubcriberId} | KH: {FullName} | SĐT: {PhoneNumber} | " +
               $"Biển số: {LicensePlate} ({VehicleType}) | Hạn: {StartDate:dd/MM/yyyy} - {EndDate:dd/NN/yyyy} | " +
               $"Trạng thái: {status} ({GetRemainingDays()} ngày còn lại)";
    }
}
