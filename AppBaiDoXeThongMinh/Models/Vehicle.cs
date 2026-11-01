namespace AppBaiDoXeThongMinh.Models;
/*24130216 Võ Thành Nhân
lop quan li phuong tien*/

public class Vehicle
{
    // Mã Phương Tiện
    public int VehicleId { get; set; }

    // Biển số xe
    public string LicensePlate { get; set; }

    // Loại phương tiện
    public string VehicleType { get; set; }

    // hãng xe
    public string Brand { get; set; }

    // màu xe
    public string Color { get; set; }

    // Tên chủ xe
    public string OwerName { get; set; }

    // Số điện thoại chủ xe
    public string PhoneNumber { get; set; }

    // Danh sách vé gửi xe của phương tiện
    public virtual ICollection<Ticket> Ticket { get; set; }
    
    
}
