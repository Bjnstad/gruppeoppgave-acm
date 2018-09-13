using System.Collections.Generic;

namespace gruppeoppgave_acm.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}