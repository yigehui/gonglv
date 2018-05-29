using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using WindowsFormsApplication1.Util;

namespace WindowsFormsApplication1.Dao
{
    public class GongShiDao
    {
        private BaseSqliteSql session = new BaseSqliteSql();
        public List<Gongshi> list() {
            string sql = "select '0'as color, g.* from gongshi g order by g.addtime desc";
            return baseList(sql);
        }
        /// <summary>
        /// 根据sql获得list
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private List<Gongshi> baseList(string sql) {
            List<Gongshi> list = new List<Gongshi>();
                    //准备读数据
                    using (SQLiteDataReader reader = session.ExecuteQuery(sql))
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
                                    if (propertyInfo != null)
                                        propertyInfo.SetValue(gs, reader.GetValue(i), null);//给对应属性赋值
                                }
                                list.Add(gs);//添加到集合中
                            }//end while
                        }//end if
                    }// end sqldatareader
            return list;
        }
        //添加数据
        public void add(Gongshi g)
        {
         
            string sql = PropertyUtil.getProperties<Gongshi>(g);
        
            string msg = session.QuerySql(sql) > 0 ? "操作成功" : "操作失败";
            MessageBox.Show(msg);

        }
        //删除数据
        public void del(String id)
        {
            string sql = "delete  from gongshi where id='{0}'; ";
            int n = session.QuerySql(string.Format(sql,id));
            string msg = n > 0 ? "操作成功" : "操作失败";
            if (!(n > 0))
            {
                MessageBox.Show(msg);
            }

        }
        public List<Gongshi> getLikeList(string cellname,double cellvalue,string xiangsidu) {
            string sql = "SELECT(CASE WHEN groupid IN(SELECT a.groupid FROM(SELECT groupid, (abs(sum({0}) - ({1}))) AS chazhi FROM gongshi GROUP BY groupid ORDER BY addtime DESC) a WHERE a.chazhi < {2}) THEN '1' ELSE '0' END) AS color, g.* FROM gongshi g ORDER BY addtime DESC";
            return baseList(string.Format(sql, cellname, cellvalue, xiangsidu));

        }

    }
}
