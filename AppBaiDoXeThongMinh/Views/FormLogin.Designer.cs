using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Views;

partial class FormLogin
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
        txtUsername = new System.Windows.Forms.TextBox();
        txtPassword = new System.Windows.Forms.TextBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // txtUsername
        // 
        txtUsername.Location = new System.Drawing.Point(411, 153);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new System.Drawing.Size(100, 23);
        txtUsername.TabIndex = 0;
        // 
        // txtPassword
        // 
        txtPassword.Location = new System.Drawing.Point(411, 194);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new System.Drawing.Size(100, 23);
        txtPassword.TabIndex = 1;
        // 
        // chkShowPassword
        // 
        chkShowPassword.Location = new System.Drawing.Point(411, 240);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new System.Drawing.Size(104, 24);
        chkShowPassword.TabIndex = 2;
        chkShowPassword.Text = "checkBox1";
        chkShowPassword.UseVisualStyleBackColor = true;
        // 
        // FormLogin
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(chkShowPassword);
        Controls.Add(txtPassword);
        Controls.Add(txtUsername);
        Text = "FormLogin";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox chkShowPassword;

    private System.Windows.Forms.TextBox txtPassword;

    private System.Windows.Forms.TextBox txtUsername;

    #endregion
}