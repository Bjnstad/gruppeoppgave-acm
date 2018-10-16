using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oslomet_film.BLL;
using oslomet_film.Model;

namespace oslomet_film.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult DisplayCustomers()
        {
            var customerBLL = new CustomerBLL();
            List<Customer> displayAllCustomers = customerBLL.getAll();
            return View(displayAllCustomers);
        }

        public ActionResult Register()
        {
            Customer customerModel = new Customer();
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Register(Customer customerModel)
        {
            var customerBLL = new CustomerBLL();
            bool userAdded = customerBLL.addCustomer(customerModel);
            if (userAdded)
            {
                ViewBag.RegistrationSuccess = "Registration successfull!";
                bool loginSuccess = customerBLL.login(customerModel);
                Customer customerSession = customerBLL.fetchCustomerByUsername(customerModel.Username);

                if (loginSuccess)
                {
                    ViewBag.LoginSuccess = "Login successfull!";
                    Session["customerID"] = customerSession.ID;
                    Sessions();
                    return RedirectToAction("../Home/Index");
                }
            }
            ViewBag.RegistrationFailed = "Registration Failed";
            return View(customerModel);
        }

        public ActionResult Login()
        {
            Customer loginModel = new Customer();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(Customer loginModel)
        {
            var customerBLL = new CustomerBLL();
            bool loginSuccess = customerBLL.login(loginModel);
            Customer customerSession = customerBLL.fetchCustomerByUsername(loginModel.Username);

            if (loginSuccess)
                {
                Session["customerID"] = customerSession.ID;
                ViewBag.LoginSuccess = "Login successfull!";
                Sessions();

                if (customerSession.Admin == true)
                {
                    Session["Admin"] = customerSession; 
                    return RedirectToAction("Index", "Dashboard");
                } else
                    return RedirectToAction("../Home/Index");
                }
            ViewBag.LoginFailed = "Login failed";
            return View(loginModel);
        }

        public ActionResult EditUser()
        {
            int id = (int)Session["customerID"];
            var customerBLL = new CustomerBLL();
            Customer editModel = customerBLL.fetchCustomer(id);
            return View(editModel);
        }

        [HttpPost]
        public ActionResult EditUser(int id, Customer editModel)
        {
            var customerBLL = new CustomerBLL();
            bool editSuccess = customerBLL.editUser(id, editModel);
            if (editSuccess)
            {
                ViewBag.EditSuccessfull = "Edit Successfull";
                Sessions();
                return View(editModel);
            }
            ViewBag.EditFailed = "Edit failed";
            return View(editModel);
        }

        public void Sessions()
        {
            int id = (int)Session["customerID"];
            var customerBLL = new CustomerBLL();
            Customer customerDetails = customerBLL.fetchCustomer(id);

            Session["customer"] = customerDetails;
            Session["userName"] = customerDetails.Username;
            var customer = (Customer)Session["customer"];
            string userName = (string)Session["userName"];
            int customerID = (int)Session["customerID"];
        }

        public ActionResult FetchCustomer(int id)
        {
            var customerBLL = new CustomerBLL();
            Customer customerDetails = customerBLL.fetchCustomer(id);
            return View(customerDetails);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }
    }
}