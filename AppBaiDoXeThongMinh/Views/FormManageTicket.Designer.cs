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
        pnlGridButtons = new System.Windows.Forms.Panel();
        btRegularMode = new System.Windows.Forms.Button();
        btMonthlyMode = new System.Windows.Forms.Button();
        pnlSearch = new System.Windows.Forms.Panel();
        txtSearch = new System.Windows.Forms.TextBox();
        cbFilter = new System.Windows.Forms.ComboBox();
        btSearch = new System.Windows.Forms.Button();

        pnlRightHost = new System.Windows.Forms.Panel();

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
        SuspendLayout();

        // =====================================================
        //  THỐNG KÊ (phía trên)
        // =====================================================
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

        pnlStatTotal.BackColor = System.Drawing.Color.White;
        pnlStatTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatTotal.Controls.Add(lbTotalValue);
        pnlStatTotal.Controls.Add(lbTotalHeader);
        pnlStatTotal.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatTotal.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatTotal.Name = "pnlStatTotal";
        pnlStatTotal.TabIndex = 0;

        lbTotalHeader.BackColor = System.Drawing.Color.FromArgb(173, 216, 250);
        lbTotalHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbTotalHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbTotalHeader.Name = "lbTotalHeader";
        lbTotalHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbTotalHeader.Size = new System.Drawing.Size(100, 26);
        lbTotalHeader.TabIndex = 0;
        lbTotalHeader.Text = "Tổng số vé";
        lbTotalHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        lbTotalValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbTotalValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbTotalValue.ForeColor = System.Drawing.Color.FromArgb(70, 130, 190);
        lbTotalValue.Name = "lbTotalValue";
        lbTotalValue.TabIndex = 1;
        lbTotalValue.Text = "0";
        lbTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        pnlStatInUse.BackColor = System.Drawing.Color.White;
        pnlStatInUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatInUse.Controls.Add(lbInUseValue);
        pnlStatInUse.Controls.Add(lbInUseHeader);
        pnlStatInUse.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatInUse.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatInUse.Name = "pnlStatInUse";
        pnlStatInUse.TabIndex = 1;

        lbInUseHeader.BackColor = System.Drawing.Color.FromArgb(160, 220, 205);
        lbInUseHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbInUseHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbInUseHeader.Name = "lbInUseHeader";
        lbInUseHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbInUseHeader.Size = new System.Drawing.Size(100, 26);
        lbInUseHeader.TabIndex = 0;
        lbInUseHeader.Text = "Vé đang sử dụng";
        lbInUseHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        lbInUseValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbInUseValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbInUseValue.ForeColor = System.Drawing.Color.FromArgb(70, 160, 90);
        lbInUseValue.Name = "lbInUseValue";
        lbInUseValue.TabIndex = 1;
        lbInUseValue.Text = "0";
        lbInUseValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        pnlStatMonthly.BackColor = System.Drawing.Color.White;
        pnlStatMonthly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatMonthly.Controls.Add(lbMonthlyValue);
        pnlStatMonthly.Controls.Add(lbMonthlyHeader);
        pnlStatMonthly.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatMonthly.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatMonthly.Name = "pnlStatMonthly";
        pnlStatMonthly.TabIndex = 2;

        lbMonthlyHeader.BackColor = System.Drawing.Color.FromArgb(252, 205, 140);
        lbMonthlyHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbMonthlyHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbMonthlyHeader.Name = "lbMonthlyHeader";
        lbMonthlyHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbMonthlyHeader.Size = new System.Drawing.Size(100, 26);
        lbMonthlyHeader.TabIndex = 0;
        lbMonthlyHeader.Text = "Vé tháng";
        lbMonthlyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        lbMonthlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbMonthlyValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbMonthlyValue.ForeColor = System.Drawing.Color.FromArgb(225, 150, 40);
        lbMonthlyValue.Name = "lbMonthlyValue";
        lbMonthlyValue.TabIndex = 1;
        lbMonthlyValue.Text = "0";
        lbMonthlyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        pnlStatLocked.BackColor = System.Drawing.Color.White;
        pnlStatLocked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlStatLocked.Controls.Add(lbLockedValue);
        pnlStatLocked.Controls.Add(lbLockedHeader);
        pnlStatLocked.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlStatLocked.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        pnlStatLocked.Name = "pnlStatLocked";
        pnlStatLocked.TabIndex = 3;

        lbLockedHeader.BackColor = System.Drawing.Color.FromArgb(250, 170, 175);
        lbLockedHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbLockedHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbLockedHeader.Name = "lbLockedHeader";
        lbLockedHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbLockedHeader.Size = new System.Drawing.Size(100, 26);
        lbLockedHeader.TabIndex = 0;
        lbLockedHeader.Text = "Vé bị khóa";
        lbLockedHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        lbLockedValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbLockedValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        lbLockedValue.ForeColor = System.Drawing.Color.FromArgb(215, 90, 90);
        lbLockedValue.Name = "lbLockedValue";
        lbLockedValue.TabIndex = 1;
        lbLockedValue.Text = "0";
        lbLockedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // =====================================================
        //  NỘI DUNG: DANH SÁCH VÉ (trái) + USER CONTROL (phải)
        // =====================================================
        
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
        tlpMain.Controls.Add(grbList, 0, 0);
        tlpMain.Controls.Add(pnlRightHost, 1, 0);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMain.Location = new System.Drawing.Point(0, 112);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new System.Windows.Forms.Padding(6);
        tlpMain.RowCount = 1;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.Size = new System.Drawing.Size(1100, 588);
        tlpMain.TabIndex = 0;
        
        // ---------- Bên trái: Danh sách ----------
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
        
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Controls.Add(cbFilter);
        pnlSearch.Controls.Add(btSearch);
        pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
        pnlSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        pnlSearch.Location = new System.Drawing.Point(8, 22);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Size = new System.Drawing.Size(662, 44);
        pnlSearch.TabIndex = 2;
        
        txtSearch.Location = new System.Drawing.Point(0, 10);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Biển số, mã vé";
        txtSearch.Size = new System.Drawing.Size(220, 24);
        txtSearch.TabIndex = 0;
        
        cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbFilter.FormattingEnabled = true;
        cbFilter.Location = new System.Drawing.Point(230, 10);
        cbFilter.Name = "cbFilter";
        cbFilter.Size = new System.Drawing.Size(150, 25);
        cbFilter.TabIndex = 1;
        
        btSearch.Location = new System.Drawing.Point(390, 8);
        btSearch.Name = "btSearch";
        btSearch.Size = new System.Drawing.Size(90, 29);
        btSearch.TabIndex = 2;
        btSearch.Text = "Tìm kiếm";
        btSearch.UseVisualStyleBackColor = true;
        
        dgvTickets.AllowUserToAddRows = false;
        dgvTickets.AllowUserToDeleteRows = false;
        dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
        dgvTickets.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        dgvTickets.BackgroundColor = System.Drawing.Color.White;
        dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
        
        pnlGridButtons.Controls.Add(btRegularMode);
        pnlGridButtons.Controls.Add(btMonthlyMode);
        pnlGridButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlGridButtons.Location = new System.Drawing.Point(8, 514);
        pnlGridButtons.Name = "pnlGridButtons";
        pnlGridButtons.Size = new System.Drawing.Size(662, 48);
        pnlGridButtons.TabIndex = 1;
        
        btRegularMode.BackColor = System.Drawing.Color.FromArgb(25, 105, 170);
        btRegularMode.FlatAppearance.BorderSize = 0;
        btRegularMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btRegularMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btRegularMode.ForeColor = System.Drawing.Color.White;
        btRegularMode.Location = new System.Drawing.Point(0, 10);
        btRegularMode.Name = "btRegularMode";
        btRegularMode.Size = new System.Drawing.Size(140, 34);
        btRegularMode.TabIndex = 0;
        btRegularMode.Text = "Vé thường";
        btRegularMode.UseVisualStyleBackColor = false;
        
        btMonthlyMode.BackColor = System.Drawing.Color.FromArgb(215, 222, 230);
        btMonthlyMode.FlatAppearance.BorderSize = 0;
        btMonthlyMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btMonthlyMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btMonthlyMode.ForeColor = System.Drawing.Color.Black;
        btMonthlyMode.Location = new System.Drawing.Point(150, 10);
        btMonthlyMode.Name = "btMonthlyMode";
        btMonthlyMode.Size = new System.Drawing.Size(140, 34);
        btMonthlyMode.TabIndex = 1;
        btMonthlyMode.Text = "Vé tháng";
        btMonthlyMode.UseVisualStyleBackColor = false;
        
        // ---------- Bên phải: Vùng chứa 2 User Control ----------
        pnlRightHost.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlRightHost.Location = new System.Drawing.Point(693, 9);
        pnlRightHost.Name = "pnlRightHost";
        pnlRightHost.Size = new System.Drawing.Size(398, 570);
        pnlRightHost.TabIndex = 1;
        
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
    private System.Windows.Forms.Panel pnlGridButtons;
    private System.Windows.Forms.Button btRegularMode;
    private System.Windows.Forms.Button btMonthlyMode;
    
    private System.Windows.Forms.Panel pnlRightHost;
    
    #endregion
}