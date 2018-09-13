using System.Collections.Generic;

namespace gruppeoppgave_acm.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; } 
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public virtual List<Category_Relation> Category_Relation { get; set; }
    }
}