using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.Dal;

namespace ProjectCinema.Controllers
{
    public class MovieController : Controller
    {


        public ActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Movie(Movie MyMovie)
        {

            if (ModelState.IsValid)
            {
                MovieDal dal = new MovieDal();
                dal.MOVIES.Add(MyMovie);
                dal.SaveChanges();
                return View("Movie", MyMovie);
            }
            else
                return View("Movie");
        }


    }

}