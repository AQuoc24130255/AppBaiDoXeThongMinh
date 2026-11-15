using AppBaiDoXeThongMinh.Models;
using AppBaiDoXeThongMinh.Views;

namespace AppBaiDoXeThongMinh;

/// <summary>
/// Màn hình điều khiển chính sau khi đăng nhập.
/// </summary>
public partial class FormMain : Form
{
    private readonly User _currentUser;
    private readonly Panel _contentPanel = new();
    private readonly Label _lblPageTitle = new();

    public FormMain(User user)
    {
        _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        InitializeComponent();
        BuildInterface();
        OpenChildForm(new FormDashboard(), "TỔNG QUAN");
    }

    private void BuildInterface()
    {
        Text = "Bãi đỗ xe thông minh - Hệ thống quản lý";
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1050, 650);
        BackColor = Color.FromArgb(243, 246, 250);
        Font = new Font("Segoe UI", 10F);

        var sidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 245,
            BackColor = Color.FromArgb(22, 48, 75)
        };
        Controls.Add(sidebar);

        var brand = new Label
        {
            Text = "SMART PARKING",
            Dock = DockStyle.Top,
            Height = 85,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold)
        };
        sidebar.Controls.Add(brand);

        var menu = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(12, 12, 12, 0),
            BackColor = sidebar.BackColor
        };
        sidebar.Controls.Add(menu);

        AddMenuButton(menu, "Tổng quan", () => OpenChildForm(new FormDashboard(), "TỔNG QUAN"));
        AddMenuButton(menu, "Xe vào bãi", () => OpenChildForm(new FormCheckIn(), "TIẾP NHẬN XE VÀO"));
        AddMenuButton(menu, "Xe ra bãi", () => OpenChildForm(new FormCheckOut(), "XỬ LÝ XE RA"));
        AddMenuButton(menu, "Tra cứu", () => OpenChildForm(new FormSearch(), "TRA CỨU THÔNG TIN"));

        if (_currentUser.Role == Role.Admin)
        {
            AddMenuButton(menu, "Kiểm tra dữ liệu", () =>
                OpenChildForm(new TestDatabase(), "KIỂM TRA DỮ LIỆU"));
        }

        var logout = new Button
        {
            Text = "Đăng xuất",
            Dock = DockStyle.Bottom,
            Height = 48,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(160, 55, 55),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold)
        };
        logout.FlatAppearance.BorderSize = 0;
        logout.Click += (_, _) =>
        {
            var answer = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes) Close();
        };
        sidebar.Controls.Add(logout);

        var userPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 82,
            BackColor = Color.FromArgb(30, 62, 91)
        };
        sidebar.Controls.Add(userPanel);

        userPanel.Controls.Add(new Label
        {
            Text = _currentUser.FullName,
            Dock = DockStyle.Top,
            Height = 35,
            Padding = new Padding(15, 8, 5, 0),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold)
        });
        userPanel.Controls.Add(new Label
        {
            Text = _currentUser.Role == Role.Admin ? "Quản trị viên" : "Nhân viên bảo vệ",
            Dock = DockStyle.Top,
            Height = 30,
            Padding = new Padding(15, 3, 5, 0),
            ForeColor = Color.LightSkyBlue
        });

        var topBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 68,
            BackColor = Color.White
        };
        Controls.Add(topBar);

        _lblPageTitle.Text = "TỔNG QUAN";
        _lblPageTitle.Dock = DockStyle.Left;
        _lblPageTitle.Width = 500;
        _lblPageTitle.Padding = new Padding(25, 0, 0, 0);
        _lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
        _lblPageTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        _lblPageTitle.ForeColor = Color.FromArgb(25, 65, 105);
        topBar.Controls.Add(_lblPageTitle);

        var lblDate = new Label
        {
            Text = DateTime.Now.ToString("dd/MM/yyyy"),
            Dock = DockStyle.Right,
            Width = 150,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DimGray
        };
        topBar.Controls.Add(lblDate);

        _contentPanel.Dock = DockStyle.Fill;
        _contentPanel.Padding = new Padding(18);
        _contentPanel.BackColor = Color.FromArgb(243, 246, 250);
        Controls.Add(_contentPanel);
        _contentPanel.BringToFront();
        topBar.BringToFront();
        sidebar.BringToFront();
    }

    private static void AddMenuButton(Control parent, string text, Action action)
    {
        var button = new Button
        {
            Text = "   " + text,
            Width = 215,
            Height = 48,
            TextAlign = ContentAlignment.MiddleLeft,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(22, 48, 75),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F),
            Margin = new Padding(0, 4, 0, 4),
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 79, 115);
        button.Click += (_, _) => action();
        parent.Controls.Add(button);
    }

    private void OpenChildForm(Form child, string title)
    {
        // Các form chức năng hiện có đang được xây dựng theo dạng Form độc lập.
        // Hiển thị dạng hộp thoại để tránh chồng nhiều cửa sổ con.
        _lblPageTitle.Text = title;
        using (child)
        {
            child.StartPosition = FormStartPosition.CenterParent;
            child.ShowDialog(this);
        }
    }
}
