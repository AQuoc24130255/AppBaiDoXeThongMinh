using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormManagePriceConfig
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
        tlpMain = new System.Windows.Forms.TableLayoutPanel();

        grbList = new System.Windows.Forms.GroupBox();
        dgvPrices = new System.Windows.Forms.DataGridView();
        colConfigId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colVType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDayPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNightPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTimeUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNightStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNightEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colLostFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
        pnlGridButtons = new System.Windows.Forms.Panel();
        btRefresh = new System.Windows.Forms.Button();

        grbEdit = new System.Windows.Forms.GroupBox();
        lbMode = new System.Windows.Forms.Label();
        lbConfigId = new System.Windows.Forms.Label();
        nudConfigId = new System.Windows.Forms.NumericUpDown();
        lbVehicleType = new System.Windows.Forms.Label();
        cbVehicleType = new System.Windows.Forms.ComboBox();
        lbDayPrice = new System.Windows.Forms.Label();
        nudDayPrice = new System.Windows.Forms.NumericUpDown();
        lbNightPrice = new System.Windows.Forms.Label();
        nudNightPrice = new System.Windows.Forms.NumericUpDown();
        lbTimeUnit = new System.Windows.Forms.Label();
        nudTimeUnit = new System.Windows.Forms.NumericUpDown();
        lbLostFee = new System.Windows.Forms.Label();
        nudLostFee = new System.Windows.Forms.NumericUpDown();
        lbNightStart = new System.Windows.Forms.Label();
        dtpNightStart = new System.Windows.Forms.DateTimePicker();
        lbNightEnd = new System.Windows.Forms.Label();
        dtpNightEnd = new System.Windows.Forms.DateTimePicker();
        lbHint = new System.Windows.Forms.Label();
        btSave = new System.Windows.Forms.Button();

        tlpMain.SuspendLayout();
        grbList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPrices).BeginInit();
        pnlGridButtons.SuspendLayout();
        grbEdit.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudConfigId).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudDayPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudNightPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTimeUnit).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudLostFee).BeginInit();
        SuspendLayout();

        //
        // tlpMain
        //
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
        tlpMain.Controls.Add(grbList, 0, 0);
        tlpMain.Controls.Add(grbEdit, 1, 0);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMain.Location = new System.Drawing.Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new System.Windows.Forms.Padding(8);
        tlpMain.RowCount = 1;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.Size = new System.Drawing.Size(1100, 560);
        tlpMain.TabIndex = 0;

        //
        // grbList
        //
        grbList.Controls.Add(dgvPrices);
        grbList.Controls.Add(pnlGridButtons);
        grbList.Dock = System.Windows.Forms.DockStyle.Fill;
        grbList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbList.Location = new System.Drawing.Point(11, 11);
        grbList.Name = "grbList";
        grbList.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
        grbList.Size = new System.Drawing.Size(613, 538);
        grbList.TabIndex = 0;
        grbList.TabStop = false;
        grbList.Text = "Danh sách cấu hình giá";
        //
        // dgvPrices
        //
        dgvPrices.AllowUserToAddRows = false;
        dgvPrices.AllowUserToDeleteRows = false;
        dgvPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvPrices.BackgroundColor = System.Drawing.Color.White;
        dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colConfigId, colVType, colDayPrice, colNightPrice, colTimeUnit, colNightStart, colNightEnd, colLostFee });
        dgvPrices.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvPrices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dgvPrices.Location = new System.Drawing.Point(8, 22);
        dgvPrices.MultiSelect = false;
        dgvPrices.Name = "dgvPrices";
        dgvPrices.ReadOnly = true;
        dgvPrices.RowHeadersVisible = false;
        dgvPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvPrices.Size = new System.Drawing.Size(597, 460);
        dgvPrices.TabIndex = 0;
        //
        // colConfigId
        //
        colConfigId.FillWeight = 40F;
        colConfigId.HeaderText = "ID";
        colConfigId.Name = "colConfigId";
        colConfigId.ReadOnly = true;
        colConfigId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //
        // colVType
        //
        colVType.FillWeight = 70F;
        colVType.HeaderText = "Loại xe";
        colVType.Name = "colVType";
        colVType.ReadOnly = true;
        //
        // colDayPrice
        //
        colDayPrice.FillWeight = 80F;
        colDayPrice.HeaderText = "Giá ngày";
        colDayPrice.Name = "colDayPrice";
        colDayPrice.ReadOnly = true;
        colDayPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //
        // colNightPrice
        //
        colNightPrice.FillWeight = 80F;
        colNightPrice.HeaderText = "Giá đêm";
        colNightPrice.Name = "colNightPrice";
        colNightPrice.ReadOnly = true;
        colNightPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //
        // colTimeUnit
        //
        colTimeUnit.FillWeight = 65F;
        colTimeUnit.HeaderText = "Block (giờ)";
        colTimeUnit.Name = "colTimeUnit";
        colTimeUnit.ReadOnly = true;
        colTimeUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //
        // colNightStart
        //
        colNightStart.FillWeight = 65F;
        colNightStart.HeaderText = "Đêm từ";
        colNightStart.Name = "colNightStart";
        colNightStart.ReadOnly = true;
        colNightStart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //
        // colNightEnd
        //
        colNightEnd.FillWeight = 65F;
        colNightEnd.HeaderText = "Đến";
        colNightEnd.Name = "colNightEnd";
        colNightEnd.ReadOnly = true;
        colNightEnd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //
        // colLostFee
        //
        colLostFee.FillWeight = 80F;
        colLostFee.HeaderText = "Phí mất vé";
        colLostFee.Name = "colLostFee";
        colLostFee.ReadOnly = true;
        colLostFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //
        // pnlGridButtons
        //
        pnlGridButtons.Controls.Add(btRefresh);
        pnlGridButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlGridButtons.Location = new System.Drawing.Point(8, 482);
        pnlGridButtons.Name = "pnlGridButtons";
        pnlGridButtons.Size = new System.Drawing.Size(597, 48);
        pnlGridButtons.TabIndex = 1;
        //
        // btRefresh
        //
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(0, 10);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(110, 34);
        btRefresh.TabIndex = 0;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;
        //
        // grbEdit
        //
        grbEdit.Controls.Add(lbMode);
        grbEdit.Controls.Add(lbConfigId);
        grbEdit.Controls.Add(nudConfigId);
        grbEdit.Controls.Add(lbVehicleType);
        grbEdit.Controls.Add(cbVehicleType);
        grbEdit.Controls.Add(lbDayPrice);
        grbEdit.Controls.Add(nudDayPrice);
        grbEdit.Controls.Add(lbNightPrice);
        grbEdit.Controls.Add(nudNightPrice);
        grbEdit.Controls.Add(lbTimeUnit);
        grbEdit.Controls.Add(nudTimeUnit);
        grbEdit.Controls.Add(lbLostFee);
        grbEdit.Controls.Add(nudLostFee);
        grbEdit.Controls.Add(lbNightStart);
        grbEdit.Controls.Add(dtpNightStart);
        grbEdit.Controls.Add(lbNightEnd);
        grbEdit.Controls.Add(dtpNightEnd);
        grbEdit.Controls.Add(lbHint);
        grbEdit.Controls.Add(btSave);
        grbEdit.Dock = System.Windows.Forms.DockStyle.Fill;
        grbEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbEdit.Location = new System.Drawing.Point(630, 11);
        grbEdit.Name = "grbEdit";
        grbEdit.Size = new System.Drawing.Size(459, 538);
        grbEdit.TabIndex = 1;
        grbEdit.TabStop = false;
        grbEdit.Text = "Chỉnh sửa cấu hình giá";
        //
        // lbMode
        //
        lbMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        lbMode.ForeColor = System.Drawing.Color.FromArgb(25, 105, 170);
        lbMode.Location = new System.Drawing.Point(16, 30);
        lbMode.Name = "lbMode";
        lbMode.Size = new System.Drawing.Size(420, 24);
        lbMode.TabIndex = 0;
        lbMode.Text = "Đang chỉnh sửa cấu hình";
        lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbConfigId
        //
        lbConfigId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbConfigId.Location = new System.Drawing.Point(16, 66);
        lbConfigId.Name = "lbConfigId";
        lbConfigId.Size = new System.Drawing.Size(190, 20);
        lbConfigId.TabIndex = 1;
        lbConfigId.Text = "Mã cấu hình (ConfigId)";
        //
        // nudConfigId
        //
        nudConfigId.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudConfigId.Location = new System.Drawing.Point(16, 88);
        nudConfigId.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        nudConfigId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudConfigId.Name = "nudConfigId";
        nudConfigId.Size = new System.Drawing.Size(190, 25);
        nudConfigId.TabIndex = 2;
        nudConfigId.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // lbVehicleType
        //
        lbVehicleType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbVehicleType.Location = new System.Drawing.Point(226, 66);
        lbVehicleType.Name = "lbVehicleType";
        lbVehicleType.Size = new System.Drawing.Size(190, 20);
        lbVehicleType.TabIndex = 3;
        lbVehicleType.Text = "Loại xe";
        //
        // cbVehicleType
        //
        cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
        cbVehicleType.FormattingEnabled = true;
        cbVehicleType.Items.AddRange(new object[] { "Xe máy", "Ô tô" });
        cbVehicleType.Location = new System.Drawing.Point(226, 88);
        cbVehicleType.Name = "cbVehicleType";
        cbVehicleType.Size = new System.Drawing.Size(210, 25);
        cbVehicleType.TabIndex = 4;
        //
        // lbDayPrice
        //
        lbDayPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbDayPrice.Location = new System.Drawing.Point(16, 128);
        lbDayPrice.Name = "lbDayPrice";
        lbDayPrice.Size = new System.Drawing.Size(190, 20);
        lbDayPrice.TabIndex = 5;
        lbDayPrice.Text = "Giá ban ngày / block (VNĐ)";
        //
        // nudDayPrice
        //
        nudDayPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudDayPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        nudDayPrice.Location = new System.Drawing.Point(16, 150);
        nudDayPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudDayPrice.Name = "nudDayPrice";
        nudDayPrice.Size = new System.Drawing.Size(190, 25);
        nudDayPrice.TabIndex = 6;
        nudDayPrice.ThousandsSeparator = true;
        //
        // lbNightPrice
        //
        lbNightPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbNightPrice.Location = new System.Drawing.Point(226, 128);
        lbNightPrice.Name = "lbNightPrice";
        lbNightPrice.Size = new System.Drawing.Size(210, 20);
        lbNightPrice.TabIndex = 7;
        lbNightPrice.Text = "Giá ban đêm / block (VNĐ)";
        //
        // nudNightPrice
        //
        nudNightPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudNightPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        nudNightPrice.Location = new System.Drawing.Point(226, 150);
        nudNightPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudNightPrice.Name = "nudNightPrice";
        nudNightPrice.Size = new System.Drawing.Size(210, 25);
        nudNightPrice.TabIndex = 8;
        nudNightPrice.ThousandsSeparator = true;
        //
        // lbTimeUnit
        //
        lbTimeUnit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbTimeUnit.Location = new System.Drawing.Point(16, 190);
        lbTimeUnit.Name = "lbTimeUnit";
        lbTimeUnit.Size = new System.Drawing.Size(190, 20);
        lbTimeUnit.TabIndex = 9;
        lbTimeUnit.Text = "Block tính phí (giờ)";
        //
        // nudTimeUnit
        //
        nudTimeUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudTimeUnit.Location = new System.Drawing.Point(16, 212);
        nudTimeUnit.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
        nudTimeUnit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTimeUnit.Name = "nudTimeUnit";
        nudTimeUnit.Size = new System.Drawing.Size(190, 25);
        nudTimeUnit.TabIndex = 10;
        nudTimeUnit.Value = new decimal(new int[] { 60, 0, 0, 0 });
        //
        // lbLostFee
        //
        lbLostFee.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbLostFee.Location = new System.Drawing.Point(226, 190);
        lbLostFee.Name = "lbLostFee";
        lbLostFee.Size = new System.Drawing.Size(210, 20);
        lbLostFee.TabIndex = 11;
        lbLostFee.Text = "Phí mất vé (VNĐ)";
        //
        // nudLostFee
        //
        nudLostFee.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudLostFee.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        nudLostFee.Location = new System.Drawing.Point(226, 212);
        nudLostFee.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudLostFee.Name = "nudLostFee";
        nudLostFee.Size = new System.Drawing.Size(210, 25);
        nudLostFee.TabIndex = 12;
        nudLostFee.ThousandsSeparator = true;
        //
        // lbNightStart
        //
        lbNightStart.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbNightStart.Location = new System.Drawing.Point(16, 252);
        lbNightStart.Name = "lbNightStart";
        lbNightStart.Size = new System.Drawing.Size(190, 20);
        lbNightStart.TabIndex = 13;
        lbNightStart.Text = "Ban đêm bắt đầu lúc";
        //
        // dtpNightStart
        //
        dtpNightStart.CustomFormat = "HH:mm";
        dtpNightStart.Font = new System.Drawing.Font("Segoe UI", 10F);
        dtpNightStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNightStart.Location = new System.Drawing.Point(16, 274);
        dtpNightStart.Name = "dtpNightStart";
        dtpNightStart.ShowUpDown = true;
        dtpNightStart.Size = new System.Drawing.Size(190, 25);
        dtpNightStart.TabIndex = 14;
        dtpNightStart.Value = new System.DateTime(2000, 1, 1, 18, 0, 0, 0);
        //
        // lbNightEnd
        //
        lbNightEnd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbNightEnd.Location = new System.Drawing.Point(226, 252);
        lbNightEnd.Name = "lbNightEnd";
        lbNightEnd.Size = new System.Drawing.Size(210, 20);
        lbNightEnd.TabIndex = 15;
        lbNightEnd.Text = "Ban đêm kết thúc lúc";
        //
        // dtpNightEnd
        //
        dtpNightEnd.CustomFormat = "HH:mm";
        dtpNightEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
        dtpNightEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNightEnd.Location = new System.Drawing.Point(226, 274);
        dtpNightEnd.Name = "dtpNightEnd";
        dtpNightEnd.ShowUpDown = true;
        dtpNightEnd.Size = new System.Drawing.Size(210, 25);
        dtpNightEnd.TabIndex = 16;
        dtpNightEnd.Value = new System.DateTime(2000, 1, 1, 6, 0, 0, 0);
        //
        // lbHint
        //
        lbHint.Font = new System.Drawing.Font("Segoe UI", 9F);
        lbHint.ForeColor = System.Drawing.Color.DimGray;
        lbHint.Location = new System.Drawing.Point(16, 314);
        lbHint.Name = "lbHint";
        lbHint.Size = new System.Drawing.Size(420, 64);
        lbHint.TabIndex = 17;
        lbHint.Text = "Phí tính theo từng block: block bắt đầu trong khung đêm dùng giá đêm, ngoài khung đêm dùng giá ngày. Khung đêm có thể vắt qua nửa đêm (ví dụ 18:00 → 06:00). Đổi ConfigId sang số chưa có để tạo cấu hình mới.";
        //
        // btSave
        //
        btSave.BackColor = System.Drawing.Color.FromArgb(25, 105, 170);
        btSave.FlatAppearance.BorderSize = 0;
        btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btSave.ForeColor = System.Drawing.Color.White;
        btSave.Location = new System.Drawing.Point(16, 394);
        btSave.Name = "btSave";
        btSave.Size = new System.Drawing.Size(150, 40);
        btSave.TabIndex = 18;
        btSave.Text = "Lưu cấu hình";
        btSave.UseVisualStyleBackColor = false;

        //
        // FormManagePriceConfig
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(243, 246, 250);
        ClientSize = new System.Drawing.Size(1100, 560);
        Controls.Add(tlpMain);
        MinimumSize = new System.Drawing.Size(1000, 520);
        Name = "FormManagePriceConfig";
        Text = "Quản lý biểu phí gửi xe";

        tlpMain.ResumeLayout(false);
        grbList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPrices).EndInit();
        pnlGridButtons.ResumeLayout(false);
        grbEdit.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudConfigId).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudDayPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudNightPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTimeUnit).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudLostFee).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel tlpMain;

    private System.Windows.Forms.GroupBox grbList;
    private System.Windows.Forms.DataGridView dgvPrices;
    private System.Windows.Forms.DataGridViewTextBoxColumn colConfigId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colVType;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDayPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNightPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTimeUnit;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNightStart;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNightEnd;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLostFee;
    private System.Windows.Forms.Panel pnlGridButtons;
    private System.Windows.Forms.Button btRefresh;

    private System.Windows.Forms.GroupBox grbEdit;
    private System.Windows.Forms.Label lbMode;
    private System.Windows.Forms.Label lbConfigId;
    private System.Windows.Forms.NumericUpDown nudConfigId;
    private System.Windows.Forms.Label lbVehicleType;
    private System.Windows.Forms.ComboBox cbVehicleType;
    private System.Windows.Forms.Label lbDayPrice;
    private System.Windows.Forms.NumericUpDown nudDayPrice;
    private System.Windows.Forms.Label lbNightPrice;
    private System.Windows.Forms.NumericUpDown nudNightPrice;
    private System.Windows.Forms.Label lbTimeUnit;
    private System.Windows.Forms.NumericUpDown nudTimeUnit;
    private System.Windows.Forms.Label lbLostFee;
    private System.Windows.Forms.NumericUpDown nudLostFee;
    private System.Windows.Forms.Label lbNightStart;
    private System.Windows.Forms.DateTimePicker dtpNightStart;
    private System.Windows.Forms.Label lbNightEnd;
    private System.Windows.Forms.DateTimePicker dtpNightEnd;
    private System.Windows.Forms.Label lbHint;
    private System.Windows.Forms.Button btSave;
    
    #endregion
}