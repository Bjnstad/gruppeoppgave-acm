using System.Web.Mvc;
using oslomet_film.Model;
using oslomet_film.BLL;
using System.Collections.Generic;

namespace oslomet_film.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult FilterMovies(int categoryID)
        {
            var movieBLL = new MovieBLL();
            List<Movie> movies = movieBLL.FilterMovies(categoryID);
            return PartialView("MovieList", movies);
        }

        public Movie GetMovie(int movieID)
        {
            var movieBLL = new MovieBLL();
            return movieBLL.GetMovie(movieID);
        }

        // Dette viewet må gjøres om til enten en collapse eller en popup!!!
        public ActionResult Details(int movieID)
        {
            var movieBLL = new MovieBLL();
            Movie movie = movieBLL.GetMovie(movieID);
            //Gjør om til partial
            return PartialView(movie);
        }
    }
}