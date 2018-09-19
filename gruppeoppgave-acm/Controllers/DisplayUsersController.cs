using gruppeoppgave_acm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gruppeoppgave_acm.Controllers
{
    public class DisplayUsersController : Controller
    {
        // GET: DisplayUsers
        public ActionResult DisplayUsers()
        {
            var users = new DB();

            return View(users.Customer.ToList());
        }
    }
}