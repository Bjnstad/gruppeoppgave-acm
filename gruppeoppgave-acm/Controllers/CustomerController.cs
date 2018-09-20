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


    }
}