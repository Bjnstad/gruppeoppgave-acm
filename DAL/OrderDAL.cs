using oslomet_film.Model;
using System.Collections.Generic;
using System.Linq;

namespace oslomet_film.DAL
{
    public class OrderDAL
    {
        public void CreateOrder(Cart cart, Customer customer)
        {
            var db = new DB();

            List<OrderLine> orderLines = new List<Model.OrderLine>();
            Order order = new Order
            {
                Customer = customer
            };


            db.Order.Add(order);
            foreach (CartItem cartItem in cart.CartItem)
            {
                db.OrderLine.Add(new OrderLine
                {
                    Order = order,
                    Movie = cartItem.Movie,
                    Price = cartItem.Price
                });
            }

            db.SaveChanges();
        }

        public bool OwnsMovie(Customer customer, Movie movie)
        {
            var db = new DB();
            OrderLine orderlines = db.OrderLine.Where(line => line.Order.Customer.ID.Equals(customer.ID) && line.Movie.ID.Equals(movie.ID)).First();
            return orderlines != null;
        }
    }
}
