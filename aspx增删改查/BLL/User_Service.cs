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
        private readonly User_dao userDao = new User_dao();
        public List<Users_Model> GetList()
        {
            return userDao.GetList();
        }

        public bool AddUser(Users_Model usermodel)
        {
            return userDao.AddUser(usermodel)>0;
        }
        /// <summary>
        /// 根据用户编号查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Users_Model FindUser(int id)
        {
            return userDao.FindUser(id);
        }
        /// <summary>
        /// 根据用户名称
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Users_Model FindUser(string userName)
        {
            return userDao.FindUser(userName);
        }

        public bool UpdateUser(Users_Model usermodel)
        {
            return userDao.UpdateUser(usermodel)>0;
        }
        public bool DeleteUser(int id)
        {
            return userDao.DeleteUser(id) > 0;
        }
        /// <summary>
        /// 判断用户的用户名密码是否正确
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="msg">返回的信息</param>
        /// <param name="usermodel">返回的登录用户的信息</param>
        /// <returns></returns>
        public bool CheckLoginUser(string userName, string userPwd, out string msg, out Users_Model usermodel)
        {
            usermodel= userDao.FindUser(userName);
            if (usermodel!=null)
            {
                if (usermodel.LoginPwd==userPwd)
                {
                    msg = "登陆成功";
                    return true;
                }
                else
                {
                    msg = "用户名或密码错误";
                    return false;
                }
            }
            else
            {
                msg = "此用户不存在";
                return false;
            }
        }

    }
}
