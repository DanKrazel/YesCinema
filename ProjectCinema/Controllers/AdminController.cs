using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;
using ProjectCinema.Dal;
using ProjectCinema.ViewModel;

namespace ProjectCinema.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SlideMenu()
        {

            List<MenuItem> list = new List<MenuItem>();

            list.Add(new MenuItem { Link = "ManageHall", LinkName = "ManageHall" });
            list.Add(new MenuItem { Link = "Admin", LinkName = "Admin" });
            list.Add(new MenuItem { Link = "/Movie/ManageMovie", LinkName = "MovieManager" });


            return PartialView("SlideMenu", list);
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin obj)

        {
            if (ModelState.IsValid)
            {
                AdminDal AD = new AdminDal();
                AD.Admin.Add(obj);
                AD.SaveChanges();
                return RedirectToAction("ManageMovie", "Movie");

            }
            return View("Admin", obj);
        }

        public static char getChar(int i)
        {
            return i < 0 || i > 25 ? '?' : (char)('A' + i);
        }
        public ActionResult ManageHall()
        {
            return View();
        }

 
        [HttpPost]
        public ActionResult ManageHall(Seat obj)

        {
            if (ModelState.IsValid)
            {
                SeatDal dal = new SeatDal();
                dal.Seats.Add(obj);
                dal.SaveChanges();
                return View("SlideMenu");

            }
            return View();
        }
    }
}