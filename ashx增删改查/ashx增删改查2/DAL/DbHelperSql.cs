using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DbHelperSql
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 返回表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tyoe"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql,CommandType tyoe,params SqlParameter[] pars)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlDataAdapter atper=new SqlDataAdapter(sql,conn))
                {
                    atper.SelectCommand.CommandType = tyoe;
                    if (pars !=null)
                    {
                        atper.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable da = new DataTable();
                    atper.Fill(da);
                    return da;
                }
            }
        }
        /// <summary>
        /// 返回行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tyoe"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlCommand comm=new SqlCommand(sql,conn))
                {
                    comm.CommandType = type;
                    if (pars!=null)
                    {
                        comm.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return comm.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql,CommandType type,params SqlParameter []pars)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlCommand comm=new SqlCommand(sql,conn))
                {
                    comm.CommandType = type;
                    if (pars!=null)
                    {
                        comm.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return comm.ExecuteScalar();
                }
            }
        }



    }
}
