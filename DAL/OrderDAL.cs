using oslomet_film.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class OrderDAL
    {
        public bool CreateOrderLine(Cart cart)
        {

            var db = new DB();

           // List<OrderLine> orderLines = new List<OrderLine>();

            foreach (CartItem cartItem in cart.CartItem)
            {
                var orderLine = new OrderLine()
                {
                    //ID = cartItem.ID,
                    Price = cartItem.Price,
                    Movie = cartItem.Movie
                };

                /*var order = new Order()
                {
                    ID = cartItem.ID,
                    Created = cart.DateCreated,
                    Customer = orde.Customer,
                    OrdeLine = orderLines
                }; */

                db.OrderLine.Add(orderLine);
                //Order.OrderLine.Add(orderLine);
                //db.Order.Add(order);
            }

            try
            {
                
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
                /**orderLine.ID = cartItem.ID;
                orderLine.Movie = cartItem.Movie;
                orderLine.Price = cartItem.Price;
                db.OrderLine.Add(orderLine); //Check the testing
                Console.Write(db.OrderLine.ToList() + "Dette er steg 1"); //Denne må fungere
                orderLines.Add(orderLine);
                Console.Write(orderLines.ToList() + "Dette er steg 2"); */
                /* order.OrdeLine = orderLines;
                db.Order.Add(order);
                Console.Write(order.ToString() + "Dette er steg 3");

                db.SaveChanges();
                return true; */
            
        }

        public List<Order> GetAll()
        {
            var db = new DB();
            // var orderLineCheck = db.OrderLine.Where(o => o.Order.Customer.ID == customer.ID);
            // if(orderLineCheck != null)
            List<Order> orders = db.Order.ToList();
            return orders;
        }

        public List<OrderLine> GetOrderLines()
        {
            var db = new DB();
            List<OrderLine> orderLines = db.OrderLine.ToList();
            return orderLines;
        }

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        }
    }
}
