using oslomet_film.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class OrderDAL
    {
        public void CreateOrder(Customer customer, Cart cart)
        {
            var db = new DB();

            DBCustomer dBCustomer = db.Customers.Find(customer.ID);
            Order order = new Order
            {
                DateCreated = DateTime.Now,
                Customer = dBCustomer
            };


            db.Order.Add(order);

            foreach (CartItem cartItem in cart.CartItem)
            {
                Movie movie = db.Movie.Find(cartItem.Movie.ID);
                OrderLine orderLine = new OrderLine
                {
                    Order = order,
                    Movie = movie,
                    Price = cartItem.Price
                };
                db.OrderLine.Add(orderLine);
            }
            db.SaveChanges();
        }

  

        public List<Order> GetAll()
        {
            var db = new DB();
            List<Order> allOrders = db.Order.ToList();
            return allOrders;
        }

        

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            if (customer == null || movie == null) return false;
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).FirstOrDefault();
            return orderlines != null;
        }
    }
}
