using System.ComponentModel;

namespace AppBaiDoXeThongMinh.ControlUser;

partial class UcTicketFullDetail
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        pnlTop = new Panel();
        lblTitle = new Label();
        btnPrintInvoice = new Button(); // <--- NÚT MỚI
        btnClose = new Button();
        pnlBody = new FlowLayoutPanel();
        grbTicket = new GroupBox();
        lblTicketCode = new Label();
        lblTicketStatus = new Label();
        lblTicketType = new Label();
        lblSlotInfo = new Label();
        lblEntryTime = new Label();
        lblExitTime = new Label();
        lblDuration = new Label();
        grbVehicle = new GroupBox();
        lblPlate = new Label();
        lblVType = new Label();
        lblBrandColor = new Label();
        lblOwner = new Label();
        lblPhone = new Label();
        grbInvoice = new GroupBox();
        lblInvoiceId = new Label();
        lblTotalAmount = new Label();
        lblPayMethod = new Label();
        lblPayDate = new Label();
        lblCreator = new Label();
        lblShift = new Label();

        pnlTop.SuspendLayout();
        pnlBody.SuspendLayout();
        grbTicket.SuspendLayout();
        grbVehicle.SuspendLayout();
        grbInvoice.SuspendLayout();
        SuspendLayout();

        // pnlTop
        pnlTop.BackColor = Color.FromArgb(235, 242, 250);
        pnlTop.Controls.Add(btnPrintInvoice); // <--- THÊM VÀO TOP PANEL
        pnlTop.Controls.Add(btnClose);
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Padding = new Padding(10, 6, 10, 6);
        pnlTop.Size = new Size(520, 44);
        pnlTop.TabIndex = 0;

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Dock = DockStyle.Left;
        lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(25, 65, 105);
        lblTitle.Location = new Point(10, 6);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(190, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "CHI TIẾT THÔNG TIN VÉ";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;

        // btnPrintInvoice
        btnPrintInvoice.BackColor = Color.FromArgb(40, 145, 75);
        btnPrintInvoice.Cursor = Cursors.Hand;
        btnPrintInvoice.Dock = DockStyle.Right;
        btnPrintInvoice.FlatAppearance.BorderSize = 0;
        btnPrintInvoice.FlatStyle = FlatStyle.Flat;
        btnPrintInvoice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnPrintInvoice.ForeColor = Color.White;
        btnPrintInvoice.Location = new Point(260, 6);
        btnPrintInvoice.Name = "btnPrintInvoice";
        btnPrintInvoice.Size = new Size(115, 32);
        btnPrintInvoice.TabIndex = 2;
        btnPrintInvoice.Text = "🖨 In hóa đơn";
        btnPrintInvoice.UseVisualStyleBackColor = false;

        // btnClose
        btnClose.BackColor = Color.FromArgb(215, 70, 70);
        btnClose.Cursor = Cursors.Hand;
        btnClose.Dock = DockStyle.Right;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(375, 6);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(110, 32);
        btnClose.TabIndex = 1;
        btnClose.Text = "✕ Quay lại";
        btnClose.UseVisualStyleBackColor = false;

        // pnlBody
        pnlBody.AutoScroll = true;
        pnlBody.Controls.Add(grbTicket);
        pnlBody.Controls.Add(grbVehicle);
        pnlBody.Controls.Add(grbInvoice);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.FlowDirection = FlowDirection.TopDown;
        pnlBody.Location = new Point(0, 44);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(10);
        pnlBody.Size = new Size(520, 310);
        pnlBody.TabIndex = 1;
        pnlBody.WrapContents = false;

        // grbTicket
        grbTicket.Controls.Add(lblDuration);
        grbTicket.Controls.Add(lblExitTime);
        grbTicket.Controls.Add(lblEntryTime);
        grbTicket.Controls.Add(lblSlotInfo);
        grbTicket.Controls.Add(lblTicketType);
        grbTicket.Controls.Add(lblTicketStatus);
        grbTicket.Controls.Add(lblTicketCode);
        grbTicket.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grbTicket.ForeColor = Color.FromArgb(25, 105, 170);
        grbTicket.Location = new Point(13, 13);
        grbTicket.Name = "grbTicket";
        grbTicket.Size = new Size(480, 195);
        grbTicket.TabIndex = 0;
        grbTicket.TabStop = false;
        grbTicket.Text = "1. Thông tin vé gửi xe";

        ConfigureDetailLabel(lblTicketCode, 24, "Mã vé:");
        ConfigureDetailLabel(lblTicketStatus, 47, "Trạng thái:");
        ConfigureDetailLabel(lblTicketType, 70, "Loại vé:");
        ConfigureDetailLabel(lblSlotInfo, 93, "Vị trí đỗ:");
        ConfigureDetailLabel(lblEntryTime, 116, "Giờ vào:");
        ConfigureDetailLabel(lblExitTime, 139, "Giờ ra:");
        ConfigureDetailLabel(lblDuration, 162, "Thời gian gửi:");

        // grbVehicle
        grbVehicle.Controls.Add(lblPhone);
        grbVehicle.Controls.Add(lblOwner);
        grbVehicle.Controls.Add(lblBrandColor);
        grbVehicle.Controls.Add(lblVType);
        grbVehicle.Controls.Add(lblPlate);
        grbVehicle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grbVehicle.ForeColor = Color.FromArgb(25, 105, 170);
        grbVehicle.Location = new Point(13, 214);
        grbVehicle.Name = "grbVehicle";
        grbVehicle.Size = new Size(480, 150);
        grbVehicle.TabIndex = 1;
        grbVehicle.TabStop = false;
        grbVehicle.Text = "2. Thông tin phương tiện & chủ xe";

        ConfigureDetailLabel(lblPlate, 24, "Biển số:");
        ConfigureDetailLabel(lblVType, 47, "Loại xe:");
        ConfigureDetailLabel(lblBrandColor, 70, "Hãng / Màu sắc:");
        ConfigureDetailLabel(lblOwner, 93, "Chủ xe:");
        ConfigureDetailLabel(lblPhone, 116, "Số điện thoại:");

        // grbInvoice
        grbInvoice.Controls.Add(lblShift);
        grbInvoice.Controls.Add(lblCreator);
        grbInvoice.Controls.Add(lblPayDate);
        grbInvoice.Controls.Add(lblPayMethod);
        grbInvoice.Controls.Add(lblTotalAmount);
        grbInvoice.Controls.Add(lblInvoiceId);
        grbInvoice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grbInvoice.ForeColor = Color.FromArgb(25, 105, 170);
        grbInvoice.Location = new Point(13, 370);
        grbInvoice.Name = "grbInvoice";
        grbInvoice.Size = new Size(480, 172);
        grbInvoice.TabIndex = 2;
        grbInvoice.TabStop = false;
        grbInvoice.Text = "3. Thông tin hóa đơn thanh toán";

        ConfigureDetailLabel(lblInvoiceId, 24, "Mã hóa đơn:");
        ConfigureDetailLabel(lblTotalAmount, 47, "Tổng tiền:");
        ConfigureDetailLabel(lblPayMethod, 70, "Hình thức TT:");
        ConfigureDetailLabel(lblPayDate, 93, "Thời điểm TT:");
        ConfigureDetailLabel(lblCreator, 116, "Người lập:");
        ConfigureDetailLabel(lblShift, 139, "Ca trực:");

        // UcTicketFullDetail
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        BorderStyle = BorderStyle.FixedSingle;
        Controls.Add(pnlBody);
        Controls.Add(pnlTop);
        Name = "UcTicketFullDetail";
        Size = new Size(520, 354);

        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlBody.ResumeLayout(false);
        grbTicket.ResumeLayout(false);
        grbVehicle.ResumeLayout(false);
        grbInvoice.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static void ConfigureDetailLabel(Label lbl, int top, string defaultText)
    {
        lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        lbl.ForeColor = Color.Black;
        lbl.Location = new Point(14, top);
        lbl.Size = new Size(450, 22);
        lbl.Text = defaultText;
    }

    private Panel pnlTop;
    private Label lblTitle;
    private Button btnPrintInvoice; // <--- KHAI BÁO NÚT MỚI
    private Button btnClose;
    private FlowLayoutPanel pnlBody;
    private GroupBox grbTicket;
    private Label lblTicketCode;
    private Label lblTicketStatus;
    private Label lblTicketType;
    private Label lblSlotInfo;
    private Label lblEntryTime;
    private Label lblExitTime;
    private Label lblDuration;
    private GroupBox grbVehicle;
    private Label lblPlate;
    private Label lblVType;
    private Label lblBrandColor;
    private Label lblOwner;
    private Label lblPhone;
    private GroupBox grbInvoice;
    private Label lblInvoiceId;
    private Label lblTotalAmount;
    private Label lblPayMethod;
    private Label lblPayDate;
    private Label lblCreator;
    private Label lblShift;

    #endregion
}
