using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormCheckIn
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
        components = new System.ComponentModel.Container();
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        panel1 = new System.Windows.Forms.Panel();
        panel2 = new System.Windows.Forms.Panel();
        panel3 = new System.Windows.Forms.Panel();
        panel4 = new System.Windows.Forms.Panel();
        panel5 = new System.Windows.Forms.Panel();
        panel6 = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Location = new System.Drawing.Point(27, 12);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(118, 200);
        panel1.TabIndex = 0;
        // 
        // panel2
        // 
        panel2.Location = new System.Drawing.Point(173, 12);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(118, 200);
        panel2.TabIndex = 1;
        // 
        // panel3
        // 
        panel3.Location = new System.Drawing.Point(318, 12);
        panel3.Name = "panel3";
        panel3.Size = new System.Drawing.Size(118, 200);
        panel3.TabIndex = 1;
        // 
        // panel4
        // 
        panel4.Location = new System.Drawing.Point(467, 12);
        panel4.Name = "panel4";
        panel4.Size = new System.Drawing.Size(119, 200);
        panel4.TabIndex = 2;
        // 
        // panel5
        // 
        panel5.Location = new System.Drawing.Point(632, 12);
        panel5.Name = "panel5";
        panel5.Size = new System.Drawing.Size(110, 200);
        panel5.TabIndex = 3;
        // 
        // panel6
        // 
        panel6.Location = new System.Drawing.Point(27, 238);
        panel6.Name = "panel6";
        panel6.Size = new System.Drawing.Size(118, 200);
        panel6.TabIndex = 4;
        // 
        // FormCheckIn
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(panel6);
        Controls.Add(panel5);
        Controls.Add(panel4);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Text = "FormCheckIn";
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.BindingSource bindingSource1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel6;

    #endregion
}