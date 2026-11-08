using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormDashboard
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
        groupBox1 = new System.Windows.Forms.GroupBox();
        flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        panel5 = new System.Windows.Forms.Panel();
        label17 = new System.Windows.Forms.Label();
        label18 = new System.Windows.Forms.Label();
        label19 = new System.Windows.Forms.Label();
        label20 = new System.Windows.Forms.Label();
        panel2 = new System.Windows.Forms.Panel();
        label5 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        panel3 = new System.Windows.Forms.Panel();
        label9 = new System.Windows.Forms.Label();
        label10 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        panel4 = new System.Windows.Forms.Panel();
        label13 = new System.Windows.Forms.Label();
        label14 = new System.Windows.Forms.Label();
        label15 = new System.Windows.Forms.Label();
        label16 = new System.Windows.Forms.Label();
        panel1 = new System.Windows.Forms.Panel();
        label4 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        groupBox2 = new System.Windows.Forms.GroupBox();
        flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        button1 = new System.Windows.Forms.Button();
        groupBox3 = new System.Windows.Forms.GroupBox();
        label6 = new System.Windows.Forms.Label();
        flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        label21 = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        groupBox4 = new System.Windows.Forms.GroupBox();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
        groupBox1.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        panel5.SuspendLayout();
        panel2.SuspendLayout();
        panel3.SuspendLayout();
        panel4.SuspendLayout();
        panel1.SuspendLayout();
        groupBox2.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        flowLayoutPanel3.SuspendLayout();
        groupBox3.SuspendLayout();
        flowLayoutPanel4.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        groupBox1.Controls.Add(flowLayoutPanel1);
        groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        groupBox1.Location = new System.Drawing.Point(0, 0);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(800, 133);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Current Parking";
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Controls.Add(panel5);
        flowLayoutPanel1.Controls.Add(panel2);
        flowLayoutPanel1.Controls.Add(panel3);
        flowLayoutPanel1.Controls.Add(panel4);
        flowLayoutPanel1.Controls.Add(panel1);
        flowLayoutPanel1.Location = new System.Drawing.Point(25, 17);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new System.Drawing.Size(741, 110);
        flowLayoutPanel1.TabIndex = 3;
        // 
        // panel5
        // 
        panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panel5.Controls.Add(label17);
        panel5.Controls.Add(label18);
        panel5.Controls.Add(label19);
        panel5.Controls.Add(label20);
        panel5.Location = new System.Drawing.Point(0, 3);
        panel5.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panel5.Name = "panel5";
        panel5.Size = new System.Drawing.Size(140, 105);
        panel5.TabIndex = 8;
        // 
        // label17
        // 
        label17.Location = new System.Drawing.Point(0, 75);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(140, 30);
        label17.TabIndex = 3;
        label17.Text = "Car: 0";
        label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label18
        // 
        label18.Location = new System.Drawing.Point(0, 59);
        label18.Name = "label18";
        label18.Size = new System.Drawing.Size(140, 16);
        label18.TabIndex = 2;
        label18.Text = "Motobike: 0";
        label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label19
        // 
        label19.Font = new System.Drawing.Font("Segoe UI", 14F);
        label19.Location = new System.Drawing.Point(0, 23);
        label19.Name = "label19";
        label19.Size = new System.Drawing.Size(140, 36);
        label19.TabIndex = 1;
        label19.Text = "0";
        label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label20
        // 
        label20.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label20.Location = new System.Drawing.Point(0, 0);
        label20.Name = "label20";
        label20.Size = new System.Drawing.Size(140, 23);
        label20.TabIndex = 0;
        label20.Text = "Total States parked";
        label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel2
        // 
        panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panel2.Controls.Add(label5);
        panel2.Controls.Add(label7);
        panel2.Controls.Add(label8);
        panel2.Location = new System.Drawing.Point(150, 3);
        panel2.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(140, 105);
        panel2.TabIndex = 5;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(0, 75);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(140, 30);
        label5.TabIndex = 3;
        label5.Text = "Avaliable Slot: 0";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label7
        // 
        label7.Font = new System.Drawing.Font("Segoe UI", 14F);
        label7.Location = new System.Drawing.Point(0, 23);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(140, 52);
        label7.TabIndex = 1;
        label7.Text = "0%";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label8
        // 
        label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label8.Location = new System.Drawing.Point(0, 0);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(140, 23);
        label8.TabIndex = 0;
        label8.Text = "Occupancy Rate";
        label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel3
        // 
        panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panel3.Controls.Add(label9);
        panel3.Controls.Add(label10);
        panel3.Controls.Add(label11);
        panel3.Controls.Add(label12);
        panel3.Location = new System.Drawing.Point(300, 3);
        panel3.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panel3.Name = "panel3";
        panel3.Size = new System.Drawing.Size(140, 105);
        panel3.TabIndex = 6;
        // 
        // label9
        // 
        label9.Location = new System.Drawing.Point(0, 75);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(140, 30);
        label9.TabIndex = 3;
        label9.Text = "Car: 0";
        label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label10
        // 
        label10.Location = new System.Drawing.Point(0, 59);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(140, 16);
        label10.TabIndex = 2;
        label10.Text = "Motobike: 0";
        label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label11
        // 
        label11.Font = new System.Drawing.Font("Segoe UI", 14F);
        label11.Location = new System.Drawing.Point(0, 23);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(140, 36);
        label11.TabIndex = 1;
        label11.Text = "0";
        label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label12
        // 
        label12.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label12.Location = new System.Drawing.Point(0, 0);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(140, 23);
        label12.TabIndex = 0;
        label12.Text = "Total Vehicles";
        label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel4
        // 
        panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panel4.Controls.Add(label13);
        panel4.Controls.Add(label14);
        panel4.Controls.Add(label15);
        panel4.Controls.Add(label16);
        panel4.Location = new System.Drawing.Point(450, 3);
        panel4.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
        panel4.Name = "panel4";
        panel4.Size = new System.Drawing.Size(140, 105);
        panel4.TabIndex = 9;
        // 
        // label13
        // 
        label13.Location = new System.Drawing.Point(0, 75);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(140, 30);
        label13.TabIndex = 3;
        label13.Text = "Car: 0";
        label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label14
        // 
        label14.Location = new System.Drawing.Point(0, 59);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(140, 16);
        label14.TabIndex = 2;
        label14.Text = "Motobike: 0";
        label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label15
        // 
        label15.Font = new System.Drawing.Font("Segoe UI", 14F);
        label15.Location = new System.Drawing.Point(0, 23);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(140, 36);
        label15.TabIndex = 1;
        label15.Text = "0";
        label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label16
        // 
        label16.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label16.Location = new System.Drawing.Point(0, 0);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(140, 23);
        label16.TabIndex = 0;
        label16.Text = "Total Foremerized";
        label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        panel1.Controls.Add(label4);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(label1);
        panel1.Location = new System.Drawing.Point(600, 3);
        panel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(140, 105);
        panel1.TabIndex = 2;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(0, 75);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(140, 30);
        label4.TabIndex = 3;
        label4.Text = "Car: 0";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(0, 59);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(140, 16);
        label3.TabIndex = 2;
        label3.Text = "Motobike: 0";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 14F);
        label2.Location = new System.Drawing.Point(0, 23);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(140, 36);
        label2.TabIndex = 1;
        label2.Text = "0";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(140, 23);
        label1.TabIndex = 0;
        label1.Text = "Total Vehicles parked";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // groupBox2
        // 
        groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
        groupBox2.Controls.Add(flowLayoutPanel2);
        groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox2.Location = new System.Drawing.Point(0, 133);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(800, 317);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Revenue Report By Day/Night";
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.Controls.Add(flowLayoutPanel3);
        flowLayoutPanel2.Controls.Add(flowLayoutPanel4);
        flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        flowLayoutPanel2.Location = new System.Drawing.Point(3, 19);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new System.Drawing.Size(794, 295);
        flowLayoutPanel2.TabIndex = 0;
        // 
        // flowLayoutPanel3
        // 
        flowLayoutPanel3.Controls.Add(button1);
        flowLayoutPanel3.Controls.Add(groupBox3);
        flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel3.Location = new System.Drawing.Point(591, 3);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Size = new System.Drawing.Size(200, 292);
        flowLayoutPanel3.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(3, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(197, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(label6);
        groupBox3.Location = new System.Drawing.Point(3, 32);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(200, 257);
        groupBox3.TabIndex = 1;
        groupBox3.TabStop = false;
        groupBox3.Text = "groupBox3";
        // 
        // label6
        // 
        label6.BackColor = System.Drawing.SystemColors.MenuHighlight;
        label6.Location = new System.Drawing.Point(28, 19);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(141, 23);
        label6.TabIndex = 0;
        label6.Text = "Total Revenue Collected";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // flowLayoutPanel4
        // 
        flowLayoutPanel4.Controls.Add(tableLayoutPanel1);
        flowLayoutPanel4.Controls.Add(groupBox4);
        flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
        flowLayoutPanel4.Name = "flowLayoutPanel4";
        flowLayoutPanel4.Size = new System.Drawing.Size(582, 292);
        flowLayoutPanel4.TabIndex = 1;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.22222F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
        tableLayoutPanel1.Controls.Add(label21, 0, 0);
        tableLayoutPanel1.Controls.Add(dateTimePicker1, 0, 1);
        tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.295776F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.704224F));
        tableLayoutPanel1.Size = new System.Drawing.Size(579, 57);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // label21
        // 
        label21.Location = new System.Drawing.Point(3, 0);
        label21.Name = "label21";
        label21.Size = new System.Drawing.Size(130, 23);
        label21.TabIndex = 0;
        label21.Text = "Start Date";
        label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new System.Drawing.Point(3, 31);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(130, 23);
        dateTimePicker1.TabIndex = 1;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(dataGridView1);
        groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
        groupBox4.Location = new System.Drawing.Point(3, 66);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(579, 223);
        groupBox4.TabIndex = 1;
        groupBox4.TabStop = false;
        groupBox4.Text = "Revenue Detail Grid";
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Date, Shift });
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(3, 19);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new System.Drawing.Size(573, 201);
        dataGridView1.TabIndex = 0;
        dataGridView1.Text = "dataGridView1";
        // 
        // Date
        // 
        Date.HeaderText = "Date";
        Date.Name = "Date";
        // 
        // Shift
        // 
        Shift.HeaderText = "Shift";
        Shift.Name = "Shift";
        // 
        // FormDashboard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Text = "FormDashboard";
        groupBox1.ResumeLayout(false);
        flowLayoutPanel1.ResumeLayout(false);
        panel5.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel3.ResumeLayout(false);
        panel4.ResumeLayout(false);
        panel1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        flowLayoutPanel2.ResumeLayout(false);
        flowLayoutPanel3.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        flowLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    private System.Windows.Forms.DataGridViewTextBoxColumn Shift;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.GroupBox groupBox4;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.Label label21;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.GroupBox groupBox3;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    private System.Windows.Forms.GroupBox groupBox2;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.GroupBox groupBox1;

    #endregion
}