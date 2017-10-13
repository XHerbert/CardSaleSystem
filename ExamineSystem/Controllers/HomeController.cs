using System;
using System.Collections.Generic;
using System.Linq;
using ExamineSystem.Bll;
using System.Web.Mvc;
using ExamineSystem.Models.ExamModel;
namespace ExamineSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IList<ExamEntity> exams = new List<ExamEntity>();
            exams = ExamBll.GetInstance().GetExamList();
            return View(exams);
        }

        public ActionResult ExamList()
        {
            return View();
        }
    }
}
