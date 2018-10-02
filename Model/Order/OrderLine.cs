using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oslomet_film.Model
{
    public class OrderLine
    {
        [Key]
        public int ID { get; set; }
        public int Price { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}
