using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormRevenueChart
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
        pnlFilter = new System.Windows.Forms.Panel();
        lbFrom = new System.Windows.Forms.Label();
        dtpFrom = new System.Windows.Forms.DateTimePicker();
        lbTo = new System.Windows.Forms.Label();
        dtpTo = new System.Windows.Forms.DateTimePicker();
        lbShift = new System.Windows.Forms.Label();
        cbShift = new System.Windows.Forms.ComboBox();
        lbVehicle = new System.Windows.Forms.Label();
        cbVehicle = new System.Windows.Forms.ComboBox();
        btApply = new System.Windows.Forms.Button();

        tlpKpi = new System.Windows.Forms.TableLayoutPanel();
        pnlKpiTotal = new System.Windows.Forms.Panel();
        lbKpiTotalValue = new System.Windows.Forms.Label();
        lbKpiTotalHeader = new System.Windows.Forms.Label();
        pnlKpiCount = new System.Windows.Forms.Panel();
        lbKpiCountValue = new System.Windows.Forms.Label();
        lbKpiCountHeader = new System.Windows.Forms.Label();
        pnlKpiAvg = new System.Windows.Forms.Panel();
        lbKpiAvgValue = new System.Windows.Forms.Label();
        lbKpiAvgHeader = new System.Windows.Forms.Label();
        pnlKpiPeak = new System.Windows.Forms.Panel();
        lbKpiPeakValue = new System.Windows.Forms.Label();
        lbKpiPeakHeader = new System.Windows.Forms.Label();

        tlpCharts = new System.Windows.Forms.TableLayoutPanel();
        pnlDaily = new System.Windows.Forms.Panel();
        pnlVehicle = new System.Windows.Forms.Panel();
        pnlHourly = new System.Windows.Forms.Panel();
        pnlMethod = new System.Windows.Forms.Panel();

        pnlFilter.SuspendLayout();
        tlpKpi.SuspendLayout();
        pnlKpiTotal.SuspendLayout();
        pnlKpiCount.SuspendLayout();
        pnlKpiAvg.SuspendLayout();
        pnlKpiPeak.SuspendLayout();
        tlpCharts.SuspendLayout();
        SuspendLayout();

        //
        // pnlFilter
        //
        pnlFilter.BackColor = System.Drawing.Color.FromArgb(22, 48, 75);
        pnlFilter.Controls.Add(lbFrom);
        pnlFilter.Controls.Add(dtpFrom);
        pnlFilter.Controls.Add(lbTo);
        pnlFilter.Controls.Add(dtpTo);
        pnlFilter.Controls.Add(lbShift);
        pnlFilter.Controls.Add(cbShift);
        pnlFilter.Controls.Add(lbVehicle);
        pnlFilter.Controls.Add(cbVehicle);
        pnlFilter.Controls.Add(btApply);
        pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
        pnlFilter.Location = new System.Drawing.Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Size = new System.Drawing.Size(1180, 54);
        pnlFilter.TabIndex = 2;
        //
        // lbFrom
        //
        lbFrom.ForeColor = System.Drawing.Color.White;
        lbFrom.Location = new System.Drawing.Point(14, 17);
        lbFrom.Name = "lbFrom";
        lbFrom.Size = new System.Drawing.Size(56, 20);
        lbFrom.TabIndex = 0;
        lbFrom.Text = "Từ ngày";
        lbFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // dtpFrom
        //
        dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpFrom.Location = new System.Drawing.Point(72, 15);
        dtpFrom.Name = "dtpFrom";
        dtpFrom.Size = new System.Drawing.Size(115, 23);
        dtpFrom.TabIndex = 1;
        //
        // lbTo
        //
        lbTo.ForeColor = System.Drawing.Color.White;
        lbTo.Location = new System.Drawing.Point(204, 17);
        lbTo.Name = "lbTo";
        lbTo.Size = new System.Drawing.Size(62, 20);
        lbTo.TabIndex = 2;
        lbTo.Text = "Đến ngày";
        lbTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // dtpTo
        //
        dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpTo.Location = new System.Drawing.Point(268, 15);
        dtpTo.Name = "dtpTo";
        dtpTo.Size = new System.Drawing.Size(115, 23);
        dtpTo.TabIndex = 3;
        //
        // lbShift
        //
        lbShift.ForeColor = System.Drawing.Color.White;
        lbShift.Location = new System.Drawing.Point(402, 17);
        lbShift.Name = "lbShift";
        lbShift.Size = new System.Drawing.Size(26, 20);
        lbShift.TabIndex = 4;
        lbShift.Text = "Ca";
        lbShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // cbShift
        //
        cbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbShift.FormattingEnabled = true;
        cbShift.Items.AddRange(new object[] { "Tất cả các ca", "Ca sáng", "Ca đêm" });
        cbShift.Location = new System.Drawing.Point(430, 15);
        cbShift.Name = "cbShift";
        cbShift.Size = new System.Drawing.Size(130, 23);
        cbShift.TabIndex = 5;
        //
        // lbVehicle
        //
        lbVehicle.ForeColor = System.Drawing.Color.White;
        lbVehicle.Location = new System.Drawing.Point(578, 17);
        lbVehicle.Name = "lbVehicle";
        lbVehicle.Size = new System.Drawing.Size(56, 20);
        lbVehicle.TabIndex = 6;
        lbVehicle.Text = "Loại xe";
        lbVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // cbVehicle
        //
        cbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbVehicle.FormattingEnabled = true;
        cbVehicle.Items.AddRange(new object[] { "Tất cả", "Xe máy", "Ô tô" });
        cbVehicle.Location = new System.Drawing.Point(636, 15);
        cbVehicle.Name = "cbVehicle";
        cbVehicle.Size = new System.Drawing.Size(120, 23);
        cbVehicle.TabIndex = 7;
        //
        // btApply
        //
        btApply.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btApply.FlatAppearance.BorderSize = 0;
        btApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btApply.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        btApply.ForeColor = System.Drawing.Color.White;
        btApply.Location = new System.Drawing.Point(776, 11);
        btApply.Name = "btApply";
        btApply.Size = new System.Drawing.Size(120, 32);
        btApply.TabIndex = 8;
        btApply.Text = "Cập nhật";
        btApply.UseVisualStyleBackColor = false;

        //
        // tlpKpi
        //
        tlpKpi.ColumnCount = 4;
        tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tlpKpi.Controls.Add(pnlKpiTotal, 0, 0);
        tlpKpi.Controls.Add(pnlKpiCount, 1, 0);
        tlpKpi.Controls.Add(pnlKpiAvg, 2, 0);
        tlpKpi.Controls.Add(pnlKpiPeak, 3, 0);
        tlpKpi.Dock = System.Windows.Forms.DockStyle.Top;
        tlpKpi.Location = new System.Drawing.Point(0, 54);
        tlpKpi.Name = "tlpKpi";
        tlpKpi.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
        tlpKpi.RowCount = 1;
        tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpKpi.Size = new System.Drawing.Size(1180, 88);
        tlpKpi.TabIndex = 1;
        //
        // pnlKpiTotal
        //
        pnlKpiTotal.BackColor = System.Drawing.Color.White;
        pnlKpiTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlKpiTotal.Controls.Add(lbKpiTotalValue);
        pnlKpiTotal.Controls.Add(lbKpiTotalHeader);
        pnlKpiTotal.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlKpiTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        pnlKpiTotal.Name = "pnlKpiTotal";
        pnlKpiTotal.TabIndex = 0;
        //
        // lbKpiTotalHeader
        //
        lbKpiTotalHeader.BackColor = System.Drawing.Color.FromArgb(173, 216, 250);
        lbKpiTotalHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbKpiTotalHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbKpiTotalHeader.Name = "lbKpiTotalHeader";
        lbKpiTotalHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbKpiTotalHeader.Size = new System.Drawing.Size(100, 26);
        lbKpiTotalHeader.TabIndex = 0;
        lbKpiTotalHeader.Text = "Tổng doanh thu";
        lbKpiTotalHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbKpiTotalValue
        //
        lbKpiTotalValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbKpiTotalValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lbKpiTotalValue.ForeColor = System.Drawing.Color.FromArgb(70, 130, 190);
        lbKpiTotalValue.Name = "lbKpiTotalValue";
        lbKpiTotalValue.TabIndex = 1;
        lbKpiTotalValue.Text = "0 VNĐ";
        lbKpiTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlKpiCount
        //
        pnlKpiCount.BackColor = System.Drawing.Color.White;
        pnlKpiCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlKpiCount.Controls.Add(lbKpiCountValue);
        pnlKpiCount.Controls.Add(lbKpiCountHeader);
        pnlKpiCount.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlKpiCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        pnlKpiCount.Name = "pnlKpiCount";
        pnlKpiCount.TabIndex = 1;
        //
        // lbKpiCountHeader
        //
        lbKpiCountHeader.BackColor = System.Drawing.Color.FromArgb(160, 220, 205);
        lbKpiCountHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbKpiCountHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbKpiCountHeader.Name = "lbKpiCountHeader";
        lbKpiCountHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbKpiCountHeader.Size = new System.Drawing.Size(100, 26);
        lbKpiCountHeader.TabIndex = 0;
        lbKpiCountHeader.Text = "Số giao dịch";
        lbKpiCountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbKpiCountValue
        //
        lbKpiCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbKpiCountValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lbKpiCountValue.ForeColor = System.Drawing.Color.FromArgb(70, 160, 90);
        lbKpiCountValue.Name = "lbKpiCountValue";
        lbKpiCountValue.TabIndex = 1;
        lbKpiCountValue.Text = "0";
        lbKpiCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlKpiAvg
        //
        pnlKpiAvg.BackColor = System.Drawing.Color.White;
        pnlKpiAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlKpiAvg.Controls.Add(lbKpiAvgValue);
        pnlKpiAvg.Controls.Add(lbKpiAvgHeader);
        pnlKpiAvg.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlKpiAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        pnlKpiAvg.Name = "pnlKpiAvg";
        pnlKpiAvg.TabIndex = 2;
        //
        // lbKpiAvgHeader
        //
        lbKpiAvgHeader.BackColor = System.Drawing.Color.FromArgb(252, 205, 140);
        lbKpiAvgHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbKpiAvgHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbKpiAvgHeader.Name = "lbKpiAvgHeader";
        lbKpiAvgHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbKpiAvgHeader.Size = new System.Drawing.Size(100, 26);
        lbKpiAvgHeader.TabIndex = 0;
        lbKpiAvgHeader.Text = "Trung bình / giao dịch";
        lbKpiAvgHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbKpiAvgValue
        //
        lbKpiAvgValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbKpiAvgValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lbKpiAvgValue.ForeColor = System.Drawing.Color.FromArgb(225, 150, 40);
        lbKpiAvgValue.Name = "lbKpiAvgValue";
        lbKpiAvgValue.TabIndex = 1;
        lbKpiAvgValue.Text = "0 VNĐ";
        lbKpiAvgValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // pnlKpiPeak
        //
        pnlKpiPeak.BackColor = System.Drawing.Color.White;
        pnlKpiPeak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlKpiPeak.Controls.Add(lbKpiPeakValue);
        pnlKpiPeak.Controls.Add(lbKpiPeakHeader);
        pnlKpiPeak.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlKpiPeak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        pnlKpiPeak.Name = "pnlKpiPeak";
        pnlKpiPeak.TabIndex = 3;
        //
        // lbKpiPeakHeader
        //
        lbKpiPeakHeader.BackColor = System.Drawing.Color.FromArgb(250, 170, 175);
        lbKpiPeakHeader.Dock = System.Windows.Forms.DockStyle.Top;
        lbKpiPeakHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lbKpiPeakHeader.Name = "lbKpiPeakHeader";
        lbKpiPeakHeader.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
        lbKpiPeakHeader.Size = new System.Drawing.Size(100, 26);
        lbKpiPeakHeader.TabIndex = 0;
        lbKpiPeakHeader.Text = "Ngày doanh thu cao nhất";
        lbKpiPeakHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lbKpiPeakValue
        //
        lbKpiPeakValue.Dock = System.Windows.Forms.DockStyle.Fill;
        lbKpiPeakValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lbKpiPeakValue.ForeColor = System.Drawing.Color.FromArgb(215, 90, 90);
        lbKpiPeakValue.Name = "lbKpiPeakValue";
        lbKpiPeakValue.TabIndex = 1;
        lbKpiPeakValue.Text = "—";
        lbKpiPeakValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        //
        // tlpCharts
        //
        tlpCharts.ColumnCount = 2;
        tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
        tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
        tlpCharts.Controls.Add(pnlDaily, 0, 0);
        tlpCharts.Controls.Add(pnlVehicle, 1, 0);
        tlpCharts.Controls.Add(pnlHourly, 0, 1);
        tlpCharts.Controls.Add(pnlMethod, 1, 1);
        tlpCharts.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpCharts.Location = new System.Drawing.Point(0, 142);
        tlpCharts.Name = "tlpCharts";
        tlpCharts.Padding = new System.Windows.Forms.Padding(6);
        tlpCharts.RowCount = 2;
        tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
        tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
        tlpCharts.Size = new System.Drawing.Size(1180, 578);
        tlpCharts.TabIndex = 0;
        //
        // pnlDaily
        //
        pnlDaily.BackColor = System.Drawing.Color.White;
        pnlDaily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlDaily.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlDaily.Margin = new System.Windows.Forms.Padding(4);
        pnlDaily.Name = "pnlDaily";
        pnlDaily.TabIndex = 0;
        //
        // pnlVehicle
        //
        pnlVehicle.BackColor = System.Drawing.Color.White;
        pnlVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlVehicle.Margin = new System.Windows.Forms.Padding(4);
        pnlVehicle.Name = "pnlVehicle";
        pnlVehicle.TabIndex = 1;
        //
        // pnlHourly
        //
        pnlHourly.BackColor = System.Drawing.Color.White;
        pnlHourly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlHourly.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlHourly.Margin = new System.Windows.Forms.Padding(4);
        pnlHourly.Name = "pnlHourly";
        pnlHourly.TabIndex = 2;
        //
        // pnlMethod
        //
        pnlMethod.BackColor = System.Drawing.Color.White;
        pnlMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlMethod.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlMethod.Margin = new System.Windows.Forms.Padding(4);
        pnlMethod.Name = "pnlMethod";
        pnlMethod.TabIndex = 3;

        //
        // FormRevenueChart
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(243, 246, 250);
        ClientSize = new System.Drawing.Size(1180, 720);
        Controls.Add(tlpCharts);
        Controls.Add(tlpKpi);
        Controls.Add(pnlFilter);
        MinimumSize = new System.Drawing.Size(980, 620);
        Name = "FormRevenueChart";
        Text = "Thống kê doanh thu";

        pnlFilter.ResumeLayout(false);
        tlpKpi.ResumeLayout(false);
        pnlKpiTotal.ResumeLayout(false);
        pnlKpiCount.ResumeLayout(false);
        pnlKpiAvg.ResumeLayout(false);
        pnlKpiPeak.ResumeLayout(false);
        tlpCharts.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.Label lbFrom;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.Label lbTo;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.Label lbShift;
    private System.Windows.Forms.ComboBox cbShift;
    private System.Windows.Forms.Label lbVehicle;
    private System.Windows.Forms.ComboBox cbVehicle;
    private System.Windows.Forms.Button btApply;

    private System.Windows.Forms.TableLayoutPanel tlpKpi;
    private System.Windows.Forms.Panel pnlKpiTotal;
    private System.Windows.Forms.Label lbKpiTotalValue;
    private System.Windows.Forms.Label lbKpiTotalHeader;
    private System.Windows.Forms.Panel pnlKpiCount;
    private System.Windows.Forms.Label lbKpiCountValue;
    private System.Windows.Forms.Label lbKpiCountHeader;
    private System.Windows.Forms.Panel pnlKpiAvg;
    private System.Windows.Forms.Label lbKpiAvgValue;
    private System.Windows.Forms.Label lbKpiAvgHeader;
    private System.Windows.Forms.Panel pnlKpiPeak;
    private System.Windows.Forms.Label lbKpiPeakValue;
    private System.Windows.Forms.Label lbKpiPeakHeader;

    private System.Windows.Forms.TableLayoutPanel tlpCharts;
    private System.Windows.Forms.Panel pnlDaily;
    private System.Windows.Forms.Panel pnlVehicle;
    private System.Windows.Forms.Panel pnlHourly;
    private System.Windows.Forms.Panel pnlMethod;

    #endregion
}