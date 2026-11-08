namespace AppBaiDoXeThongMinh.Models;
/*24130255 Trần Anh Quốc
lop quan ly ca truc*/
public class Shift
{
    // ma ca truc
    public int ShiftId { get; set; }
    // ma nguoi truc
    public int UserId { get; set; }
    // thoi gian bat dau
    public DateTime StartDate { get; set; }
    // thoi gian ket thuc
    public DateTime EndDate { get; set; }
}