namespace AppBaiDoXeThongMinh.Views
{
    partial class FormCheckIn
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
            this.lblStats = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.pnlSubHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblCardCode = new System.Windows.Forms.Label();
            this.txtCardCodeIn = new System.Windows.Forms.TextBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cboVehicleType = new System.Windows.Forms.ComboBox();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.txtLicensePlateIn = new System.Windows.Forms.TextBox();
            this.pnlInputStatus = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvParkedVehicles = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);

            this.pnlHeader.SuspendLayout();
            this.pnlSubHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkedVehicles)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlHeader.Controls.Add(this.lblStats);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 42);

            // lblStats
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblStats.ForeColor = System.Drawing.Color.Cyan;
            this.lblStats.Location = new System.Drawing.Point(15, 11);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(260, 20);
            this.lblStats.Text = "Đang gửi: 0 xe | Doanh thu: 0 đ";

            // lblClock
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.Gold;
            this.lblClock.Location = new System.Drawing.Point(650, 11);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(220, 20);
            this.lblClock.Text = "00:00:00 - 01/01/2026";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlSubHeader
            this.pnlSubHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlSubHeader.Controls.Add(this.lblSubTitle);
            this.pnlSubHeader.Location = new System.Drawing.Point(15, 52);
            this.pnlSubHeader.Name = "pnlSubHeader";
            this.pnlSubHeader.Size = new System.Drawing.Size(854, 38);

            // lblSubTitle
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubTitle.ForeColor = System.Drawing.Color.White;
            this.lblSubTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(854, 38);
            this.lblSubTitle.Text = "1. LÀN VÀO – QUẸT THẺ & NHẬP BIỂN SỐ";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblCardCode
            this.lblCardCode.AutoSize = true;
            this.lblCardCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardCode.Location = new System.Drawing.Point(15, 105);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new System.Drawing.Size(110, 19);
            this.lblCardCode.Text = "Mã thẻ RFID:";

            // txtCardCodeIn
            this.txtCardCodeIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtCardCodeIn.Location = new System.Drawing.Point(130, 101);
            this.txtCardCodeIn.Name = "txtCardCodeIn";
            this.txtCardCodeIn.Size = new System.Drawing.Size(260, 27);

            // lblVehicleType
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVehicleType.Location = new System.Drawing.Point(450, 105);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(95, 19);
            this.lblVehicleType.Text = "Loại xe (F3):";

            // cboVehicleType
            this.cboVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboVehicleType.Location = new System.Drawing.Point(555, 101);
            this.cboVehicleType.Name = "cboVehicleType";
            this.cboVehicleType.Size = new System.Drawing.Size(314, 28);

            // lblLicensePlate
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLicensePlate.Location = new System.Drawing.Point(15, 142);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(120, 19);
            this.lblLicensePlate.Text = "Biển số xe vào:";

            // txtLicensePlateIn
            this.txtLicensePlateIn.BackColor = System.Drawing.Color.FromArgb(255, 255, 204);
            this.txtLicensePlateIn.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.txtLicensePlateIn.Location = new System.Drawing.Point(15, 166);
            this.txtLicensePlateIn.Name = "txtLicensePlateIn";
            this.txtLicensePlateIn.Size = new System.Drawing.Size(854, 57);
            this.txtLicensePlateIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // pnlInputStatus
            this.pnlInputStatus.BackColor = System.Drawing.Color.LightGray;
            this.pnlInputStatus.Location = new System.Drawing.Point(15, 232);
            this.pnlInputStatus.Name = "pnlInputStatus";
            this.pnlInputStatus.Size = new System.Drawing.Size(854, 14);

            // btnCheckIn
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(15, 255);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(854, 48);
            this.btnCheckIn.Text = "LƯU XE VÀO & MỞ BARRIER (F1 / Enter)";
            this.btnCheckIn.UseVisualStyleBackColor = false;

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSearch.Location = new System.Drawing.Point(15, 322);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(95, 17);
            this.lblSearch.Text = "Tìm thẻ/biển số:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(125, 318);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 25);

            // dgvParkedVehicles
            this.dgvParkedVehicles.AllowUserToAddRows = false;
            this.dgvParkedVehicles.AllowUserToDeleteRows = false;
            this.dgvParkedVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParkedVehicles.BackgroundColor = System.Drawing.Color.White;
            this.dgvParkedVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkedVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colCardCode, this.colLicensePlate, this.colVehicleType, this.colCheckInTime
            });
            this.dgvParkedVehicles.Location = new System.Drawing.Point(15, 352);
            this.dgvParkedVehicles.Name = "dgvParkedVehicles";
            this.dgvParkedVehicles.ReadOnly = true;
            this.dgvParkedVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParkedVehicles.Size = new System.Drawing.Size(854, 245);

            // Columns
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;

            this.colCardCode.DataPropertyName = "CardCode";
            this.colCardCode.HeaderText = "Mã thẻ";
            this.colCardCode.Name = "colCardCode";

            this.colLicensePlate.DataPropertyName = "LicensePlate";
            this.colLicensePlate.HeaderText = "Biển số";
            this.colLicensePlate.Name = "colLicensePlate";

            this.colVehicleType.DataPropertyName = "VehicleType";
            this.colVehicleType.HeaderText = "Loại xe";
            this.colVehicleType.Name = "colVehicleType";

            this.colCheckInTime.DataPropertyName = "CheckInTime";
            this.colCheckInTime.HeaderText = "Giờ vào";
            this.colCheckInTime.Name = "colCheckInTime";

            // FormCheckIn
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.dgvParkedVehicles);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.pnlInputStatus);
            this.Controls.Add(this.txtLicensePlateIn);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.cboVehicleType);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.txtCardCodeIn);
            this.Controls.Add(this.lblCardCode);
            this.Controls.Add(this.pnlSubHeader);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bãi Giữ Xe - Làn Vào (Check-In)";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSubHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkedVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblCardCode;
        private System.Windows.Forms.TextBox txtCardCodeIn;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cboVehicleType;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtLicensePlateIn;
        private System.Windows.Forms.Panel pnlInputStatus;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvParkedVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckInTime;
        private System.Windows.Forms.Timer tmrClock;
    }
}