using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;



namespace ProjectCinema.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private DB_Entities db = new DB_Entities();

        public ActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Movie(Movie MyMovie)
        {

            if (ModelState.IsValid)
            {
 
                db.MOVIES.Add(MyMovie);
                db.SaveChanges();
                return View("Movie", MyMovie);
            }
            else
                return View("Movie");
        }
    }
}