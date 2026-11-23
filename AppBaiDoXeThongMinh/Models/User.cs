namespace AppBaiDoXeThongMinh.Models;
/*24130255 Trần Anh Quốc
lop quan ly nhan vien*/
public enum Role { Admin, Guard }
public class User
{
    // ma id user
    public int UserId { get; set; }
    // ten user dang nhap
    public string UserName { get; set; }
    // mat khau dang nhap
    public string PasswordHash { get; set; }
    // ten day dau user
    public string FullName { get; set; }
    // chuc vu
    public Role Role { get; set; }
    // con hoat dong hay khong
    public bool IsActive { get; set; }
}