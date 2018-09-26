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
            MovieBLL movieBLL = new MovieBLL();
            Movie movie = movieBLL.GetMovie(movieID);
            CartItem item = new CartItem
            {
                Movie = movie,
                Price = movie.Price
            };
            Cart cart = GetSessionCart();
            cart.CartItem.Add(item);
            return PartialView("CartPartial", cart.CartItem.ToList());
        }

        // GET: Cart
        public ActionResult Index()
        {
            
            return View();
        }



        private Cart GetSessionCart()
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
    }
}