using gruppeoppgave_acm.Models;
using System.Data.Entity.Validation;
using System.Linq;
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
                if (db.Customer.Any(bruker => bruker.ID == customerModel.ID))
                {
                    ViewBag.DuplicateID = "User already exists";
                    return View("Register", customerModel);
                }

                if (db.Customer.Any(bruker => bruker.Email == customerModel.Email))
                {
                    ViewBag.DuplicateEmail = "Email already in use";
                    return View("Register", customerModel);
                }

                db.Customer.Add(customerModel);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }
            ModelState.Clear();
            ViewBag.RegisterSuccess = "User successfully added.";
            return View("Register");
        }


    }
}