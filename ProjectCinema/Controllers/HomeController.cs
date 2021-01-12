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

        public HomeController(MovieDal movieDal, UserDal userDal)
        {
            MovieDal _movieDal;
            UserDal _userDal;
            _movieDal = movieDal;
            _userDal = userDal;
        }
        public ActionResult Home()
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

        private bool checkseat(string seatno, string movieId)
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
        }


        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Item Name comes here",
                currency = "USD",
                price = "1",
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = "3", // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = "your generated invoice number", //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }


    }
}