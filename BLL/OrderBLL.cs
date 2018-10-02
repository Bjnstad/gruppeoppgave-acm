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

        public List<Order> GetAll()
        {
            var OrderDAL = new OrderDAL();
            List<Order> orders = OrderDAL.GetAll();
            return orders;
        }

        public List<OrderLine> GetOrderLines()
        {
            var OrderDal = new OrderDAL();
            List<OrderLine> orderLines = OrderDal.GetOrderLines();
            return orderLines;
        }

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            OrderDAL orderDAL = new OrderDAL();
            return orderDAL.OwnsMovie(customer, movie);
        }
    }
}
