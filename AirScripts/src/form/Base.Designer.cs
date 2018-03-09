namespace AirScripts.src.form
{
    partial class Base
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.startToBack_checkBox = new System.Windows.Forms.CheckBox();
            this.startUp_checkBox = new System.Windows.Forms.CheckBox();
            this.autoStartServer_checkBox = new System.Windows.Forms.CheckBox();
            this.closeToBack_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // startToBack_checkBox
            // 
            this.startToBack_checkBox.AutoSize = true;
            this.startToBack_checkBox.Location = new System.Drawing.Point(37, 84);
            this.startToBack_checkBox.Name = "startToBack_checkBox";
            this.startToBack_checkBox.Size = new System.Drawing.Size(84, 16);
            this.startToBack_checkBox.TabIndex = 3;
            this.startToBack_checkBox.Text = "启动到托盘";
            this.startToBack_checkBox.UseVisualStyleBackColor = true;
            this.startToBack_checkBox.CheckedChanged += new System.EventHandler(this.startToBack_checkBox_CheckedChanged);
            // 
            // startUp_checkBox
            // 
            this.startUp_checkBox.AutoSize = true;
            this.startUp_checkBox.Location = new System.Drawing.Point(37, 37);
            this.startUp_checkBox.Name = "startUp_checkBox";
            this.startUp_checkBox.Size = new System.Drawing.Size(72, 16);
            this.startUp_checkBox.TabIndex = 2;
            this.startUp_checkBox.Text = "开机启动";
            this.startUp_checkBox.UseVisualStyleBackColor = true;
            this.startUp_checkBox.CheckedChanged += new System.EventHandler(this.startUp_checkBox_CheckedChanged);
            // 
            // autoStartServer_checkBox
            // 
            this.autoStartServer_checkBox.AutoSize = true;
            this.autoStartServer_checkBox.Location = new System.Drawing.Point(37, 172);
            this.autoStartServer_checkBox.Name = "autoStartServer_checkBox";
            this.autoStartServer_checkBox.Size = new System.Drawing.Size(108, 16);
            this.autoStartServer_checkBox.TabIndex = 4;
            this.autoStartServer_checkBox.Text = "自动启动服务器";
            this.autoStartServer_checkBox.UseVisualStyleBackColor = true;
            this.autoStartServer_checkBox.CheckedChanged += new System.EventHandler(this.autoStartServer_checkBox_CheckedChanged);
            // 
            // closeToBack_checkBox
            // 
            this.closeToBack_checkBox.AutoSize = true;
            this.closeToBack_checkBox.Location = new System.Drawing.Point(37, 127);
            this.closeToBack_checkBox.Name = "closeToBack_checkBox";
            this.closeToBack_checkBox.Size = new System.Drawing.Size(84, 16);
            this.closeToBack_checkBox.TabIndex = 5;
            this.closeToBack_checkBox.Text = "关闭到托盘";
            this.closeToBack_checkBox.UseVisualStyleBackColor = true;
            this.closeToBack_checkBox.CheckedChanged += new System.EventHandler(this.closeToBack_checkBox_CheckedChanged);
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 227);
            this.Controls.Add(this.closeToBack_checkBox);
            this.Controls.Add(this.autoStartServer_checkBox);
            this.Controls.Add(this.startToBack_checkBox);
            this.Controls.Add(this.startUp_checkBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base";
            this.Text = "Base";
            this.Load += new System.EventHandler(this.Base_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox startToBack_checkBox;
        private System.Windows.Forms.CheckBox startUp_checkBox;
        private System.Windows.Forms.CheckBox autoStartServer_checkBox;
        private System.Windows.Forms.CheckBox closeToBack_checkBox;
    }
}