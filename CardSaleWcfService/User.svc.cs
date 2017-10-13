using CardSaleSystem.Bll;
using CardSaleSystem.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CardSaleWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“User”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 User.svc 或 User.svc.cs，然后开始调试。
    public class User : IUser
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool DoChangePassword(string userCode, string newPassword)
        {
            bool success = false;

            if (string.IsNullOrEmpty(userCode) || string.IsNullOrEmpty(newPassword))
            {
                return success;
            }

            success = UsersBll.GetInstance().ChangePassword(userCode, newPassword);
            return success;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool DoLogin(string user , string pass)
        {
            bool success = false;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return success;
            }
            else
            {
                bool allowed = UsersBll.GetInstance().IsAllowedLogin(new UsersEntity { UserCode = user, Password = pass });
                if (allowed)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }


    }
}
