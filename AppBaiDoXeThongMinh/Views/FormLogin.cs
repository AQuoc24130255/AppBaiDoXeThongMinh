namespace AppBaiDoXeThongMinh.Views;


using System;
using System.Windows.Forms;

namespace AppBaiDoXeThongMinh.Views;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    // Xử lý đăng nhập
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (username == "" || password == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        }
        else if (username == "admin" && password == "123456")
        {
            MessageBox.Show("Đăng nhập thành công!");
        }
        else
        {
            MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
        }
    }

    // Hiện hoặc ẩn mật khẩu
    private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }

    // Thoát chương trình
    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
