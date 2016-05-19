using Lab3._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3._2.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GradesListForStudent(int studentId)
        {
            List<Grade> grades = ((Student)Session["Student"]).Grades;
            return PartialView(grades);
        }
        public PartialViewResult AddGrade(int studentId)
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddGrade(Grade model)
        {
            ((Student)Session["Student"]).Grades.Add(model);
            return RedirectToAction(actionName: "GradesListForStudent",
                routeValues: new { studentId = 9 });
        }
    }
}
