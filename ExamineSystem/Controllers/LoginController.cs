using ExamineSystem.Bll;
using ExamineSystem.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamineSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoLogin(FormCollection form)
        {
            string user = form["username"];
            string pass = form["password"];
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return Redirect("Index");
            }
            else
            {
                bool allowed =UsersBll.GetInstance().IsAllowedLogin(new UsersEntity { UserCode = user, Password = pass });
                if (allowed)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    return Redirect("Index");
                }
            }
        }
    }
}