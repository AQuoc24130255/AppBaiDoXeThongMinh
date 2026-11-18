using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormManageTicket
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
        grbStats = new System.Windows.Forms.GroupBox();
        tlpStats = new System.Windows.Forms.TableLayoutPanel();
        pnlStatTotal = new System.Windows.Forms.Panel();
        lbTotalValue = new System.Windows.Forms.Label();
        lbTotalHeader = new System.Windows.Forms.Label();
        pnlStatInUse = new System.Windows.Forms.Panel();
        lbInUseValue = new System.Windows.Forms.Label();
        lbInUseHeader = new System.Windows.Forms.Label();
        pnlStatMonthly = new System.Windows.Forms.Panel();
        lbMonthlyValue = new System.Windows.Forms.Label();
        lbMonthlyHeader = new System.Windows.Forms.Label();
        pnlStatLocked = new System.Windows.Forms.Panel();
        lbLockedValue = new System.Windows.Forms.Label();
        lbLockedHeader = new System.Windows.Forms.Label();

        tlpMain = new System.Windows.Forms.TableLayoutPanel();

        grbList = new System.Windows.Forms.GroupBox();
        dgvTickets = new System.Windows.Forms.DataGridView();
        colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colVType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colExit = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colMonthly = new System.Windows.Forms.DataGridViewTextBoxColumn();
        pnlGridButtons = new System.Windows.Forms.Panel();
        btLock = new System.Windows.Forms.Button();
        btDelete = new System.Windows.Forms.Button();
        btRefresh = new System.Windows.Forms.Button();
        pnlSearch = new System.Windows.Forms.Panel();
        txtSearch = new System.Windows.Forms.TextBox();
        cbFilter = new System.Windows.Forms.ComboBox();
        btSearch = new System.Windows.Forms.Button();

        grbAdd = new System.Windows.Forms.GroupBox();
        lbPlate = new System.Windows.Forms.Label();
        txtPlate = new System.Windows.Forms.TextBox();
        lbVehicleType = new System.Windows.Forms.Label();
        cbVehicleType = new System.Windows.Forms.ComboBox();
        chkMonthly = new System.Windows.Forms.CheckBox();
        grbOwner = new System.Windows.Forms.GroupBox();
        lbOwnerName = new System.Windows.Forms.Label();
        txtOwnerName = new System.Windows.Forms.TextBox();
        lbPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lbMonths = new System.Windows.Forms.Label();
        nudMonths = new System.Windows.Forms.NumericUpDown();
        lbFee = new System.Windows.Forms.Label();
        nudFee = new System.Windows.Forms.NumericUpDown();
        btAdd = new System.Windows.Forms.Button();
        btClear = new System.Windows.Forms.Button();

        grbStats.SuspendLayout();
        tlpStats.SuspendLayout();
        pnlStatTotal.SuspendLayout();
        pnlStatInUse.SuspendLayout();
        pnlStatMonthly.SuspendLayout();
        pnlStatLocked.SuspendLayout();
        tlpMain.SuspendLayout();
        grbList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
        pnlGridButtons.SuspendLayout();
        pnlSearch.SuspendLayout();
        grbAdd.SuspendLayout();
        grbOwner.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFee).BeginInit();
        SuspendLayout();

        // =====================================================
        //  THỐNG KÊ (phía trên)
        // =====================================================
        //
        // grbStats
        //
        grbStats.Controls.Add(tlpStats);
        grbStats.Dock = System.Windows.Forms.DockStyle.Top;
        grbStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbStats.Location = new System.Drawing.Point(0, 0);
        grbStats.Name = "grbStats";
        grbStats.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
        grbStats.Size = new System.Drawing.Size(1100, 112);
        grbStats.TabIndex = 1;
        grbStats.TabStop = false;
        grbStats.Text = "Thống kê vé";
        //
        // tlpStats
        //
        tlpStats.ColumnCount = 4;
        tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpStats.Controls.Add(pnlStatTotal, 0, 0);
        tlpStats.Controls.Add(pnlStatInUse, 1, 0);
        tlpStats.Controls.Add(pnlStatMonthly, 2, 0);
        tlpStats.Controls.Add(pnlStatLocked, 3, 0);
        tlpStats.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpStats.Location = new System.Drawing.Point(6, 24);
        tlpStats.Name = "tlpStats";
        tlpStats.RowCount = 1;
        tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpStats.Size = new System.Drawing.Size(1088, 82);
        tlpStats.TabIndex = 0;
        //
        // pnlStatTotal
        //
        pnlStatTotal.BackColor = System.Drawing.Color.White;
        pnlStatTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatTotal.Controls.Add(lbTotalValue);
        pnlStatTotal.Controls.Add(lbTotalHeader);
        pnlStatTotal.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatTotal.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatTotal.Name = "pnlStatTotal";
        pnlStatTotal.TabIndex = 0;
        //
        // lbTotalHeader
        //
        lbTotalHeader.BackColor = System.Drawing.Color.FromArgb(173, 216, 250);
        lbTotalHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbTotalHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbTotalHeader.Name = "lbTotalHeader";
        lbTotalHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbTotalHeader.Size = new System.Drawing.Size(100, 26);
        lbTotalHeader.TabIndex = 0;
        lbTotalHeader.Text = "Tổng số vé";
        lbTotalHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbTotalValue
        //
        lbTotalValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbTotalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbTotalValue.ForeColor = System.Drawing.Color.FromArgb(70, 130, 190);
        lbTotalValue.Name = "lbTotalValue";
        lbTotalValue.TabIndex = 1;
        lbTotalValue.Text = "0";
        lbTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlStatInUse
        //
        pnlStatInUse.BackColor = System.Drawing.Color.White;
        pnlStatInUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatInUse.Controls.Add(lbInUseValue);
        pnlStatInUse.Controls.Add(lbInUseHeader);
        pnlStatInUse.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatInUse.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatInUse.Name = "pnlStatInUse";
        pnlStatInUse.TabIndex = 1;
        //
        // lbInUseHeader
        //
        lbInUseHeader.BackColor = System.Drawing.Color.FromArgb(160, 220, 205);
        lbInUseHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbInUseHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbInUseHeader.Name = "lbInUseHeader";
        lbInUseHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbInUseHeader.Size = new System.Drawing.Size(100, 26);
        lbInUseHeader.TabIndex = 0;
        lbInUseHeader.Text = "Vé đang sử dụng";
        lbInUseHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbInUseValue
        //
        lbInUseValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbInUseValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbInUseValue.ForeColor = System.Drawing.Color.FromArgb(70, 160, 90);
        lbInUseValue.Name = "lbInUseValue";
        lbInUseValue.TabIndex = 1;
        lbInUseValue.Text = "0";
        lbInUseValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlStatMonthly
        //
        pnlStatMonthly.BackColor = System.Drawing.Color.White;
        pnlStatMonthly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatMonthly.Controls.Add(lbMonthlyValue);
        pnlStatMonthly.Controls.Add(lbMonthlyHeader);
        pnlStatMonthly.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatMonthly.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatMonthly.Name = "pnlStatMonthly";
        pnlStatMonthly.TabIndex = 2;
        //
        // lbMonthlyHeader
        //
        lbMonthlyHeader.BackColor = System.Drawing.Color.FromArgb(252, 205, 140);
        lbMonthlyHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbMonthlyHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbMonthlyHeader.Name = "lbMonthlyHeader";
        lbMonthlyHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbMonthlyHeader.Size = new System.Drawing.Size(100, 26);
        lbMonthlyHeader.TabIndex = 0;
        lbMonthlyHeader.Text = "Vé tháng";
        lbMonthlyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbMonthlyValue
        //
        lbMonthlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbMonthlyValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbMonthlyValue.ForeColor = System.Drawing.Color.FromArgb(225, 150, 40);
        lbMonthlyValue.Name = "lbMonthlyValue";
        lbMonthlyValue.TabIndex = 1;
        lbMonthlyValue.Text = "0";
        lbMonthlyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlStatLocked
        //
        pnlStatLocked.BackColor = System.Drawing.Color.White;
        pnlStatLocked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatLocked.Controls.Add(lbLockedValue);
        pnlStatLocked.Controls.Add(lbLockedHeader);
        pnlStatLocked.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatLocked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatLocked.Name = "pnlStatLocked";
        pnlStatLocked.TabIndex = 3;
        //
        // lbLockedHeader
        //
        lbLockedHeader.BackColor = System.Drawing.Color.FromArgb(250, 170, 175);
        lbLockedHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbLockedHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbLockedHeader.Name = "lbLockedHeader";
        lbLockedHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbLockedHeader.Size = new System.Drawing.Size(100, 26);
        lbLockedHeader.TabIndex = 0;
        lbLockedHeader.Text = "Vé bị khóa";
        lbLockedHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbLockedValue
        //
        lbLockedValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbLockedValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbLockedValue.ForeColor = System.Drawing.Color.FromArgb(215, 90, 90);
        lbLockedValue.Name = "lbLockedValue";
        lbLockedValue.TabIndex = 1;
        lbLockedValue.Text = "0";
        lbLockedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // =====================================================
        //  NỘI DUNG: DANH SÁCH VÉ (trái) + THÊM VÉ (phải)
        // =====================================================
        //
        // tlpMain
        //
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
        tlpMain.Controls.Add(grbList, 0, 0);
        tlpMain.Controls.Add(grbAdd, 1, 0);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMain.Location = new System.Drawing.Point(0, 112);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new System.Windows.Forms.Padding(6);
        tlpMain.RowCount = 1;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.Size = new System.Drawing.Size(1100, 588);
        tlpMain.TabIndex = 0;
        //
        // grbList
        //
        grbList.Controls.Add(dgvTickets);
        grbList.Controls.Add(pnlGridButtons);
        grbList.Controls.Add(pnlSearch);
        grbList.Dock = System.Windows.Forms.DockStyle.Fill;
        grbList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbList.Location = new System.Drawing.Point(9, 9);
        grbList.Name = "grbList";
        grbList.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
        grbList.Size = new System.Drawing.Size(678, 570);
        grbList.TabIndex = 0;
        grbList.TabStop = false;
        grbList.Text = "Danh sách vé";
        //
        // pnlSearch
        //
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Controls.Add(cbFilter);
        pnlSearch.Controls.Add(btSearch);
        pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
        pnlSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        pnlSearch.Location = new System.Drawing.Point(8, 22);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Size = new System.Drawing.Size(662, 44);
        pnlSearch.TabIndex = 2;
        //
        // txtSearch
        //
        txtSearch.Location = new System.Drawing.Point(0, 10);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Biển số hoặc mã vé";
        txtSearch.Size = new System.Drawing.Size(220, 24);
        txtSearch.TabIndex = 0;
        //
        // cbFilter
        //
        cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbFilter.FormattingEnabled = true;
        cbFilter.Items.AddRange(new object[] { "Tất cả", "Đang sử dụng", "Đã ra khỏi bãi", "Bị khóa", "Vé tháng" });
        cbFilter.Location = new System.Drawing.Point(230, 10);
        cbFilter.Name = "cbFilter";
        cbFilter.Size = new System.Drawing.Size(150, 25);
        cbFilter.TabIndex = 1;
        //
        // btSearch
        //
        btSearch.Location = new System.Drawing.Point(390, 8);
        btSearch.Name = "btSearch";
        btSearch.Size = new System.Drawing.Size(90, 29);
        btSearch.TabIndex = 2;
        btSearch.Text = "Tìm kiếm";
        btSearch.UseVisualStyleBackColor = true;
        //
        // dgvTickets
        //
        dgvTickets.AllowUserToAddRows = false;
        dgvTickets.AllowUserToDeleteRows = false;
        dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvTickets.BackgroundColor = System.Drawing.Color.White;
        dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colCode, colPlate, colVType, colEntry, colExit, colStatus, colMonthly });
        dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvTickets.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dgvTickets.Location = new System.Drawing.Point(8, 66);
        dgvTickets.MultiSelect = false;
        dgvTickets.Name = "dgvTickets";
        dgvTickets.ReadOnly = true;
        dgvTickets.RowHeadersVisible = false;
        dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvTickets.Size = new System.Drawing.Size(662, 448);
        dgvTickets.TabIndex = 0;
        //
        // colId
        //
        colId.FillWeight = 35F;
        colId.HeaderText = "ID";
        colId.Name = "colId";
        colId.ReadOnly = true;
        //
        // colCode
        //
        colCode.FillWeight = 90F;
        colCode.HeaderText = "Mã vé";
        colCode.Name = "colCode";
        colCode.ReadOnly = true;
        //
        // colPlate
        //
        colPlate.FillWeight = 85F;
        colPlate.HeaderText = "Biển số";
        colPlate.Name = "colPlate";
        colPlate.ReadOnly = true;
        //
        // colVType
        //
        colVType.FillWeight = 60F;
        colVType.HeaderText = "Loại xe";
        colVType.Name = "colVType";
        colVType.ReadOnly = true;
        //
        // colEntry
        //
        colEntry.FillWeight = 105F;
        colEntry.HeaderText = "Giờ vào";
        colEntry.Name = "colEntry";
        colEntry.ReadOnly = true;
        //
        // colExit
        //
        colExit.FillWeight = 105F;
        colExit.HeaderText = "Giờ ra";
        colExit.Name = "colExit";
        colExit.ReadOnly = true;
        //
        // colStatus
        //
        colStatus.FillWeight = 85F;
        colStatus.HeaderText = "Trạng thái";
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        //
        // colMonthly
        //
        colMonthly.FillWeight = 55F;
        colMonthly.HeaderText = "Vé tháng";
        colMonthly.Name = "colMonthly";
        colMonthly.ReadOnly = true;
        //
        // pnlGridButtons
        //
        pnlGridButtons.Controls.Add(btLock);
        pnlGridButtons.Controls.Add(btDelete);
        pnlGridButtons.Controls.Add(btRefresh);
        pnlGridButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlGridButtons.Location = new System.Drawing.Point(8, 514);
        pnlGridButtons.Name = "pnlGridButtons";
        pnlGridButtons.Size = new System.Drawing.Size(662, 48);
        pnlGridButtons.TabIndex = 1;
        //
        // btLock
        //
        btLock.BackColor = System.Drawing.Color.FromArgb(230, 150, 40);
        btLock.FlatAppearance.BorderSize = 0;
        btLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btLock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btLock.ForeColor = System.Drawing.Color.White;
        btLock.Location = new System.Drawing.Point(0, 10);
        btLock.Name = "btLock";
        btLock.Size = new System.Drawing.Size(130, 34);
        btLock.TabIndex = 0;
        btLock.Text = "Khóa vé";
        btLock.UseVisualStyleBackColor = false;
        //
        // btDelete
        //
        btDelete.BackColor = System.Drawing.Color.FromArgb(200, 60, 55);
        btDelete.FlatAppearance.BorderSize = 0;
        btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btDelete.ForeColor = System.Drawing.Color.White;
        btDelete.Location = new System.Drawing.Point(140, 10);
        btDelete.Name = "btDelete";
        btDelete.Size = new System.Drawing.Size(130, 34);
        btDelete.TabIndex = 1;
        btDelete.Text = "Xóa vé";
        btDelete.UseVisualStyleBackColor = false;
        //
        // btRefresh
        //
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(280, 10);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(110, 34);
        btRefresh.TabIndex = 2;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;

        // ---------- Thêm vé mới (bên phải) ----------
        //
        // grbAdd
        //
        grbAdd.Controls.Add(lbPlate);
        grbAdd.Controls.Add(txtPlate);
        grbAdd.Controls.Add(lbVehicleType);
        grbAdd.Controls.Add(cbVehicleType);
        grbAdd.Controls.Add(chkMonthly);
        grbAdd.Controls.Add(grbOwner);
        grbAdd.Controls.Add(btAdd);
        grbAdd.Controls.Add(btClear);
        grbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        grbAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbAdd.Location = new System.Drawing.Point(693, 9);
        grbAdd.Name = "grbAdd";
        grbAdd.Size = new System.Drawing.Size(398, 570);
        grbAdd.TabIndex = 1;
        grbAdd.TabStop = false;
        grbAdd.Text = "Thêm vé mới";
        //
        // lbPlate
        //
        lbPlate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbPlate.Location = new System.Drawing.Point(16, 30);
        lbPlate.Name = "lbPlate";
        lbPlate.Size = new System.Drawing.Size(340, 20);
        lbPlate.TabIndex = 0;
        lbPlate.Text = "Biển số xe";
        //
        // txtPlate
        //
        txtPlate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        txtPlate.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPlate.Location = new System.Drawing.Point(16, 52);
        txtPlate.MaxLength = 20;
        txtPlate.Name = "txtPlate";
        txtPlate.Size = new System.Drawing.Size(366, 25);
        txtPlate.TabIndex = 1;
        //
        // lbVehicleType
        //
        lbVehicleType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbVehicleType.Location = new System.Drawing.Point(16, 88);
        lbVehicleType.Name = "lbVehicleType";
        lbVehicleType.Size = new System.Drawing.Size(340, 20);
        lbVehicleType.TabIndex = 2;
        lbVehicleType.Text = "Loại xe";
        //
        // cbVehicleType
        //
        cbVehicleType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
        cbVehicleType.FormattingEnabled = true;
        cbVehicleType.Items.AddRange(new object[] { "Xe máy", "Ô tô" });
        cbVehicleType.Location = new System.Drawing.Point(16, 110);
        cbVehicleType.Name = "cbVehicleType";
        cbVehicleType.Size = new System.Drawing.Size(366, 25);
        cbVehicleType.TabIndex = 3;
        //
        // chkMonthly
        //
        chkMonthly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        chkMonthly.Location = new System.Drawing.Point(16, 148);
        chkMonthly.Name = "chkMonthly";
        chkMonthly.Size = new System.Drawing.Size(340, 26);
        chkMonthly.TabIndex = 4;
        chkMonthly.Text = "Đây là vé tháng";
        chkMonthly.UseVisualStyleBackColor = true;
        //
        // grbOwner
        //
        grbOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        grbOwner.Controls.Add(lbOwnerName);
        grbOwner.Controls.Add(txtOwnerName);
        grbOwner.Controls.Add(lbPhone);
        grbOwner.Controls.Add(txtPhone);
        grbOwner.Controls.Add(lbMonths);
        grbOwner.Controls.Add(nudMonths);
        grbOwner.Controls.Add(lbFee);
        grbOwner.Controls.Add(nudFee);
        grbOwner.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        grbOwner.Location = new System.Drawing.Point(16, 182);
        grbOwner.Name = "grbOwner";
        grbOwner.Size = new System.Drawing.Size(366, 200);
        grbOwner.TabIndex = 5;
        grbOwner.TabStop = false;
        grbOwner.Text = "Thông tin chủ xe (bắt buộc với vé tháng)";
        //
        // lbOwnerName
        //
        lbOwnerName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbOwnerName.Location = new System.Drawing.Point(12, 26);
        lbOwnerName.Name = "lbOwnerName";
        lbOwnerName.Size = new System.Drawing.Size(340, 20);
        lbOwnerName.TabIndex = 0;
        lbOwnerName.Text = "Họ tên chủ xe";
        //
        // txtOwnerName
        //
        txtOwnerName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtOwnerName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtOwnerName.Location = new System.Drawing.Point(12, 48);
        txtOwnerName.MaxLength = 100;
        txtOwnerName.Name = "txtOwnerName";
        txtOwnerName.Size = new System.Drawing.Size(342, 25);
        txtOwnerName.TabIndex = 1;
        //
        // lbPhone
        //
        lbPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbPhone.Location = new System.Drawing.Point(12, 82);
        lbPhone.Name = "lbPhone";
        lbPhone.Size = new System.Drawing.Size(340, 20);
        lbPhone.TabIndex = 2;
        lbPhone.Text = "Số điện thoại";
        //
        // txtPhone
        //
        txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPhone.Location = new System.Drawing.Point(12, 104);
        txtPhone.MaxLength = 20;
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new System.Drawing.Size(342, 25);
        txtPhone.TabIndex = 3;
        //
        // lbMonths
        //
        lbMonths.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbMonths.Location = new System.Drawing.Point(12, 138);
        lbMonths.Name = "lbMonths";
        lbMonths.Size = new System.Drawing.Size(120, 20);
        lbMonths.TabIndex = 4;
        lbMonths.Text = "Số tháng đăng ký";
        //
        // nudMonths
        //
        nudMonths.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudMonths.Location = new System.Drawing.Point(12, 160);
        nudMonths.Maximum = new decimal(new int[] { 36, 0, 0, 0 });
        nudMonths.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudMonths.Name = "nudMonths";
        nudMonths.Size = new System.Drawing.Size(120, 25);
        nudMonths.TabIndex = 5;
        nudMonths.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // lbFee
        //
        lbFee.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbFee.Location = new System.Drawing.Point(150, 138);
        lbFee.Name = "lbFee";
        lbFee.Size = new System.Drawing.Size(190, 20);
        lbFee.TabIndex = 6;
        lbFee.Text = "Phí hàng tháng (VNĐ)";
        //
        // nudFee
        //
        nudFee.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudFee.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
        nudFee.Location = new System.Drawing.Point(150, 160);
        nudFee.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudFee.Name = "nudFee";
        nudFee.Size = new System.Drawing.Size(204, 25);
        nudFee.TabIndex = 7;
        nudFee.ThousandsSeparator = true;
        //
        // btAdd
        //
        btAdd.BackColor = System.Drawing.Color.FromArgb(25, 105, 170);
        btAdd.FlatAppearance.BorderSize = 0;
        btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btAdd.ForeColor = System.Drawing.Color.White;
        btAdd.Location = new System.Drawing.Point(16, 400);
        btAdd.Name = "btAdd";
        btAdd.Size = new System.Drawing.Size(150, 38);
        btAdd.TabIndex = 6;
        btAdd.Text = "Thêm vé";
        btAdd.UseVisualStyleBackColor = false;
        //
        // btClear
        //
        btClear.Font = new System.Drawing.Font("Segoe UI", 10F);
        btClear.Location = new System.Drawing.Point(176, 400);
        btClear.Name = "btClear";
        btClear.Size = new System.Drawing.Size(110, 38);
        btClear.TabIndex = 7;
        btClear.Text = "Nhập lại";
        btClear.UseVisualStyleBackColor = true;

        //
        // FormManageTicket
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(243, 246, 250);
        ClientSize = new System.Drawing.Size(1100, 700);
        Controls.Add(tlpMain);
        Controls.Add(grbStats);
        MinimumSize = new System.Drawing.Size(1000, 650);
        Name = "FormManageTicket";
        Text = "Quản lý vé";

        grbStats.ResumeLayout(false);
        tlpStats.ResumeLayout(false);
        pnlStatTotal.ResumeLayout(false);
        pnlStatInUse.ResumeLayout(false);
        pnlStatMonthly.ResumeLayout(false);
        pnlStatLocked.ResumeLayout(false);
        tlpMain.ResumeLayout(false);
        grbList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
        pnlGridButtons.ResumeLayout(false);
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        grbAdd.ResumeLayout(false);
        grbAdd.PerformLayout();
        grbOwner.ResumeLayout(false);
        grbOwner.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFee).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grbStats;
    private System.Windows.Forms.TableLayoutPanel tlpStats;
    private System.Windows.Forms.Panel pnlStatTotal;
    private System.Windows.Forms.Label lbTotalValue;
    private System.Windows.Forms.Label lbTotalHeader;
    private System.Windows.Forms.Panel pnlStatInUse;
    private System.Windows.Forms.Label lbInUseValue;
    private System.Windows.Forms.Label lbInUseHeader;
    private System.Windows.Forms.Panel pnlStatMonthly;
    private System.Windows.Forms.Label lbMonthlyValue;
    private System.Windows.Forms.Label lbMonthlyHeader;
    private System.Windows.Forms.Panel pnlStatLocked;
    private System.Windows.Forms.Label lbLockedValue;
    private System.Windows.Forms.Label lbLockedHeader;

    private System.Windows.Forms.TableLayoutPanel tlpMain;

    private System.Windows.Forms.GroupBox grbList;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.ComboBox cbFilter;
    private System.Windows.Forms.Button btSearch;
    private System.Windows.Forms.DataGridView dgvTickets;
    private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPlate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colVType;
    private System.Windows.Forms.DataGridViewTextBoxColumn colEntry;
    private System.Windows.Forms.DataGridViewTextBoxColumn colExit;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMonthly;
    private System.Windows.Forms.Panel pnlGridButtons;
    private System.Windows.Forms.Button btLock;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Button btRefresh;

    private System.Windows.Forms.GroupBox grbAdd;
    private System.Windows.Forms.Label lbPlate;
    private System.Windows.Forms.TextBox txtPlate;
    private System.Windows.Forms.Label lbVehicleType;
    private System.Windows.Forms.ComboBox cbVehicleType;
    private System.Windows.Forms.CheckBox chkMonthly;
    private System.Windows.Forms.GroupBox grbOwner;
    private System.Windows.Forms.Label lbOwnerName;
    private System.Windows.Forms.TextBox txtOwnerName;
    private System.Windows.Forms.Label lbPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label lbMonths;
    private System.Windows.Forms.NumericUpDown nudMonths;
    private System.Windows.Forms.Label lbFee;
    private System.Windows.Forms.NumericUpDown nudFee;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btClear;

    #endregion
}