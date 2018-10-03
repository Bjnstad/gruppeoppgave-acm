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
        public bool CreateOrderLine(Cart cart)
        {
            var ordre = new OrderDAL();
            ordre.CreateOrderLine(cart);
            return true;
        }

        public bool SaveOrder(List<OrderLine> orderLines, Customer customer)
        {
            var orderDAL = new OrderDAL();
            orderDAL.SaveOrder(orderLines, customer);
            return true;
        }

        public List<Order> GetAll()
        {
            var orderDAL = new OrderDAL();
            List<Order> allOrders = orderDAL.GetAll();
            return allOrders;
        }



        /* public bool OwnsMovie(Customer customer, Movie movie)
         {
             OrderDAL orderDAL = new OrderDAL();
             return orderDAL.OwnsMovie(customer, movie);
         } */
    }
}
