using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using ProjectCinema.Dal;
using System.Data.Entity;
using System.IO;
using PayPal.Api;

namespace ProjectCinema.Controllers
{
    public class HomeController : Controller
    {
        /*private MovieDal _movieDal = new MovieDal();
        private UserDal _userDal = new UserDal();
        public HomeController(MovieDal movieDal, UserDal userDal)
        {
            _movieDal = movieDal;
            _userDal = userDal;
        }*/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult BookingSeat()
        {
            return View();
        }

        public ActionResult GetImage(string id)
        {
            var dir = Server.MapPath("/Content/Images");
            var path = Path.Combine(dir, id + ".jpg");
            return base.File(path, "image/jpeg");
        }

        public ActionResult ImagesView()
        {

            ImagesDal dal = new ImagesDal();
            return View(dal.Images.ToList());
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

                return View("MovieGallery");
        }

        public ActionResult SeatGallery(MovieViewModel model)
        {
            SeatDal dal = new SeatDal();
            SeatViewModel mvm = new SeatViewModel();
            List<Seat> seats = dal.Seats.ToList();
            mvm.Seat= new Seat();
            mvm.Seats = seats;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult SeatGallery()
        {
            SeatDal dal = new SeatDal();
            if (ModelState.IsValid)
            {
                var data = dal.Seats.ToList();
                return View();
            }
            else

                return View("SeatGallery");
        }

        public ActionResult BookTicket(string id)
        {
            /*TicketsDal dal = new TicketsDal();
            MovieDal movieDal = new MovieDal();
            TicketsViewModel mvm = new TicketsViewModel();
            var item = movieDal.MOVIES.Where(a => a.ID == id).FirstOrDefault(); ;
            List<Tickets> tickets = dal.TicketsList.ToList();
            mvm.Tickets = new Tickets();
            mvm.TicketsList = tickets;
            return View(mvm);*/
            Tickets mvm = new Tickets();
            MovieDal dal = new MovieDal();
            var item = dal.MOVIES.Where(a => a.ID == id).FirstOrDefault();
            mvm.MOVIENAME = item.name;
            mvm.SHOWTIME = item.showtime;
            mvm.COST = item.price; 
            return View(mvm);
        }

        [HttpPost]
        public ActionResult BookTicket(Tickets obj)
        {
            /*if (ModelState.IsValid)
            {
                UserDal userDal = new UserDal();
                TicketsDal dal = new TicketsDal();
                TicketsViewModel tickets = new TicketsViewModel();
                //List<Tickets> tickets = new List<Tickets>();
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
                        tickets.TicketsList.Add(new Tickets { COST =mvm.COST, MOVIEID = mvm.MOVIEID, USERID = mvm.USERID, SHOWTIME = mvm.SHOWTIME, SEAT = item });
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
            return View("BookYourTicket");

            if (ModelState.IsValid)
            {
                MovieDal movieDal = new MovieDal();
                TicketsDal dal = new TicketsDal();
                var item = movieDal.MOVIES.Where(a => a.ID == mvm.MOVIEID).FirstOrDefault(); ;
                mvm.USERID = "1";
                mvm.MOVIENAME = item.name;
                mvm.SHOWTIME = item.showtime;
                mvm.COST = item.price;


                dal.TicketsList.Add(mvm);
                dal.SaveChanges();
                return View("BookYourTicket", mvm);
            }
            return View("MovieGallery", mvm);*/
            if (ModelState.IsValid)
            {
                TicketsDal dal = new TicketsDal();
                //MovieDal movieDal = new MovieDal();
                SeatDal seatDal = new SeatDal();
                if (seatDal.Seats.Where(s => s.Number.Equals(obj.SEAT)).Count()>0)
                {
                    dal.TicketsList.Add(obj);
                    dal.SaveChanges();
                    return View("MovieGallery");

                }
                else
                {
                    return RedirectToAction("BookTicket");
                }

            }
            return View("MovieGallery");
        }

        /*private bool checkseat(string seatno, string movieId)
        {
            bool flag = true;
            TicketsDal dal = new TicketsDal();
            string seat = seatno;
            string[] seatreserve = seat.Split(',');
            var seatnolist = dal.TicketsList.Where(a => a.MOVIEID == movieId).ToList();
            foreach (var item in seatnolist)
            {
                string alreadybook = item.SEAT;
                foreach (var item1 in seatreserve)
                {
                    if (item1 == alreadybook)
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
        }*/


        /*[HttpPost]
        public ActionResult checkseat(DateTime showtime,Tickets BookYourTicket)
        {
            MovieDal movieDal = new MovieDal();
            string seatno = string.Empty;
            var movielist = movieDal.Where(a =>a. == showtime).ToList();
            return View();
        }*/

       


    }
}