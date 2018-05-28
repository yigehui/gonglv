using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Util
{
    public class PropertyUtil
    {
        /// <summary>
        /// 反射获取对象的属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object ReflectGetter(object obj, string propertyName)
        {
            var type = obj.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            var propertyValue = propertyInfo.GetValue(obj);
            return propertyValue;
        }
        /// <summary>
        /// 把数据加载到datagridview中
        /// </summary>
        /// <param name="d"></param>
        /// <param name="gongsi"></param>
        public void addDateToDateGrid(DataGridView d, Gongshi gongsi) {
            DataGridViewRow row = new DataGridViewRow();
            int index = d.Rows.Add(row);
            for (int i = 0; i < d.Rows[0].Cells.Count; i++)
            {
                //根据类型获得数据
                String name = Enum.Parse(typeof(cell), (i + 1).ToString()).ToString();
                Double value = (double)PropertyUtil.ReflectGetter(gongsi, name);
                d.Rows[index].Cells[i].Value = String.Format("{0:N2}", value);//保留两位小数
            }
        }
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        private static string GetUniqueKey()
        {
            int maxSize = 8;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
        public static string GetId() {
            string str = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), GetUniqueKey());
            return str;
        }
        /// <summary>
        /// string转double，""转换成0.00
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Double StringToDouble(String s) {
            if (s.Trim().Equals(""))
                return 0.00;
            return double.Parse(s);
        }

        #region DataGridView导出到Excel，有一定的判断性     
        /// <summary>      
        ///方法，导出DataGridView中的数据到Excel文件      
        /// </summary>      
        /// <remarks>     
        /// add com "Microsoft Excel 11.0 Object Library"     
        /// using Excel=Microsoft.Office.Interop.Excel;     
        /// using System.Reflection;     
        /// </remarks>     
        /// <param name= "dgv"> DataGridView </param>      
        public static void DataGridViewToExcel(DataGridView dgv)
        {


            #region   验证可操作性     

            //申明保存对话框      
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀      
            dlg.DefaultExt = "xls ";
            //文件后缀列表      
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径      
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框      
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径      
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效      
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数      
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0      
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0      
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536      
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255      
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它      
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象      
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见      
                objExcel.Visible = false;

                //向Excel中写入表格的表头      
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //设置进度条      
                //tempProgressBar.Refresh();      
                //tempProgressBar.Visible   =   true;      
                //tempProgressBar.Minimum=1;      
                //tempProgressBar.Maximum=dgv.RowCount;      
                //tempProgressBar.Step=1;      
                //向Excel中逐行逐列写入表格中的数据      
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();      

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //隐藏进度条      
                //tempProgressBar.Visible   =   false;      
                //保存文件      
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用      
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion

        /// <summary>
        /// 读取对象的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }
            string[] field = new string[properties.Length-1];
            string[] fieldvalue = new string[properties.Length-1];
            int i = 0;
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                if (name.Equals("color"))
                    continue;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    field[i] = name;
                    fieldvalue[i] = "'"+value.ToString()+"'";
                    tStr += string.Format("{0}:{1},", name, value);
                }
                i++;
            }
            tStr = "insert into gongshi(" + string.Join(",", field) + ",addtime)values(" + string.Join(",", fieldvalue) + ",'" + DateTime.Now + "');";

            return tStr;
        }

    }

}
