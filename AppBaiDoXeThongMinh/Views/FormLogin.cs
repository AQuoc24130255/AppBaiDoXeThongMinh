
using System.Security.Cryptography;
using System.Text;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Views;

public partial class FormLogin : Form
{
    public FormLogin()
    {
        InitializeComponent();

        btnLogin.Click += BtnLogin_Click;

        chkShowPassword.CheckedChanged += (_, _) =>
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        };

        txtUsername.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        };

        txtPassword.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
                e.SuppressKeyPress = true;
            }
        };
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        Login();
    }

    private void Login()
    {
        lblMessage.Text = "";

        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            lblMessage.Text =
                "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
            return;
        }

        btnLogin.Enabled = false;

        try
        {
            using var db = new AppDbContext();

            var user = db.Users.SingleOrDefault(
                u => u.UserName == username);

            if (user == null)
            {
                lblMessage.Text =
                    "Tên đăng nhập hoặc mật khẩu không đúng.";
                return;
            }

            if (!user.IsActive)
            {
                lblMessage.Text =
                    "Tài khoản đã bị khóa hoặc ngừng hoạt động.";
                return;
            }

            // Băm mật khẩu bằng SHA256
            string enteredHash = Convert.ToHexString(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(password)));

            bool passwordCorrect = string.Equals(
                user.PasswordHash,
                enteredHash,
                StringComparison.OrdinalIgnoreCase);

            if (!passwordCorrect)
            {
                lblMessage.Text =
                    "Tên đăng nhập hoặc mật khẩu không đúng.";
                return;
            }

            Hide();

            using (var mainForm =
                   new global::AppBaiDoXeThongMinh.FormMain(user))
            {
                mainForm.ShowDialog(this);
            }

            txtPassword.Clear();
            Show();
            txtUsername.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể đăng nhập. Vui lòng kiểm tra database.\n\n"
                + ex.Message,
                "Lỗi đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }
}
