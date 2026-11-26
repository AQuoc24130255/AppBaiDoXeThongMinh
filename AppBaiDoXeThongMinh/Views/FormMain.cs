using AppBaiDoXeThongMinh.Models;
using AppBaiDoXeThongMinh.Views;
using AppBaiDoXeThongMinh.database;
using Microsoft.EntityFrameworkCore;

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
        _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        InitializeComponent();
        LoadUserInformation();
        BuildMenu();
        RegisterEvents();

        Shown += (_, _) => OpenChildForm(new FormDashboard(), "TỔNG QUAN");
    }

    private void LoadUserInformation()
    {
        lblUserName.Text = _currentUser.FullName;
        lblUserRole.Text = _currentUser.Role == Role.Admin
            ? "Quản trị viên"
            : "Nhân viên bảo vệ";
    }

    private void RegisterEvents()
    {
        btnToggleMenu.Click += (_, _) => ToggleMenu();
        btnLogout.Click += (_, _) => Logout();
    }

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

        AddMenuButton("Cá nhân", "♙", () =>
            OpenChildForm(new FormProfile(_currentUser), "THÔNG TIN CÁ NHÂN"));

        if (_currentUser.Role == Role.Admin)
        {
            AddMenuButton("Quản lý tài khoản", "♙", () =>
                OpenChildForm(new FormEditUser(), "QUẢN LÝ TÀI KHOẢN"));
            AddMenuButton("Quản lý chỗ đỗ", "▦", () =>
                OpenChildForm(new FormEditSlot(), "QUẢN LÝ CHỖ ĐỖ"));
            AddMenuButton("Quản lý vé tháng", "▤", () =>
                OpenChildForm(new FormManageTicket(), "QUẢN LÝ VÉ THÁNG"));
            AddMenuButton("Quản lý giá", "▤", () =>
                OpenChildForm(new FormManagePriceConfig(), "QUẢN LÝ GIÁ"));
            AddMenuButton("Thống kê doanh thu", "▥", () =>
                OpenChildForm(new FormDashboard(), "THỐNG KÊ DOANH THU"));
        }
        else
        {
            AddMenuButton("Theo dõi chỗ đỗ", "▦", ShowParkingOverview);
            AddMenuButton("Xe vào bãi", "↓", () =>
                OpenChildForm(new FormCheckIn(), "TIẾP NHẬN XE VÀO"));
            AddMenuButton("Xe ra bãi", "↑", () =>
                OpenChildForm(new FormCheckOut(_currentUser.UserId), "XỬ LÝ XE RA"));
            AddMenuButton("Tra cứu", "⌕", () =>
                OpenChildForm(new FormSearch(_currentUser), "TRA CỨU THÔNG TIN"));
        }
    }

    private void AddMenuButton(string text, string symbol, Action action)
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
        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 79, 115);
        button.Click += (_, _) => action();
        _menuFlow.Controls.Add(button);
    }

    private void ToggleMenu()
    {
        _isMenuCollapsed = !_isMenuCollapsed;
        pnlSidebar.Width = _isMenuCollapsed ? CollapsedWidth : ExpandedWidth;
        lblBrand.Text = _isMenuCollapsed ? "SP" : "SMART PARKING";
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
                "Quản lý chỗ đỗ" or "Theo dõi chỗ đỗ" => "▦",
                "Quản lý vé tháng" => "▤",
                "Quản lý giá" => "▤",
                "Thống kê doanh thu" => "▥",
                "Xe vào bãi" => "↓",
                "Xe ra bãi" => "↑",
                "Tra cứu" => "⌕",
                _ => "•"
            };
            button.Width = _isMenuCollapsed ? 48 : 215;
            button.Text = _isMenuCollapsed ? symbol : $"{symbol}   {text}";
            button.TextAlign = _isMenuCollapsed
                ? ContentAlignment.MiddleCenter
                : ContentAlignment.MiddleLeft;
        }
    }

    private void OpenChildForm(Form child, string title)
    {
        CloseCurrentChildForm();
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

    // Màn hình theo dõi chỉ được tạo trực tiếp trong FormMain.cs, không cần tạo Form mới.
    private void ShowParkingOverview()
    {
        CloseCurrentChildForm();
        lblPageTitle.Text = "THEO DÕI TÌNH TRẠNG CHỖ ĐỖ";
        pnlContent.Controls.Clear();

        var page = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(243, 246, 250), Padding = new Padding(8) };
        var heading = new Label
        {
            Text = "TÌNH TRẠNG BÃI ĐỖ XE",
            Dock = DockStyle.Top,
            Height = 42,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            ForeColor = Color.FromArgb(25, 65, 105),
            TextAlign = ContentAlignment.MiddleLeft
        };
        var subheading = new Label
        {
            Text = "Thông tin chỉ xem dành cho nhân viên bảo vệ",
            Dock = DockStyle.Top,
            Height = 30,
            ForeColor = Color.DimGray,
            Font = new Font("Segoe UI", 9.5F),
            TextAlign = ContentAlignment.MiddleLeft
        };

        var btnRefresh = new Button
        {
            Text = "↻  Làm mới dữ liệu",
            Dock = DockStyle.Top,
            Height = 40,
            Width = 180,
            BackColor = Color.FromArgb(0, 102, 204),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnRefresh.FlatAppearance.BorderSize = 0;

        var statsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 105,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(0, 8, 0, 8),
            BackColor = page.BackColor
        };

        var grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            EnableHeadersVisualStyles = false,
            Font = new Font("Segoe UI", 9.5F),
            RowTemplate = { Height = 38 }
        };
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 48, 75);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grid.ColumnHeadersHeight = 42;
        grid.Columns.Add("SlotName", "MÃ / TÊN CHỖ");
        grid.Columns.Add("Zone", "KHU VỰC");
        grid.Columns.Add("VehicleType", "LOẠI XE ĐƯỢC PHÉP");
        grid.Columns.Add("Status", "TÌNH TRẠNG");
        grid.Columns.Add("LicensePlate", "BIỂN SỐ XE");

        var gridTitle = new Label
        {
            Text = "DANH SÁCH CHI TIẾT CÁC VỊ TRÍ",
            Dock = DockStyle.Top,
            Height = 38,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            ForeColor = Color.FromArgb(25, 65, 105),
            TextAlign = ContentAlignment.MiddleLeft
        };

        page.Controls.Add(grid);
        page.Controls.Add(gridTitle);
        page.Controls.Add(statsPanel);
        page.Controls.Add(btnRefresh);
        page.Controls.Add(subheading);
        page.Controls.Add(heading);
        pnlContent.Controls.Add(page);

        void LoadParkingData()
        {
            try
            {
                using var db = new AppDbContext();
                var slots = db.ParkingSlots.AsNoTracking()
                    .OrderBy(s => s.Zone).ThenBy(s => s.SlotName).ToList();

                var activeTickets = db.Tickets.AsNoTracking()
                    .Where(t => t.Status == TicketStatus.Inparking && t.ParkingSlotId != null)
                    .Select(t => new { SlotId = t.ParkingSlotId!.Value, Plate = t.Vehicle.LicensePlate })
                    .ToList();
                var plateBySlot = activeTickets
                    .GroupBy(t => t.SlotId)
                    .ToDictionary(g => g.Key, g => g.First().Plate);

                var vehicleIds = slots.Where(s => s.CurrentVehicleID.HasValue)
                    .Select(s => s.CurrentVehicleID!.Value).Distinct().ToList();
                var fallbackPlates = db.Vehicles.AsNoTracking()
                    .Where(v => vehicleIds.Contains(v.VehicleId))
                    .ToDictionary(v => v.VehicleId, v => v.LicensePlate);

                grid.Rows.Clear();
                int occupiedCount = 0;
                foreach (var slot in slots)
                {
                    string plate = "";
                    bool hasTicket = plateBySlot.TryGetValue(slot.SlotId, out plate!);
                    if (!hasTicket && slot.CurrentVehicleID.HasValue)
                        fallbackPlates.TryGetValue(slot.CurrentVehicleID.Value, out plate!);

                    bool occupied = slot.IsOccupied || hasTicket || !string.IsNullOrWhiteSpace(plate);
                    if (occupied) occupiedCount++;
                    int rowIndex = grid.Rows.Add(
                        slot.SlotName,
                        slot.Zone,
                        slot.AllowedVehicleType == VehicleType.Car ? "Ô tô" : "Xe máy",
                        occupied ? "ĐÃ CÓ XE" : "CÒN TRỐNG",
                        occupied ? (plate ?? "Chưa có dữ liệu biển số") : "—");
                    grid.Rows[rowIndex].DefaultCellStyle.BackColor = occupied
                        ? Color.FromArgb(255, 239, 235)
                        : Color.FromArgb(232, 248, 239);
                    grid.Rows[rowIndex].Cells[3].Style.ForeColor = occupied
                        ? Color.Firebrick : Color.ForestGreen;
                    grid.Rows[rowIndex].Cells[3].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                int total = slots.Count;
                int free = Math.Max(0, total - occupiedCount);
                statsPanel.Controls.Clear();
                statsPanel.Controls.Add(CreateStatCard("TỔNG SỐ CHỖ", total.ToString(), Color.FromArgb(25, 65, 105)));
                statsPanel.Controls.Add(CreateStatCard("ĐANG CÓ XE", occupiedCount.ToString(), Color.FromArgb(190, 70, 55)));
                statsPanel.Controls.Add(CreateStatCard("CÒN TRỐNG", free.ToString(), Color.FromArgb(35, 145, 85)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu chỗ đỗ. Chi tiết: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        btnRefresh.Click += (_, _) => LoadParkingData();
        LoadParkingData();
    }

    private Control CreateStatCard(string title, string value, Color accent)
    {
        var card = new Panel
        {
            Width = 220,
            Height = 78,
            BackColor = Color.White,
            Margin = new Padding(0, 0, 14, 0),
            Padding = new Padding(12)
        };
        var titleLabel = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 25,
            ForeColor = Color.DimGray,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold)
        };
        var valueLabel = new Label
        {
            Text = value,
            Dock = DockStyle.Fill,
            ForeColor = accent,
            Font = new Font("Segoe UI", 19F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft
        };
        card.Controls.Add(valueLabel);
        card.Controls.Add(titleLabel);
        return card;
    }

    private void CloseCurrentChildForm()
    {
        if (_currentChildForm != null)
        {
            _currentChildForm.Close();
            _currentChildForm.Dispose();
            _currentChildForm = null;
        }
    }

    private void Logout()
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes) Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        CloseCurrentChildForm();
        base.OnFormClosed(e);
    }
}
    