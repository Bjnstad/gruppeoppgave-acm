using oslomet_film.BLL;
using System.Web.Mvc;

namespace oslomet_film.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var movieBLL = new MovieBLL();
            var moviemerge = movieBLL.GetAll();
            return View(moviemerge);
        }
    }
}