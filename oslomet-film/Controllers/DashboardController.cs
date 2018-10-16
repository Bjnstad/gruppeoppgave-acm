using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}