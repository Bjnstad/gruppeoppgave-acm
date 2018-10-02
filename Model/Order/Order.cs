using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using oslomet_film.Model;


namespace oslomet_film.Model

{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderLine> OrdeLine { get; set; }

    }
}
