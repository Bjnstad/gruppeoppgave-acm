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
        
        public void Review(Cart cart, Customer customer, Order order)
        {
            var ordre = new OrderDAL();
            ordre.Review(cart, customer, order);
        }

        public void CreateOrder(Order order, Cart cart)
        {
            var ordre = new OrderDAL();
            ordre.CreateOrder(order, cart);
        }

        public bool SaveOrder(List<OrderLine> orderLines, Customer customer)
        {
            var order = new OrderDAL();
            order.SaveOrder(orderLines, customer);
            return true;
        }

        public bool Details(int? id, Customer customer, Order order)
        {
            var ordre = new OrderDAL();
            ordre.Details(id, customer, order);
            return true;
        }


        public List<Order> GetAll()
        {
            var order = new OrderDAL();
            List<Order> allOrders = order.GetAll();
            return allOrders;
        }



        /* public bool OwnsMovie(Customer customer, Movie movie)
         {
             OrderDAL orderDAL = new OrderDAL();
             return orderDAL.OwnsMovie(customer, movie);
         } */
    }
}
