using System.Security.Cryptography;
using System.Text;
using AppBaiDoXeThongMinh.database;
using AppBaiDoXeThongMinh.Models;

namespace AppBaiDoXeThongMinh.Views;

/// <summary>
/// Màn hình đăng nhập. Giao diện được tạo hoàn toàn bằng code,
/// không phụ thuộc các control trong Designer.
/// </summary>
public partial class FormLogin : Form
{
    private readonly TextBox _txtUsername = new();
    private readonly TextBox _txtPassword = new();
    private readonly CheckBox _chkShowPassword = new();
    private readonly Label _lblMessage = new();
    private readonly Button _btnLogin = new();

    public FormLogin()
    {
        InitializeComponent();
        BuildInterface();
        AcceptButton = _btnLogin;
    }

    private void BuildInterface()
    {
        Text = "Bãi đỗ xe thông minh - Đăng nhập";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(520, 430);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BackColor = Color.FromArgb(245, 247, 250);
        Font = new Font("Segoe UI", 10F);

        var panel = new Panel
        {
            Size = new Size(390, 340),
            Location = new Point(65, 42),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        Controls.Add(panel);

        var title = new Label
        {
            Text = "BÃI ĐỖ XE THÔNG MINH",
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            ForeColor = Color.FromArgb(25, 65, 105),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(25, 25),
            Size = new Size(338, 38)
        };
        panel.Controls.Add(title);

        var subtitle = new Label
        {
            Text = "Đăng nhập hệ thống quản lý",
            ForeColor = Color.Gray,
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(25, 65),
            Size = new Size(338, 25)
        };
        panel.Controls.Add(subtitle);

        AddLabel(panel, "Tên đăng nhập", 35, 112);
        _txtUsername.SetBounds(35, 137, 320, 34);
        _txtUsername.Font = new Font("Segoe UI", 11F);
        _txtUsername.PlaceholderText = "Nhập tên đăng nhập";
        panel.Controls.Add(_txtUsername);

        AddLabel(panel, "Mật khẩu", 35, 185);
        _txtPassword.SetBounds(35, 210, 320, 34);
        _txtPassword.Font = new Font("Segoe UI", 11F);
        _txtPassword.UseSystemPasswordChar = true;
        _txtPassword.PlaceholderText = "Nhập mật khẩu";
        panel.Controls.Add(_txtPassword);

        _chkShowPassword.Text = "Hiển thị mật khẩu";
        _chkShowPassword.SetBounds(35, 250, 180, 25);
        _chkShowPassword.CheckedChanged += (_, _) =>
            _txtPassword.UseSystemPasswordChar = !_chkShowPassword.Checked;
        panel.Controls.Add(_chkShowPassword);

        _btnLogin.Text = "ĐĂNG NHẬP";
        _btnLogin.SetBounds(35, 283, 320, 40);
        _btnLogin.BackColor = Color.FromArgb(25, 105, 170);
        _btnLogin.ForeColor = Color.White;
        _btnLogin.FlatStyle = FlatStyle.Flat;
        _btnLogin.FlatAppearance.BorderSize = 0;
        _btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnLogin.Click += BtnLogin_Click;
        panel.Controls.Add(_btnLogin);

        _lblMessage.SetBounds(35, 326, 320, 25);
        _lblMessage.ForeColor = Color.Firebrick;
        _lblMessage.TextAlign = ContentAlignment.MiddleCenter;
        panel.Controls.Add(_lblMessage);

        _txtUsername.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; _txtPassword.Focus(); }
        };
        _txtPassword.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnLogin_Click(this, EventArgs.Empty); }
        };
    }

    private static void AddLabel(Control parent, string text, int x, int y)
    {
        parent.Controls.Add(new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(55, 65, 81)
        });
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        _lblMessage.Text = "";
        string username = _txtUsername.Text.Trim();
        string password = _txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
        {
            _lblMessage.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
            return;
        }

        _btnLogin.Enabled = false;
        try
        {
            using var db = new AppDbContext();
            var user = db.Users.SingleOrDefault(u => u.UserName == username);

            if (user == null)
            {
                _lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return;
            }

            if (!user.IsActive)
            {
                _lblMessage.Text = "Tài khoản đã bị khóa hoặc ngừng hoạt động.";
                return;
            }

            // Dữ liệu mẫu trong database hiện tại dùng SHA-256 dạng chuỗi hex.
            // Không thay đổi PasswordHash trong database tại bước đăng nhập.
            string enteredHash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(password)));

            bool passwordCorrect = string.Equals(
                user.PasswordHash, enteredHash, StringComparison.OrdinalIgnoreCase);

            if (!passwordCorrect)
            {
                _lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return;
            }

            Hide();
            using (var main = new global::AppBaiDoXeThongMinh.FormMain(user))
            {
                main.ShowDialog(this);
            }
            _txtPassword.Clear();
            Show();
            _txtUsername.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể đăng nhập. Vui lòng kiểm tra database.\n\nChi tiết: " + ex.Message,
                "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _btnLogin.Enabled = true;
        }
    }
}
