using System.Collections.Generic;

namespace gruppeoppgave_acm.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Forname { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}