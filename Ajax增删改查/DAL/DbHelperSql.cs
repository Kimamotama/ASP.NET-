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
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)
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
                    DataTable da = new DataTable();
                    adapter.Fill(da);
                    return da;
                }
            }
        }

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

        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
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
