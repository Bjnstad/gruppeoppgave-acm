using oslomet_film.Model;
using System.Collections.Generic;

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
     
    }
}
