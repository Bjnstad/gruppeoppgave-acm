using oslomet_film.Model;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class MovieDAL
    {
        public List<Movie> GetMovies()
        {
            var db = new DB();
            List<Movie> movies = db.Movie.ToList();
            return movies;
        }

        public Movie GetMovie(int movieID)
        {
            var db = new DB();
            return db.Movie.Find(movieID);
        } 

        public List<Category> GetCategories()
        {
            var db = new DB();
            List<Category> categories = db.Category.ToList();
            return categories;
        }

        public List<Movie> FilterMovies(int categoryId)
        {
            var db = new DB();
            Category category = db.Category.Find(categoryId);
            List<Movie> movies = new List<Movie>();
            foreach(Category_Relation relation in category.Category_Relation)
            {
                movies.Add(relation.Movie);
            }
            return movies.ToList();
        }
    }
}
