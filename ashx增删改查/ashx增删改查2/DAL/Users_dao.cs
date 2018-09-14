using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Users_dao
    {
        public List<Users_model> GetList()
        {
            string sql = "select * from users";
            DataTable da = DbHelperSql.GetTable(sql, CommandType.Text);
            List<Users_model> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<Users_model>();
                Users_model usermodel = null;
                foreach (DataRow row in da.Rows)
                {
                    usermodel = new Users_model();
                    LoadEntity(row, usermodel);
                    list.Add(usermodel);
                }
            }
            return list;
        }

        private void LoadEntity(DataRow row, Users_model usermodel)
        {
            usermodel.Id = Convert.ToInt32(row["Id"]);
            usermodel.LoginPwd = row["LoginPwd"] != DBNull.Value ? row["LoginPwd"].ToString() : string.Empty;
            usermodel.NickName = row["NickName"] != DBNull.Value ? row["NickName"].ToString() : string.Empty;
            usermodel.Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : string.Empty;
            usermodel.Age = Convert.ToInt32(row["Age"]);
            usermodel.FaceId = Convert.ToInt32(row["FaceId"]);
            usermodel.Friend = Convert.ToInt32(row["FriendShipPolicyId"]);
            usermodel.Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty;
            usermodel.StarId = Convert.ToInt32(row["StarId"]);
            usermodel.BloodId = Convert.ToInt32(row["BloodTypeId"]);
        }

        public int AddUser(Users_model usermodel)
        {
            string sql = "insert into users values(@pwd,@nick,@sex,@age,@face,@friend,@name,@star,@blood)";
            SqlParameter[] pars ={
                                    new SqlParameter("@pwd",SqlDbType.VarChar,20),
                                    new SqlParameter("@nick",SqlDbType.VarChar,20),
            new SqlParameter("@sex",SqlDbType.Char,2),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@face",SqlDbType.Int),
            new SqlParameter("@friend",SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.VarChar,20),
            new SqlParameter("@star",SqlDbType.Int),
            new SqlParameter("@blood",SqlDbType.Int)
                                };
            pars[0].Value = usermodel.LoginPwd;
            pars[1].Value = usermodel.NickName;
            pars[2].Value = usermodel.Sex;
            pars[3].Value = usermodel.Age;
            pars[4].Value = usermodel.FaceId;
            pars[5].Value = usermodel.Friend;
            pars[6].Value = usermodel.Name;
            pars[7].Value = usermodel.StarId;
            pars[8].Value = usermodel.BloodId;
            return DbHelperSql.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public Users_model GetUserById(int id)
        {
            string sql = "select * from Users where id=@id";
            Users_model usermodel = new Users_model();
            DataTable da = DbHelperSql.GetTable(sql, CommandType.Text, new SqlParameter("@id", id));
            if (da.Rows.Count>0)
            {
                usermodel = new Users_model();
                LoadEntity(da.Rows[0], usermodel);
            }
            return usermodel;


        }

        public int UpdateUser(Users_model usermodel)
        {
            string sql = "update users set loginpwd=@pwd,NickName=@nick,sex=@sex,age=@age,faceid=@face,FriendShipPolicyId=@friend,Name=@name,StarId=@star,BloodTypeId=@blood where id=@id";
            SqlParameter[] pars ={
                                      new SqlParameter("@pwd",SqlDbType.VarChar,20),
            new SqlParameter("@nick",SqlDbType.VarChar,20),
            new SqlParameter("@sex",SqlDbType.Char,2),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@face",SqlDbType.Int),
            new SqlParameter("@friend",SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.VarChar,20),
            new SqlParameter("@star",SqlDbType.Int),
            new SqlParameter("@blood",SqlDbType.Int),
            new SqlParameter("@id",SqlDbType.Int)
                                 };
            pars[0].Value = usermodel.LoginPwd;
            pars[1].Value = usermodel.NickName;
            pars[2].Value = usermodel.Sex;
            pars[3].Value = usermodel.Age;
            pars[4].Value = usermodel.FaceId;
            pars[5].Value = usermodel.Friend;
            pars[6].Value = usermodel.Name;
            pars[7].Value = usermodel.StarId;
            pars[8].Value = usermodel.BloodId;
            pars[9].Value = usermodel.Id;
            return DbHelperSql.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public int DeleteUser(int id)
        {
            string sql = "delete from users where id=@id";
            return DbHelperSql.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@id", id));
        }
    }
}
