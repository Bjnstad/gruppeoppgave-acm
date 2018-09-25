using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oslomet_film.Models
{
    class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Forname { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Surname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Required")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public virtual List<Order> Order { get; set; }
    }
}
}
