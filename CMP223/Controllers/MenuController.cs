using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data_Adapter_Object;

namespace CMP233.Controllers
{
    public class MenuController : Controller
    {
        // GET: MENU
        public ActionResult Index()
        {   
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult TypeFood()
        {
            var model = new MenuDAO().ListAll();
            return PartialView(model);
        }
    }
}