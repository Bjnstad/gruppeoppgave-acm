using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gruppeoppgave_acm.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Forname { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Required")]

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Required")]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required")]
        public virtual List<Order> Order { get; set; }
    }
}