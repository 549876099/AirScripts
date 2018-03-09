using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirScripts.src.form
{
    public partial class ShellCommand : Form
    {
        Process proc = null;
        String scriptsLocation = AppDomain.CurrentDomain.BaseDirectory + "Scripts\\";

        public ShellCommand()
        {
            InitializeComponent();
            proc = new Process();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //显示在HeaderCell上
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow r = this.dataGridView1.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", i + 1);
            }
            this.dataGridView1.Refresh();
        }

        private void ShellCommand_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 刷新按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ShellCommand_Load(new Object(), new EventArgs());
        }

        /// <summary>
        /// 刷新Shell列表
        /// </summary>
        private void flushShellList()
        {
            this.dataGridView1.Rows.Clear();

            DirectoryInfo dir = new DirectoryInfo(scriptsLocation);
            FileInfo[] files = dir.GetFiles("*.bat");
            foreach (FileInfo file in files)
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dataGridView1);
                dr.Cells[0].Value = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf(".") - file.Name.LastIndexOf("\\") - 1));
                dataGridView1.Rows.Insert(0, dr);
            }

            if ((9 - files.Length) > 0)
            {
                dataGridView1.Rows.Add(9 - files.Length);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            flushShellList();
        }
        /// <summary>
        /// 执行Shell按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow r = dataGridView1.Rows[rowIndex];
            try
            {
                String name = r.Cells[0].Value.ToString();
                proc.StartInfo.FileName = scriptsLocation + name;
                proc.StartInfo.Arguments = string.Format("10");
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch{}
        }
    }
}
