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
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        comboBox1 = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(150, 228);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(487, 178);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(35, 69);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(266, 27);
        textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(435, 62);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(271, 27);
        textBox2.TabIndex = 2;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(323, 170);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(262, 28);
        comboBox1.TabIndex = 3;
        // 
        // FormCheckIn
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(comboBox1);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Text = "FormCheckIn";
        Load += FormCheckIn_Load;
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.BindingSource bindingSource1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;

    #endregion
}