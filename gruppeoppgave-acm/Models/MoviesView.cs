using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/**
 * Should be removed in future
 */
namespace gruppeoppgave_acm.Models
{
    public class MoviesView
    {
        public virtual List<Movie> Movies { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}