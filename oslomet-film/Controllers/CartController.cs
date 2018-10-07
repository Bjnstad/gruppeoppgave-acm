using System.Web.Mvc;
using System.Linq;
using oslomet_film.Model;
using oslomet_film.BLL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oslomet_film.Controllers
{
    public class CartController : Controller
    {
        public ActionResult AddMovie(int movieID)
        {
            MovieBLL movieBLL = new MovieBLL();
            OrderBLL orderBLL = new OrderBLL();

            Cart cart = GetSessionCart();
            Movie movie = movieBLL.GetMovie(movieID);

            bool ownMovie = false; // False is user not logged in
            // Check if user is logged in
            Customer customer = (Customer)Session["customer"];
            if (customer != null)
            {
                ownMovie = orderBLL.OwnsMovie(customer, movie);
            }

            if (!InCart(movie, cart) || ownMovie)
            {
                CartItem item = new CartItem()
                {
                    Movie = movie,
                    Price = movie.Price
                };
                cart.CartItem.Add(item);
            }
            
            ViewBag.Total = GetTotal();
            return PartialView("CartPartial", cart.CartItem.ToList());
        }
        public ActionResult CompleteOrder()
        {
            OrderBLL orderBLL = new OrderBLL();

            Customer customer = (Customer)Session["customer"];
            if(customer == null)
            {
                // User must be logged in
                return null;
            }

            orderBLL.CreateOrder(customer, GetSessionCart());
            Session["cart"] = null;
            return Content("Success");
        } 

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
            return View("index", GetSessionCart());
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

        
        private bool InCart(Movie movie, Cart cart)
        {
            foreach(CartItem item in cart.CartItem)
            {
                if (item.Movie.ID == movie.ID) return true;
            }
            return false;
        }
    }
}