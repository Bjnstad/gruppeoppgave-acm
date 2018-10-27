using System.Web.Mvc;
using oslomet_film.Model;
using oslomet_film.BLL;

namespace oslomet_film.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if(Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Movie movie)
        {
            var movieBLL = new MovieBLL();
            bool movieAdded = movieBLL.AddMovie(movie);
            if (movieAdded)
            {
                ViewBag.RegistrationSuccess = "Movie added";
                return RedirectToAction("../Home/Index");  
            }
            ViewBag.RegistrationFailed = "Movie Failed";
            return View(movie);
        }
    }
}