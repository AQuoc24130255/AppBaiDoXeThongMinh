using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormEditUser
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
        dgvUsers = new System.Windows.Forms.DataGridView();
        colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
        pnlGridButtons = new System.Windows.Forms.Panel();
        btDelete = new System.Windows.Forms.Button();
        btLock = new System.Windows.Forms.Button();
        grbAdd = new System.Windows.Forms.GroupBox();
        lbUserName = new System.Windows.Forms.Label();
        txtUserName = new System.Windows.Forms.TextBox();
        lbFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lbPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lbConfirm = new System.Windows.Forms.Label();
        txtConfirm = new System.Windows.Forms.TextBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        lbRole = new System.Windows.Forms.Label();
        cbRole = new System.Windows.Forms.ComboBox();
        chkActive = new System.Windows.Forms.CheckBox();
        btAdd = new System.Windows.Forms.Button();
        btClear = new System.Windows.Forms.Button();
        btRefresh = new System.Windows.Forms.Button();
        tlpMain.SuspendLayout();
        grbList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
        grbList.Controls.Add(dgvUsers);
        grbList.Controls.Add(pnlGridButtons);
        grbList.Dock = System.Windows.Forms.DockStyle.Fill;
        grbList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbList.Location = new System.Drawing.Point(11, 11);
        grbList.Name = "grbList";
        grbList.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
        grbList.Size = new System.Drawing.Size(554, 518);
        grbList.TabIndex = 0;
        grbList.TabStop = false;
        grbList.Text = "Danh sách người dùng";
        // 
        // dgvUsers
        // 
        dgvUsers.AllowUserToAddRows = false;
        dgvUsers.AllowUserToDeleteRows = false;
        dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvUsers.BackgroundColor = System.Drawing.Color.White;
        dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUserId, colUserName, colFullName, colRole, colStatus });
        dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dgvUsers.Location = new System.Drawing.Point(8, 22);
        dgvUsers.MultiSelect = false;
        dgvUsers.Name = "dgvUsers";
        dgvUsers.ReadOnly = true;
        dgvUsers.RowHeadersVisible = false;
        dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvUsers.Size = new System.Drawing.Size(538, 440);
        dgvUsers.TabIndex = 0;
        // 
        // colUserId
        // 
        colUserId.FillWeight = 40F;
        colUserId.HeaderText = "ID";
        colUserId.Name = "colUserId";
        colUserId.ReadOnly = true;
        colUserId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // colUserName
        // 
        colUserName.HeaderText = "Tên đăng nhập";
        colUserName.Name = "colUserName";
        colUserName.ReadOnly = true;
        // 
        // colFullName
        // 
        colFullName.FillWeight = 130F;
        colFullName.HeaderText = "Họ và tên";
        colFullName.Name = "colFullName";
        colFullName.ReadOnly = true;
        // 
        // colRole
        // 
        colRole.HeaderText = "Chức vụ";
        colRole.Name = "colRole";
        colRole.ReadOnly = true;
        // 
        // colStatus
        // 
        colStatus.FillWeight = 80F;
        colStatus.HeaderText = "Trạng thái";
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        // 
        // pnlGridButtons
        // 
        pnlGridButtons.Controls.Add(btRefresh);
        pnlGridButtons.Controls.Add(btDelete);
        pnlGridButtons.Controls.Add(btLock);
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
        btDelete.Text = "Xóa người dùng";
        btDelete.UseVisualStyleBackColor = false;
        // 
        // btLock
        // 
        btLock.Font = new System.Drawing.Font("Segoe UI", 10F);
        btLock.Location = new System.Drawing.Point(160, 10);
        btLock.Name = "btLock";
        btLock.Size = new System.Drawing.Size(110, 34);
        btLock.TabIndex = 1;
        btLock.Text = "Khóa tài khoản";
        btLock.UseVisualStyleBackColor = true;
        // 
        // grbAdd
        // 
        grbAdd.Controls.Add(lbUserName);
        grbAdd.Controls.Add(txtUserName);
        grbAdd.Controls.Add(lbFullName);
        grbAdd.Controls.Add(txtFullName);
        grbAdd.Controls.Add(lbPassword);
        grbAdd.Controls.Add(txtPassword);
        grbAdd.Controls.Add(lbConfirm);
        grbAdd.Controls.Add(txtConfirm);
        grbAdd.Controls.Add(chkShowPassword);
        grbAdd.Controls.Add(lbRole);
        grbAdd.Controls.Add(cbRole);
        grbAdd.Controls.Add(chkActive);
        grbAdd.Controls.Add(btAdd);
        grbAdd.Controls.Add(btClear);
        grbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        grbAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbAdd.Location = new System.Drawing.Point(571, 11);
        grbAdd.Name = "grbAdd";
        grbAdd.Size = new System.Drawing.Size(338, 518);
        grbAdd.TabIndex = 1;
        grbAdd.TabStop = false;
        grbAdd.Text = "Thêm người dùng mới";
        // 
        // lbUserName
        // 
        lbUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbUserName.Location = new System.Drawing.Point(16, 32);
        lbUserName.Name = "lbUserName";
        lbUserName.Size = new System.Drawing.Size(300, 20);
        lbUserName.TabIndex = 0;
        lbUserName.Text = "Tên đăng nhập";
        // 
        // txtUserName
        // 
        txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtUserName.Location = new System.Drawing.Point(16, 54);
        txtUserName.MaxLength = 50;
        txtUserName.Name = "txtUserName";
        txtUserName.Size = new System.Drawing.Size(306, 25);
        txtUserName.TabIndex = 1;
        // 
        // lbFullName
        // 
        lbFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbFullName.Location = new System.Drawing.Point(16, 90);
        lbFullName.Name = "lbFullName";
        lbFullName.Size = new System.Drawing.Size(300, 20);
        lbFullName.TabIndex = 2;
        lbFullName.Text = "Họ và tên";
        // 
        // txtFullName
        // 
        txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtFullName.Location = new System.Drawing.Point(16, 112);
        txtFullName.MaxLength = 50;
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new System.Drawing.Size(306, 25);
        txtFullName.TabIndex = 3;
        // 
        // lbPassword
        // 
        lbPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbPassword.Location = new System.Drawing.Point(16, 148);
        lbPassword.Name = "lbPassword";
        lbPassword.Size = new System.Drawing.Size(300, 20);
        lbPassword.TabIndex = 4;
        lbPassword.Text = "Mật khẩu (tối thiểu 6 ký tự)";
        // 
        // txtPassword
        // 
        txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtPassword.Location = new System.Drawing.Point(16, 170);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new System.Drawing.Size(306, 25);
        txtPassword.TabIndex = 5;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lbConfirm
        // 
        lbConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbConfirm.Location = new System.Drawing.Point(16, 206);
        lbConfirm.Name = "lbConfirm";
        lbConfirm.Size = new System.Drawing.Size(300, 20);
        lbConfirm.TabIndex = 6;
        lbConfirm.Text = "Nhập lại mật khẩu";
        // 
        // txtConfirm
        // 
        txtConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
        txtConfirm.Location = new System.Drawing.Point(16, 228);
        txtConfirm.Name = "txtConfirm";
        txtConfirm.Size = new System.Drawing.Size(306, 25);
        txtConfirm.TabIndex = 7;
        txtConfirm.UseSystemPasswordChar = true;
        // 
        // chkShowPassword
        // 
        chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        chkShowPassword.Location = new System.Drawing.Point(16, 260);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new System.Drawing.Size(200, 24);
        chkShowPassword.TabIndex = 8;
        chkShowPassword.Text = "Hiển thị mật khẩu";
        chkShowPassword.UseVisualStyleBackColor = true;
        // 
        // lbRole
        // 
        lbRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lbRole.Location = new System.Drawing.Point(16, 296);
        lbRole.Name = "lbRole";
        lbRole.Size = new System.Drawing.Size(300, 20);
        lbRole.TabIndex = 9;
        lbRole.Text = "Chức vụ";
        // 
        // cbRole
        // 
        cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
        cbRole.FormattingEnabled = true;
        cbRole.Items.AddRange(new object[] { "Quản trị viên", "Nhân viên bảo vệ" });
        cbRole.Location = new System.Drawing.Point(16, 318);
        cbRole.Name = "cbRole";
        cbRole.Size = new System.Drawing.Size(306, 25);
        cbRole.TabIndex = 10;
        cbRole.SelectedIndex = 1;
        // 
        // chkActive
        // 
        chkActive.Checked = true;
        chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
        chkActive.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        chkActive.Location = new System.Drawing.Point(16, 354);
        chkActive.Name = "chkActive";
        chkActive.Size = new System.Drawing.Size(250, 24);
        chkActive.TabIndex = 11;
        chkActive.Text = "Tài khoản hoạt động";
        chkActive.UseVisualStyleBackColor = true;
        // 
        // btAdd
        // 
        btAdd.BackColor = System.Drawing.Color.FromArgb(((int)((byte)25)), ((int)((byte)105)), ((int)((byte)170)));
        btAdd.FlatAppearance.BorderSize = 0;
        btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btAdd.ForeColor = System.Drawing.Color.White;
        btAdd.Location = new System.Drawing.Point(16, 394);
        btAdd.Name = "btAdd";
        btAdd.Size = new System.Drawing.Size(150, 38);
        btAdd.TabIndex = 12;
        btAdd.Text = "Thêm người dùng";
        btAdd.UseVisualStyleBackColor = false;
        // 
        // btClear
        // 
        btClear.Font = new System.Drawing.Font("Segoe UI", 10F);
        btClear.Location = new System.Drawing.Point(176, 394);
        btClear.Name = "btClear";
        btClear.Size = new System.Drawing.Size(110, 38);
        btClear.TabIndex = 13;
        btClear.Text = "Nhập lại";
        btClear.UseVisualStyleBackColor = true;
        // 
        // btRefresh
        // 
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(276, 10);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(110, 34);
        btRefresh.TabIndex = 2;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;
        // 
        // FormEditUser
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)243)), ((int)((byte)246)), ((int)((byte)250)));
        ClientSize = new System.Drawing.Size(920, 540);
        Controls.Add(tlpMain);
        MinimumSize = new System.Drawing.Size(820, 520);
        Text = "Quản lý người dùng";
        tlpMain.ResumeLayout(false);
        grbList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
        pnlGridButtons.ResumeLayout(false);
        grbAdd.ResumeLayout(false);
        grbAdd.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btRefresh;

    private System.Windows.Forms.TableLayoutPanel tlpMain;

    private System.Windows.Forms.GroupBox grbList;
    private System.Windows.Forms.DataGridView dgvUsers;
    private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    private System.Windows.Forms.Panel pnlGridButtons;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Button btLock;

    private System.Windows.Forms.GroupBox grbAdd;
    private System.Windows.Forms.Label lbUserName;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.Label lbFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lbPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lbConfirm;
    private System.Windows.Forms.TextBox txtConfirm;
    private System.Windows.Forms.CheckBox chkShowPassword;
    private System.Windows.Forms.Label lbRole;
    private System.Windows.Forms.ComboBox cbRole;
    private System.Windows.Forms.CheckBox chkActive;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btClear;

    #endregion
}