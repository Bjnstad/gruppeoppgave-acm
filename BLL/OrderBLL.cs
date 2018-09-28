using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oslomet_film.DAL;
using oslomet_film.Model;

namespace oslomet_film.BLL
{
    public class OrderBLL
    {
        public bool CreateOrder(Cart cart, Customer customer)
        {
            var ordre = new OrderDAL();
            ordre.CreateOrder(cart, customer);
            return true;
        }
    }
}
