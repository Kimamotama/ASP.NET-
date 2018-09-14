using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbHelperSql
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter atper = new SqlDataAdapter(sql, conn))
                {
                    try
                    {
                        atper.SelectCommand.CommandType = type;
                        if (pars != null)
                        {
                            atper.SelectCommand.Parameters.AddRange(pars);
                        }
                        DataTable da = new DataTable();
                        atper.Fill(da);
                        return da;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }


        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
                conn.Close();
            }
        }


    }
}
