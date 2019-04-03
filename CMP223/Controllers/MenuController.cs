using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using Syncfusion.EJ2.Navigations;


namespace CMP233.Controllers
{
    public class MenuController : Controller
    {
        

        // GET: MENU
        public ActionResult Index()
        {
            var category = new MenuDAO().ListAll();
            ViewBag.Types = category;
            ViewBag.ListDishes = new MenuDAO().ListDish();
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