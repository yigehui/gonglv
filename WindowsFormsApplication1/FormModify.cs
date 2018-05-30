using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Dao;

namespace WindowsFormsApplication1
{
    public partial class FormModify : Form
    {
        private Form1 _form1;
        public string groupid;
        public FormModify(Form1 form1)
        {
            _form1 = form1;
      
            InitializeComponent();

            //设置新窗口的位置
            this.Owner = form1;
            StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.Owner.Location.X + 10, this.Owner.Location.Y + 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = comboBox1.Text.ToString();
            GongShiDao dao = new GongShiDao();
            dao.modifyResult(result,groupid);
            _form1.dataGridView1.DataSource = dao.list();
            this.Close();

        }
    }
}
