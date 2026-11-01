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
        label1 = new System.Windows.Forms.Label();
        flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        textBox1 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        label3 = new System.Windows.Forms.Label();
        comboBox1 = new System.Windows.Forms.ComboBox();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        IDVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        IDTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
        EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
        VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Action = new System.Windows.Forms.DataGridViewButtonColumn();
        flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        flowLayoutPanel1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        flowLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        flowLayoutPanel3.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(66, 11);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(86, 23);
        label1.TabIndex = 4;
        label1.Text = "Search Vehicle Ticket";
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        flowLayoutPanel1.Controls.Add(textBox1);
        flowLayoutPanel1.Controls.Add(button1);
        flowLayoutPanel1.Controls.Add(label2);
        flowLayoutPanel1.Controls.Add(dateTimePicker1);
        flowLayoutPanel1.Controls.Add(label3);
        flowLayoutPanel1.Controls.Add(comboBox1);
        flowLayoutPanel1.Location = new System.Drawing.Point(12, 37);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new System.Drawing.Size(776, 39);
        flowLayoutPanel1.TabIndex = 6;
        // 
        // textBox1
        // 
        textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        textBox1.Location = new System.Drawing.Point(5, 6);
        textBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(124, 23);
        textBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(137, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(54, 30);
        button1.TabIndex = 1;
        button1.Text = "Search";
        button1.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
        label2.Location = new System.Drawing.Point(197, 6);
        label2.Margin = new System.Windows.Forms.Padding(3);
        label2.Name = "label2";
        label2.Padding = new System.Windows.Forms.Padding(3);
        label2.Size = new System.Drawing.Size(80, 23);
        label2.TabIndex = 2;
        label2.Text = "Date Range";
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        dateTimePicker1.Location = new System.Drawing.Point(283, 6);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(200, 23);
        dateTimePicker1.TabIndex = 3;
        // 
        // label3
        // 
        label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
        label3.Location = new System.Drawing.Point(489, 6);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(43, 23);
        label3.TabIndex = 4;
        label3.Text = "Status";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // comboBox1
        // 
        comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "All", "In The Parking", "Out The Parking" });
        comboBox1.Location = new System.Drawing.Point(538, 6);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(121, 23);
        comboBox1.TabIndex = 5;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
        tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 0);
        tableLayoutPanel1.Location = new System.Drawing.Point(12, 82);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(776, 356);
        tableLayoutPanel1.TabIndex = 7;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { STT, IDVehicle, IDTicket, EntryTime, Duration, VehicleType, Action });
        dataGridView1.Location = new System.Drawing.Point(3, 3);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new System.Drawing.Size(382, 350);
        dataGridView1.TabIndex = 0;
        dataGridView1.Text = "dataGridView1";
        // 
        // STT
        // 
        STT.HeaderText = "STT";
        STT.Name = "STT";
        // 
        // IDVehicle
        // 
        IDVehicle.HeaderText = "License Plate";
        IDVehicle.Name = "IDVehicle";
        // 
        // IDTicket
        // 
        IDTicket.HeaderText = "CardID";
        IDTicket.Name = "IDTicket";
        // 
        // EntryTime
        // 
        EntryTime.HeaderText = "EntryTime";
        EntryTime.Name = "EntryTime";
        // 
        // Duration
        // 
        Duration.HeaderText = "Duration";
        Duration.Name = "Duration";
        // 
        // VehicleType
        // 
        VehicleType.HeaderText = "Vehicle Type";
        VehicleType.Name = "VehicleType";
        // 
        // Action
        // 
        Action.HeaderText = "ActionGetHistoryVehicle";
        Action.Name = "Action";
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
        flowLayoutPanel2.Controls.Add(pictureBox1);
        flowLayoutPanel2.Controls.Add(flowLayoutPanel3);
        flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel2.Location = new System.Drawing.Point(391, 3);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new System.Drawing.Size(382, 350);
        flowLayoutPanel2.TabIndex = 1;
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
        pictureBox1.Location = new System.Drawing.Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(186, 157);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // flowLayoutPanel3
        // 
        flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
        flowLayoutPanel3.Controls.Add(button2);
        flowLayoutPanel3.Controls.Add(button3);
        flowLayoutPanel3.Location = new System.Drawing.Point(3, 166);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Size = new System.Drawing.Size(379, 32);
        flowLayoutPanel3.TabIndex = 1;
        // 
        // button2
        // 
        button2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
        button2.Location = new System.Drawing.Point(3, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(75, 23);
        button2.TabIndex = 0;
        button2.Text = "Lock Card";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(84, 3);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(75, 23);
        button3.TabIndex = 1;
        button3.Text = "Calculate";
        button3.UseVisualStyleBackColor = true;
        // 
        // FormSearch
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(flowLayoutPanel1);
        Controls.Add(label1);
        Cursor = System.Windows.Forms.Cursors.AppStarting;
        Location = new System.Drawing.Point(15, 15);
        Text = "Form Search";
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        flowLayoutPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        flowLayoutPanel3.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

    private System.Windows.Forms.DataGridViewTextBoxColumn STT;
    private System.Windows.Forms.DataGridViewTextBoxColumn IDVehicle;
    private System.Windows.Forms.DataGridViewTextBoxColumn IDTicket;
    private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
    private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
    private System.Windows.Forms.DataGridViewButtonColumn Action;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    #endregion
}