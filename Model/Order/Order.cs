using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using oslomet_film.Model;


namespace oslomet_film.Model

{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime DateCreated { get; set; }
        public Decimal TotalPrice { get; set; }
        public String CustomerName { get; set; }
        //public virtual Customer Customer { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
