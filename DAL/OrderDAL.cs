using oslomet_film.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class OrderDAL
    {
        public bool CreateOrder(Cart cart)
        {

            using (var db = new DB())
            {
                List<OrderLine> orderLines = new List<OrderLine>();
                //Order order = new Order();
                Random random = new Random();

                foreach (CartItem cartItem in cart.CartItem)
                {
                    var orderLine = new OrderLine();
                    orderLine.ID = random.Next(1000);
                    orderLine.Movie = cartItem.Movie;
                    orderLine.Price = cartItem.Price;
                    orderLines.Add(orderLine);
                    db.OrderLine.Add(orderLine);
                }

                //order.OrdeLine = orderLines;
                //db.Order.Add(order);
                try
                {


                    db.SaveChanges();
                    return true;

                }


                catch
                {
                    return false;
                }
            }
        }

     /*   public List<OrderLine> GetOrderLines(Customer customer)
        {
            try
            {
                var db = new DB();
                var orderLineCheck = db.OrderLine.Where(o => o.Order.Customer.ID == customer.ID);
                if(orderLineCheck != null)
                {
                    List<OrderLine> ordre = db.OrderLine.ToList();
                    return ordre;
                } else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        } */

      /*  public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        } */
    }
}
