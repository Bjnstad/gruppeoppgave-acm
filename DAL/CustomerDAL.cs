using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gruppeoppgave_acm.Models;

namespace gruppeoppgave_acm.DAL
{
    public class CustomerDAL
    {
        public List<Customer> getCustomers()
        {
            var db = new #();
            return db.Customer.ToList();
        }

        public
    }
}
