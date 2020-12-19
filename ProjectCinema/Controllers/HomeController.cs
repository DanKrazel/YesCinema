using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;

namespace ProjectCinema.Controllers
{
    public class HomeController : Controller
    {
        private DB_Entities db = new DB_Entities();
        public ActionResult Index()
        {
            return View("Index","_Layout");
        }

        public ActionResult newIndex()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}