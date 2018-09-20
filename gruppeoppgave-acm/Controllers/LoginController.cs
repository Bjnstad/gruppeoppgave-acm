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
            using (DB db = new DB())
            {

                var userData = db.Customer.Where(bruker => bruker.Username == loginModel.Username && bruker.Password == loginModel.Password).FirstOrDefault();
                if(userData == null)
                {
                    ViewBag.LoginUserErr = "Login failed. Check username or password";
                    return View("Login");
                } else
                {
                    Session["id"] = userData.ID;
                    Session["userName"] = userData.Username;
                }

                ViewBag.LoginSuccessAlert = "Login Successful!";
                return View("LoggedIn");

                //Gammel Funker dårlig
                /*if (db.Customer.Any(bruker => bruker.Username == loginModel.Username) && db.Customer.Any(bruker => bruker.Password == loginModel.Password))
                {
                    ViewBag.LoginSuccessAlert = "Login Successful!";
                    return View("LoggedIn");
                }
                ViewBag.LoginUserErr = "Login failed. Check username or password"; 
                return View("Login"); */
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            //return View("../Home/Index");
            return RedirectToAction("Login");
        }
    }
}