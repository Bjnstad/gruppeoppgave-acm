using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oslomet_film.Model
{
    class OrderLine
    {
        public int ID { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Order Order { get; set; }
    }
}
