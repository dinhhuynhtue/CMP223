using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class DishController : BaseController
    {
        // GET: Admin/Dish
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DishDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(short id)
        {
            var dish = new DishDAO().ViewDetail(id);
            SetViewBag(dish.Type_ID);
            return View(dish);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Dish dish)
        {
            if (ModelState.IsValid)
            {
                var dao = new DishDAO();
                short id = dao.Insert(dish);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Dish");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessed");
                }
            }
            SetViewBag();
            return RedirectToAction("Create", "Dish");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Dish dish)
        {
            if (ModelState.IsValid)
            {
                var dao = new DishDAO();
                var result = dao.Update(dish);
                if (result)
                {
                    SetAlert("Update successfully", "success");
                    return RedirectToAction("Index", "Dish");
                }
                else
                {
                    ModelState.AddModelError("", "Update unsuccessfully");
                }
            }
            SetViewBag(dish.Type_ID);
            return RedirectToAction("Index", "Dish");
        }
        public void SetViewBag(short? selectedID = null)
        {
            var dao = new DishTypeDAO();
            ViewBag.Type_ID = new SelectList(dao.ListAll(), "Type_ID", "Name", selectedID);
        }
        [HttpDelete]
        public ActionResult Delete(short id)
        {
            new DishDAO().Delete(id);
            return RedirectToAction("Index", "Dish");
        }
    }
}