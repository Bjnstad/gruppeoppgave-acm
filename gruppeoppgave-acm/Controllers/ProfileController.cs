using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace gruppeoppgave_acm.Controllers
{
    public class ProfileController : Controller
    {
        private DB db = new DB();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       /**
        public ActionResult MovieDetails(int movieID)
        {
            Movie movie = db.Movie.Find(movieID);
            Customer customer = (Customer)Session["user"];

            if (movie == null) return View("Index");

            return PartialView("../Movie/MovieDetails", movie);
        } */

        

        public ActionResult EditUser()
        {
            Customer customer = (Customer)Session["user"];
            if (customer == null)
            {
                ViewBag.OrderUserNotLoggedIn = "Create a profile to visit the profile page ";
                return View("../Login/Login");
            }

            var userid = Session["id"];
            Customer user = db.Customer.Find(userid);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(Customer user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return View("../DisplayUsers/DisplayUsers");
            }
            return View(user);
        }



        // GET: Profile
        public ActionResult Index()
        {
            Customer customer = (Customer)Session["user"];

            if (customer == null)
            {
                ViewBag.OrderUserNotLoggedIn = "Create a profile to visit the profile page ";
                return View("../Login/Login");
            } // Right way to check user loggedin? Works fine :)
            List<OrderLine> orderLines = db.OrderLines.Where(orderline => orderline.Order.Customer.ID == customer.ID).ToList();
            List<Movie> movies = new List<Movie>();

            foreach (OrderLine orderline in orderLines)
            {   
                movies.Add(orderline.Movie);
            }
            return PartialView("../Profile/Index", movies.ToList());
        }
    }
}
 