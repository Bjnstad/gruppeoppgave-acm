using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: Profile
        public ActionResult Index()
        {
            Customer customer = (Customer)Session["user"];
            List<OrderLine> orderLines = db.OrderLines.Where(orderline => orderline.Order.Customer.ID == customer.ID).ToList();
            List<Movie> movies = new List<Movie>();

            foreach (OrderLine orderline in orderLines)
            {   
                movies.Add(orderline.Movie);
            }
            return PartialView("../Movie/MoviePartial", movies.ToList());
        }
    }
}