using oslomet_film.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class OrderDAL
    {
        private DB db = new DB();

        public decimal CreateOrderLines(Cart cart, int orderID)
        {
            decimal orderTotal = 0;
            foreach (CartItem cartItem in cart.CartItem)
            {
                OrderLine orderLine = new OrderLine
                {
                    Movie = cartItem.Movie,
                    MovieID = cartItem.Movie.ID,
                    MovieTitle = cartItem.Movie.Title,
                    OrderID = orderID,
                    Price = cartItem.Price,
                };

                db.OrderLine.Add(orderLine);
                orderTotal += cartItem.Price;
            }
            db.SaveChanges();
            //Create method in controller to empty cart
            return orderTotal;
        }


        public void Review(Cart cart, Customer customer, Order order, OrderLine orderLine)
        {
            //List<OrderLine> orderLines = new List<OrderLine>();

            order.UserID = customer.ID;
            order.CustomerName = customer.Name + " " + customer.Surname;
            order.OrderLines = new List<OrderLine>();
            try
            {
                foreach (CartItem cartItem in cart.CartItem)
                {
                    orderLine = new OrderLine
                    {
                        Movie = cartItem.Movie,
                        MovieID = cartItem.Movie.ID,
                        MovieTitle = cartItem.Movie.Title,
                        Price = cartItem.Price,
                        OrderID = order.OrderID,
                        Order = order
                    };
                    order.OrderLines.Add(orderLine);
                    order.TotalPrice += cartItem.Price;
                    db.OrderLine.Add(orderLine);
                }
                db.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public void CreateOrder(Order order, Cart cart)
        {
            order.DateCreated = DateTime.Now;
            db.Order.Add(order);
            db.SaveChanges();

            order.TotalPrice = CreateOrderLines(cart, order.OrderID);
            db.SaveChanges();
        }

        public Order FetchOrder(int? id, Customer customer)
        {
            var order = db.Order.Where(o => o.OrderID == id && o.UserID == customer.ID).FirstOrDefault();

            if (order == null)
            {
                return null;
            }
            else
            {
                return order;
            }
        }


        

        public bool SaveOrder(List<OrderLine> orderLines, Customer customer)
        {
            DateTime now = DateTime.Now;
            var order = new Order();

            order.DateCreated = now;
            //order.Customer = customer;
            order.OrderLines = orderLines;

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

        public List<Order> GetAll()
        {
            List<Order> allOrders = db.Order.ToList();
            return allOrders;
        }

        

       /* public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        } */
    }
}
