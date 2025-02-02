﻿using oslomet_film.Model;
using oslomet_film.DAL;
using System.Collections.Generic;

namespace oslomet_film.BLL
{
    public class MovieBLL
    {

        public List<Movie> FilterMovies(int categoryID)
        {
            var movieDAL = new MovieDAL();
            List<Movie> movies = movieDAL.FilterMovies(categoryID);
            return movies;
        } 

        public MovieMerge GetAll()
        {
            var movieDAL = new MovieDAL();
            MovieMerge movieMerge = new MovieMerge();
            movieMerge.Movie = movieDAL.GetMovies();
            movieMerge.Category = movieDAL.GetCategories();
            return movieMerge;
        }

        public List<Movie> ListMovies()
        {
            var movieDAL = new MovieDAL();
            List<Movie> allMovies = movieDAL.GetMovies();
            return allMovies;
        }
        
        public List<Category> GetCategories()
        {
            var movieDAL = new MovieDAL();
            List<Category> categories = movieDAL.GetCategories();
            return categories;
        }

        public Movie GetMovie(int movieID)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.GetMovie(movieID);
        }

        public List<Movie> GetMyMovies(Customer customer)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.GetMyMovies(customer);
        }

        public bool AddMovie(MovieHelper movieHelper)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.AddMovie(movieHelper);
        }

        public List<string> SelectedCategoriesIDs(int movieID)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.SelectedCategoriesIDs(movieID);
        }

        public bool EditMovie(int movieID, MovieHelper movieHelper)
        {
            var movieDAL = new MovieDAL();
            return movieDAL.EditMovie(movieID, movieHelper);
        }
    }
}