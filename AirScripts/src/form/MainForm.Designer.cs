using System.Windows.Forms;

namespace AirScripts.src.form
{
    partial class MainForm
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

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();

            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

            this.serverForm = new AirScripts.src.form.Server();
            this.baseForm = new AirScripts.src.form.Base();
            this.shellCommand = new ShellCommand();
            this.systemCommand = new SystemCommand();
            this.about = new About();

            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(78, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 257);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            ///////////////////////////////////////////////////////////////////
            // 
            // baseForm
            // 
            this.baseForm.BackColor = System.Drawing.Color.White;
            this.baseForm.ClientSize = new System.Drawing.Size(386, 227);
            this.baseForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.baseForm.Name = "serverForm";
            this.baseForm.Visible = false;
            this.baseForm.TopLevel = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.baseForm);
            this.baseForm.Show();
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本";
            this.tabPage1.UseVisualStyleBackColor = true;
            ///////////////////////////////////////////////////////////////////
            // 
            // systemCommand
            // 
            this.systemCommand.BackColor = System.Drawing.Color.White;
            this.systemCommand.ClientSize = new System.Drawing.Size(386, 227);
            this.systemCommand.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.systemCommand.Name = "serverForm";
            this.systemCommand.Visible = false;
            this.systemCommand.TopLevel = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.systemCommand);
            this.systemCommand.Show();
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "系统";
            this.tabPage2.UseVisualStyleBackColor = true;
            ///////////////////////////////////////////////////////////////////
            // 
            // shellCommand
            // 
            this.shellCommand.BackColor = System.Drawing.Color.White;
            this.shellCommand.ClientSize = new System.Drawing.Size(386, 227);
            this.shellCommand.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.shellCommand.Name = "serverForm";
            this.shellCommand.Visible = false;
            this.shellCommand.TopLevel = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.shellCommand);
            this.shellCommand.Show();
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(386, 227);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "脚本";
            this.tabPage3.UseVisualStyleBackColor = true;
            ///////////////////////////////////////////////////////////////////
            // 
            // serverForm
            // 
            this.serverForm.BackColor = System.Drawing.Color.White;
            this.serverForm.ClientSize = new System.Drawing.Size(386, 227);
            this.serverForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.serverForm.Name = "serverForm";
            this.serverForm.Visible = false;
            this.serverForm.TopLevel = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.serverForm);
            this.serverForm.Show();
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(386, 227);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "网络";
            this.tabPage4.UseVisualStyleBackColor = true;
            ///////////////////////////////////////////////////////////////////
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.White;
            this.about.ClientSize = new System.Drawing.Size(386, 227);
            this.about.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.about.Name = "serverForm";
            this.about.Visible = false;
            this.about.TopLevel = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.about);
            this.about.Show();
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(386, 227);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "关于";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 257);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AirScripts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Server serverForm;
        private Base baseForm;
        private ShellCommand shellCommand;
        private SystemCommand systemCommand;
        private About about;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}