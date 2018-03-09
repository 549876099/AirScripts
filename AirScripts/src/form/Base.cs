using AirScripts.src.util;
using System;
using System.Windows.Forms;

namespace AirScripts.src.form
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }

        private void Base_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startUp)
            {
                startUp_checkBox.Checked = true;
            }

            if (Properties.Settings.Default.StartOnTheTray)
            {
                startToBack_checkBox.Checked = true;
            }

            if (Properties.Settings.Default.CloseOnTheTray)
            {
                closeToBack_checkBox.Checked = true;
            }

            if (Properties.Settings.Default.AutoStartServer)
            {
                autoStartServer_checkBox.Checked = true;
            }

            autoStartServer_checkBox.Enabled = false;
        }

        /// <summary>
        /// 开机启动按钮状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startUp_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startUp_checkBox.Checked)
            {
                StartUp.set();
                Properties.Settings.Default.startUp = true;
            }
            else
            {
                StartUp.del();
                Properties.Settings.Default.startUp = false;
            }
        }

        /// <summary>
        /// 启动到托盘按钮状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startToBack_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startToBack_checkBox.Checked)
            {
                Properties.Settings.Default.StartOnTheTray = true;
            }
            else
            {
                Properties.Settings.Default.StartOnTheTray = false;
            }
        }


        /// <summary>
        /// 关闭到托盘按钮状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToBack_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeToBack_checkBox.Checked)
            {
                Properties.Settings.Default.CloseOnTheTray = true;
            }
            else
            {
                Properties.Settings.Default.CloseOnTheTray = false;
            }
        }

        /// <summary>
        /// 自动启动服务器按钮状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoStartServer_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoStartServer_checkBox.Checked)
            {
                Properties.Settings.Default.AutoStartServer = true;
            }
            else
            {
                Properties.Settings.Default.AutoStartServer = false;
            }
        }
    }
}
