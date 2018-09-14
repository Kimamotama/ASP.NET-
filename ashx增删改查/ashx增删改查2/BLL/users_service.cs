using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class users_service
    {
        Users_dao userdao = new Users_dao();
        public List<Users_model> GetList()
        {
            return userdao.GetList();
        }
        
        public bool AddUser(Users_model usermodel)
        {
            return userdao.AddUser(usermodel) > 0;
        }

        public bool UserIsNull(Users_model usermodel)
        {
            if (usermodel.LoginPwd==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.NickName==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.Sex==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.Age==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.FaceId==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.Friend==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.Name==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.StarId==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            if (usermodel.BloodId==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Users_model GetUserById(int id)
        {
            return userdao.GetUserById(id);
        }
        public bool UpdateUser(Users_model usermodel)
        {
            return userdao.UpdateUser(usermodel)>0;
        }
        public bool DeleteUser(int id)
        {
            return userdao.DeleteUser(id)>0;
        }
    }
}
