using AirScripts.src.util;
using System;
using System.IO;
using System.Windows.Forms;

namespace AirScripts.src.form
{
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon = null;

        public MainForm()
        {
            InitializeComponent();
            //关闭线程锁
            Control.CheckForIllegalCrossThreadCalls = false;
            //中间显示
            this.StartPosition = FormStartPosition.CenterScreen;
            //禁止拖拽
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //禁止最大化
            this.MaximizeBox = false;
            InitialTray();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Scripts\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Scripts\\");
            }            
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Properties.Settings.Default.StartOnTheTray)
            {
                this.Visible = false;
            }
        }

        /// <summary>
        /// 窗体关闭方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.CloseOnTheTray)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
            System.Environment.Exit(0);
        }

        //###############托盘相关################
        /// <summary>
        /// 托盘
        /// </summary>
        private void InitialTray()
        {
            //实例化一个NotifyIcon对象  
            notifyIcon = new NotifyIcon();
            //托盘图标气泡显示的内容  
            notifyIcon.BalloonTipText = "正在后台运行";
            //托盘图标显示的内容  
            notifyIcon.Text = "AirScripts";
            //注意：下面的路径可以是绝对路径、相对路径。但是需要注意的是：文件必须是一个.ico格式  
            notifyIcon.Icon = GetFileIcon.GetIcon(GetType().Assembly.Location);
            //true表示在托盘区可见，false表示在托盘区不可见  
            notifyIcon.Visible = true;
            //气泡显示的时间（单位是毫秒）  
            notifyIcon.ShowBalloonTip(2000);
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);

            ////设置二级菜单  
            //MenuItem setting1 = new MenuItem("二级菜单1");  
            //MenuItem setting2 = new MenuItem("二级菜单2");  
            //MenuItem setting = new MenuItem("一级菜单", new MenuItem[]{setting1,setting2});  

            //帮助选项，这里只是“有名无实”在菜单上只是显示，单击没有效果，可以参照下面的“退出菜单”实现单击事件  
            //MenuItem help = new MenuItem("帮助");
            //help.Click += new EventHandler(button1_Click);

            //关于选项  
            //MenuItem about = new MenuItem("关于");

            //退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(exit_Click);

            ////关联托盘控件  
            //注释的这一行与下一行的区别就是参数不同，setting这个参数是为了实现二级菜单  
            //MenuItem[] childen = new MenuItem[] { setting, help, about, exit };  
            MenuItem[] childen = new MenuItem[] { exit };
            notifyIcon.ContextMenu = new ContextMenu(childen);
        }

        /// <summary>  
        /// 鼠标单击托盘
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //鼠标左键单击  
            if (e.Button == MouseButtons.Left)
            {
                //如果窗体是可见的，那么鼠标左击托盘区图标后，窗体为不可见  
                if (this.Visible == true)
                {
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                    this.Activate();
                }
            }
        }

        /// <summary>  
        /// 托盘退出选项  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void exit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            System.Environment.Exit(0);
        }
    }
}
