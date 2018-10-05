using System.Web.Mvc;
using System;
using System.Linq;
using oslomet_film.Model;
using oslomet_film.BLL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace oslomet_film.Controllers
{
    public class CartController : Controller
    {
        public ActionResult GetCart()
        {
            ViewBag.Total = GetTotal();
            Cart cart = GetSessionCart();
            return PartialView("CartPartial", cart.CartItem.ToList());
        }

        public ActionResult GetCartFull()
        {
            Cart cart = GetSessionCart();
            ViewBag.Total = GetTotal();
            return View(cart.CartItem.ToList());
        }

        //Removing item from CartItems List in Cart
        public ActionResult RemoveItem(int movieID)
        {
            Cart cart = GetSessionCart();
            cart.CartItem.RemoveAll(ci => ci.Movie.ID == movieID);
            return RedirectToAction("GetCartFull");
        }

        public ActionResult AddItem(int movieID)
        {
            Cart cart = GetSessionCart();
            MovieBLL movieBLL = new MovieBLL();
            Movie movie = movieBLL.GetMovie(movieID);
            //Tried running test if movie ID exists in List<CartItem> Not finished
            //var checkDuplicte = (cart.CartItem.FindAll(m => m.Movie.ID != movie.ID));
            //if(checkDuplicte == null)
            //{
                CartItem item = new CartItem()
            {
                Movie = movie,
                Price = movie.Price
            };
                cart.CartItem.Add(item);
                ViewBag.Total = GetTotal();
                return PartialView("CartPartial", cart.CartItem.ToList());
            //}
            ViewBag.AlreadyInCart = "Movie is already in Cart";
            return View("Index");
        }

        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.Total = GetTotal();
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

        // Trying to create the order and orderline based on the cart Session


        /* public ActionResult CreateOrderLine()
         {
             if (Session["cart"] == null)
             {
                 return Content("Handlekurven er tom");
             }
             Cart cart = GetSessionCart();
             //List<CartItem> cartItem = cart.CartItem;
             List<OrderLine> orderLines = new List<OrderLine>();

             OrderBLL orderBLL = new OrderBLL();

             //For å generere en tilfeldig ID på de forskjellige Ordrelinjene
             Random random = new Random();

             foreach (CartItem cartItem in cart.CartItem)
              {
                  OrderLine newOrderLine = new OrderLine()
                  {
                      //ID = random.Next(1000),
                      Price = cartItem.Price,
                      Movie = cartItem.Movie
                 };
                 orderLines.Add(newOrderLine);
             }

             orderBLL.SaveOrder(orderLines, (Customer)Session["customer"]);

             return View("../Order/OrderLinePartial", orderLines.ToList());
         } */

        public async Task<ActionResult> Review()
        {
            if(Session["customer"] == null)
            {
                return null;
            }

            Order order = new Order();
            OrderLine orderLine = new OrderLine();

            var ordre = new OrderBLL();
            ordre.Review((Cart)Session["cart"], (Customer)Session["customer"], order, orderLine);
            return View(order);
        }

        [HttpPost]
        public ActionResult CreateOrder([Bind(Include = "UserId")] Order order)
        {
            var ordre = new OrderBLL();
            ordre.CreateOrder(order, (Cart)Session["cart"]);
            Session.Remove("cart");

            return RedirectToAction("FetchOrder", new { id = order.OrderID });
        }

        public ActionResult FetchOrder(int? id, Customer customer)
        {
            var order = new OrderBLL();
            Order orderDetails = order.FetchOrder(id, (Customer)Session["customer"]);
            return View(orderDetails.OrderLines.ToList());
        }

    }
}