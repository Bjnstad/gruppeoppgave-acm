using System.Collections.Generic;

namespace gruppeoppgave_acm.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}