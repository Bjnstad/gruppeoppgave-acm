using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{

    [RequireHttps]
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

        // GET: Home
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