using CardSaleSystem.Bll;
using CardSaleSystem.Models.ExtModel;
using CardSaleSystem.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSaleSystem.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            string currentUser = System.Web.HttpContext.Current.User.Identity.Name;
            string createBy = string.IsNullOrEmpty(currentUser) ? string.Empty : currentUser;
            UserExt uext = new UserExt();
            if (Session["_Search"] != null)
            {
                var userEntities = Session["_Search"] as List<UsersEntity>;
                Session.Remove("_Search");
                uext.UsersEntity = userEntities;
                ViewBag.Data = uext;
            }
            else
            {
                IList<UsersEntity> list = new List<UsersEntity>();
                list = UsersBll.GetInstance().GetSpecialUsers(createBy);
                uext.UsersEntity = list;
                ViewBag.Data = uext;
            }


            return View(uext);
        }

        public ActionResult CreateProxy(UsersEntity user)
        {
            string createBy = System.Web.HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(createBy) || null == user)
            {
                //当前没有用户登录
                return Redirect("/Home/Index");
            }

            UsersEntity entity = new UsersEntity();
            entity.UserName = user.UserName;
            entity.UserCode = user.UserCode;
            entity.Password = user.Password == null ? "111111" : user.Password;
            entity.CreateBy = createBy;
            entity.Phone = user.Phone;
            entity.UserType = user.UserType;
            entity.IsActive = user.IsActive;
            entity.Memo = user.Memo;
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            UsersBll.GetInstance().Insert(entity);
            return Redirect("/User/Index/");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult DoChangePassword(FormCollection form)
        {
            if (form.Count == 0)
            {
                return Redirect("/User/ChangePassword");
            }

            foreach (var item in form.Keys)
            {
                if (string.IsNullOrEmpty(form[item.ToString()].ToString()))
                {
                    return Redirect("/User/ChangePassword");
                }
            }
            
            string newPassword = form["newPassword"];
            string loginUser = Session["user"].ToString();
            bool ret = UsersBll.GetInstance().ChangePassword(loginUser, newPassword);
            if (ret)
            {
                //更新密码成功
                return Redirect("/User/Index");
            }
            else
            {
                //更新密码失败
                return Redirect("/User/ChangePassword");
            }
        }

        public ActionResult SearchUser(string info)
        {
            if (null == base.CurrentUserInfo)
            {
                Redirect("/Home/Index");
                return null;
            }
            info = info.Trim();
            
            if (!string.IsNullOrEmpty(info))
            {
                long uid = Session["_UserId"] == null ? 0 : long.Parse(Session["_UserId"].ToString());
                var user = UsersBll.GetInstance().GetAdminSingle(uid);
                ViewBag.Data = UsersBll.GetInstance().GetSearchUser(user.CreateBy, info);
                Session.Add("_Search", ViewBag.Data);
            }
            
            return Redirect("/User/Index");
        }

        public ActionResult Delete(long uid)
        {
            long ret =  UsersBll.GetInstance().DeleteLogical(uid);


            return Redirect("/User/Index");
        }
    }
}