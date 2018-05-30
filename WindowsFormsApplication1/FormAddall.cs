using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Dao;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class FormAddall : Form
    {
        private Form1 form1;
        private GongShiDao gsdao = new GongShiDao();
        public FormAddall(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            comboBox1.SelectedIndex = 0;
            //设置新窗口的位置
            this.Owner = form1;
            StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.Owner.Location.X + 10, this.Owner.Location.Y + 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyUtil util = new PropertyUtil();
            DataGridView d = (DataGridView)form1.Controls.Find("dataGridView1", false)[0];
            if (textBox1.Text.Length > 0){
                foreach (String temp in textBox1.Lines) {
                    if (!temp.Equals("")) {
                        String[] arg = temp.Split(' ');
                        //3个数据是一组数据
                        if (arg.Length != 11 || (!arg[10].Equals("")) ) {
                             MessageBox.Show("数据格式错误");
                            break;
                        }
                        String groupId = PropertyUtil.GetId();
                        String result = this.comboBox1.Text.ToString();
                        //排序问题这里需要倒序加入
                        for (int i = 2; i >= 0; i--) {
                            Gongshi gonshi = new Gongshi(PropertyUtil.StringToDouble(arg[i+3]), PropertyUtil.StringToDouble(arg[i+6]), PropertyUtil.StringToDouble(arg[i]), PropertyUtil.StringToDouble(arg[9]));
                            gonshi.id = PropertyUtil.GetId();
                            gonshi.groupid = groupId;
                            gonshi.result = result;
                            gsdao.add(gonshi);
                            //如果出现顺序问题，添加上延时程序;
                            //Thread.Sleep(200);
                        }
                    }
                }
                //刷新datagrid
                form1.dataGridView1.DataSource = gsdao.list();

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
