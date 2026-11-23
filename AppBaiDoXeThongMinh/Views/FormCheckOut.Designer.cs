namespace AppBaiDoXeThongMinh.Views
{
    partial class FormCheckOut
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlHeader = new System.Windows.Forms.Panel();
            lblStats = new System.Windows.Forms.Label();
            lblClock = new System.Windows.Forms.Label();
            pnlSubHeader = new System.Windows.Forms.Panel();
            lblSubTitle = new System.Windows.Forms.Label();
            lblCardCodeOut = new System.Windows.Forms.Label();
            txtCardCodeOut = new System.Windows.Forms.TextBox();
            lblRecordedTitle = new System.Windows.Forms.Label();
            txtLicensePlateRecorded = new System.Windows.Forms.TextBox();
            lblOutTitle = new System.Windows.Forms.Label();
            txtLicensePlateOut = new System.Windows.Forms.TextBox();
            lblFee = new System.Windows.Forms.Label();
            lblMatchStatus = new System.Windows.Forms.Label();
            btnCheckOut = new System.Windows.Forms.Button();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnLoadLostCard = new System.Windows.Forms.Button();
            dgvParkedVehicles = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCheckInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tmrClock = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlSubHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParkedVehicles).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)30)));
            pnlHeader.Controls.Add(lblStats);
            pnlHeader.Controls.Add(lblClock);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(884, 42);
            pnlHeader.TabIndex = 14;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblStats.ForeColor = System.Drawing.Color.Cyan;
            lblStats.Location = new System.Drawing.Point(15, 11);
            lblStats.Name = "lblStats";
            lblStats.Size = new System.Drawing.Size(277, 25);
            lblStats.TabIndex = 0;
            lblStats.Text = "Đang gửi: 0 xe | Doanh thu: 0 đ";
            // 
            // lblClock
            // 
            lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            lblClock.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblClock.ForeColor = System.Drawing.Color.Gold;
            lblClock.Location = new System.Drawing.Point(650, 11);
            lblClock.Name = "lblClock";
            lblClock.Size = new System.Drawing.Size(220, 20);
            lblClock.TabIndex = 1;
            lblClock.Text = "00:00:00 - 01/01/2026";
            lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSubHeader
            // 
            pnlSubHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)41)), ((int)((byte)54)));
            pnlSubHeader.Controls.Add(lblSubTitle);
            pnlSubHeader.Location = new System.Drawing.Point(15, 52);
            pnlSubHeader.Name = "pnlSubHeader";
            pnlSubHeader.Size = new System.Drawing.Size(854, 38);
            pnlSubHeader.TabIndex = 13;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblSubTitle.ForeColor = System.Drawing.Color.White;
            lblSubTitle.Location = new System.Drawing.Point(0, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new System.Drawing.Size(854, 38);
            lblSubTitle.TabIndex = 0;
            lblSubTitle.Text = "2. LÀN RA – ĐỐI CHIẾU BIỂN SỐ & TÍNH CƯỚC";
            lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardCodeOut
            // 
            lblCardCodeOut.AutoSize = true;
            lblCardCodeOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCardCodeOut.Location = new System.Drawing.Point(15, 102);
            lblCardCodeOut.Name = "lblCardCodeOut";
            lblCardCodeOut.Size = new System.Drawing.Size(124, 23);
            lblCardCodeOut.TabIndex = 12;
            lblCardCodeOut.Text = "Quẹt thẻ xe ra:";
            // 
            // txtCardCodeOut
            // 
            txtCardCodeOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtCardCodeOut.Location = new System.Drawing.Point(130, 98);
            txtCardCodeOut.Name = "txtCardCodeOut";
            txtCardCodeOut.Size = new System.Drawing.Size(260, 32);
            txtCardCodeOut.TabIndex = 11;
            // 
            // lblRecordedTitle
            // 
            lblRecordedTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblRecordedTitle.Location = new System.Drawing.Point(15, 134);
            lblRecordedTitle.Name = "lblRecordedTitle";
            lblRecordedTitle.Size = new System.Drawing.Size(415, 20);
            lblRecordedTitle.TabIndex = 10;
            lblRecordedTitle.Text = "BIỂN SỐ GHI LÚC VÀO";
            lblRecordedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLicensePlateRecorded
            // 
            txtLicensePlateRecorded.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)235)), ((int)((byte)100)));
            txtLicensePlateRecorded.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            txtLicensePlateRecorded.Location = new System.Drawing.Point(15, 156);
            txtLicensePlateRecorded.Name = "txtLicensePlateRecorded";
            txtLicensePlateRecorded.ReadOnly = true;
            txtLicensePlateRecorded.Size = new System.Drawing.Size(415, 65);
            txtLicensePlateRecorded.TabIndex = 9;
            txtLicensePlateRecorded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOutTitle
            // 
            lblOutTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblOutTitle.Location = new System.Drawing.Point(454, 134);
            lblOutTitle.Name = "lblOutTitle";
            lblOutTitle.Size = new System.Drawing.Size(415, 20);
            lblOutTitle.TabIndex = 8;
            lblOutTitle.Text = "GÕ BIỂN SỐ XE RA ĐỂ KHỚP";
            lblOutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLicensePlateOut
            // 
            txtLicensePlateOut.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)204)));
            txtLicensePlateOut.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            txtLicensePlateOut.Location = new System.Drawing.Point(454, 156);
            txtLicensePlateOut.Name = "txtLicensePlateOut";
            txtLicensePlateOut.Size = new System.Drawing.Size(415, 65);
            txtLicensePlateOut.TabIndex = 7;
            txtLicensePlateOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFee
            // 
            lblFee.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblFee.ForeColor = System.Drawing.Color.Red;
            lblFee.Location = new System.Drawing.Point(15, 215);
            lblFee.Name = "lblFee";
            lblFee.Size = new System.Drawing.Size(854, 38);
            lblFee.TabIndex = 6;
            lblFee.Text = "0 VNĐ";
            lblFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMatchStatus
            // 
            lblMatchStatus.BackColor = System.Drawing.Color.LightGray;
            lblMatchStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMatchStatus.Location = new System.Drawing.Point(15, 256);
            lblMatchStatus.Name = "lblMatchStatus";
            lblMatchStatus.Size = new System.Drawing.Size(854, 26);
            lblMatchStatus.TabIndex = 5;
            lblMatchStatus.Text = "SẴN SÀNG QUẸT THẺ RA";
            lblMatchStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)102)), ((int)((byte)204)));
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            btnCheckOut.ForeColor = System.Drawing.Color.White;
            btnCheckOut.Location = new System.Drawing.Point(15, 288);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new System.Drawing.Size(854, 46);
            btnCheckOut.TabIndex = 4;
            btnCheckOut.Text = "XÁC NHẬN KHỚP & MỞ BARRIER RA (F2 / Enter)";
            btnCheckOut.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblSearch.Location = new System.Drawing.Point(15, 353);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(121, 21);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Tìm thẻ/biển số:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(125, 349);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(265, 30);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnLoadLostCard
            // 
            btnLoadLostCard.BackColor = System.Drawing.Color.FromArgb(((int)((byte)240)), ((int)((byte)140)), ((int)((byte)0)));
            btnLoadLostCard.FlatAppearance.BorderSize = 0;
            btnLoadLostCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLoadLostCard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLoadLostCard.ForeColor = System.Drawing.Color.White;
            btnLoadLostCard.Location = new System.Drawing.Point(405, 346);
            btnLoadLostCard.Name = "btnLoadLostCard";
            btnLoadLostCard.Size = new System.Drawing.Size(340, 30);
            btnLoadLostCard.TabIndex = 1;
            btnLoadLostCard.Text = "Nạp xe đang chọn lên Làn Ra / Mất thẻ (F5)";
            btnLoadLostCard.UseVisualStyleBackColor = false;
            // 
            // dgvParkedVehicles
            // 
            dgvParkedVehicles.AllowUserToAddRows = false;
            dgvParkedVehicles.AllowUserToDeleteRows = false;
            dgvParkedVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvParkedVehicles.BackgroundColor = System.Drawing.Color.White;
            dgvParkedVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParkedVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colCardCode, colLicensePlate, colVehicleType, colCheckInTime });
            dgvParkedVehicles.Location = new System.Drawing.Point(15, 384);
            dgvParkedVehicles.Name = "dgvParkedVehicles";
            dgvParkedVehicles.ReadOnly = true;
            dgvParkedVehicles.RowHeadersWidth = 51;
            dgvParkedVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvParkedVehicles.Size = new System.Drawing.Size(854, 240);
            dgvParkedVehicles.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colCardCode
            // 
            colCardCode.DataPropertyName = "CardCode";
            colCardCode.HeaderText = "Mã thẻ";
            colCardCode.MinimumWidth = 6;
            colCardCode.Name = "colCardCode";
            colCardCode.ReadOnly = true;
            // 
            // colLicensePlate
            // 
            colLicensePlate.DataPropertyName = "LicensePlate";
            colLicensePlate.HeaderText = "Biển số";
            colLicensePlate.MinimumWidth = 6;
            colLicensePlate.Name = "colLicensePlate";
            colLicensePlate.ReadOnly = true;
            // 
            // colVehicleType
            // 
            colVehicleType.DataPropertyName = "VehicleType";
            colVehicleType.HeaderText = "Loại xe";
            colVehicleType.MinimumWidth = 6;
            colVehicleType.Name = "colVehicleType";
            colVehicleType.ReadOnly = true;
            // 
            // colCheckInTime
            // 
            colCheckInTime.DataPropertyName = "CheckInTime";
            colCheckInTime.HeaderText = "Giờ vào";
            colCheckInTime.MinimumWidth = 6;
            colCheckInTime.Name = "colCheckInTime";
            colCheckInTime.ReadOnly = true;
            // 
            // FormCheckOut
            // 
            ClientSize = new System.Drawing.Size(884, 636);
            Controls.Add(dgvParkedVehicles);
            Controls.Add(btnLoadLostCard);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnCheckOut);
            Controls.Add(lblMatchStatus);
            Controls.Add(lblFee);
            Controls.Add(txtLicensePlateOut);
            Controls.Add(lblOutTitle);
            Controls.Add(txtLicensePlateRecorded);
            Controls.Add(lblRecordedTitle);
            Controls.Add(txtCardCodeOut);
            Controls.Add(lblCardCodeOut);
            Controls.Add(pnlSubHeader);
            Controls.Add(pnlHeader);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Bãi Giữ Xe - Làn Ra (Check-Out)";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSubHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParkedVehicles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblCardCodeOut;
        private System.Windows.Forms.TextBox txtCardCodeOut;
        private System.Windows.Forms.Label lblRecordedTitle;
        private System.Windows.Forms.TextBox txtLicensePlateRecorded;
        private System.Windows.Forms.Label lblOutTitle;
        private System.Windows.Forms.TextBox txtLicensePlateOut;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label lblMatchStatus;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLoadLostCard;
        private System.Windows.Forms.DataGridView dgvParkedVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckInTime;
        private System.Windows.Forms.Timer tmrClock;
    }
}