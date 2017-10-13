using System;
using System.Collections.Generic;
using System.Linq;
using ExamineSystem.Bll;
using System.Web.Mvc;
using ExamineSystem.Models.ExamModel;

namespace ExamineSystem.Controllers
{
    public class ExamDetailController : Controller
    {
        // GET: ExamDetail
        public ActionResult Index(long examId)
        {
            IList<ExamLineEntity> list = ExamLineBll.GetInstance().GetExamLineByExamId(examId);
            return View(list);
        }
    }
}