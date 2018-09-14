using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBHelperSql
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        public static DataTable ExecuteTable(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter=new SqlDataAdapter(sql,conn))
                {
                    adapter.SelectCommand.CommandType = type;
                    if (pars!=null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static int ExecuteNonQuery(string sql,CommandType type,params SqlParameter[] pars)
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

        public static object ExecuteScalar(string sql,CommandType type,params SqlParameter[] pars)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlCommand comm=new SqlCommand(sql,conn))
                {
                    comm.CommandType = type;
                    if (pars!=null)
                    {
                        comm.Parameters.Add(pars);
                    }
                    conn.Open();
                    return comm.ExecuteScalar();
                }
            }
        }
    }
}
