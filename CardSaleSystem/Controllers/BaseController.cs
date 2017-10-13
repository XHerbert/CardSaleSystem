using CardSaleSystem.Bll;
using CardSaleSystem.Models.ExtModel;
using System.Linq;
using System.Web.Mvc;

namespace CardSaleSystem.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (null == Session["_User"])
            {
                Redirect("/Home/Index");
                return;
            }

            base.OnActionExecuting(filterContext);

            string currentUser = filterContext.HttpContext.User.Identity.Name;

            var user = UsersBll.GetInstance().GetUserByCode(currentUser);
            var info = LoginUserInfo.GetInstance();
            info.CurrentUser = currentUser;
            info.Point = user.Point;
            info.IsAdmin = (user.UserType.Equals("1") || user.UserType.Equals("管理员")) ? true : false;
            info.PreUserCode = user.CreateBy;
            info.Id = user.Id;

            CurrentUserInfo = info;
            Session["_UserId"] = user.Id;
            Session["_PreUserCode"] = info.PreUserCode;
            Session["_Point"] = info.Point;
            Session["_IsAdmin"] = info.IsAdmin;
            Session["_UserType"] = user.UserType;
            Session["_UserInfo"] = info;
            //获取触发当前方法（OnActionExecuting）的Action名字（即：哪个Action方法被执行的时候触发的
            string actionName = filterContext.ActionDescriptor.ActionName;

            //获取触发当前方法的的Action所在的控制器名字
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var paramss = filterContext.ActionParameters;
            string str = "";
            if (paramss.Any()) //Any是判断这个集合是否包含任何元素，如果包含元素返回true，否则返回false
            {
                foreach (var key in paramss.Keys) //遍历它的键；(因为我们要获取的是参数的名称s,所以遍历键)
                {
                    str = key + "的值是" + paramss[key];  //paramss[key] 是key的值
                }
            }

            if (string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
            {
                //if (!(actionName == "Index" && controllerName == "Home"))
                {
                    //filterContext.HttpContext.Response.Redirect("/Home/Index");
                }
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //获取触发当前方法（OnActionExecuting）的Action名字（即：哪个Action方法被执行的时候触发的
            string actionName = filterContext.ActionDescriptor.ActionName;

            //获取触发当前方法的的Action所在的控制器名字
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name) && !(actionName == "Index" && controllerName == "Home"))
            {
                //filterContext.HttpContext.Response.Redirect("/Home/Index");
            }
        }

        public LoginUserInfo CurrentUserInfo { get; private set; }

        //public int Point { get; private set; }

        //public bool IsAdmin { get; private set; }

        //public int PreUserId { get; set; }

        //public string PreUserCode { get; set; }

    }
}