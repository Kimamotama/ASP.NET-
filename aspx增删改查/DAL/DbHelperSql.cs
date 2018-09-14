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
            //using (SqlConnection conn=new SqlConnection(connStr))
            //{
            //    using (SqlDataAdapter atper=new SqlDataAdapter(sql,conn))
            //    {
            //        atper.SelectCommand.CommandType = type;
            //        if (pars!=null)
            //        {
            //            atper.SelectCommand.Parameters.AddRange(pars);
            //        }
            //        DataTable da = new DataTable();
            //        atper.Fill(da);
            //        return da;
            //    }
            //}


            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlDataAdapter atper = new SqlDataAdapter(sql, conn);
            atper.SelectCommand.CommandType = type;

            if (pars != null)
            {
                atper.SelectCommand.Parameters.AddRange(pars);
            }

            DataTable ds = new DataTable();
            atper.Fill(ds);
            conn.Close();
            conn.Dispose();
            return ds;


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
