using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormSearch
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        lbtitle = new System.Windows.Forms.Label();
        flowLayoutPanelFilter = new System.Windows.Forms.FlowLayoutPanel();
        textBoxSearch = new System.Windows.Forms.TextBox();
        btSearch = new System.Windows.Forms.Button();
        lbDateSearch = new System.Windows.Forms.Label();
        dateTimePickerSearch = new System.Windows.Forms.DateTimePicker();
        lbStatusSearch = new System.Windows.Forms.Label();
        comboBoxStatusSearch = new System.Windows.Forms.ComboBox();
        tableLayoutPanelSummary = new System.Windows.Forms.TableLayoutPanel();
        dataGridViewSummary = new System.Windows.Forms.DataGridView();
        STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        IDVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        IDTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
        EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
        VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Action = new System.Windows.Forms.DataGridViewButtonColumn();
        flowLayoutPanelDetail = new System.Windows.Forms.FlowLayoutPanel();
        grbDetail = new System.Windows.Forms.GroupBox();
        lbStatusTicket = new System.Windows.Forms.Label();
        lbTimeIn = new System.Windows.Forms.Label();
        lbLicensePlate = new System.Windows.Forms.Label();
        lbName = new System.Windows.Forms.Label();
        flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        buttonLockTicket = new System.Windows.Forms.Button();
        buttonCalculate = new System.Windows.Forms.Button();
        lbVehicleInfo = new System.Windows.Forms.Label();
        lbOwnerInfo = new System.Windows.Forms.Label();
        lbDurationInfo = new System.Windows.Forms.Label();
        lbFeeInfo = new System.Windows.Forms.Label();
        flowLayoutPanelFilter.SuspendLayout();
        tableLayoutPanelSummary.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewSummary).BeginInit();
        flowLayoutPanelDetail.SuspendLayout();
        grbDetail.SuspendLayout();
        flowLayoutPanel3.SuspendLayout();
        SuspendLayout();
        // 
        // lbtitle
        // 
        lbtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lbtitle.Location = new System.Drawing.Point(12, 11);
        lbtitle.Name = "lbtitle";
        lbtitle.Size = new System.Drawing.Size(200, 23);
        lbtitle.TabIndex = 4;
        lbtitle.Text = "Tìm Kiếm Vé Xe";
        // 
        // flowLayoutPanelFilter
        // 
        flowLayoutPanelFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
        flowLayoutPanelFilter.Controls.Add(textBoxSearch);
        flowLayoutPanelFilter.Controls.Add(btSearch);
        flowLayoutPanelFilter.Controls.Add(lbDateSearch);
        flowLayoutPanelFilter.Controls.Add(dateTimePickerSearch);
        flowLayoutPanelFilter.Controls.Add(lbStatusSearch);
        flowLayoutPanelFilter.Controls.Add(comboBoxStatusSearch);
        flowLayoutPanelFilter.Location = new System.Drawing.Point(12, 37);
        flowLayoutPanelFilter.Name = "flowLayoutPanelFilter";
        flowLayoutPanelFilter.Size = new System.Drawing.Size(776, 39);
        flowLayoutPanelFilter.TabIndex = 6;
        // 
        // textBoxSearch
        // 
        textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
        textBoxSearch.Location = new System.Drawing.Point(5, 6);
        textBoxSearch.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        textBoxSearch.Multiline = true;
        textBoxSearch.Name = "textBoxSearch";
        textBoxSearch.PlaceholderText = "Biển số hoặc mã thẻ";
        textBoxSearch.Size = new System.Drawing.Size(199, 23);
        textBoxSearch.TabIndex = 0;
        // 
        // btSearch
        // 
        btSearch.Location = new System.Drawing.Point(212, 3);
        btSearch.Name = "btSearch";
        btSearch.Size = new System.Drawing.Size(67, 30);
        btSearch.TabIndex = 1;
        btSearch.Text = "Tìm Kiếm";
        btSearch.UseVisualStyleBackColor = true;
        // 
        // lbDateSearch
        // 
        lbDateSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        lbDateSearch.Location = new System.Drawing.Point(285, 6);
        lbDateSearch.Margin = new System.Windows.Forms.Padding(3);
        lbDateSearch.Name = "lbDateSearch";
        lbDateSearch.Padding = new System.Windows.Forms.Padding(3);
        lbDateSearch.Size = new System.Drawing.Size(53, 23);
        lbDateSearch.TabIndex = 2;
        lbDateSearch.Text = "Ngày";
        lbDateSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // dateTimePickerSearch
        // 
        dateTimePickerSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        dateTimePickerSearch.Checked = false;
        dateTimePickerSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dateTimePickerSearch.Location = new System.Drawing.Point(344, 6);
        dateTimePickerSearch.Name = "dateTimePickerSearch";
        dateTimePickerSearch.ShowCheckBox = true;
        dateTimePickerSearch.Size = new System.Drawing.Size(218, 23);
        dateTimePickerSearch.TabIndex = 3;
        dateTimePickerSearch.Value = new System.DateTime(2026, 11, 17, 0, 0, 0, 0);
        // 
        // lbStatusSearch
        // 
        lbStatusSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        lbStatusSearch.Location = new System.Drawing.Point(568, 6);
        lbStatusSearch.Name = "lbStatusSearch";
        lbStatusSearch.Size = new System.Drawing.Size(68, 23);
        lbStatusSearch.TabIndex = 4;
        lbStatusSearch.Text = "Trạng Thái";
        lbStatusSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboBoxStatusSearch
        // 
        comboBoxStatusSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        comboBoxStatusSearch.DisplayMember = "0";
        comboBoxStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxStatusSearch.FormattingEnabled = true;
        comboBoxStatusSearch.Items.AddRange(new object[] { "Tất cả", "Đang trong bãi", "Đã ra khỏi bãi" });
        comboBoxStatusSearch.Location = new System.Drawing.Point(642, 6);
        comboBoxStatusSearch.Name = "comboBoxStatusSearch";
        comboBoxStatusSearch.Size = new System.Drawing.Size(121, 23);
        comboBoxStatusSearch.TabIndex = 5;
        // 
        // tableLayoutPanelSummary
        // 
        tableLayoutPanelSummary.ColumnCount = 2;
        tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
        tableLayoutPanelSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        tableLayoutPanelSummary.Controls.Add(dataGridViewSummary, 0, 0);
        tableLayoutPanelSummary.Controls.Add(flowLayoutPanelDetail, 1, 0);
        tableLayoutPanelSummary.Location = new System.Drawing.Point(12, 82);
        tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
        tableLayoutPanelSummary.RowCount = 1;
        tableLayoutPanelSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelSummary.Size = new System.Drawing.Size(776, 356);
        tableLayoutPanelSummary.TabIndex = 7;
        // 
        // dataGridViewSummary
        // 
        dataGridViewSummary.AllowUserToAddRows = false;
        dataGridViewSummary.AllowUserToDeleteRows = false;
        dataGridViewSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { STT, IDVehicle, IDTicket, EntryTime, Duration, VehicleType, Action });
        dataGridViewSummary.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewSummary.Location = new System.Drawing.Point(3, 3);
        dataGridViewSummary.MultiSelect = false;
        dataGridViewSummary.Name = "dataGridViewSummary";
        dataGridViewSummary.ReadOnly = true;
        dataGridViewSummary.RowHeadersVisible = false;
        dataGridViewSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewSummary.Size = new System.Drawing.Size(537, 350);
        dataGridViewSummary.TabIndex = 0;
        dataGridViewSummary.Text = "dataGridView1";
        // 
        // STT
        // 
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        STT.DefaultCellStyle = dataGridViewCellStyle1;
        STT.FillWeight = 40F;
        STT.HeaderText = "STT";
        STT.Name = "STT";
        STT.ReadOnly = true;
        // 
        // IDVehicle
        // 
        IDVehicle.HeaderText = "Biển số";
        IDVehicle.Name = "IDVehicle";
        IDVehicle.ReadOnly = true;
        // 
        // IDTicket
        // 
        IDTicket.HeaderText = "Mã thẻ";
        IDTicket.Name = "IDTicket";
        IDTicket.ReadOnly = true;
        // 
        // EntryTime
        // 
        EntryTime.HeaderText = "Giờ vào";
        EntryTime.Name = "EntryTime";
        EntryTime.ReadOnly = true;
        // 
        // Duration
        // 
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        Duration.DefaultCellStyle = dataGridViewCellStyle2;
        Duration.HeaderText = "Thời gian gửi";
        Duration.Name = "Duration";
        Duration.ReadOnly = true;
        // 
        // VehicleType
        // 
        VehicleType.HeaderText = "Loại xe";
        VehicleType.Name = "VehicleType";
        VehicleType.ReadOnly = true;
        // 
        // Action
        // 
        Action.HeaderText = "Thao tác";
        Action.Name = "Action";
        Action.ReadOnly = true;
        Action.Text = "Chi tiết";
        Action.UseColumnTextForButtonValue = true;
        // 
        // flowLayoutPanelDetail
        // 
        flowLayoutPanelDetail.Controls.Add(grbDetail);
        flowLayoutPanelDetail.Controls.Add(flowLayoutPanel3);
        flowLayoutPanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanelDetail.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanelDetail.Location = new System.Drawing.Point(546, 3);
        flowLayoutPanelDetail.Name = "flowLayoutPanelDetail";
        flowLayoutPanelDetail.Size = new System.Drawing.Size(227, 350);
        flowLayoutPanelDetail.TabIndex = 1;
        // 
        // grbDetail
        // 
        grbDetail.Controls.Add(lbFeeInfo);
        grbDetail.Controls.Add(lbDurationInfo);
        grbDetail.Controls.Add(lbOwnerInfo);
        grbDetail.Controls.Add(lbVehicleInfo);
        grbDetail.Controls.Add(lbStatusTicket);
        grbDetail.Controls.Add(lbTimeIn);
        grbDetail.Controls.Add(lbLicensePlate);
        grbDetail.Controls.Add(lbName);
        grbDetail.Location = new System.Drawing.Point(3, 3);
        grbDetail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
        grbDetail.Name = "grbDetail";
        grbDetail.Size = new System.Drawing.Size(219, 268);
        grbDetail.TabIndex = 2;
        grbDetail.TabStop = false;
        grbDetail.Text = "Thông Tin Vé Xe";
        // 
        // lbStatusTicket
        // 
        lbStatusTicket.Location = new System.Drawing.Point(6, 88);
        lbStatusTicket.Name = "lbStatusTicket";
        lbStatusTicket.Size = new System.Drawing.Size(208, 23);
        lbStatusTicket.TabIndex = 3;
        lbStatusTicket.Text = "Trạng Thái";
        lbStatusTicket.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbTimeIn
        // 
        lbTimeIn.Location = new System.Drawing.Point(6, 65);
        lbTimeIn.Name = "lbTimeIn";
        lbTimeIn.Size = new System.Drawing.Size(208, 23);
        lbTimeIn.TabIndex = 2;
        lbTimeIn.Text = "Thời gian vào";
        lbTimeIn.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbLicensePlate
        // 
        lbLicensePlate.Location = new System.Drawing.Point(6, 42);
        lbLicensePlate.Name = "lbLicensePlate";
        lbLicensePlate.Size = new System.Drawing.Size(208, 23);
        lbLicensePlate.TabIndex = 1;
        lbLicensePlate.Text = "Biển Số";
        lbLicensePlate.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbName
        // 
        lbName.Location = new System.Drawing.Point(6, 19);
        lbName.Name = "lbName";
        lbName.Size = new System.Drawing.Size(208, 23);
        lbName.TabIndex = 0;
        lbName.Text = "Vé Xe:";
        lbName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbVehicleInfo
        // 
        lbVehicleInfo.Location = new System.Drawing.Point(6, 111);
        lbVehicleInfo.Name = "lbVehicleInfo";
        lbVehicleInfo.Size = new System.Drawing.Size(208, 23);
        lbVehicleInfo.TabIndex = 4;
        lbVehicleInfo.Text = "Loại xe";
        lbVehicleInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbOwnerInfo
        // 
        lbOwnerInfo.Location = new System.Drawing.Point(6, 134);
        lbOwnerInfo.Name = "lbOwnerInfo";
        lbOwnerInfo.Size = new System.Drawing.Size(208, 23);
        lbOwnerInfo.TabIndex = 5;
        lbOwnerInfo.Text = "Chủ xe";
        lbOwnerInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbDurationInfo
        // 
        lbDurationInfo.Location = new System.Drawing.Point(6, 157);
        lbDurationInfo.Name = "lbDurationInfo";
        lbDurationInfo.Size = new System.Drawing.Size(208, 23);
        lbDurationInfo.TabIndex = 6;
        lbDurationInfo.Text = "Đã gửi";
        lbDurationInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lbFeeInfo
        // 
        lbFeeInfo.Location = new System.Drawing.Point(6, 180);
        lbFeeInfo.Name = "lbFeeInfo";
        lbFeeInfo.Size = new System.Drawing.Size(208, 23);
        lbFeeInfo.TabIndex = 7;
        lbFeeInfo.Text = "Phí tạm tính";
        lbFeeInfo.TextAlign = ContentAlignment.MiddleLeft;
        lbFeeInfo.Font = new Font(Font, FontStyle.Bold);
        lbFeeInfo.ForeColor = Color.FromArgb(40, 120, 60);
        // 
        // flowLayoutPanel3
        // 
        flowLayoutPanel3.Controls.Add(buttonLockTicket);
        flowLayoutPanel3.Controls.Add(buttonCalculate);
        flowLayoutPanel3.Location = new System.Drawing.Point(3, 284);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Size = new System.Drawing.Size(219, 45);
        flowLayoutPanel3.TabIndex = 1;
        // 
        // buttonLockTicket
        // 
        buttonLockTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
        buttonLockTicket.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        buttonLockTicket.Location = new System.Drawing.Point(3, 3);
        buttonLockTicket.Name = "buttonLockTicket";
        buttonLockTicket.Size = new System.Drawing.Size(97, 42);
        buttonLockTicket.TabIndex = 0;
        buttonLockTicket.Text = "Khóa Thẻ";
        buttonLockTicket.UseVisualStyleBackColor = true;
        // 
        // buttonCalculate
        // 
        buttonCalculate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
        buttonCalculate.Location = new System.Drawing.Point(106, 3);
        buttonCalculate.Name = "buttonCalculate";
        buttonCalculate.Size = new System.Drawing.Size(98, 42);
        buttonCalculate.TabIndex = 1;
        buttonCalculate.Text = "Thanh Toán";
        buttonCalculate.UseVisualStyleBackColor = true;
        // 
        // FormSearch
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tableLayoutPanelSummary);
        Controls.Add(flowLayoutPanelFilter);
        Controls.Add(lbtitle);
        Cursor = System.Windows.Forms.Cursors.Default;
        Location = new System.Drawing.Point(15, 15);
        Text = "Form Search";
        flowLayoutPanelFilter.ResumeLayout(false);
        flowLayoutPanelFilter.PerformLayout();
        tableLayoutPanelSummary.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridViewSummary).EndInit();
        flowLayoutPanelDetail.ResumeLayout(false);
        grbDetail.ResumeLayout(false);
        flowLayoutPanel3.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbOwnerInfo;
    private System.Windows.Forms.Label lbDurationInfo;
    private System.Windows.Forms.Label lbFeeInfo;

    private System.Windows.Forms.Label lbVehicleInfo;

    private System.Windows.Forms.Label lbTimeIn;
    private System.Windows.Forms.Label lbStatusTicket;

    private System.Windows.Forms.Label lbName;
    private System.Windows.Forms.Label lbLicensePlate;

    private System.Windows.Forms.GroupBox grbDetail;

    private System.Windows.Forms.Button buttonCalculate;

    private System.Windows.Forms.Button buttonLockTicket;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDetail;

    private System.Windows.Forms.DataGridViewTextBoxColumn STT;
    private System.Windows.Forms.DataGridViewTextBoxColumn IDVehicle;
    private System.Windows.Forms.DataGridViewTextBoxColumn IDTicket;
    private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
    private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
    private System.Windows.Forms.DataGridViewButtonColumn Action;

    private System.Windows.Forms.DataGridView dataGridViewSummary;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSummary;

    private System.Windows.Forms.ComboBox comboBoxStatusSearch;

    private System.Windows.Forms.Label lbStatusSearch;

    private System.Windows.Forms.DateTimePicker dateTimePickerSearch;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFilter;
    private System.Windows.Forms.TextBox textBoxSearch;
    private System.Windows.Forms.Button btSearch;
    private System.Windows.Forms.Label lbDateSearch;
    private System.Windows.Forms.Label lbtitle;
    #endregion
}