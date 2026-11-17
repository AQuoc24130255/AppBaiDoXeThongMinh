using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormEditSlot
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
        dgvSlots = new System.Windows.Forms.DataGridView();
        pnlGridButtons = new System.Windows.Forms.Panel();
        btDelete = new System.Windows.Forms.Button();
        btRefresh = new System.Windows.Forms.Button();
        grbAdd = new System.Windows.Forms.GroupBox();
        lbSlotName = new System.Windows.Forms.Label();
        txtSlotName = new System.Windows.Forms.TextBox();
        lbZone = new System.Windows.Forms.Label();
        txtZone = new System.Windows.Forms.TextBox();
        lbRole = new System.Windows.Forms.Label();
        cbAllowedVehicleType = new System.Windows.Forms.ComboBox();
        btAdd = new System.Windows.Forms.Button();
        btClear = new System.Windows.Forms.Button();
        colSlotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSlotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colAllowedVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colIsOccupied = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        colCurrentVehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        tlpMain.SuspendLayout();
        grbList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSlots).BeginInit();
        pnlGridButtons.SuspendLayout();
        grbAdd.SuspendLayout();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
        tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
        tlpMain.Controls.Add(grbList, 0, 0);
        tlpMain.Controls.Add(grbAdd, 1, 0);
        tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMain.Location = new System.Drawing.Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new System.Windows.Forms.Padding(8);
        tlpMain.RowCount = 1;
        tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMain.Size = new System.Drawing.Size(920, 540);
        tlpMain.TabIndex = 0;
        // 
        // grbList
        // 
        grbList.Controls.Add(dgvSlots);
        grbList.Controls.Add(pnlGridButtons);
        grbList.Dock = System.Windows.Forms.DockStyle.Fill;
        grbList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbList.Location = new System.Drawing.Point(11, 11);
        grbList.Name = "grbList";
        grbList.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
        grbList.Size = new System.Drawing.Size(554, 518);
        grbList.TabIndex = 0;
        grbList.TabStop = false;
        grbList.Text = "Danh sách chỗ đỗ";
        // 
        // dgvSlots
        // 
        dgvSlots.AllowUserToAddRows = false;
        dgvSlots.AllowUserToDeleteRows = false;
        dgvSlots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvSlots.BackgroundColor = System.Drawing.Color.White;
        dgvSlots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvSlots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSlotId, colSlotName, colZone, colAllowedVehicleType, colIsOccupied, colCurrentVehicleID });
        dgvSlots.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvSlots.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dgvSlots.Location = new System.Drawing.Point(8, 22);
        dgvSlots.MultiSelect = false;
        dgvSlots.Name = "dgvSlots";
        dgvSlots.ReadOnly = true;
        dgvSlots.RowHeadersVisible = false;
        dgvSlots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvSlots.Size = new System.Drawing.Size(538, 440);
        dgvSlots.TabIndex = 0;
        // 
        // pnlGridButtons
        // 
        pnlGridButtons.Controls.Add(btDelete);
        pnlGridButtons.Controls.Add(btRefresh);
        pnlGridButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlGridButtons.Location = new System.Drawing.Point(8, 462);
        pnlGridButtons.Name = "pnlGridButtons";
        pnlGridButtons.Size = new System.Drawing.Size(538, 48);
        pnlGridButtons.TabIndex = 1;
        // 
        // btDelete
        // 
        btDelete.BackColor = System.Drawing.Color.FromArgb(((int)((byte)200)), ((int)((byte)60)), ((int)((byte)55)));
        btDelete.FlatAppearance.BorderSize = 0;
        btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btDelete.ForeColor = System.Drawing.Color.White;
        btDelete.Location = new System.Drawing.Point(0, 10);
        btDelete.Name = "btDelete";
        btDelete.Size = new System.Drawing.Size(150, 34);
        btDelete.TabIndex = 0;
        btDelete.Text = "Xóa chỗ đỗ";
        btDelete.UseVisualStyleBackColor = false;
        // 
        // btRefresh
        // 
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(160, 10);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(110, 34);
        btRefresh.TabIndex = 1;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;
        // 
        // grbAdd
        // 
        grbAdd.Controls.Add(lbSlotName);
        grbAdd.Controls.Add(txtSlotName);
        grbAdd.Controls.Add(lbZone);
        grbAdd.Controls.Add(txtZone);
        grbAdd.Controls.Add(lbRole);
        grbAdd.Controls.Add(cbAllowedVehicleType);
        grbAdd.Controls.Add(btAdd);
        grbAdd.Controls.Add(btClear);
        grbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        grbAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbAdd.Location = new System.Drawing.Point(571, 11);
        grbAdd.Name = "grbAdd";
        grbAdd.Size = new System.Drawing.Size(338, 518);
        grbAdd.TabIndex = 1;
        grbAdd.TabStop = false;
        grbAdd.Text = "Thêm chỗ đỗ mới";
        // 
        // lbSlotName
        // 
        lbSlotName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbSlotName.Location = new System.Drawing.Point(16, 32);
        lbSlotName.Name = "lbSlotName";
        lbSlotName.Size = new System.Drawing.Size(300, 20);
        lbSlotName.TabIndex = 0;
        lbSlotName.Text = "Tên chỗ đỗ";
        // 
        // txtSlotName
        // 
        txtSlotName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtSlotName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtSlotName.Location = new System.Drawing.Point(16, 54);
        txtSlotName.MaxLength = 50;
        txtSlotName.Name = "txtSlotName";
        txtSlotName.Size = new System.Drawing.Size(306, 25);
        txtSlotName.TabIndex = 1;
        // 
        // lbZone
        // 
        lbZone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbZone.Location = new System.Drawing.Point(16, 90);
        lbZone.Name = "lbZone";
        lbZone.Size = new System.Drawing.Size(300, 20);
        lbZone.TabIndex = 2;
        lbZone.Text = "Khu vực";
        // 
        // txtZone
        // 
        txtZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtZone.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtZone.Location = new System.Drawing.Point(16, 112);
        txtZone.MaxLength = 50;
        txtZone.Name = "txtZone";
        txtZone.Size = new System.Drawing.Size(306, 25);
        txtZone.TabIndex = 3;
        // 
        // lbRole
        // 
        lbRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbRole.Location = new System.Drawing.Point(16, 164);
        lbRole.Name = "lbRole";
        lbRole.Size = new System.Drawing.Size(300, 20);
        lbRole.TabIndex = 9;
        lbRole.Text = "Loại xe được phép đỗ";
        // 
        // cbAllowedVehicleType
        // 
        cbAllowedVehicleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        cbAllowedVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbAllowedVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
        cbAllowedVehicleType.FormattingEnabled = true;
        cbAllowedVehicleType.Items.AddRange(new object[] { "Xe Máy", "Xe Ô Tô" });
        cbAllowedVehicleType.Location = new System.Drawing.Point(16, 186);
        cbAllowedVehicleType.Name = "cbAllowedVehicleType";
        cbAllowedVehicleType.Size = new System.Drawing.Size(306, 25);
        cbAllowedVehicleType.TabIndex = 10;
        cbAllowedVehicleType.SelectedIndex = 0;
        // 
        // btAdd
        // 
        btAdd.BackColor = System.Drawing.Color.FromArgb(((int)((byte)25)), ((int)((byte)105)), ((int)((byte)170)));
        btAdd.FlatAppearance.BorderSize = 0;
        btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btAdd.ForeColor = System.Drawing.Color.White;
        btAdd.Location = new System.Drawing.Point(16, 256);
        btAdd.Name = "btAdd";
        btAdd.Size = new System.Drawing.Size(150, 38);
        btAdd.TabIndex = 12;
        btAdd.Text = "Thêm chỗ đỗ";
        btAdd.UseVisualStyleBackColor = false;
        // 
        // btClear
        // 
        btClear.Font = new System.Drawing.Font("Segoe UI", 10F);
        btClear.Location = new System.Drawing.Point(176, 256);
        btClear.Name = "btClear";
        btClear.Size = new System.Drawing.Size(110, 38);
        btClear.TabIndex = 13;
        btClear.Text = "Nhập lại";
        btClear.UseVisualStyleBackColor = true;
        // 
        // colSlotId
        // 
        colSlotId.FillWeight = 40F;
        colSlotId.HeaderText = "ID";
        colSlotId.Name = "colSlotId";
        colSlotId.ReadOnly = true;
        colSlotId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // colSlotName
        // 
        colSlotName.HeaderText = "Tên chỗ đỗ";
        colSlotName.Name = "colSlotName";
        colSlotName.ReadOnly = true;
        // 
        // colZone
        // 
        colZone.FillWeight = 130F;
        colZone.HeaderText = "Khu Vực";
        colZone.Name = "colZone";
        colZone.ReadOnly = true;
        // 
        // colAllowedVehicleType
        // 
        colAllowedVehicleType.FillWeight = 80F;
        colAllowedVehicleType.HeaderText = "Loại xe";
        colAllowedVehicleType.Name = "colAllowedVehicleType";
        colAllowedVehicleType.ReadOnly = true;
        colAllowedVehicleType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // colIsOccupied
        // 
        colIsOccupied.HeaderText = "Đã đỗ";
        colIsOccupied.Name = "colIsOccupied";
        colIsOccupied.ReadOnly = true;
        colIsOccupied.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        colIsOccupied.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        // 
        // colCurrentVehicleID
        // 
        colCurrentVehicleID.HeaderText = "Biển số xe";
        colCurrentVehicleID.Name = "colCurrentVehicleID";
        colCurrentVehicleID.ReadOnly = true;
        colCurrentVehicleID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // FormEditSlot
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)243)), ((int)((byte)246)), ((int)((byte)250)));
        ClientSize = new System.Drawing.Size(920, 540);
        Controls.Add(tlpMain);
        MinimumSize = new System.Drawing.Size(820, 520);
        Text = "Quản lý chỗ đỗ xe";
        tlpMain.ResumeLayout(false);
        grbList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSlots).EndInit();
        pnlGridButtons.ResumeLayout(false);
        grbAdd.ResumeLayout(false);
        grbAdd.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridViewTextBoxColumn colZone;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAllowedVehicleType;
    private System.Windows.Forms.DataGridViewCheckBoxColumn colIsOccupied;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentVehicleID;

    private System.Windows.Forms.DataGridViewTextBoxColumn colSlotId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSlotName;

    private System.Windows.Forms.Button btRefresh;

    private System.Windows.Forms.TableLayoutPanel tlpMain;

    private System.Windows.Forms.GroupBox grbList;
    private System.Windows.Forms.DataGridView dgvSlots;
    private System.Windows.Forms.Panel pnlGridButtons;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Button btLock;

    private System.Windows.Forms.GroupBox grbAdd;
    private System.Windows.Forms.Label lbSlotName;
    private System.Windows.Forms.TextBox txtSlotName;
    private System.Windows.Forms.Label lbZone;
    private System.Windows.Forms.TextBox txtZone;
    private System.Windows.Forms.Label lbRole;
    private System.Windows.Forms.ComboBox cbAllowedVehicleType;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btClear;

    #endregion
}