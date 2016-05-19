using Lab3._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3._2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            Student student = new Student()
            {
                StudentID = 1,
                Address = "Någongatan 01",
                Name="Någon",
                LastName="Dude",
                Personnumber="130113-1337",
                Grades = new List<Grade>()
                {
                    new Grade() {StudentID=2, CourseName="English", CourseGrade="MVG" },
                    new Grade() {StudentID=3, CourseName="History", CourseGrade="MVG" }
                }
            };
            Session["Student"] = student;
            return View(student);
        }
    }
}