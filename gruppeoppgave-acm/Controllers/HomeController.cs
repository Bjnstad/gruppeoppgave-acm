using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{

    public class HomeController : Controller
    {
        private DB db = new DB();

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /**
         *  Setup for multiple movie purchased at once
         *  Dirty code - NEED REWRITE
         */


        public ActionResult MovieDetails(int movieID)
        {
            Movie movie = db.Movie.Find(movieID);
            Customer customer = (Customer)Session["user"];

            if (movie == null) return View("Index");

            return View("../Movie/MovieDetails", movie);
        }
        
        public ActionResult BuyMovie(int movieID)
        {
            //Movie movie = db.Movie.Where(m => m.ID == movieID).First();
            Movie movie = db.Movie.Find(movieID);
            Customer customer = (Customer)Session["user"];

            // Create error messages
            if (movie == null) {

                return View("Index");
            }
            if (customer == null)
            {
                ViewBag.OrderUserNotLoggedIn = "Need to be logged in to buy movies :) ";
                return View("../Login/Login");
            } // Right way to check user loggedin? Works fine :)










            Order order = new Order
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                Customer = customer
            };
            
            OrderLine orderLine = new OrderLine
            {
                Movie = movie,
                Order = order
            };
            if (order.OrderLines == null) order.OrderLines = new List<OrderLine>();
            order.OrderLines.Add(orderLine);

            db.OrderLines.Add(orderLine);

            customer.Order.Add(order);


            db.Customer.Attach(customer);
            var entry = db.Entry(customer);
           // entry.Property(e => e.Order).IsModified = true;
            db.SaveChanges();
            ViewBag.OrderSuccessfullyAdded = "Order Successfull! ";
            return View("../Profile/Index");
            

            //return Content("sucess"); // SUCCESS
        }

        public ActionResult GetMovie(int movieID)
        {
            Movie movie = db.Movie.Find(movieID);
            if (movie == null) return Content("Movie not found");
            return PartialView("../Movie/MovieExtendPartial", movie);
        }

        public ActionResult FilterMovie(string category)
        {
            List<Category> categories = db.Categories.ToList();
            List<Movie> movies = null;

            foreach (Category c in categories)
            {
                if (c.Name.Equals(category))
                {
                    movies = new List<Movie>();
                    foreach (Category_Relation cr in c.Category_Relation)
                    {
                        movies.Add(cr.Movie);
                    }
                }
            }
            return PartialView("../Movie/MoviePartial", movies);
        }

        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            List<Movie> movies = db.Movie.ToList();
            MoviesView mv = new MoviesView
            {
                Movies = movies,
                Categories = categories
            };
            return View(mv);
        }

        
    }
}