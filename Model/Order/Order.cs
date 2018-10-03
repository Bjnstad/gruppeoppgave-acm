using System;
using System.Collections.Generic;
using oslomet_film.Model;


namespace oslomet_film.Model

{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderLine> OrdeLine { get; set; }
    }
}
