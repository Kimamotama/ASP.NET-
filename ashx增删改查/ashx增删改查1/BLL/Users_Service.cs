using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class Users_Service
    {
        User_dao userdao=new User_dao();
        /// <summary>
        /// 返回用户的列表
        /// </summary>
        /// <returns></returns>
        public List<Users_Model> GetList()
        {
            return userdao.GetList();
        }

        public bool AddUser(Users_Model usermodel)
        {
            return userdao.AddUser(usermodel)>0;
        }

        public bool DeleteUser(int id)
        {
            return userdao.DeleteUser(id)>0;
        }

        public Users_Model GetUserModel(int id)
        {
            return userdao.GetUserModel(id);
        }

        public bool UpdateUser(Users_Model user)
        {
            return userdao.UpdataUser(user)>0;
        }
    }
}
