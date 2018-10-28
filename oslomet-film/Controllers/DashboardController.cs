using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oslomet_film.BLL;
using oslomet_film.Model;

namespace oslomet_film.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if(Session["Admin"] == null)
            {
                return View("NotAllowed");
            }
            return View();
        }

        public ActionResult DisplayUsers()
        {
            var customerBLL = new CustomerBLL();
            List<Customer> displayAllCustomers = customerBLL.getAll();
            return PartialView(displayAllCustomers);
        }

        public ActionResult DisplayMovies()
        {
            return View();
        }

        public ActionResult DisplayOrders()
        {
            return View();
        }
    }
}