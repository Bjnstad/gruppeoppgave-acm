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
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            var movieBLL = new MovieBLL();
            MovieHelper mh = new MovieHelper()
            {
                selectList = movieBLL.GetCategories()
            };
            return View(mh);
        }
        // Legg til ny Film
        public ActionResult AddMovie()
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
        public ActionResult AddMovie(MovieHelper movieHelper)
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
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            var movieBLL = new MovieBLL();  
            var moviemerge = movieBLL.GetAll();
            return View(moviemerge.Movie);
        }

        //List alle brukere
        public ActionResult AllCustomers()
        {
            var customerBLL = new CustomerBLL();
            var allCustomers = customerBLL.getAll();
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(allCustomers);
        }

        // Rediger Film
        public ActionResult EditMovie(int id)
        {
            var movieBLL = new MovieBLL();
            Movie movie = movieBLL.GetMovie(id);
            if (movie == null) return RedirectToAction("AllMovies"); // Movie not found

            MovieHelper movieHelper = new MovieHelper
            {
                movie = movie,
                selectList = movieBLL.GetCategories(),
                selectedList = movieBLL.SelectedCategoriesIDs(id)
        };
            return View(movieHelper);
        }

        [HttpPost]
        public ActionResult EditMovie(int id, MovieHelper movieHelper)
        {
            var movieBLL = new MovieBLL();
            if (movieBLL.EditMovie(id, movieHelper))
            {
                ViewBag.EditSuccessfull = "Endret film";
                return RedirectToAction("AllMovies");
            }

            movieHelper.selectedList = movieBLL.SelectedCategoriesIDs(id);
            movieHelper.selectList = movieBLL.GetCategories();
            ViewBag.EditSuccessfull = "Endring feilet";
            return View(movieHelper);
        }

        // Rediger Bruker
        public ActionResult EditUser(int id)
        {
            var customerBLL = new CustomerBLL();
            Customer editModel = customerBLL.fetchCustomer(id);
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(editModel);
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

        // Legg til ny kunde
        public ActionResult Register()
        {
            Customer customerModel = new Customer();
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Register(Customer customerModel)
        {
            var customerBLL = new CustomerBLL();
            bool userAdded = customerBLL.addCustomer(customerModel);
            if (userAdded)
            {
                return RedirectToAction("AllCustomers");
            }
            return View(customerModel);
        }

        // List Alle ordre
        public ActionResult AllOrders()
        {
            var orderBLL = new OrderBLL();
            var allOrders = orderBLL.GetAll();
            if (Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View(allOrders);
        }
    }
}