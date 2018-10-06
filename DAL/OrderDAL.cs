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

            List<OrderLine> orderLines = new List<OrderLine>();
            Order order = new Order
            {
                DateCreated = DateTime.Now,
                Customer = customer
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

        public Order FetchOrder(int? id, Customer customer)
        {
            /*
            var order = db.Order.Where(o => o.OrderID == id && o.UserID == customer.ID).FirstOrDefault();

            if (order == null)
            {
                return null;
            }
            else
            {
                return order;
            }*/
            return null;
        }


        

        public List<Order> GetAll()
        {
            var db = new DB();
            List<Order> allOrders = db.Order.ToList();
            return allOrders;
        }

        

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        }
    }
}
