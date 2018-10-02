using System.Collections.Generic;
using oslomet_film.Model;
using System;

namespace oslomet_film.Model
{
    public class Cart
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<CartItem> CartItem { get; set; }
    }
}
