using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class FromAdd : Form
    {
        private Form1 form1;
        public FromAdd(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PropertyUtil util = new PropertyUtil();
            Gongshi gonshi = new Gongshi(PropertyUtil.StringToDouble(textBox1.Text), PropertyUtil.StringToDouble(textBox2.Text), PropertyUtil.StringToDouble(textBox3.Text), PropertyUtil.StringToDouble(textBox4.Text));
            //Console.WriteLine(gongsi.ToString());
           
          DataGridView d = (DataGridView)form1.Controls.Find("dataGridView1", false)[0];
            Console.WriteLine(PropertyUtil.GetId());
            util.addDateToDateGrid(d, gonshi);



        }
    }
}
