using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{
    public class LoginController : Controller
    { 
        [HttpGet]
        public ActionResult Login()
        {
            Customer loginModel = new Customer();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(Customer loginModel)
        {
            using(DB db = new DB())
            {
                if (db.Customer.Any(bruker => bruker.Username != loginModel.Username))
                {
                    ViewBag.LoginUserErr = "Login failed. Check username or password";
                    return View("Login");
                } if (db.Customer.Any(bruker => bruker.Password != loginModel.Password))
                {
                    ViewBag.LoginUserErr = "Login failed. Check username or password";
                    return View("Login");
                }
            }
            ViewBag.LoginSuccessAlert = "Login Successful!";
            return View("LoggedIn");
            
        }
    }
}