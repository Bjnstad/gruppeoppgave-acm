using gruppeoppgave_acm.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{
    public class CustomerController : Controller
    {

        [HttpGet]
        public ActionResult Register(int id=0)
        {
            Customer customerModel = new Customer();
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Register(Customer customerModel)
        {
            using (DB db = new DB())
            {
                if (db.Customer.Any(bruker => bruker.Username == customerModel.Username))
                {
                    ViewBag.DuplicateUserName = "Username already exists";
                    return View("Register", customerModel);
                }

                if (db.Customer.Any(bruker => bruker.Email == customerModel.Email))
                {
                    ViewBag.DuplicateEmail = "Email already exists";
                    return View("Register", customerModel);
                }

                db.Customer.Add(customerModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.RegisterSuccess = "User successfully added.";
            return View("../Login/Login");
        }

        public ActionResult Login()
        {
            Customer loginModel = new Customer();
            return View(loginModel);
        }

        /*
         * Needs rewrite
         */

        [HttpPost]
        public ActionResult Login(Customer loginModel)
        {
            using (DB db = new DB())
            {

                var userData = db.Customer.Where(bruker => bruker.Username == loginModel.Username && bruker.Password == loginModel.Password).FirstOrDefault();
                if (userData == null)
                {
                    ViewBag.LoginUserErr = "Login failed. Check username or password";
                    return View("Login");
                }
                else
                {
                    Session["user"] = userData;


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