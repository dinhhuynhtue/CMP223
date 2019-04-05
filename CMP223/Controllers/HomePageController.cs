using Model.Data_Adapter_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP233.Controllers
{
    public class HomePageController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            ViewBag.HotDish = new HomeDAO().DishesList(6);
            return View();
        }

    }
}