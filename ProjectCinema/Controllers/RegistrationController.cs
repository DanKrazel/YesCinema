using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;
using ProjectCinema.Dal;


namespace ProjectCinema.Controllers
{
    public class RegistrationController : Controller
    {
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
                UserDal dal = new UserDal();
                var data = dal.Users.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).ToList();
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
        public ActionResult Register(Register obj)

        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                dal.Users.Add(obj);
                dal.SaveChanges();
                return View("Login", obj);

            }
            return View("Register",obj);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}