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
        public ActionResult BuyMovie(int movieID)
        {
            Movie movie = db.Movie.Where(m => m.ID == movieID).First();
            Customer customer = (Customer)Session["user"];

            // Create error messages
            if (movie == null) return null;
            if (customer == null) return null; // Right way to check user loggedin?










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
            entry.Property(e => e.Order).IsModified = true;
            db.SaveChanges();

            return Content("sucess"); // SUCCESS
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

        //Modal view
        public ActionResult DisplayMovieInfo(int? id)
        {
            Movie movie = db.Movie.Find(id);
            return PartialView("../Movie/MovieModal", movie);
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