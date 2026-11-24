
namespace AppBaiDoXeThongMinh;

partial class FormMain
{
    private System.ComponentModel.IContainer? components = null;

    private Panel pnlSidebar = null!;
    private Panel pnlTopBar = null!;
    private Panel pnlContent = null!;
    private Panel pnlMenu = null!;
    private Panel pnlUser = null!;

    private Button btnToggleMenu = null!;
    private Button btnLogout = null!;

    private Label lblBrand = null!;
    private Label lblUserName = null!;
    private Label lblUserRole = null!;
    private Label lblPageTitle = null!;
    private Label lblDate = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        pnlTopBar = new Panel();
        pnlContent = new Panel();
        pnlMenu = new Panel();
        pnlUser = new Panel();

        btnToggleMenu = new Button();
        btnLogout = new Button();

        lblBrand = new Label();
        lblUserName = new Label();
        lblUserRole = new Label();
        lblPageTitle = new Label();
        lblDate = new Label();

        SuspendLayout();

        // Form chính
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Bãi đỗ xe thông minh";
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1050, 650);
        BackColor = Color.FromArgb(243, 246, 250);
        Font = new Font("Segoe UI", 10F);

        // Sidebar
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Width = 245;
        pnlSidebar.BackColor = Color.FromArgb(22, 48, 75);

        // Nút thu gọn
        btnToggleMenu.Text = "☰";
        btnToggleMenu.Dock = DockStyle.Top;
        btnToggleMenu.Height = 48;
        btnToggleMenu.FlatStyle = FlatStyle.Flat;
        btnToggleMenu.FlatAppearance.BorderSize = 0;
        btnToggleMenu.BackColor = Color.FromArgb(30, 62, 91);
        btnToggleMenu.ForeColor = Color.White;
        btnToggleMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        btnToggleMenu.Cursor = Cursors.Hand;

        // Tên hệ thống
        lblBrand.Text = "SMART PARKING";
        lblBrand.Dock = DockStyle.Top;
        lblBrand.Height = 75;
        lblBrand.TextAlign = ContentAlignment.MiddleCenter;
        lblBrand.ForeColor = Color.White;
        lblBrand.Font = new Font("Segoe UI", 15F, FontStyle.Bold);

        // Menu
        pnlMenu.Dock = DockStyle.Fill;
        pnlMenu.BackColor = pnlSidebar.BackColor;
        pnlMenu.AutoScroll = true;
        pnlMenu.Padding = new Padding(8, 12, 8, 8);

        // Thông tin tài khoản
        pnlUser.Dock = DockStyle.Bottom;
        pnlUser.Height = 112;
        pnlUser.BackColor = Color.FromArgb(30, 62, 91);

        lblUserName.Dock = DockStyle.Top;
        lblUserName.Height = 34;
        lblUserName.Padding = new Padding(14, 7, 5, 0);
        lblUserName.ForeColor = Color.White;
        lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUserName.AutoEllipsis = true;

        lblUserRole.Dock = DockStyle.Top;
        lblUserRole.Height = 28;
        lblUserRole.Padding = new Padding(14, 3, 5, 0);
        lblUserRole.ForeColor = Color.LightSkyBlue;

        // Nút đăng xuất
        btnLogout.Text = "Đăng xuất";
        btnLogout.Dock = DockStyle.Bottom;
        btnLogout.Height = 42;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.BackColor = Color.FromArgb(160, 55, 55);
        btnLogout.ForeColor = Color.White;
        btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnLogout.Cursor = Cursors.Hand;

        // Thanh tiêu đề
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Height = 68;
        pnlTopBar.BackColor = Color.White;

        lblPageTitle.Text = "TỔNG QUAN";
        lblPageTitle.Dock = DockStyle.Left;
        lblPageTitle.Width = 500;
        lblPageTitle.Padding = new Padding(25, 0, 0, 0);
        lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblPageTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblPageTitle.ForeColor = Color.FromArgb(25, 65, 105);

        lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        lblDate.Dock = DockStyle.Right;
        lblDate.Width = 150;
        lblDate.TextAlign = ContentAlignment.MiddleCenter;
        lblDate.ForeColor = Color.DimGray;

        // Vùng nội dung
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Padding = new Padding(18);
        pnlContent.BackColor = Color.FromArgb(243, 246, 250);

        // Ghép giao diện
        pnlUser.Controls.Add(lblUserName);
        pnlUser.Controls.Add(lblUserRole);
        pnlUser.Controls.Add(btnLogout);

        pnlSidebar.Controls.Add(pnlMenu);
        pnlSidebar.Controls.Add(pnlUser);
        pnlSidebar.Controls.Add(lblBrand);
        pnlSidebar.Controls.Add(btnToggleMenu);

        pnlTopBar.Controls.Add(lblPageTitle);
        pnlTopBar.Controls.Add(lblDate);

        Controls.Add(pnlContent);
        Controls.Add(pnlTopBar);
        Controls.Add(pnlSidebar);

        ResumeLayout(false);
    }
}
