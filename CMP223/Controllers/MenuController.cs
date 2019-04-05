using System.Web.Mvc;
using Model.Data_Adapter_Object;


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
        public PartialViewResult DishType()
        {
            var model = new MenuDAO().ListAll();
            return PartialView(model);
        }
    }
}