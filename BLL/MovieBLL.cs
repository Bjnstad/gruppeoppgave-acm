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
            movieMerge.movies = movieDAL.GetMovies();
            movieMerge.categories = movieDAL.GetCategories();
            return movieMerge;
        }
        
        public List<Category> GetCategories()
        {
            var movieDAL = new MovieDAL();
            List<Category> categories = movieDAL.GetCategories();
            return categories;
        }
    }
}
