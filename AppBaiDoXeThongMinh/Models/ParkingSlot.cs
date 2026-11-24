namespace AppBaiDoXeThongMinh.Models;
/*24130255 Trần Anh Quốc
lop quan ly vi tri do xe*/

public class ParkingSlot
{
    // so id
    public int SlotId { get; set; }
    // ten
    public string SlotName { get; set; }
    // khu vuc
    public string Zone { get; set; }
    // trang thai do, co xe la true, khong la false
    public bool IsOccupied { get; set; } = false;
    // loai xe duoc cho phep do
    public VehicleType AllowedVehicleType { get; set; }
    // id xe dang do, khong neu trong
    public int? CurrentVehicleID { get; set; }
}