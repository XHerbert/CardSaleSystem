using CardSaleSystem.Bll;
using CardSaleSystem.Models;
using CardSaleSystem.Models.UserModel;
using CardSaleSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using XHB.Card.BLL.Bll;

namespace CardSaleSystem.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Desktop()
        {
            var act = ActTypeBll.GetInstance().GetActTypeList();
            CardQueryExt ext = new CardQueryExt();
            ext.ActType = act;
            ext.VPack = new List<XHB.Card.Entity.VPack>();
            return View(ext);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }

        public ActionResult DoLogin(FormCollection form)
        {
            string user = form["username"];
            string pass = form["password"];
            if (ConfigHelper.GetConfig("Debug").Equals("True"))
            {
                FormsAuthentication.SetAuthCookie("debuger", true);
                Session.Add("_User", user);
                return Redirect("/Home/Desktop");
            }
            
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return Redirect("Index");
            }
            else
            {
                bool allowed = UsersBll.GetInstance().IsAllowedLogin(new UsersEntity { UserCode = user, Password = pass });
                if (allowed)
                {
                    Session.Add("_User", user);
                    FormsAuthentication.SetAuthCookie(user, true);
                    return Redirect("/Home/Desktop");
                }
                else
                {
                    return Redirect("Index");
                }
            }
        }


        public ActionResult Logout()
        {
            Session.RemoveAll();
            return Redirect("Index");
        }
    }
}
