using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class FormController : Controller
    {

        public static List<SanPham> lstSp = new List<SanPham>()
        {
            new SanPham() {ProductId=001,ProductName="Noi com"},
            new SanPham() {ProductId=002,ProductName="Tu Lanh"},
            new SanPham() {ProductId=003,ProductName="Laptop"},
            new SanPham() {ProductId=004,ProductName="Quat cay"},
        };
        // GET: Form
        public ActionResult GetAllStudent()
        {
            var sp = lstSp.ToList();
            return View(sp);
        }
        public ActionResult DetailProduct(int? id)
        {
            var result = lstSp.Where(n => n.ProductId == id).FirstOrDefault();
            return View(result);
        }
        public ActionResult ThemSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(SanPham sp)
        {
            lstSp.Add(sp);
            return RedirectToAction("GetAllStudent");
        }
    }
}