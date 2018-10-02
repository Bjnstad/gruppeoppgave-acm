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
            //List<OrderLine> orderLines = new List<OrderLine>();
            var db = new DB();

            //For å generere en tilfeldig ID på de forskjellige Ordrelinjene
            Random random = new Random();
            int randomID = random.Next(1000);
            

            foreach (CartItem cartItem in cart.CartItem)
            {
                OrderLine newOrderLine = new OrderLine()
                {
                    ID = randomID,
                    Price = cartItem.Price,
                    Movie = cartItem.Movie
                };
                db.OrderLine.Add(newOrderLine);
            }
            try
            {
                db.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
            
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

       /* public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        } */
    }
}
