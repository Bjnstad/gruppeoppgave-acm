using System.Web.Mvc;
using oslomet_film.Model;
using oslomet_film.BLL;
using System.Collections.Generic;

namespace oslomet_film.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            MovieBLL movieBLL = new MovieBLL();
            MovieHelper movieHelper = new MovieHelper
            {
                selectList = movieBLL.GetCategories()
            };

            if(Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(movieHelper);
        }

        [HttpPost]
        public ActionResult Index(MovieHelper movieHelper)
        {
            var movieBLL = new MovieBLL();
            bool movieAdded = movieBLL.AddMovie(movieHelper);
            if (movieAdded)
            {
                ViewBag.RegistrationSuccess = "Movie added";
                return RedirectToAction("../Home/Index");  
            }
            ViewBag.RegistrationFailed = "Movie Failed";
            movieHelper.selectList = movieBLL.GetCategories();
            return View(movieHelper);
        }

        //List alle filmer
        public ActionResult AllMovies()
        {
            var movieBLL = new MovieBLL();
            var moviemerge = movieBLL.GetAll();
            return View(moviemerge);
        }

        //List alle brukere
        public ActionResult AllCustomers()
        {
            var customerBLL = new CustomerBLL();
            var allCustomers = customerBLL.getAll();
            return View(allCustomers);
        }

        // Rediger Bruker
        public ActionResult EditUser(int id)
        {
            var customerBLL = new CustomerBLL();
            Customer editModel = customerBLL.fetchCustomer(id);
            return PartialView(editModel);
        }

        [HttpPost]
        public ActionResult EditUser(int id, Customer editModel)
        {
            var customer = new CustomerController();
            var customerBLL = new CustomerBLL();
            bool editSuccess = customerBLL.editUser(id, editModel);
            if (editSuccess)
            {
                ViewBag.EditSuccessfull = "Edit Successfull";
                return RedirectToAction("AllCustomers");
            }
            ViewBag.EditFailed = "Edit failed";
            return PartialView(editModel);
        }

        // List Alle ordre
        public ActionResult AllOrders()
        {
            var orderBLL = new OrderBLL();
            var allOrders = orderBLL.GetAll();
            return View(allOrders);
        }
    }
}