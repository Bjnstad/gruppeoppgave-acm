using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oslomet_film.Model
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Thumbnail { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public virtual List<Category_Relation> Category_Relation { get; set; }
    }
}
