using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{
    public class CustomerController : Controller
    {
        private Customer customerModel = new Customer();



        public ActionResult Register(int id=0)
        {
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Register(Customer CustomerController)
        {

            using (DB db = new DB())
            {
                db.Customer.Add(customerModel);
                db.SaveChanges();

            }
            ModelState.Clear();
            return View("Register");
        }


    }
}