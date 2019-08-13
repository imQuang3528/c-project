using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        public static List<SanPham> lstData = new List<SanPham>()
        {
            new SanPham() {ProductId=001,ProductName="Tivi" },
            new SanPham() {ProductId=00,ProductName="Tu Lanh" },
            new SanPham() {ProductId=003,ProductName="Ban La" },
            new SanPham() {ProductId=004,ProductName="May Giat" },
            new SanPham() {ProductId=005,ProductName="Dieu Hoa" },
            new SanPham() {ProductId=006,ProductName="Bep Gas" },
        };
        public ActionResult dsSanPham()
        {
            return View(lstData);
        }
        public ActionResult GetProductById(int id)
        {
            var pr = lstData.Where(n => n.ProductId == id).FirstOrDefault();
            return View(pr);
        }
        public ActionResult ThemSP()
        {
            return View();

        }
        [HttpPost]
        public ActionResult SubmitThemMoi(SanPham model)
        {
            lstData.Add(model);
            return RedirectToAction("dsSanPham");
        }
        public ActionResult Update(SanPham model)
        {
            var query = lstData.Where(n => n.ProductId == model.ProductId).FirstOrDefault();
            query.ProductName = model.ProductName;
            return RedirectToAction("dsSanPham");
        }

        //Moi 1 action se tra du lieu ra cho Client(page html,1 phan cua page Html,1 chuoi,json,...)
        //quan tam nhieu action tra ra 1 page html,1 json
        //Actionresult - Tra ve client 1 page html

            //Co 4 cach truyen du lieu tu controller ra View
            //model,ViewBag,ViewData,TempData
       public ActionResult ListStudent()
        {
            //Truyen du lieu bang model
            List<SinhVien> lstSt = new List<SinhVien>()
            {
                new SinhVien() {StudentId=001,StudentName="Nguyen Minh Quang" },
                new SinhVien() {StudentId=002,StudentName="Nguyen Minh Huyen" },
                new SinhVien() {StudentId=003,StudentName="Nguyen Trung Hieu" },
                new SinhVien() {StudentId=004,StudentName="Nguyen Trung Kien" },
            };

            SinhVien hs = new SinhVien() { StudentId = 01, StudentName = "Nguyen Thi Huyen" };

            //Truyen du lieu bang ViewBag
            ViewBag.lstST = lstSt;
            ViewBag.hs = hs;
            //Khi truyen du lieu bang model phai tra ve doi tuong trong View
            return View(lstSt);
        }
        //PartialViewResult - Tra ve 1 phan cua html
        public PartialViewResult ThemMoi()
        {
            return PartialView();
        }
        //Tra ve cho client 1 json
        //public JsonResult CapNhatTT()
        //{
        //    return Json(new Student() { StudentId =001,StudentName="Quang"},JsonRequestBehavior.AllowGet);
        //}
        public ActionResult CreateStudent()
        {
            return View();
        }
    }
}