using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Dao;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       private  GongShiDao dao = new GongShiDao();
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
            initComboBox();
            //加载表格数据
            dataGridView1.DataSource = dao.list();

        }
        private void initComboBox() {
            //初始化界面
            //先构造一个dataTable，或者从数据库读取到一个，这里自己构造一个
            DataTable dataTable = new DataTable("Gailv");
            dataTable.Columns.Add("Name", typeof(String));
            dataTable.Columns.Add("Value", typeof(String));
            dataTable.Rows.Add(new String[] {  "赔率差值", "peilvchazhi" });
            dataTable.Rows.Add(new String[] {"相对赔付率", "xiangduipeilv" });
            dataTable.Rows.Add(new String[] { "概率差值1", "gailvchazhi1" });
            dataTable.Rows.Add(new String[] {"概率差值2", "gailvchazhi2" });
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = dataTable.Columns[0].ColumnName;//显示的文本
            comboBox1.ValueMember = dataTable.Columns[1].ColumnName;//对应的值
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

        /// <summary>
        /// 实现斑马线功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.RowIndex > dataGridView1.Rows.Count - 1)
                    return;
                if (dgv.Rows[e.RowIndex].Cells["color"].Value.ToString().Equals("1") && dataGridView1[1, e.RowIndex].GetType() == typeof(DataGridViewTextBoxCell))
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                }

            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 对第1列相同单元格进行合并 这里11是根据添加的列生成的
            if (e.ColumnIndex == 11 && e.RowIndex != -1)
            {
                using (
                    Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                    )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 清除单元格
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // 画 Grid 边线（仅画单元格的底边线和右边线）
                        //   如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                        if ((e.RowIndex < dataGridView1.Rows.Count - 1 &&
                        dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString()) ||   ((e.RowIndex + 1) % 3 == 0))
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                        if (e.Value != null)
                        {
                          
                            if (e.RowIndex < dataGridView1.Rows.Count  && (!(e.RowIndex % 3 == 0)))
                            {
                            }
                            else
                            {
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                    Brushes.Black, e.CellBounds.X + 2,
                                    e.CellBounds.Y + 5, StringFormat.GenericDefault);
                            }
                        }
                        e.Handled = true;
                    }
                }
            }
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
                        if (dr.IsNewRow == false)
                        {//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                         //逻辑删除
                         //dataGridView1.Rows.Remove(dr);
                            string id = dr.Cells[0].Value.ToString();
                            dao.del(id);

                        }
                        
                    }
                    //删除任意行数据后，应该刷新dataGridView表格，使索引值从上至下按大小顺序排序  
                    dataGridView1.DataSource = dao.list();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //选中的行数  
            int iCount = dataGridView1.SelectedRows.Count;
            if (iCount < 1|| iCount>3)
            {
                MessageBox.Show("请选择同一组数据!", "错误", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            string cellname = comboBox1.SelectedValue.ToString();
            //string groupid = "";
            double cellvalue = 0.00;
            //遍历数据
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                if (dr.IsNewRow == false)
                {//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                 //逻辑删除
                 //dataGridView1.Rows.Remove(dr);
                    cellvalue += Double.Parse(dr.Cells[cellname].Value.ToString());
                   // groupid = dr.Cells[1].Value.ToString();

                }

            }
            //MessageBox.Show(cellname + " " +cellvalue.ToString()+ " "+ groupid);
           //展示查找出来的数据
            dataGridView1.DataSource = dao.getLikeList(cellname, cellvalue,textBox1.Text);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //加载表格数据
            dataGridView1.DataSource = dao.list();

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选中的行数  
            int iCount = dataGridView1.SelectedRows.Count;
            if (iCount < 1 || iCount > 3)
            {
                MessageBox.Show("请选择同一组数据!", "错误", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            string groupid = "";
            //遍历数据
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                if (dr.IsNewRow == false)
                {
                    groupid = dr.Cells["groupid"].Value.ToString();
                    break;
                }

            }
            string sql = "select DISTINCT result from gongshi where groupid = '{0}';";
            string result = dao.select(string.Format(sql, groupid))["result"].ToString();
            FormModify fm = new FormModify(this);
            fm.comboBox1.Text = result;
            fm.groupid = groupid;
            fm.Show();

        }
    }
}
