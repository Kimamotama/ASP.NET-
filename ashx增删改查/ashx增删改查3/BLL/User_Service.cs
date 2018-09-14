using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class User_Service
    {
        private static readonly User_dao dao = new User_dao();
        public List<User_Model> GetList()
        {
            return dao.GetList();
        }

        public bool AddUser(User_Model usermodel)
        {
            return dao.AddUser(usermodel)>0;
        }
        public User_Model GetUser(int id)
        {
            return dao.GetUser(id);
        }
        public bool UpdateUser(User_Model usermodel)
        {
            return dao.Update(usermodel)>0;
        }

        public bool DeleteUser(int id)
        {
            return dao.DeleteUser(id) > 0;
        }
    }
}
