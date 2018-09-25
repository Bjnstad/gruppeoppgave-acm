using oslomet_film.Models;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class MovieDAL
    {
        public List<Movie> GetAll()
        {
            var db = new DB();
            List<Movie> movies = db.Movie.ToList();
            return movies;
        }
    }
}
