using System.Web.Mvc;
using System;
using System.Linq;
using oslomet_film.Model;
using oslomet_film.BLL;
using System.Collections.Generic;

namespace oslomet_film.Controllers
{
    public class CartController : Controller
    {
        public ActionResult GetCart()
        {
            Cart cart = GetSessionCart();
            return PartialView("CartPartial", cart.CartItem.ToList());
        }

        public ActionResult AddItem(int movieID)
        {
            Cart cart = GetSessionCart();
            MovieBLL movieBLL = new MovieBLL();
            Movie movie = movieBLL.GetMovie(movieID);

            CartItem item = new CartItem
            {
                Movie = movie,
                Price = movie.Price
            };

            cart.CartItem.Add(item);
            ViewBag.Total = GetTotal();
            return PartialView("CartPartial", cart.CartItem.ToList());
        }


        public ActionResult CreateOrder()
        {
            if (Session["customer"] == null)
            {
                return Content("Ikke logget inn");
            }

            Cart cart = GetSessionCart();

            OrderBLL orderBLL = new OrderBLL();
            orderBLL.CreateOrder(cart);
            return RedirectToAction("GetOrders", "Order");
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetSessionCart());
        }

        public Cart GetSessionCart()
        {
            Cart cart = (Cart)Session["cart"];

            if (cart != null) {
                return cart;
            }

            cart = new Cart
            {
                CartItem = new List<CartItem>()
            };
            Session["cart"] = cart;
            return cart;
        }


        private int GetTotal()
        {
            int total = 0;
            Cart cart = GetSessionCart();
            foreach(CartItem item in cart.CartItem) {
                total += item.Price;
            }
            return total;
        }
    }
}