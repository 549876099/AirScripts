using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirScripts.src.form
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = "AirScripts 版本V1.0\n\n这是一个免费的远程脚本执行工具。\n\n限于时间、水平等因素，软件难免会有不足。\n\n若您发现了任何问题，或想到了有趣的建议，欢迎与我联系。";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/549876099/AirScripts");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:plzwb@outlook.com?Subject=[AirScripts] 反馈");
        }
    }
}
