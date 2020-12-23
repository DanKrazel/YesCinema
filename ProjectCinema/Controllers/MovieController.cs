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

        public ActionResult DisplayMovieGallery(MovieViewModel model)
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }
     
        [HttpPost]
        public ActionResult DisplayMovieGallery()
        {
            MovieDal dal = new MovieDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else
                return View("Movie");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            Movie obj = new Movie();
            obj.Delete(id);
            return RedirectToAction("DisplayMovieGallery");
        }
       



    }

}


