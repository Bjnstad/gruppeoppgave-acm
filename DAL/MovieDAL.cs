using oslomet_film.Model;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Movie> GetMyMovies(Customer customer)
        {
            var db = new DB();

            List<Movie> movies = new List<Movie>();
            List<OrderLine> orderLines = db.OrderLine.ToList();
            foreach(OrderLine line in orderLines)
            {
                movies.Add(line.Movie);
            }
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
            
            // Category not found
            if(category == null)
            {
                List<Movie> list = db.Movie.ToList();
                return list;
            }

            List<Movie> movies = new List<Movie>();
            foreach(Category_Relation relation in category.Category_Relation)
            {
                movies.Add(relation.Movie);
            }
            return movies.ToList();
        }


        public bool AddMovie(MovieHelper movieHelper)
        {
            var db = new DB();
            try
            {
                db.Movie.Add(movieHelper.movie);
                foreach(var category in movieHelper.selectedList)
                {
                    Category c = db.Category.Find(int.Parse(category));
                    Category_Relation cr = new Category_Relation
                    {
                        Movie = movieHelper.movie,
                        Category = c
                    };
                    db.Category_Relations.Add(cr);
                }
                db.SaveChanges();
                return true; 
            }
            catch
            {
                return false;
            }
        }

        public List<string> SelectedCategoriesIDs(int movieID)
        {
            var db = new DB();
            Movie movie = db.Movie.Find(movieID);
            List<string> categories = new List<string>();
            if (movie == null) return categories;
            foreach(var cr in db.Category_Relations.ToList())
            {
                if(cr.Movie.ID == movie.ID)
                {
                    categories.Add("" + cr.Category.ID);
                }
            }
            return categories;
        }

        public bool EditMovie(int movieID, MovieHelper movieHelper)
        {
            var db = new DB();

            //try
            //{
                Movie movie = movieHelper.movie;
                Movie dbmovie = db.Movie.Find(movieID);

                dbmovie.Price = movie.Price;
                dbmovie.Title = movie.Title;
                dbmovie.Thumbnail = movie.Thumbnail;

                foreach(var ca in db.Category.ToList())
                {
                    bool selected = false;
                    if(movieHelper.selectedList != null)
                    {
                        foreach (var category in movieHelper.selectedList)
                        {
                            Category c = db.Category.Find(int.Parse(category));
                            if (c.ID == ca.ID)
                            {
                                selected = true;
                                break;
                            }
                        }
                    }
                  

                    if(selected)
                    {
                        bool exist = false;
                        foreach(var cr in db.Category_Relations.ToList())
                        {
                            if(cr.Category.ID == ca.ID && cr.Movie.ID == movie.ID)
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            Category_Relation _cr = new Category_Relation
                            {
                                Movie = dbmovie,
                                Category = ca
                            };
                            db.Category_Relations.Add(_cr);
                        }
                    } else
                    {
                        bool exists = false;
                        Category_Relation addedCr = null;
                        foreach (var cr in db.Category_Relations.ToList())
                        {
                            if (cr.Category.ID == ca.ID && cr.Movie.ID == movie.ID)
                            {
                                exists = true;
                                addedCr = cr;
                                break;
                            }
                        }

                        if(exists)
                        {
                            Category_Relation rm = db.Category_Relations.Find(addedCr.ID);
                            db.Category_Relations.Remove(rm);
                        }
                    }
                }
 
                db.SaveChanges();
                return true;
            /*}
            catch
            {
                return false;
            }*/
        }
    }
}
