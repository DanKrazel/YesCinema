using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.Dal;
using System.Security.Cryptography;

namespace ProjectCinema.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImagesView()
        {

            ImagesDal dal = new ImagesDal();
            return View(dal.Images.ToList());
        }

        public ActionResult newIndex()
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