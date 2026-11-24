
using AppBaiDoXeThongMinh.Models;
using AppBaiDoXeThongMinh.Views;

namespace AppBaiDoXeThongMinh;

public partial class FormMain : Form
{
    private readonly User _currentUser;

    private Form? _currentChildForm;

    private FlowLayoutPanel _menuFlow = null!;

    private bool _isMenuCollapsed = false;

    private const int ExpandedWidth = 245;
    private const int CollapsedWidth = 72;

    public FormMain(User user)
    {
        _currentUser = user ??
            throw new ArgumentNullException(nameof(user));

        InitializeComponent();

        LoadUserInformation();
        BuildMenu();
        RegisterEvents();

        // Mở màn hình mặc định sau đăng nhập
        Shown += (_, _) =>
        {
            OpenChildForm(
                new FormDashboard(),
                "TỔNG QUAN");
        };
    }

    // Hiển thị thông tin tài khoản
    private void LoadUserInformation()
    {
        lblUserName.Text = _currentUser.FullName;

        lblUserRole.Text =
            _currentUser.Role == Role.Admin
                ? "Quản trị viên"
                : "Nhân viên bảo vệ";
    }

    // Gắn sự kiện cho các nút
    private void RegisterEvents()
    {
        btnToggleMenu.Click += (_, _) =>
        {
            ToggleMenu();
        };

        btnLogout.Click += (_, _) =>
        {
            Logout();
        };
    }

    // Tạo menu theo quyền người dùng
    private void BuildMenu()
    {
        _menuFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            BackColor = pnlSidebar.BackColor,
            Padding = new Padding(8, 10, 8, 10)
        };

        pnlMenu.Controls.Clear();
        pnlMenu.Controls.Add(_menuFlow);

        // Chức năng chung
        AddMenuButton(
            "Cá nhân",
            "♙",
            () => OpenChildForm(
                new FormProfile(_currentUser),
                "THÔNG TIN CÁ NHÂN"));

        if (_currentUser.Role == Role.Admin)
        {
            AddMenuButton(
                "Quản lý tài khoản",
                "♙",
                () => OpenChildForm(
                    new FormEditUser(),
                    "QUẢN LÝ TÀI KHOẢN"));

            AddMenuButton(
                "Quản lý chỗ đỗ",
                "▦",
                () => OpenChildForm(
                    new FormEditSlot(),
                    "QUẢN LÝ CHỖ ĐỖ"));

            AddMenuButton(
                "Quản lý vé tháng",
                "▤",
                () => OpenChildForm(
                    new FormManageTicket(),
                    "QUẢN LÝ VÉ THÁNG"));
            
            AddMenuButton(
                "Quản lý giá",
                "▤",
                () => OpenChildForm(
                    new FormManagePriceConfig(),
                    "QUẢN LÝ GIÁ"));

            AddMenuButton(
                "Thống kê doanh thu",
                "▥",
                () => OpenChildForm(
                    new FormDashboard(),
                    "THỐNG KÊ DOANH THU"));
        }
        else
        {
            AddMenuButton(
                "Xe vào bãi",
                "↓",
                () => OpenChildForm(
                    new FormCheckIn(),
                    "TIẾP NHẬN XE VÀO"));

            AddMenuButton(
                "Xe ra bãi",
                "↑",
                () => OpenChildForm(
                    new FormCheckOut(),
                    "XỬ LÝ XE RA"));

            AddMenuButton(
                "Tra cứu",
                "⌕",
                () => OpenChildForm(
                    new FormSearch(_currentUser),
                    "TRA CỨU THÔNG TIN"));
        }
    }

    // Tạo một nút menu
    private void AddMenuButton(
        string text,
        string symbol,
        Action action)
    {
        Button button = new Button
        {
            Text = $"{symbol}   {text}",
            Width = 215,
            Height = 46,
            TextAlign = ContentAlignment.MiddleLeft,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(22, 48, 75),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5F),
            Margin = new Padding(0, 4, 0, 4),
            Cursor = Cursors.Hand,
            Tag = text
        };

        button.FlatAppearance.BorderSize = 0;

        button.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(38, 79, 115);

        button.Click += (_, _) => action();

        _menuFlow.Controls.Add(button);
    }

    // Thu gọn hoặc mở rộng menu
    private void ToggleMenu()
    {
        _isMenuCollapsed = !_isMenuCollapsed;

        pnlSidebar.Width = _isMenuCollapsed
            ? CollapsedWidth
            : ExpandedWidth;

        lblBrand.Text = _isMenuCollapsed
            ? "SP"
            : "SMART PARKING";

        lblUserName.Visible = !_isMenuCollapsed;
        lblUserRole.Visible = !_isMenuCollapsed;
        btnLogout.Text = _isMenuCollapsed ? "↪" : "Đăng xuất";

        foreach (Button button in _menuFlow.Controls.OfType<Button>())
        {
            string text = button.Tag?.ToString() ?? "";

            string symbol = text switch
            {
                "Cá nhân" => "♙",
                "Quản lý tài khoản" => "♙",
                "Quản lý chỗ đỗ" => "▦",
                "Quản lý vé tháng" => "▤",
                "Quản lý vé giá" => "▤",
                "Thống kê doanh thu" => "▥",
                "Xe vào bãi" => "↓",
                "Xe ra bãi" => "↑",
                "Tra cứu" => "⌕",
                _ => "•"
            };

            button.Width = _isMenuCollapsed ? 48 : 215;

            button.Text = _isMenuCollapsed
                ? symbol
                : $"{symbol}   {text}";

            button.TextAlign = _isMenuCollapsed
                ? ContentAlignment.MiddleCenter
                : ContentAlignment.MiddleLeft;
        }
    }

    // Mở form chức năng trong vùng nội dung
    private void OpenChildForm(Form child, string title)
    {
        if (_currentChildForm != null)
        {
            _currentChildForm.Close();
            _currentChildForm.Dispose();
            _currentChildForm = null;
        }

        lblPageTitle.Text = title;

        _currentChildForm = child;

        child.TopLevel = false;
        child.FormBorderStyle = FormBorderStyle.None;
        child.Dock = DockStyle.Fill;
        child.MinimumSize = Size.Empty;
        child.AutoScroll = true;

        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(child);

        child.BringToFront();
        child.Show();
    }

    // Đăng xuất
    private void Logout()
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            Close();
        }
    }

    // Đóng form con khi đóng FormMain
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (_currentChildForm != null)
        {
            _currentChildForm.Close();
            _currentChildForm.Dispose();
            _currentChildForm = null;
        }

        base.OnFormClosed(e);
    }
}
