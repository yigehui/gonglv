using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Dao;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class FromAdd : Form
    {
        private Form1 form1;

        private GongShiDao gsdao = new GongShiDao();
        public FromAdd(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PropertyUtil util = new PropertyUtil();
            //3个数据是一组数据
            String groupId = PropertyUtil.GetId();
            Gongshi gonshi1 = new Gongshi(PropertyUtil.StringToDouble(textBox1.Text), PropertyUtil.StringToDouble(textBox2.Text), PropertyUtil.StringToDouble(textBox3.Text), PropertyUtil.StringToDouble(textBox4.Text));
            Gongshi gonshi2 = new Gongshi(PropertyUtil.StringToDouble(textBox8.Text), PropertyUtil.StringToDouble(textBox7.Text), PropertyUtil.StringToDouble(textBox6.Text), PropertyUtil.StringToDouble(textBox5.Text));
            Gongshi gonshi3 = new Gongshi(PropertyUtil.StringToDouble(textBox12.Text), PropertyUtil.StringToDouble(textBox11.Text), PropertyUtil.StringToDouble(textBox10.Text), PropertyUtil.StringToDouble(textBox9.Text));
            gonshi1.id = PropertyUtil.GetId();
            gonshi1.groupid = groupId;
            gonshi2.id = PropertyUtil.GetId();
            gonshi2.groupid = groupId;
            gonshi3.id = PropertyUtil.GetId();
            gonshi3.groupid = groupId;

            DataGridView d = (DataGridView)form1.Controls.Find("dataGridView1", false)[0];
            gsdao.add(gonshi1);
            gsdao.add(gonshi2);
            gsdao.add(gonshi3);
            //刷新数据;
            d.DataSource = gsdao.list();


        }
    }
}
