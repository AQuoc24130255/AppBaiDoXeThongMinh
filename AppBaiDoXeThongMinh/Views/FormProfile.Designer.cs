namespace AppBaiDoXeThongMinh.Views
{
    partial class FormProfile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.lblFullNameTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblUsernameTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRoleTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.lblAttendanceTitle = new System.Windows.Forms.Label();
            this.lblShiftStatus = new System.Windows.Forms.Label();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.dgvShiftHistory = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);

            this.pnlHeader.SuspendLayout();
            this.grpUserInfo.SuspendLayout();
            this.pnlAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftHistory)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(820, 45);

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(220, 21);
            this.lblHeaderTitle.Text = "HỒ SƠ CÁ NHÂN NHÂN SỰ";

            // lblClock
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.Gold;
            this.lblClock.Location = new System.Drawing.Point(580, 12);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(225, 21);
            this.lblClock.Text = "00:00:00 - 01/01/2026";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // grpUserInfo
            this.grpUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpUserInfo.Location = new System.Drawing.Point(15, 58);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(790, 195);
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Thông tin tài khoản";
            this.grpUserInfo.Controls.Add(this.lblRoleBadge);
            this.grpUserInfo.Controls.Add(this.lblFullNameTitle);
            this.grpUserInfo.Controls.Add(this.lblFullName);
            this.grpUserInfo.Controls.Add(this.lblUsernameTitle);
            this.grpUserInfo.Controls.Add(this.lblUsername);
            this.grpUserInfo.Controls.Add(this.lblRoleTitle);
            this.grpUserInfo.Controls.Add(this.lblRole);
            this.grpUserInfo.Controls.Add(this.lblOldPass);
            this.grpUserInfo.Controls.Add(this.txtOldPassword);
            this.grpUserInfo.Controls.Add(this.lblNewPass);
            this.grpUserInfo.Controls.Add(this.txtNewPassword);
            this.grpUserInfo.Controls.Add(this.btnChangePassword);

            // lblRoleBadge
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.White;
            this.lblRoleBadge.Location = new System.Drawing.Point(20, 32);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Size = new System.Drawing.Size(120, 110);
            this.lblRoleBadge.Text = "ADMIN";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblFullNameTitle & lblFullName
            this.lblFullNameTitle.AutoSize = true;
            this.lblFullNameTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullNameTitle.Location = new System.Drawing.Point(160, 35);
            this.lblFullNameTitle.Name = "lblFullNameTitle";
            this.lblFullNameTitle.Text = "Họ và tên:";

            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblFullName.Location = new System.Drawing.Point(265, 34);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Text = "Nguyễn Văn A";

            // lblUsernameTitle & lblUsername
            this.lblUsernameTitle.AutoSize = true;
            this.lblUsernameTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsernameTitle.Location = new System.Drawing.Point(160, 72);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Text = "Tên đăng nhập:";

            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(265, 71);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "baove01";

            // lblRoleTitle & lblRole
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoleTitle.Location = new System.Drawing.Point(160, 109);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Text = "Chức vụ:";

            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(265, 108);
            this.lblRole.Name = "lblRole";
            this.lblRole.Text = "Nhân viên bảo vệ";

            // Đổi mật khẩu (bên phải GroupBox)
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOldPass.Location = new System.Drawing.Point(470, 35);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Text = "Mật khẩu cũ:";

            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtOldPassword.Location = new System.Drawing.Point(575, 32);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(195, 24);
            this.txtOldPassword.UseSystemPasswordChar = true;

            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNewPass.Location = new System.Drawing.Point(470, 72);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Text = "Mật khẩu mới:";

            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNewPassword.Location = new System.Drawing.Point(575, 69);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(195, 24);
            this.txtNewPassword.UseSystemPasswordChar = true;

            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(575, 104);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(195, 32);
            this.btnChangePassword.Text = "Cập nhật mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = false;

            // pnlAttendance (Chỉ hiện khi là Bảo vệ)
            this.pnlAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAttendance.Controls.Add(this.lblAttendanceTitle);
            this.pnlAttendance.Controls.Add(this.lblShiftStatus);
            this.pnlAttendance.Controls.Add(this.btnAttendance);
            this.pnlAttendance.Controls.Add(this.dgvShiftHistory);
            this.pnlAttendance.Location = new System.Drawing.Point(15, 265);
            this.pnlAttendance.Name = "pnlAttendance";
            this.pnlAttendance.Size = new System.Drawing.Size(790, 320);

            // lblAttendanceTitle
            this.lblAttendanceTitle.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblAttendanceTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttendanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAttendanceTitle.ForeColor = System.Drawing.Color.White;
            this.lblAttendanceTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAttendanceTitle.Name = "lblAttendanceTitle";
            this.lblAttendanceTitle.Size = new System.Drawing.Size(788, 34);
            this.lblAttendanceTitle.Text = "CHẤM CÔNG CA TRỰC (DÀNH CHO BẢO VỆ)";
            this.lblAttendanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblShiftStatus
            this.lblShiftStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblShiftStatus.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.lblShiftStatus.Location = new System.Drawing.Point(15, 48);
            this.lblShiftStatus.Name = "lblShiftStatus";
            this.lblShiftStatus.Size = new System.Drawing.Size(480, 42);
            this.lblShiftStatus.Text = "Trạng thái: Chưa vào ca trực";
            this.lblShiftStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnAttendance
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(510, 46);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(262, 46);
            this.btnAttendance.Text = "CHẤM CÔNG VÀO CA";
            this.btnAttendance.UseVisualStyleBackColor = false;

            // dgvShiftHistory
            this.dgvShiftHistory.AllowUserToAddRows = false;
            this.dgvShiftHistory.AllowUserToDeleteRows = false;
            this.dgvShiftHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShiftHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvShiftHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiftHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDate, this.colStartTime, this.colEndTime, this.colDuration
            });
            this.dgvShiftHistory.Location = new System.Drawing.Point(15, 104);
            this.dgvShiftHistory.Name = "dgvShiftHistory";
            this.dgvShiftHistory.ReadOnly = true;
            this.dgvShiftHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShiftHistory.Size = new System.Drawing.Size(757, 200);

            // Columns
            this.colDate.DataPropertyName = "WorkDate";
            this.colDate.HeaderText = "Ngày trực";
            this.colDate.Name = "colDate";

            this.colStartTime.DataPropertyName = "StartTime";
            this.colStartTime.HeaderText = "Giờ vào ca";
            this.colStartTime.Name = "colStartTime";

            this.colEndTime.DataPropertyName = "EndTime";
            this.colEndTime.HeaderText = "Giờ tan ca";
            this.colEndTime.Name = "colEndTime";

            this.colDuration.DataPropertyName = "Duration";
            this.colDuration.HeaderText = "Thời lượng làm việc";
            this.colDuration.Name = "colDuration";

            // FormProfile
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.pnlAttendance);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Cá Nhân";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.pnlAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Label lblFullNameTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblUsernameTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRoleTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel pnlAttendance;
        private System.Windows.Forms.Label lblAttendanceTitle;
        private System.Windows.Forms.Label lblShiftStatus;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.DataGridView dgvShiftHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.Timer tmrClock;
    }
}