using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZakatApp.Models;
using PagedList;

namespace ZakatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {

            Dictionary<Int32, string> zakatType = new Dictionary<Int32, string>();
            zakatType.Add(1, "Pendapatan");
            zakatType.Add(2, "Perniagaan");
            zakatType.Add(3, "Saham");
            zakatType.Add(4, "Harta");
            zakatType.Add(5, "Wang Simpanan");
            zakatType.Add(6, "Emas");
            zakatType.Add(7, "Perak");
            zakatType.Add(8, "Pertanian");
            zakatType.Add(9, "Ternakan");
            zakatType.Add(10, "Rikaz");
            zakatType.Add(11, "Qadha");
            
            Dictionary<Int32, string> dist_code = new Dictionary<Int32, string>();
            dist_code.Add(1 ,"KUANTAN");
            dist_code.Add(2, "PEKAN");
            dist_code.Add(3, "TEMERLOH");
            dist_code.Add(4, "ROMPIN");
            dist_code.Add(5, "MARAN");
            dist_code.Add(6, "BENTONG");
            dist_code.Add(7, "LIPIS");
            dist_code.Add(8, "CAM. HIGHLANDS");
            dist_code.Add(9, "JERANTUT");
            dist_code.Add(10, "BERA");
            dist_code.Add(11, "RAUB");

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            User user = new User();
            ViewBag.userZakat = user.FetchAll().ToPagedList(pageNumber, pageSize);
            ViewBag.zakatType = zakatType;
            ViewBag.dist_code = dist_code;
            ViewBag.pageSize = 20;
            ViewBag.pageNumber = (page ?? 1);

            return View();
        }
    }
}
