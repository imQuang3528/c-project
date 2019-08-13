using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult ListStudent()
        {
            return View();
        }
        public PartialViewResult DetailStudent()
        {
            return PartialView();
        }

        //public JsonResult Display()
        //{
        //    return Json(new DescriptionStudent() { StudentId = 001, StudentName = "Nguyen Minh Quang" }, JsonRequestBehavior.AllowGet);
        //}
    }
}