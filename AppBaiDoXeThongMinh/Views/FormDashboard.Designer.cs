using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormDashboard
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        grbCurrentParking = new System.Windows.Forms.GroupBox();
        flowLayoutPanelCurrentParking = new System.Windows.Forms.FlowLayoutPanel();
        panelParked = new System.Windows.Forms.Panel();
        lbCarParked = new System.Windows.Forms.Label();
        lbMotobikeParked = new System.Windows.Forms.Label();
        lbtotalParked = new System.Windows.Forms.Label();
        lbParked = new System.Windows.Forms.Label();
        panelOccupancy = new System.Windows.Forms.Panel();
        lbSlotOccupancy = new System.Windows.Forms.Label();
        lbTotalOccupancy = new System.Windows.Forms.Label();
        lbOccupancy = new System.Windows.Forms.Label();
        panelToday = new System.Windows.Forms.Panel();
        lbCarToday = new System.Windows.Forms.Label();
        lbMotobikeToday = new System.Windows.Forms.Label();
        lbTotalToday = new System.Windows.Forms.Label();
        lbToday = new System.Windows.Forms.Label();
        panelMonthly = new System.Windows.Forms.Panel();
        lbCarMonthly = new System.Windows.Forms.Label();
        lbMotobikeMonthly = new System.Windows.Forms.Label();
        lbTotalMonthly = new System.Windows.Forms.Label();
        lbMonthly = new System.Windows.Forms.Label();
        panelSlots = new System.Windows.Forms.Panel();
        lbCarSlots = new System.Windows.Forms.Label();
        lbMotobikeSlots = new System.Windows.Forms.Label();
        lbTotalSlots = new System.Windows.Forms.Label();
        lbSlots = new System.Windows.Forms.Label();
        grbRevenue = new System.Windows.Forms.GroupBox();
        flowLayoutPanelRevenue = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanelSummary = new System.Windows.Forms.FlowLayoutPanel();
        btRevenue = new System.Windows.Forms.Button();
        grbSummary = new System.Windows.Forms.GroupBox();
        lbTitleSummary = new System.Windows.Forms.Label();
        flowLayoutPanelFilter = new System.Windows.Forms.FlowLayoutPanel();
        tableLayoutPanelFilter = new System.Windows.Forms.TableLayoutPanel();
        cbVehicleType = new System.Windows.Forms.ComboBox();
        lbShift = new System.Windows.Forms.Label();
        lbStartDate = new System.Windows.Forms.Label();
        dtpStartDate = new System.Windows.Forms.DateTimePicker();
        lbEndDate = new System.Windows.Forms.Label();
        dtpEndDate = new System.Windows.Forms.DateTimePicker();
        lbVehicleType = new System.Windows.Forms.Label();
        cbShift = new System.Windows.Forms.ComboBox();
        grbFilter = new System.Windows.Forms.GroupBox();
        dataGridViewFilter = new System.Windows.Forms.DataGridView();
        Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
        TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
        TranSactionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
        VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
        lbTotalRevenue = new System.Windows.Forms.Label();
        lbDayAmount = new System.Windows.Forms.Label();
        lbNightAmount = new System.Windows.Forms.Label();
        lbDayTotalAmount = new System.Windows.Forms.Label();
        lbNightTotalAmount = new System.Windows.Forms.Label();
        panelThongke = new System.Windows.Forms.Panel();
        grbCurrentParking.SuspendLayout();
        flowLayoutPanelCurrentParking.SuspendLayout();
        panelParked.SuspendLayout();
        panelOccupancy.SuspendLayout();
        panelToday.SuspendLayout();
        panelMonthly.SuspendLayout();
        panelSlots.SuspendLayout();
        grbRevenue.SuspendLayout();
        flowLayoutPanelRevenue.SuspendLayout();
        flowLayoutPanelSummary.SuspendLayout();
        grbSummary.SuspendLayout();
        flowLayoutPanelFilter.SuspendLayout();
        tableLayoutPanelFilter.SuspendLayout();
        grbFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewFilter).BeginInit();
        SuspendLayout();
        // 
        // grbCurrentParking
        // 
        grbCurrentParking.BackColor = System.Drawing.SystemColors.ActiveCaption;
        grbCurrentParking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        grbCurrentParking.Controls.Add(flowLayoutPanelCurrentParking);
        grbCurrentParking.Dock = System.Windows.Forms.DockStyle.Top;
        grbCurrentParking.Location = new System.Drawing.Point(0, 0);
        grbCurrentParking.Name = "grbCurrentParking";
        grbCurrentParking.Size = new System.Drawing.Size(800, 133);
        grbCurrentParking.TabIndex = 0;
        grbCurrentParking.TabStop = false;
        grbCurrentParking.Text = "Tình trạng bãi xe hiện tại";
        // 
        // flowLayoutPanelCurrentParking
        // 
        flowLayoutPanelCurrentParking.Controls.Add(panelParked);
        flowLayoutPanelCurrentParking.Controls.Add(panelOccupancy);
        flowLayoutPanelCurrentParking.Controls.Add(panelToday);
        flowLayoutPanelCurrentParking.Controls.Add(panelMonthly);
        flowLayoutPanelCurrentParking.Controls.Add(panelSlots);
        flowLayoutPanelCurrentParking.Location = new System.Drawing.Point(25, 17);
        flowLayoutPanelCurrentParking.Name = "flowLayoutPanelCurrentParking";
        flowLayoutPanelCurrentParking.Size = new System.Drawing.Size(741, 110);
        flowLayoutPanelCurrentParking.TabIndex = 3;
        // 
        // panelParked
        // 
        panelParked.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panelParked.Controls.Add(lbCarParked);
        panelParked.Controls.Add(lbMotobikeParked);
        panelParked.Controls.Add(lbtotalParked);
        panelParked.Controls.Add(lbParked);
        panelParked.Location = new System.Drawing.Point(0, 3);
        panelParked.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panelParked.Name = "panelParked";
        panelParked.Size = new System.Drawing.Size(140, 105);
        panelParked.TabIndex = 8;
        // 
        // lbCarParked
        // 
        lbCarParked.Location = new System.Drawing.Point(0, 75);
        lbCarParked.Name = "lbCarParked";
        lbCarParked.Size = new System.Drawing.Size(140, 30);
        lbCarParked.TabIndex = 3;
        lbCarParked.Text = "Xe Ô Tô: 0";
        lbCarParked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbMotobikeParked
        // 
        lbMotobikeParked.Location = new System.Drawing.Point(0, 59);
        lbMotobikeParked.Name = "lbMotobikeParked";
        lbMotobikeParked.Size = new System.Drawing.Size(140, 16);
        lbMotobikeParked.TabIndex = 2;
        lbMotobikeParked.Text = "Xe Máy: 0";
        lbMotobikeParked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbtotalParked
        // 
        lbtotalParked.Font = new System.Drawing.Font("Segoe UI", 14F);
        lbtotalParked.Location = new System.Drawing.Point(0, 23);
        lbtotalParked.Name = "lbtotalParked";
        lbtotalParked.Size = new System.Drawing.Size(140, 36);
        lbtotalParked.TabIndex = 1;
        lbtotalParked.Text = "0";
        lbtotalParked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbParked
        // 
        lbParked.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbParked.Location = new System.Drawing.Point(0, 0);
        lbParked.Name = "lbParked";
        lbParked.Size = new System.Drawing.Size(140, 23);
        lbParked.TabIndex = 0;
        lbParked.Text = "Xe đang gửi";
        lbParked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panelOccupancy
        // 
        panelOccupancy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panelOccupancy.Controls.Add(lbSlotOccupancy);
        panelOccupancy.Controls.Add(lbTotalOccupancy);
        panelOccupancy.Controls.Add(lbOccupancy);
        panelOccupancy.Location = new System.Drawing.Point(150, 3);
        panelOccupancy.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panelOccupancy.Name = "panelOccupancy";
        panelOccupancy.Size = new System.Drawing.Size(140, 105);
        panelOccupancy.TabIndex = 5;
        // 
        // lbSlotOccupancy
        // 
        lbSlotOccupancy.Location = new System.Drawing.Point(0, 59);
        lbSlotOccupancy.Name = "lbSlotOccupancy";
        lbSlotOccupancy.Size = new System.Drawing.Size(140, 46);
        lbSlotOccupancy.TabIndex = 3;
        lbSlotOccupancy.Text = "Số Chỗ Trống: 0";
        // 
        // lbTotalOccupancy
        // 
        lbTotalOccupancy.Font = new System.Drawing.Font("Segoe UI", 14F);
        lbTotalOccupancy.Location = new System.Drawing.Point(0, 23);
        lbTotalOccupancy.Name = "lbTotalOccupancy";
        lbTotalOccupancy.Size = new System.Drawing.Size(140, 36);
        lbTotalOccupancy.TabIndex = 1;
        lbTotalOccupancy.Text = "0%";
        lbTotalOccupancy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbOccupancy
        // 
        lbOccupancy.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbOccupancy.Location = new System.Drawing.Point(0, 0);
        lbOccupancy.Name = "lbOccupancy";
        lbOccupancy.Size = new System.Drawing.Size(140, 23);
        lbOccupancy.TabIndex = 0;
        lbOccupancy.Text = "Tỷ lệ lấp đầy";
        lbOccupancy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panelToday
        // 
        panelToday.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panelToday.Controls.Add(lbCarToday);
        panelToday.Controls.Add(lbMotobikeToday);
        panelToday.Controls.Add(lbTotalToday);
        panelToday.Controls.Add(lbToday);
        panelToday.Location = new System.Drawing.Point(300, 3);
        panelToday.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panelToday.Name = "panelToday";
        panelToday.Size = new System.Drawing.Size(140, 105);
        panelToday.TabIndex = 6;
        // 
        // lbCarToday
        // 
        lbCarToday.Location = new System.Drawing.Point(0, 75);
        lbCarToday.Name = "lbCarToday";
        lbCarToday.Size = new System.Drawing.Size(140, 30);
        lbCarToday.TabIndex = 3;
        lbCarToday.Text = "Xe Ô Tô: 0";
        lbCarToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbMotobikeToday
        // 
        lbMotobikeToday.Location = new System.Drawing.Point(0, 59);
        lbMotobikeToday.Name = "lbMotobikeToday";
        lbMotobikeToday.Size = new System.Drawing.Size(140, 16);
        lbMotobikeToday.TabIndex = 2;
        lbMotobikeToday.Text = "Xe Máy: 0";
        lbMotobikeToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbTotalToday
        // 
        lbTotalToday.Font = new System.Drawing.Font("Segoe UI", 14F);
        lbTotalToday.Location = new System.Drawing.Point(0, 23);
        lbTotalToday.Name = "lbTotalToday";
        lbTotalToday.Size = new System.Drawing.Size(140, 36);
        lbTotalToday.TabIndex = 1;
        lbTotalToday.Text = "0";
        lbTotalToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbToday
        // 
        lbToday.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbToday.Location = new System.Drawing.Point(0, 0);
        lbToday.Name = "lbToday";
        lbToday.Size = new System.Drawing.Size(140, 23);
        lbToday.TabIndex = 0;
        lbToday.Text = "Xe vào hôm nay";
        lbToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panelMonthly
        // 
        panelMonthly.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panelMonthly.Controls.Add(lbCarMonthly);
        panelMonthly.Controls.Add(lbMotobikeMonthly);
        panelMonthly.Controls.Add(lbTotalMonthly);
        panelMonthly.Controls.Add(lbMonthly);
        panelMonthly.Location = new System.Drawing.Point(450, 3);
        panelMonthly.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panelMonthly.Name = "panelMonthly";
        panelMonthly.Size = new System.Drawing.Size(140, 105);
        panelMonthly.TabIndex = 9;
        // 
        // lbCarMonthly
        // 
        lbCarMonthly.Location = new System.Drawing.Point(0, 75);
        lbCarMonthly.Name = "lbCarMonthly";
        lbCarMonthly.Size = new System.Drawing.Size(140, 30);
        lbCarMonthly.TabIndex = 3;
        lbCarMonthly.Text = "Xe Ô Tô: 0";
        lbCarMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbMotobikeMonthly
        // 
        lbMotobikeMonthly.Location = new System.Drawing.Point(0, 59);
        lbMotobikeMonthly.Name = "lbMotobikeMonthly";
        lbMotobikeMonthly.Size = new System.Drawing.Size(140, 16);
        lbMotobikeMonthly.TabIndex = 2;
        lbMotobikeMonthly.Text = "Xe Máy: 0";
        lbMotobikeMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbTotalMonthly
        // 
        lbTotalMonthly.Font = new System.Drawing.Font("Segoe UI", 14F);
        lbTotalMonthly.Location = new System.Drawing.Point(0, 23);
        lbTotalMonthly.Name = "lbTotalMonthly";
        lbTotalMonthly.Size = new System.Drawing.Size(140, 36);
        lbTotalMonthly.TabIndex = 1;
        lbTotalMonthly.Text = "0";
        lbTotalMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbMonthly
        // 
        lbMonthly.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbMonthly.Location = new System.Drawing.Point(0, 0);
        lbMonthly.Name = "lbMonthly";
        lbMonthly.Size = new System.Drawing.Size(140, 23);
        lbMonthly.TabIndex = 0;
        lbMonthly.Text = "Vé tháng hiệu lực";
        lbMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panelSlots
        // 
        panelSlots.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panelSlots.Controls.Add(lbCarSlots);
        panelSlots.Controls.Add(lbMotobikeSlots);
        panelSlots.Controls.Add(lbTotalSlots);
        panelSlots.Controls.Add(lbSlots);
        panelSlots.Location = new System.Drawing.Point(600, 3);
        panelSlots.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
        panelSlots.Name = "panelSlots";
        panelSlots.Size = new System.Drawing.Size(140, 105);
        panelSlots.TabIndex = 2;
        // 
        // lbCarSlots
        // 
        lbCarSlots.Location = new System.Drawing.Point(0, 75);
        lbCarSlots.Name = "lbCarSlots";
        lbCarSlots.Size = new System.Drawing.Size(140, 30);
        lbCarSlots.TabIndex = 3;
        lbCarSlots.Text = "Xe Ô Tô: 0";
        lbCarSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbMotobikeSlots
        // 
        lbMotobikeSlots.Location = new System.Drawing.Point(0, 59);
        lbMotobikeSlots.Name = "lbMotobikeSlots";
        lbMotobikeSlots.Size = new System.Drawing.Size(140, 16);
        lbMotobikeSlots.TabIndex = 2;
        lbMotobikeSlots.Text = "Xe Máy: 0";
        lbMotobikeSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbTotalSlots
        // 
        lbTotalSlots.Font = new System.Drawing.Font("Segoe UI", 14F);
        lbTotalSlots.Location = new System.Drawing.Point(0, 23);
        lbTotalSlots.Name = "lbTotalSlots";
        lbTotalSlots.Size = new System.Drawing.Size(140, 36);
        lbTotalSlots.TabIndex = 1;
        lbTotalSlots.Text = "0";
        lbTotalSlots.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbSlots
        // 
        lbSlots.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbSlots.Location = new System.Drawing.Point(0, 0);
        lbSlots.Name = "lbSlots";
        lbSlots.Size = new System.Drawing.Size(140, 23);
        lbSlots.TabIndex = 0;
        lbSlots.Text = "Tổng số chỗ đỗ";
        lbSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // grbRevenue
        // 
        grbRevenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
        grbRevenue.Controls.Add(flowLayoutPanelRevenue);
        grbRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
        grbRevenue.Location = new System.Drawing.Point(0, 133);
        grbRevenue.Name = "grbRevenue";
        grbRevenue.Size = new System.Drawing.Size(800, 317);
        grbRevenue.TabIndex = 1;
        grbRevenue.TabStop = false;
        grbRevenue.Text = "Báo cáo doanh thu theo Ngày/Đêm";
        // 
        // flowLayoutPanelRevenue
        // 
        flowLayoutPanelRevenue.Controls.Add(flowLayoutPanelSummary);
        flowLayoutPanelRevenue.Controls.Add(flowLayoutPanelFilter);
        flowLayoutPanelRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanelRevenue.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        flowLayoutPanelRevenue.Location = new System.Drawing.Point(3, 19);
        flowLayoutPanelRevenue.Name = "flowLayoutPanelRevenue";
        flowLayoutPanelRevenue.Size = new System.Drawing.Size(794, 295);
        flowLayoutPanelRevenue.TabIndex = 0;
        // 
        // flowLayoutPanelSummary
        // 
        flowLayoutPanelSummary.Controls.Add(btRevenue);
        flowLayoutPanelSummary.Controls.Add(grbSummary);
        flowLayoutPanelSummary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanelSummary.Location = new System.Drawing.Point(591, 3);
        flowLayoutPanelSummary.Name = "flowLayoutPanelSummary";
        flowLayoutPanelSummary.Size = new System.Drawing.Size(200, 292);
        flowLayoutPanelSummary.TabIndex = 0;
        // 
        // btRevenue
        // 
        btRevenue.Location = new System.Drawing.Point(3, 3);
        btRevenue.Name = "btRevenue";
        btRevenue.Size = new System.Drawing.Size(197, 23);
        btRevenue.TabIndex = 0;
        btRevenue.Text = "Thống Kê";
        btRevenue.UseVisualStyleBackColor = true;
        btRevenue.Click += (_, _) => RefreshDashboard();
        // 
        // grbSummary
        // 
        grbSummary.Controls.Add(panelThongke);
        grbSummary.Controls.Add(lbNightTotalAmount);
        grbSummary.Controls.Add(lbDayTotalAmount);
        grbSummary.Controls.Add(lbNightAmount);
        grbSummary.Controls.Add(lbDayAmount);
        grbSummary.Controls.Add(lbTotalRevenue);
        grbSummary.Controls.Add(lbTitleSummary);
        grbSummary.Location = new System.Drawing.Point(3, 32);
        grbSummary.Name = "grbSummary";
        grbSummary.Size = new System.Drawing.Size(200, 257);
        grbSummary.TabIndex = 1;
        grbSummary.TabStop = false;
        grbSummary.Text = "Tổng doanh thu";
        // 
        // lbTitleSummary
        // 
        lbTitleSummary.BackColor = System.Drawing.SystemColors.MenuHighlight;
        lbTitleSummary.Location = new System.Drawing.Point(6, 19);
        lbTitleSummary.Name = "lbTitleSummary";
        lbTitleSummary.Size = new System.Drawing.Size(188, 23);
        lbTitleSummary.TabIndex = 0;
        lbTitleSummary.Text = "Doanh thu thu được";
        lbTitleSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanelFilter
        // 
        flowLayoutPanelFilter.Controls.Add(tableLayoutPanelFilter);
        flowLayoutPanelFilter.Controls.Add(grbFilter);
        flowLayoutPanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanelFilter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanelFilter.Location = new System.Drawing.Point(3, 3);
        flowLayoutPanelFilter.Name = "flowLayoutPanelFilter";
        flowLayoutPanelFilter.Size = new System.Drawing.Size(582, 292);
        flowLayoutPanelFilter.TabIndex = 1;
        // 
        // tableLayoutPanelFilter
        // 
        tableLayoutPanelFilter.ColumnCount = 4;
        tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.22222F));
        tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
        tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
        tableLayoutPanelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
        tableLayoutPanelFilter.Controls.Add(cbVehicleType, 3, 1);
        tableLayoutPanelFilter.Controls.Add(lbShift, 2, 0);
        tableLayoutPanelFilter.Controls.Add(lbStartDate, 0, 0);
        tableLayoutPanelFilter.Controls.Add(dtpStartDate, 0, 1);
        tableLayoutPanelFilter.Controls.Add(lbEndDate, 1, 0);
        tableLayoutPanelFilter.Controls.Add(dtpEndDate, 1, 1);
        tableLayoutPanelFilter.Controls.Add(lbVehicleType, 3, 0);
        tableLayoutPanelFilter.Controls.Add(cbShift, 2, 1);
        tableLayoutPanelFilter.Location = new System.Drawing.Point(3, 3);
        tableLayoutPanelFilter.Name = "tableLayoutPanelFilter";
        tableLayoutPanelFilter.RowCount = 2;
        tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.295776F));
        tableLayoutPanelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.704224F));
        tableLayoutPanelFilter.Size = new System.Drawing.Size(579, 57);
        tableLayoutPanelFilter.TabIndex = 0;
        // 
        // cbVehicleType
        // 
        cbVehicleType.FormattingEnabled = true;
        cbVehicleType.Items.AddRange(new object[] { "Tất Cả", "Xe Máy", "Xe Ô Tô" });
        cbVehicleType.Location = new System.Drawing.Point(440, 31);
        cbVehicleType.Name = "cbVehicleType";
        cbVehicleType.Size = new System.Drawing.Size(136, 23);
        cbVehicleType.TabIndex = 6;
        cbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
        cbVehicleType.SelectedIndex = 0;
        // 
        // lbShift
        // 
        lbShift.Location = new System.Drawing.Point(291, 0);
        lbShift.Name = "lbShift";
        lbShift.Size = new System.Drawing.Size(143, 23);
        lbShift.TabIndex = 3;
        lbShift.Text = "Ca";
        lbShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbStartDate
        // 
        lbStartDate.Location = new System.Drawing.Point(3, 0);
        lbStartDate.Name = "lbStartDate";
        lbStartDate.Size = new System.Drawing.Size(130, 23);
        lbStartDate.TabIndex = 0;
        lbStartDate.Text = "Từ ngày";
        lbStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // dtpStartDate
        // 
        dtpStartDate.Location = new System.Drawing.Point(3, 31);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new System.Drawing.Size(130, 23);
        dtpStartDate.TabIndex = 1;
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Value = DateTime.Today.AddDays(-6);
        // 
        // lbEndDate
        // 
        lbEndDate.Location = new System.Drawing.Point(139, 0);
        lbEndDate.Name = "lbEndDate";
        lbEndDate.Size = new System.Drawing.Size(146, 23);
        lbEndDate.TabIndex = 0;
        lbEndDate.Text = "Đến ngày";
        lbEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // dtpEndDate
        // 
        dtpEndDate.Location = new System.Drawing.Point(139, 31);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new System.Drawing.Size(146, 23);
        dtpEndDate.TabIndex = 2;
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Value = DateTime.Today;
        // 
        // lbVehicleType
        // 
        lbVehicleType.Location = new System.Drawing.Point(440, 0);
        lbVehicleType.Name = "lbVehicleType";
        lbVehicleType.Size = new System.Drawing.Size(136, 23);
        lbVehicleType.TabIndex = 4;
        lbVehicleType.Text = "Loại Xe";
        lbVehicleType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // cbShift
        // 
        cbShift.FormattingEnabled = true;
        cbShift.Items.AddRange(new object[] { "Cả Ngày", "Sáng", "Tối" });
        cbShift.Location = new System.Drawing.Point(291, 31);
        cbShift.Name = "cbShift";
        cbShift.Size = new System.Drawing.Size(143, 23);
        cbShift.TabIndex = 5;
        cbShift.DropDownStyle = ComboBoxStyle.DropDownList;
        cbShift.SelectedIndex = 0;
        // 
        // grbFilter
        // 
        grbFilter.Controls.Add(dataGridViewFilter);
        grbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
        grbFilter.Location = new System.Drawing.Point(3, 66);
        grbFilter.Name = "grbFilter";
        grbFilter.Size = new System.Drawing.Size(579, 223);
        grbFilter.TabIndex = 1;
        grbFilter.TabStop = false;
        grbFilter.Text = "Chi tiết doanh thu";
        // 
        // dataGridViewFilter
        // 
        dataGridViewFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Date, Shift, VehicleType, TranSactionCount, TotalAmount, Hours });
        dataGridViewFilter.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewFilter.Location = new System.Drawing.Point(3, 19);
        dataGridViewFilter.Name = "dataGridViewFilter";
        dataGridViewFilter.Size = new System.Drawing.Size(573, 201);
        dataGridViewFilter.TabIndex = 0;
        dataGridViewFilter.Text = "dataGridView1";
        dataGridViewFilter.ReadOnly = true;
        dataGridViewFilter.AllowUserToAddRows = false;
        dataGridViewFilter.AllowUserToDeleteRows = false;
        dataGridViewFilter.RowHeadersVisible = false;
        dataGridViewFilter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewFilter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        // 
        // Hours
        // 
        Hours.HeaderText = "Số Giờ Đỗ";
        Hours.Name = "Hours";
        Hours.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        // 
        // TotalAmount
        // 
        TotalAmount.HeaderText = "Tổng Tiền";
        TotalAmount.Name = "TotalAmount";
        TotalAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        // 
        // TranSactionCount
        // 
        TranSactionCount.HeaderText = "Số Lần đỗ";
        TranSactionCount.Name = "TranSactionCount";
        TranSactionCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // VehicleType
        // 
        VehicleType.HeaderText = "Loại Xe";
        VehicleType.Name = "VehicleType";
        // 
        // Shift
        // 
        Shift.HeaderText = "Ca";
        Shift.Name = "Shift";
        // 
        // Date
        // 
        Date.HeaderText = "Ngày";
        Date.Name = "Date";
        // 
        // lbTotalRevenue
        // 
        lbTotalRevenue.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        lbTotalRevenue.Location = new System.Drawing.Point(6, 53);
        lbTotalRevenue.Name = "lbTotalRevenue";
        lbTotalRevenue.Size = new System.Drawing.Size(185, 23);
        lbTotalRevenue.TabIndex = 1;
        lbTotalRevenue.Text = "0 VND";
        lbTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbDayAmount
        // 
        lbDayAmount.Location = new System.Drawing.Point(6, 86);
        lbDayAmount.Name = "lbDayAmount";
        lbDayAmount.Size = new System.Drawing.Size(56, 23);
        lbDayAmount.TabIndex = 2;
        lbDayAmount.Text = "Ca Sáng";
        lbDayAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbNightAmount
        // 
        lbNightAmount.Location = new System.Drawing.Point(6, 109);
        lbNightAmount.Name = "lbNightAmount";
        lbNightAmount.Size = new System.Drawing.Size(56, 23);
        lbNightAmount.TabIndex = 3;
        lbNightAmount.Text = "Ca Tối";
        lbNightAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lbDayTotalAmount
        // 
        lbDayTotalAmount.Location = new System.Drawing.Point(149, 86);
        lbDayTotalAmount.Name = "lbDayTotalAmount";
        lbDayTotalAmount.Size = new System.Drawing.Size(42, 23);
        lbDayTotalAmount.TabIndex = 4;
        lbDayTotalAmount.Text = "0 VND";
        lbDayTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lbDayTotalAmount.SetBounds(62, 86, 132, 23);
        lbDayTotalAmount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lbNightTotalAmount
        // 
        lbNightTotalAmount.Location = new System.Drawing.Point(146, 109);
        lbNightTotalAmount.Name = "lbNightTotalAmount";
        lbNightTotalAmount.Size = new System.Drawing.Size(48, 23);
        lbNightTotalAmount.TabIndex = 5;
        lbNightTotalAmount.Text = "0 VND";
        lbNightTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        lbNightTotalAmount.SetBounds(62, 109, 132, 23);
        lbNightTotalAmount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panelThongke
        // 
        panelThongke.Location = new System.Drawing.Point(18, 135);
        panelThongke.Name = "panelThongke";
        panelThongke.Size = new System.Drawing.Size(151, 100);
        panelThongke.TabIndex = 7;
        panelThongke.Paint += PanelThongke_Paint;
        panelThongke.Resize += (_, _) => panelThongke.Invalidate();
        // 
        // FormDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(grbRevenue);
        Controls.Add(grbCurrentParking);
        Text = "FormDashboard";
        grbCurrentParking.ResumeLayout(false);
        flowLayoutPanelCurrentParking.ResumeLayout(false);
        panelParked.ResumeLayout(false);
        panelOccupancy.ResumeLayout(false);
        panelToday.ResumeLayout(false);
        panelMonthly.ResumeLayout(false);
        panelSlots.ResumeLayout(false);
        grbRevenue.ResumeLayout(false);
        flowLayoutPanelRevenue.ResumeLayout(false);
        flowLayoutPanelSummary.ResumeLayout(false);
        grbSummary.ResumeLayout(false);
        flowLayoutPanelFilter.ResumeLayout(false);
        tableLayoutPanelFilter.ResumeLayout(false);
        grbFilter.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridViewFilter).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panelThongke;

    private System.Windows.Forms.Label lbNightAmount;
    private System.Windows.Forms.Label lbDayTotalAmount;
    private System.Windows.Forms.Label lbNightTotalAmount;

    private System.Windows.Forms.Label lbDayAmount;

    private System.Windows.Forms.Label lbTotalRevenue;

    private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
    private System.Windows.Forms.DataGridViewTextBoxColumn TranSactionCount;
    private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
    private System.Windows.Forms.DataGridViewTextBoxColumn Hours;

    private System.Windows.Forms.ComboBox cbShift;
    private System.Windows.Forms.ComboBox cbVehicleType;

    private System.Windows.Forms.Label lbVehicleType;

    private System.Windows.Forms.Label lbShift;

    private System.Windows.Forms.DateTimePicker dtpEndDate;

    private System.Windows.Forms.Label lbEndDate;

    private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    private System.Windows.Forms.DataGridViewTextBoxColumn Shift;

    private System.Windows.Forms.DataGridView dataGridViewFilter;

    private System.Windows.Forms.GroupBox grbFilter;

    private System.Windows.Forms.DateTimePicker dtpStartDate;

    private System.Windows.Forms.Label lbStartDate;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilter;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFilter;

    private System.Windows.Forms.Label lbTitleSummary;

    private System.Windows.Forms.GroupBox grbSummary;

    private System.Windows.Forms.Button btRevenue;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSummary;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRevenue;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCurrentParking;

    private System.Windows.Forms.GroupBox grbRevenue;

    private System.Windows.Forms.Panel panelOccupancy;
    private System.Windows.Forms.Label lbSlotOccupancy;
    private System.Windows.Forms.Label lbTotalOccupancy;
    private System.Windows.Forms.Label lbOccupancy;
    private System.Windows.Forms.Panel panelToday;
    private System.Windows.Forms.Label lbCarToday;
    private System.Windows.Forms.Label lbMotobikeToday;
    private System.Windows.Forms.Label lbTotalToday;
    private System.Windows.Forms.Label lbToday;
    private System.Windows.Forms.Panel panelMonthly;
    private System.Windows.Forms.Label lbCarMonthly;
    private System.Windows.Forms.Label lbMotobikeMonthly;
    private System.Windows.Forms.Label lbTotalMonthly;
    private System.Windows.Forms.Label lbMonthly;
    private System.Windows.Forms.Panel panelParked;
    private System.Windows.Forms.Label lbCarParked;
    private System.Windows.Forms.Label lbMotobikeParked;
    private System.Windows.Forms.Label lbtotalParked;
    private System.Windows.Forms.Label lbParked;

    private System.Windows.Forms.Label lbCarSlots;

    private System.Windows.Forms.Label lbTotalSlots;
    private System.Windows.Forms.Label lbMotobikeSlots;

    private System.Windows.Forms.Label lbSlots;

    private System.Windows.Forms.Panel panelSlots;

    private System.Windows.Forms.GroupBox grbCurrentParking;

    #endregion
}