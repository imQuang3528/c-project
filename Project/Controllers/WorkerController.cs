using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class WorkerController : Controller
    {
        CRMEntities db = new CRMEntities();
        // GET: Worker
        public ActionResult GetWorker()
        {
            var lstWk = db.NhanViens.ToList();
            return View(lstWk);
        }
        public JsonResult Display()
        {
            var lstNv = db.NhanViens.ToList();
            return Json(lstNv, JsonRequestBehavior.AllowGet);
        }
    }
}