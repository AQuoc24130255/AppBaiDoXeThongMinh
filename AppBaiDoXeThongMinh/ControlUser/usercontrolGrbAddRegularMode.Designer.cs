using System.ComponentModel;

namespace AppBaiDoXeThongMinh.Control;

partial class usercontrolGrbAddRegularMode
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        grbAdd = new System.Windows.Forms.GroupBox();
        btLock = new System.Windows.Forms.Button();
        btDelete = new System.Windows.Forms.Button();
        btRefresh = new System.Windows.Forms.Button();

        grbAdd.SuspendLayout();
        SuspendLayout();

        // grbAdd
        grbAdd.Controls.Add(btLock);
        grbAdd.Controls.Add(btDelete);
        grbAdd.Controls.Add(btRefresh);
        grbAdd.Dock = System.Windows.Forms.DockStyle.Fill;
        grbAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        grbAdd.Location = new System.Drawing.Point(0, 0);
        grbAdd.Name = "grbAdd";
        grbAdd.Size = new System.Drawing.Size(398, 570);
        grbAdd.TabIndex = 0;
        grbAdd.TabStop = false;
        grbAdd.Text = "Thao tác vé thường";

        // btLock
        btLock.BackColor = System.Drawing.Color.FromArgb(230, 150, 40);
        btLock.FlatAppearance.BorderSize = 0;
        btLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btLock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btLock.ForeColor = System.Drawing.Color.White;
        btLock.Location = new System.Drawing.Point(16, 36);
        btLock.Name = "btLock";
        btLock.Size = new System.Drawing.Size(115, 38);
        btLock.TabIndex = 0;
        btLock.Text = "Khóa vé";
        btLock.UseVisualStyleBackColor = false;

        // btDelete
        btDelete.BackColor = System.Drawing.Color.FromArgb(200, 60, 55);
        btDelete.FlatAppearance.BorderSize = 0;
        btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btDelete.ForeColor = System.Drawing.Color.White;
        btDelete.Location = new System.Drawing.Point(141, 36);
        btDelete.Name = "btDelete";
        btDelete.Size = new System.Drawing.Size(115, 38);
        btDelete.TabIndex = 1;
        btDelete.Text = "Xóa vé";
        btDelete.UseVisualStyleBackColor = false;

        // btRefresh
        btRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
        btRefresh.Location = new System.Drawing.Point(266, 36);
        btRefresh.Name = "btRefresh";
        btRefresh.Size = new System.Drawing.Size(115, 38);
        btRefresh.TabIndex = 2;
        btRefresh.Text = "Làm mới";
        btRefresh.UseVisualStyleBackColor = true;

        // usercontrolGrbAddRegularMode
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(243, 246, 250);
        Controls.Add(grbAdd);
        Name = "usercontrolGrbAddRegularMode";
        Size = new System.Drawing.Size(398, 570);

        grbAdd.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grbAdd;
    private System.Windows.Forms.Button btLock;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Button btRefresh;
    
    #endregion
}