using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using ProjectCinema.Dal;
using System.Data.Entity;
using System.IO;

namespace ProjectCinema.Controllers
{
    public class MovieGalleryUserController : Controller
    {
        // GET: MovieGalleryForUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieGallery(MovieViewModel model)
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult MovieGallery()
        {
            MovieDal dal = new MovieDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else

                return View("MovieGalleryUser/MovieGallery");
        }

        public ActionResult BookYourTicket(string id)
        {
            Tickets mvm = new Tickets();
            MovieDal dal = new MovieDal();
            var item = dal.MOVIES.Where(a => a.ID == id).FirstOrDefault(); ;
            mvm.MOVIENAME = item.name;
            mvm.SHOWTIME = item.showtime;
            mvm.MOVIEID = id;

            return View(mvm);
        }

        [HttpPost]
        public ActionResult BookYourTicket(Tickets mvm)
        {
            if (ModelState.IsValid)
            {
                UserDal userDal = new UserDal();
                TicketsDal dal = new TicketsDal();
                TicketsViewModel tickets = new TicketsViewModel();
                int count = 1;
                bool flag = true;
                string seatno = mvm.SEAT.ToString();
                string movieId = mvm.MOVIEID;
                string[] seatNoArray = seatno.Split(',');
                count = seatNoArray.Length;
                if (checkseat(seatno, movieId) == false)
                {
                    foreach (var item in seatNoArray)
                    {
                        tickets.TicketsList.Add(new Tickets { COST = "150", MOVIEID = mvm.MOVIEID, USERID = mvm.USERID, SHOWTIME = mvm.SHOWTIME, SEAT = item });
                    }

                    foreach (var item in tickets.TicketsList)
                    {
                        dal.TicketsList.Add(item);
                        dal.SaveChanges();
                    }
                    TempData["Success"] = "Seat no booked,check your ticket";
                }
                else
                {
                    TempData["SeatNoMasg"] = "Please, change your seat number";
                }
                return View("BookYourTicket", mvm);

            }
            return View("MovieGallery");
        }

        private bool checkseat(string seatno,string movieId)
        {
            bool flag = true;
            TicketsDal dal = new TicketsDal();
            string seat = seatno;
            string[] seatreserve = seat.Split(',');
            var seatnolist = dal.TicketsList.Where(a => a.MOVIEID == movieId).ToList();
            foreach(var item in seatnolist)
            {
                string alreadybook = item.SEAT;
                foreach(var item1 in seatreserve)
                {
                    if(item1==alreadybook)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
                return true;
            else
                return false;
        }
       
    }
}