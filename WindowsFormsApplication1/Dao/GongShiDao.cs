using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1.Dao
{
   public class GongShiDao
    {
         string str = "server=127.0.0.1;User Id=root;password=1234;Database=duqiu;sslmode=none; ";

        public List<Gongshi> list() {
            List<Gongshi> list = new List<Gongshi>();
            //通过连接字符串连接数据库
            using (MySqlConnection con = new MySqlConnection(str))
            {
                //拼接sql语句
                string sql = "select * from gongshi";
                //准备执行sql语句的对象
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    con.Open();//打开数据库
                    //准备读数据
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        //判断是否有数据(有没有行)
                        if (reader.HasRows)
                        {
                            //读取每一行
                            while (reader.Read())
                            {
                                Gongshi gs = new Gongshi();//创建餐桌对象
                                Type type = gs.GetType();//获取类型
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    System.Reflection.PropertyInfo propertyInfo = type.GetProperty(reader.GetName(i));
                                    if(propertyInfo!=null)
                                        propertyInfo.SetValue(gs, reader.GetValue(i), null);//给对应属性赋值
                                }
                                list.Add(gs);//添加到集合中
                            }//end while
                        }//end if
                    }// end sqldatareader
                }//end using
            }//end using
            return list;
        }
        //添加数据
        public void add(Gongshi g)
        {
            int n = -1;
            //获取文本框的值
            //连接数据库
            using (MySqlConnection con = new MySqlConnection(str))
            {
                string sql = PropertyUtil.getProperties<Gongshi>(g);
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    con.Open();//打开数据库
                    n = cmd.ExecuteNonQuery();
                }
            }
            string msg = n > 0 ? "操作成功" : "操作失败";
            MessageBox.Show(msg);

        }


    }
}
