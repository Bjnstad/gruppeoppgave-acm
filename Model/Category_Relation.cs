﻿namespace oslomet_film.Models
{
    public class Category_Relation
    {
        public int ID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Movie Movie { get; set; }
    }
}