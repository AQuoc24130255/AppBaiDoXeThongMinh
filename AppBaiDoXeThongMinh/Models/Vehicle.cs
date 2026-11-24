namespace AppBaiDoXeThongMinh.Models;

public enum VehicleType
{
    Motorbike,
    Car
}

public class Vehicle
{
    // Mã phương tiện
    public int VehicleId { get; set; }

    // Biển số xe
    public string LicensePlate { get; set; } = string.Empty;

    // Loại phương tiện
    public VehicleType VehicleType { get; set; }

    // Hãng xe
    public string? Brand { get; set; }

    // Màu xe
    public string? Color { get; set; }

    // Tên chủ xe
    public string? OwerName { get; set; }

    // Số điện thoại chủ xe
    public string? PhoneNumber { get; set; }

    // Danh sách vé gửi xe của phương tiện
    public virtual ICollection<Ticket> Ticket { get; set; }
        = new List<Ticket>();
}