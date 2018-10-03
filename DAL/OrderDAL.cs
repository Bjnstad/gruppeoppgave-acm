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
            

            foreach (CartItem cartItem in cart.CartItem)
            {
                OrderLine newOrderLine = new OrderLine()
                {
                    Price = cartItem.Price,
                    Movie = cartItem.Movie
                };
              //  db.OrderLine.Add(newOrderLine);
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

        public bool SaveOrder(List<OrderLine> orderLines, Customer customer)
        {
            using (var db = new DB())
            {
                DateTime now = DateTime.Now;
                var order = new Order();

                order.DateCreated = now;
                order.Customer = customer;
                order.OrderLine = orderLines;

                foreach (var ordrelinje in orderLines)
                {
                    db.OrderLine.Add(ordrelinje);
                }
                

                try
                {
                    db.Order.Add(order);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
        }

        public List<Order> GetAll()
        {
            using(var db = new DB())
            {
                List<Order> allOrders = db.Order.ToList();
                return allOrders;
            }
            
        }

        

       /* public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        } */
    }
}
