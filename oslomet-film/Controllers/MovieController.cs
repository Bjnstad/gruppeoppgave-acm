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

    }
}