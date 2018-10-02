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

            CartItem item = new CartItem()
            {
                Movie = movie,
                Price = movie.Price
            };

            cart.CartItem.Add(item);
            ViewBag.Total = GetTotal();
            return PartialView("CartPartial", cart.CartItem.ToList());
        }


        public ActionResult CreateOrderLine()
        {
            if (Session["customer"] == null)
            {
                return Content("Ikke logget inn");
            }
            if (Session["cart"] == null)
            {
                return Content("Handlekurven er tom");
            }
            Cart cart = GetSessionCart();
            //List<CartItem> cartItem = cart.CartItem;
            List<OrderLine> orderLines = new List<OrderLine>();

            //For å generere en tilfeldig ID på de forskjellige Ordrelinjene
            Random random = new Random();

            foreach (CartItem cartItem in cart.CartItem)
             {
                 OrderLine newOrderLine = new OrderLine()
                 {
                     ID = random.Next(1000),
                     Price = cartItem.Price,
                     Movie = cartItem.Movie
                 };
                 orderLines.Add(newOrderLine);
             } 
            return View("../Order/OrderLinePartial", orderLines.ToList());
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