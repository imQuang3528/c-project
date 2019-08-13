using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;//chuyen doc web config
using System.Data.SqlClient;
using Project.Models;

namespace Project.Controllers
{
    public class LopHocController : Controller
    {
        // GET: LopHoc
        public ActionResult Index()
        {
            //Tao model de mapping voi co so du lieu

            //lay chuoi ket noi tu web config
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            //SU DUNG Class Sqlconnectiom de tao 1 doi tuong ket noi
            SqlConnection conn = new SqlConnection(connectString);

            //khoi tao 1 cau query ma mk muon thuc hien
            string query = "SELECT*FROM CLASS";
            //Mo ket noi
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            //khoi tao 1 doi tuong SqlCommand truyen vao query va doi tuong SqlConnection
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            //Su dung class SqlDataReader de doc du lieu lay ra
            SqlDataReader dr = cmd.ExecuteReader();
            //Doc tu dau cho den dong cuoi cung
            List<LopHoc> lstData = new List<LopHoc>();
            while (dr.Read())
            {
                LopHoc lh = new LopHoc();
                lh.CID = Convert.ToInt32(dr["CID"].ToString());
                lh.cName = dr["cName"].ToString();
                lstData.Add(lh);
            }
            conn.Close();
            return View(lstData);
        }
        public ActionResult GetAllStudent()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "select*from student";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            List<LopHoc> lstLh = new List<LopHoc>();
            while (dr.Read())
            {
                LopHoc lh = new LopHoc();
                lh.CID = Convert.ToInt32(dr["CID"].ToString());
                lh.cName = dr["cName"].ToString();
                lstLh.Add(lh);
            }
            conn.Close();
            return View();
        }
        public ActionResult HocSinh()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "SELECT sID,sName,C.cName FROM STUDENT JOIN CLASS AS C ON STUDENT.cID = C.CID";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            List<HocSinh> lstData = new List<HocSinh>();
            while (dr.Read())
            {
                HocSinh hs = new HocSinh();
                hs.sID = Convert.ToInt32(dr["sID"].ToString());
                hs.sName = dr["sName"].ToString();
                hs.cName = dr["cName"].ToString();
                lstData.Add(hs);
            }
            return View(lstData);
        }
        public ActionResult SoLopHoc()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "select count(*) from class";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            //Lay ra 1 gia tri nhu count,sum,...
            int count = (int)cmd.ExecuteScalar();
            ViewBag.solophoc = count;
            return View(count);
        }
        public ActionResult Details(int id)
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "select * from class where cID=@cID";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter param = new SqlParameter("@cID", id);
            cmd.Parameters.Add(param);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            LopHoc lh = new LopHoc();
            while (dr.Read())
            {
                lh.CID = Convert.ToInt32(dr["CID"].ToString());
                lh.cName = dr["cName"].ToString();
            }
            conn.Close();
            return View(lh);
        }

        public ActionResult Edit(int id)
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "select * from class where cID=@cID";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter param = new SqlParameter("@cID", id);
            cmd.Parameters.Add(param);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            LopHoc lh = new LopHoc();
            while (dr.Read())
            {
                lh.CID = Convert.ToInt32(dr["CID"].ToString());
                lh.cName = dr["cName"].ToString();
            }
            conn.Close();
            return View(lh);
        }
        [HttpPost]
        public ActionResult Edit(LopHoc model)
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "update class set cName=@cName where cID=@cID";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter param = new SqlParameter("@cID",model.CID);
            SqlParameter param1 = new SqlParameter("@cName",model.cName);
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param1);
            cmd.CommandType = System.Data.CommandType.Text;
            //ExecuteNonQuery danh cho cac cau lenh lien quan den Insert,Update,Delete
            int soDongAnhHuong = cmd.ExecuteNonQuery();
            conn.Close();
            if (soDongAnhHuong > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "delete from class where cID=@cID";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter param = new SqlParameter("@cID", id);
            cmd.Parameters.Add(param);
            cmd.CommandType = System.Data.CommandType.Text;
            //ExecuteNonQuery danh cho cac cau lenh lien quan den Insert,Update,Delete
            int soDongAnhHuong = cmd.ExecuteNonQuery();
            conn.Close();
            if (soDongAnhHuong > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(LopHoc model)
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectString);
            string query = "INSERT INTO CLASS (cName) VALUES (@cName)";
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter param = new SqlParameter("@cName",model.cName);
            cmd.Parameters.Add(param);
            cmd.CommandType = System.Data.CommandType.Text;
            //ExecuteNonQuery danh cho cac cau lenh lien quan den Insert,Update,Delete
            int soDongAnhHuong = cmd.ExecuteNonQuery();
            List<LopHoc> lstData = new List<LopHoc>();
            conn.Close();
            if (soDongAnhHuong > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
   
    }
}