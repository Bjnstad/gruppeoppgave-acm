using System.Collections.Generic;

namespace gruppeoppgave_acm.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Category_Relation> Category_Relation { get; set; }
    }
}