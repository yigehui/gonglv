using System;
using System.Windows.Forms;
using WindowsFormsApplication1.Dao;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 添加数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromAdd fa = new FromAdd(this);
            fa.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载表格数据
            GongShiDao dao = new GongShiDao();
            dataGridView1.DataSource = dao.list();

        }
        //显示表格序号
        //private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        //{
        //    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
        //    {
        //        DataGridViewRow r = this.dataGridView1.Rows[i];
        //        Console.WriteLine(string.Format("{0}", i + 1));
        //        r.HeaderCell.Value = string.Format("{0}", i + 1);
        //    }
        //    this.dataGridView1.Refresh();
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void 批量添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddall fa = new FormAddall(this);
            fa.Show();
        }

        private void 删除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数  
                int iCount = dataGridView1.SelectedRows.Count;
                if (iCount < 1)
                {
                    MessageBox.Show("删除失败!", "错误", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes == MessageBox.Show("是否删除选中的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        if (dr.IsNewRow == false)//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                            dataGridView1.Rows.Remove(dr);
                    }
                    //删除任意行数据后，应该刷新dataGridView表格，使索引值从上至下按大小顺序排序  
                    //for (int i = 0; i<dataGridView1.Rows.Count - 1; i++)  
                    //{  
                    //    dataGridView1.Rows[i].Cells[0].Value = i + 1;  
                    //}  
                }     
            }  
            catch (Exception ex)  
            {  
                MessageBox.Show(ex.Message);  
            }  
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertyUtil.DataGridViewToExcel(dataGridView1);
        }
    }
}
