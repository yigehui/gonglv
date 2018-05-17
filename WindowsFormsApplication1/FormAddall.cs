using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class FormAddall : Form
    {
        private Form1 form1;
        public FormAddall(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyUtil util = new PropertyUtil();
            DataGridView d = (DataGridView)form1.Controls.Find("dataGridView1", false)[0];
            if (textBox1.Text.Length > 0){
                foreach (String temp in textBox1.Lines) {
                    if (!temp.Trim().Equals("")) {
                        String[] result = temp.Split('\t');
                        Gonshi gonshi = new Gonshi(PropertyUtil.StringToDouble(result[0].Trim()), PropertyUtil.StringToDouble(result[1].Trim()), PropertyUtil.StringToDouble(result[2].Trim()), PropertyUtil.StringToDouble(result[3].Trim()));
                        util.addDateToDateGrid(d, gonshi);
                    }
                   
                }
            }
            else {
                MessageBox.Show("请填写需要添加的信息");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要打开的文件";
            //多选
            ofd.Multiselect = true;
            //初始目录
            ofd.InitialDirectory = @"C:\";
            //设定文件类型
            ofd.Filter = "文本文件 | *.txt";
            ofd.ShowDialog();

            //获得在打开文件对话框中选择的文件的路径
            string path = ofd.FileName;
            if (path == "")
            {
                return;
            }
            using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                textBox1.Text = Encoding.Default.GetString(buffer, 0, r);
            }
        }
    }
}
