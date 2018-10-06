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
        
        public void Review(Cart cart, Customer customer, Order order, OrderLine orderLine)
        {
            var ordre = new OrderDAL();
            //ordre.Review(cart, customer, order, orderLine);
        }

        public void CreateOrder(Customer customer, Cart cart)
        {
            var ordre = new OrderDAL();
            ordre.CreateOrder(customer, cart);
        }

        public bool SaveOrder(List<OrderLine> orderLines, Customer customer)
        {
            var order = new OrderDAL();
            ///order.SaveOrder(orderLines, customer);
            return true;
        }

        public Order FetchOrder(int? id, Customer customer)
        {
            var order = new OrderDAL();
            return order.FetchOrder(id, customer);
        }

        public List<Order> GetAll()
        {
            var order = new OrderDAL();
            List<Order> allOrders = order.GetAll();
            return allOrders;
        }

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            OrderDAL orderDAL = new OrderDAL();
            return orderDAL.OwnsMovie(customer, movie);
        } 
    }
}
