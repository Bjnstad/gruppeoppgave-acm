﻿using System;
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
                return RedirectToAction("Index", "Home");
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
                if (loginSuccess)
                {
                    ViewBag.LoginSuccess = "Login successfull!";

                    Session["customer"] = loginModel;
                    Session["userName"] = loginModel.Username;
                    var customer = (Customer)Session["customer"];

                    return RedirectToAction("../Home/Index");
                }
            ViewBag.LoginFailed = "Login failed";
            return View(loginModel);
        }

        public ActionResult EditUser(int id)
        {
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
                return RedirectToAction("DisplayCustomers");
            }
            ViewBag.EditFailed = "Edit failed";
            return View(editModel);
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customerBLL = new CustomerBLL();
            Customer customer = customerBLL.fetchCustomer(id);
            return View(customer);
        }

        [HttpDelete]
        public ActionResult DeleteCustomer(int id, Customer deleteUser)
        {
            var customerBLL = new CustomerBLL();
            bool customerDeleted = customerBLL.deleteUser(id);
            if (customerDeleted)
            {
                return RedirectToAction("DisplayCustomers");
            }
            return View();
        }

        public ActionResult FetchCustomer(int id)
        {
            var customerBLL = new CustomerBLL();
            Customer customerDetails = customerBLL.fetchCustomer(id);
            return View(customerDetails);
        }

        public ActionResult Profile()
        {
            var OrderBLL = new OrderBLL();
            //  List<Order> displayAllOrders = OrderBLL.GetAll();
            //  return View(displayAllOrders);
            List<OrderLine> orderLines = OrderBLL.GetOrderLines();
            return View(orderLines);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }

    }
}