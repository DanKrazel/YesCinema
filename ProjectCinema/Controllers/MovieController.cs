using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using ProjectCinema.Dal;

namespace ProjectCinema.Controllers
{
    public class MovieController : Controller
    {
        MovieDal dal = new MovieDal();


        public ActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Movie(Movie MyMovie)
        {

            if (ModelState.IsValid)
            {
                dal.MOVIES.Add(MyMovie);
                dal.SaveChanges();
                return View("Movie", MyMovie);
            }
            else
                return View("Movie");
        }

        public ActionResult MovieGallery()
        {
            var Movies = (from movie in dal.MOVIES select movie).ToList();
            return View(Movies);
        }

        [HttpPost]
        public ActionResult MovieGallery(MovieViewModel model)
        {

            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View(data);
            }
            else
                return View("Movie");
        }


    }

}