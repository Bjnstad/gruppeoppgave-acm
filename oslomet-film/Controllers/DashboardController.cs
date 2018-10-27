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
            MovieBLL movieBLL = new MovieBLL();
            MovieHelper movieHelper = new MovieHelper
            {
                selectList = movieBLL.GetCategories()
            };

            if(Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(movieHelper);
        }

        [HttpPost]
        public ActionResult Index(MovieHelper movieHelper)
        {
            var movieBLL = new MovieBLL();
            bool movieAdded = movieBLL.AddMovie(movieHelper);
            if (movieAdded)
            {
                ViewBag.RegistrationSuccess = "Movie added";
                return RedirectToAction("../Home/Index");  
            }
            ViewBag.RegistrationFailed = "Movie Failed";
            movieHelper.selectList = movieBLL.GetCategories();
            return View(movieHelper);
        }
    }
}