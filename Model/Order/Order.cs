using System;
using System.Collections.Generic;
using oslomet_film.Model;


namespace oslomet_film.Model

{
    class Order
    {
        public int ID { get; set; }
        public virtual Cart CartInOrder { get; set; }  
        public virtual Customer Customer { get; set; }
        public virtual List<OrderLine> OrdeLine { get; set; }

    }
}
