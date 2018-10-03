using oslomet_film.Model;
using oslomet_film.Controllers;
using oslomet_film.BLL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oslomet_film.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult GetOrders()
        {
            var OrderBLL = new OrderBLL();
            List<Order> alleOrdre = OrderBLL.GetAll();
            return View(alleOrdre);
        }
    }
}
