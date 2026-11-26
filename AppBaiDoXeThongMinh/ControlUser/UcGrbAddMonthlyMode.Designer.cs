using System.ComponentModel;

namespace AppBaiDoXeThongMinh.ControlUser;

partial class UcGrbAddMonthlyMode
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        grbAdd = new System.Windows.Forms.GroupBox();
        lbPlate = new System.Windows.Forms.Label();
        txtPlate = new System.Windows.Forms.TextBox();
        lbVehicleType = new System.Windows.Forms.Label();
        cbVehicleType = new System.Windows.Forms.ComboBox();
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
        btRefresh = new System.Windows.Forms.Button();
        grbAdd.SuspendLayout();
        grbOwner.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudFee).BeginInit();
        SuspendLayout();
        // 
        // grbAdd
        // 
        grbAdd.Controls.Add(lbPlate);
        grbAdd.Controls.Add(txtPlate);
        grbAdd.Controls.Add(lbVehicleType);
        grbAdd.Controls.Add(cbVehicleType);
        grbAdd.Controls.Add(grbOwner);
        grbAdd.Controls.Add(btAdd);
        grbAdd.Controls.Add(btClear);
        grbAdd.Controls.Add(btRefresh);
        grbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        grbAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbAdd.Location = new System.Drawing.Point(0, 0);
        grbAdd.Name = "grbAdd";
        grbAdd.Size = new System.Drawing.Size(398, 570);
        grbAdd.TabIndex = 0;
        grbAdd.TabStop = false;
        grbAdd.Text = "Đăng ký vé tháng mới";
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
        txtPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
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
        cbVehicleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
        cbVehicleType.FormattingEnabled = true;
        cbVehicleType.Items.AddRange(new object[] { "Xe máy", "Ô tô" });
        cbVehicleType.Location = new System.Drawing.Point(16, 110);
        cbVehicleType.Name = "cbVehicleType";
        cbVehicleType.Size = new System.Drawing.Size(366, 25);
        cbVehicleType.TabIndex = 3;
        // 
        // grbOwner
        // 
        grbOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grbOwner.Controls.Add(lbOwnerName);
        grbOwner.Controls.Add(txtOwnerName);
        grbOwner.Controls.Add(lbPhone);
        grbOwner.Controls.Add(txtPhone);
        grbOwner.Controls.Add(lbMonths);
        grbOwner.Controls.Add(nudMonths);
        grbOwner.Controls.Add(lbFee);
        grbOwner.Controls.Add(nudFee);
        grbOwner.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        grbOwner.Location = new System.Drawing.Point(16, 150);
        grbOwner.Name = "grbOwner";
        grbOwner.Size = new System.Drawing.Size(366, 215);
        grbOwner.TabIndex = 4;
        grbOwner.TabStop = false;
        grbOwner.Text = "Thông tin chủ xe đăng ký vé tháng";
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
        txtOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
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
        lbPhone.Location = new System.Drawing.Point(12, 84);
        lbPhone.Name = "lbPhone";
        lbPhone.Size = new System.Drawing.Size(340, 20);
        lbPhone.TabIndex = 2;
        lbPhone.Text = "Số điện thoại";
        // 
        // txtPhone
        // 
        txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPhone.Location = new System.Drawing.Point(12, 106);
        txtPhone.MaxLength = 20;
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new System.Drawing.Size(342, 25);
        txtPhone.TabIndex = 3;
        // 
        // lbMonths
        // 
        lbMonths.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbMonths.Location = new System.Drawing.Point(12, 144);
        lbMonths.Name = "lbMonths";
        lbMonths.Size = new System.Drawing.Size(120, 20);
        lbMonths.TabIndex = 4;
        lbMonths.Text = "Số tháng đăng ký";
        // 
        // nudMonths
        // 
        nudMonths.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudMonths.Location = new System.Drawing.Point(12, 166);
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
        lbFee.Location = new System.Drawing.Point(150, 144);
        lbFee.Name = "lbFee";
        lbFee.Size = new System.Drawing.Size(190, 20);
        lbFee.TabIndex = 6;
        lbFee.Text = "Phí hàng tháng (VNĐ)";
        // 
        // nudFee
        // 
        nudFee.Font = new System.Drawing.Font("Segoe UI", 10F);
        nudFee.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
        nudFee.Location = new System.Drawing.Point(150, 166);
        nudFee.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudFee.Name = "nudFee";
        nudFee.Size = new System.Drawing.Size(204, 25);
        nudFee.TabIndex = 7;
        nudFee.ThousandsSeparator = true;
        // 
        // btAdd
        // 
        btAdd.BackColor = System.Drawing.Color.FromArgb(((int)((byte)25)), ((int)((byte)105)), ((int)((byte)170)));
        btAdd.FlatAppearance.BorderSize = 0;
        btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btAdd.ForeColor = System.Drawing.Color.White;
        btAdd.Location = new System.Drawing.Point(16, 382);
        btAdd.Name = "btAdd";
        btAdd.Size = new System.Drawing.Size(120, 38);
        btAdd.TabIndex = 5;
        btAdd.Text = "Thêm vé";
        btAdd.UseVisualStyleBackColor = false;
        // 
        // btClear
        // 
        btClear.Font = new System.Drawing.Font("Segoe UI", 10F);
        btClear.Location = new System.Drawing.Point(146, 382);
        btClear.Name = "btClear";
        btClear.Size = new System.Drawing.Size(110, 38);
        btClear.TabIndex = 6;
        btClear.Text = "Nhập lại";
        btClear.UseVisualStyleBackColor = true;
        // 
        // btRefresh
        // 
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(16, 436);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(120, 38);
        btRefresh.TabIndex = 7;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;
        // 
        // UcGrbAddMonthlyMode
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)243)), ((int)((byte)246)), ((int)((byte)250)));
        Controls.Add(grbAdd);
        Size = new System.Drawing.Size(398, 570);
        grbAdd.ResumeLayout(false);
        grbAdd.PerformLayout();
        grbOwner.ResumeLayout(false);
        grbOwner.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudFee).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grbAdd;
    private System.Windows.Forms.Label lbPlate;
    private System.Windows.Forms.TextBox txtPlate;
    private System.Windows.Forms.Label lbVehicleType;
    private System.Windows.Forms.ComboBox cbVehicleType;
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
    private System.Windows.Forms.Button btRefresh;
    
    #endregion
}