using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace oslomet_film.Model
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

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

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //public virtual List<Order> Order { get; set; }
    }
}
