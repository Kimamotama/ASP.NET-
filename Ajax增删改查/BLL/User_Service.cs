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
        User_dao dao = new User_dao();
        public Users_Model FindUser(string name) 
        {
            return dao.FindUser(name);
        }

        public Users_Model FindUser(int id)
        {
            return dao.FindUser(id);
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
            usermodel = dao.FindUser(userName);
            if (usermodel != null)
            {
                if (usermodel.LoginPwd == userPwd)
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

        public List<Users_Model> GetUsers()
        {
            return dao.GetUsers();
        }
        public bool DeleteUser(int id)
        {
            return dao.DeleteUser(id) > 0;
        }

        public bool AddUser(Users_Model usermodel)
        {
            return dao.AddUser(usermodel) > 0;
        }

        public bool UpdateUser(Users_Model usermodel)
        {
            return dao.UpdateUser(usermodel)>0;
        }
        /// <summary>
        /// 求总页数
        /// </summary>
        /// <param name="pageSize">每页显示的记录数据</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = dao.GetRecordCount();
            return Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
        }
        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public List<Users_Model> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return dao.GetPageList(start, end);

        }
    }
}
