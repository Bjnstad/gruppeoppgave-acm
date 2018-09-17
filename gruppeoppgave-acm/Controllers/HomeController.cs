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