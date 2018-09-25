using oslomet_film.Models;
using oslomet_film.DAL;
using System.Collections.Generic;

namespace oslomet_film.BLL
{
    public class MovieBLL
    {
        public List<Movie> GetAll()
        {

            var movieDAL = new MovieDAL();
            List<Movie> movies = movieDAL.GetAll();
            return movies;
        }
    }
}
