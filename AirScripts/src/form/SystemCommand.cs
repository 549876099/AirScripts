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
    public partial class SystemCommand : Form
    {
        public SystemCommand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("shutdown");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("reboot");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("lock");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("logoff");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("hibernate");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RunSystemAction.Run("sleep");
        }
    }
}
