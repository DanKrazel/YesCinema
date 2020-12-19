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
    public class RegistrationController : Controller
    {
        private DB_Entities db = new DB_Entities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.Users.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["USERNAME"] = data.FirstOrDefault().USERNAME;
                    Session["PASSWORD"] = data.FirstOrDefault().PASSWORD;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(REGISTER obj)

        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.MAIL == obj.MAIL);
                if (check == null)
                {
                    db.Users.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return RedirectToAction("Register");
                }
            }
            return View(obj);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}