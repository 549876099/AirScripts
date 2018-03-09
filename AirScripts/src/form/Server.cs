using AirScripts.src.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AirScripts.src.form
{
    public partial class Server : Form
    {
        HttpServer httpServer = null;
        List<String> IpList = new List<string>();
        Boolean ServerState = false;

        private System.Windows.Forms.Button permission_button;

        /// <summary>
        /// 初始化方法
        /// </summary>
        public Server()
        {
            InitializeComponent();
            //实例化对象
            httpServer = new HttpServer();
        }

        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_Load(object sender, EventArgs e)
        {
            //初始化IP表
            InitIpList();
            //检查权限
            permissionCheck();
            //初始化身份验证密钥框
            if (!Properties.Settings.Default.secret_key)
            {
                secret_key.Enabled = false;
            }
            else if(!(Properties.Settings.Default.secret_key_str == ""))
            {
                checkBox1.Checked = true;
                secret_key.ForeColor = Color.Black;
                secret_key.TextAlign = HorizontalAlignment.Left;
                secret_key.Text = Properties.Settings.Default.secret_key_str;
            }
        }

        /// <summary>
        /// 管理员权限检查
        /// </summary>
        private void permissionCheck()
        {
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //创建Windows用户主题
            Application.EnableVisualStyles();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //关闭启动服务器
                startServerButton.Visible = false;
                //创建授权按钮
                this.permission_button = new System.Windows.Forms.Button();
                this.permission_button.Location = new System.Drawing.Point(116, 127);
                this.permission_button.Name = "permission_button";
                this.permission_button.Size = new System.Drawing.Size(133, 46);
                this.permission_button.TabIndex = 9;
                this.permission_button.Text = "获取管理员权限";
                this.permission_button.UseVisualStyleBackColor = true;
                this.permission_button.Click += new System.EventHandler(this.permission_button_Click);
                this.Controls.Add(this.permission_button);
            }

        }
        
        /// <summary>
        /// 启动Http服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webservice_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            httpServer.listen();
        }

        /// <summary>
        /// 初始化IP列表方法
        /// </summary>
        private void InitIpList()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    IpList.Add(ipa.ToString());
            }
            ipBox.DataSource = IpList;
        }

        /// <summary>
        /// 启动服务器按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startServerButton_Click(object sender, EventArgs e)
        {
            if (!ServerState)
            {
                if (!httpServer.start(ipBox.Text, portBox.Text))
                {
                    ServerState = false;
                    label4.Text = "端口已占用";
                    return;
                }
                ServerState = true;
                webservice_backgroundWorker.RunWorkerAsync();
                startServerButton.Text = "停止服务器";
                label4.Text = "已启动 ";
                //关闭身份验证组件
                checkBox1.Enabled = false;
                secret_key.Enabled = false;
                ipBox.Enabled = false;
                portBox.Enabled = false;
            }
            else
            {
                httpServer.stop();
                ServerState = false;
                startServerButton.Text = "启动服务器";
                label4.Text = "未启动";
                //打开身份验证组件
                checkBox1.Enabled = true;
                ipBox.Enabled = true;
                portBox.Enabled = true;
                if (checkBox1.Checked)
                {
                    secret_key.Enabled = true;
                }

            }
        }

        /// <summary>
        /// 身份验证按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                secret_key.Enabled = true;
                Properties.Settings.Default.secret_key = true;
            }
            else
            {
                secret_key.Enabled = false;
                Properties.Settings.Default.secret_key = false;
            }
        }

        /// <summary>
        /// 密钥框点击焦点时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secret_key_Enter(object sender, EventArgs e)
        {
            if(secret_key.Text == "输入访问密钥")
            {
                secret_key.Text = "";
                secret_key.ForeColor = Color.Black;
                secret_key.TextAlign = HorizontalAlignment.Left;
            }
        }

        /// <summary>
        /// 密钥框文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secret_key_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(secret_key.Text, "^[A-Za-z0-9]*$"))
            {
                MessageBox.Show("只能输入字母和数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                secret_key.Text = "";
            }
            Properties.Settings.Default.secret_key_str = secret_key.Text;
        }

        /// <summary>
        /// 获取管理员权限按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void permission_button_Click(object sender, EventArgs e)
        {
            //创建启动对象
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //设置运行文件
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            //设置启动动作,确保以管理员身份运行
            startInfo.Verb = "runas";
            //如果不是管理员，则启动UAC
            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch
            {
                MessageBox.Show("启动网络服务器需要管理员权限！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            System.Windows.Forms.Application.Exit();
        }
    }
}
