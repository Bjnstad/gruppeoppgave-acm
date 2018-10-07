using System.Collections.Generic;
using System.Web.Mvc;
using oslomet_film.BLL;
using oslomet_film.Model;

namespace oslomet_film.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            MovieBLL movieBLL = new MovieBLL();

            Customer customer = (Customer)Session["customer"];
            if (customer == null) return null;

            List<Movie> movies = movieBLL.GetMyMovies(customer);
            return View(movies);
        }
    }
}