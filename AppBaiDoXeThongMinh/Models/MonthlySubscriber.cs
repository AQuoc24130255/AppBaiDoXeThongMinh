namespace AppBaiDoXeThongMinh.Models;

public class MonthlySubscriber
{
    public string SubcriberId { get; set; }
    public string FullName {  get; set; }
    public string PhoneNumber { get; set; }
    public string LicensePlate  { get; set; }
    public string LicensePlateNumber { get; set; }
    public string VehicleType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public decimal MonthlyFee { get; set; }
}
