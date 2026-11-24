
namespace AppBaiDoXeThongMinh.Views;

partial class FormLogin
{
    private System.ComponentModel.IContainer? components = null;

    private Panel pnlLogin = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblUsername = null!;
    private Label lblPassword = null!;
    private TextBox txtUsername = null!;
    private TextBox txtPassword = null!;
    private CheckBox chkShowPassword = null!;
    private Button btnLogin = null!;
    private Label lblMessage = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlLogin = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblUsername = new Label();
        lblPassword = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        chkShowPassword = new CheckBox();
        btnLogin = new Button();
        lblMessage = new Label();

        SuspendLayout();

        // Form
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Bãi đỗ xe thông minh - Đăng nhập";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(520, 460);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BackColor = Color.FromArgb(243, 246, 250);
        Font = new Font("Segoe UI", 10F);

        // Panel đăng nhập
        pnlLogin.Size = new Size(390, 370);
        pnlLogin.Location = new Point(65, 40);
        pnlLogin.BackColor = Color.White;
        pnlLogin.BorderStyle = BorderStyle.FixedSingle;

        // Tiêu đề
        lblTitle.Text = "BÃI ĐỖ XE THÔNG MINH";
        lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(25, 65, 105);
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblTitle.Location = new Point(20, 25);
        lblTitle.Size = new Size(348, 40);

        // Phụ đề
        lblSubtitle.Text = "Đăng nhập hệ thống quản lý";
        lblSubtitle.ForeColor = Color.Gray;
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        lblSubtitle.Location = new Point(20, 68);
        lblSubtitle.Size = new Size(348, 28);

        // Nhãn tài khoản
        lblUsername.Text = "Tên đăng nhập";
        lblUsername.Location = new Point(35, 115);
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

        // Ô tài khoản
        txtUsername.Location = new Point(35, 140);
        txtUsername.Size = new Size(320, 32);
        txtUsername.Font = new Font("Segoe UI", 11F);
        txtUsername.PlaceholderText = "Nhập tên đăng nhập";

        // Nhãn mật khẩu
        lblPassword.Text = "Mật khẩu";
        lblPassword.Location = new Point(35, 190);
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

        // Ô mật khẩu
        txtPassword.Location = new Point(35, 215);
        txtPassword.Size = new Size(320, 32);
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.PlaceholderText = "Nhập mật khẩu";
        txtPassword.UseSystemPasswordChar = true;

        // Hiện mật khẩu
        chkShowPassword.Text = "Hiển thị mật khẩu";
        chkShowPassword.Location = new Point(35, 255);
        chkShowPassword.Size = new Size(180, 28);

        // Nút đăng nhập
        btnLogin.Text = "ĐĂNG NHẬP";
        btnLogin.Location = new Point(35, 295);
        btnLogin.Size = new Size(320, 42);
        btnLogin.BackColor = Color.FromArgb(25, 105, 170);
        btnLogin.ForeColor = Color.White;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogin.Cursor = Cursors.Hand;

        // Thông báo lỗi
        lblMessage.Location = new Point(25, 340);
        lblMessage.Size = new Size(340, 25);
        lblMessage.ForeColor = Color.Firebrick;
        lblMessage.TextAlign = ContentAlignment.MiddleCenter;
        lblMessage.AutoEllipsis = true;

        // Thêm control vào Panel
        pnlLogin.Controls.Add(lblTitle);
        pnlLogin.Controls.Add(lblSubtitle);
        pnlLogin.Controls.Add(lblUsername);
        pnlLogin.Controls.Add(txtUsername);
        pnlLogin.Controls.Add(lblPassword);
        pnlLogin.Controls.Add(txtPassword);
        pnlLogin.Controls.Add(chkShowPassword);
        pnlLogin.Controls.Add(btnLogin);
        pnlLogin.Controls.Add(lblMessage);

        Controls.Add(pnlLogin);

        AcceptButton = btnLogin;

        ResumeLayout(false);
    }
}
