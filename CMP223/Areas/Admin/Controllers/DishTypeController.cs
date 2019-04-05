using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class DishTypeController : BaseController
    {
        // GET: Admin/DishType
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DishTypeDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(short id)
        {
            var dishType = new DishTypeDAO().ViewDetail(id);
            return View(dishType);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DishType dishType)
        {
            if (ModelState.IsValid)
            {
                var dao = new DishTypeDAO();
                short id = dao.Insert(dishType);
                if (id > 0)
                {
                    return RedirectToAction("Create", "DishType");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessed");
                }
            }
            return RedirectToAction("Create", "DishType");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DishType dishType)
        {
            if (ModelState.IsValid)
            {
                var dao = new DishTypeDAO();
                var result = dao.Update(dishType);
                if (result)
                {
                    SetAlert("Update successfully", "success");
                    return RedirectToAction("Index", "DishType");
                }
                else
                {
                    ModelState.AddModelError("", "Update unsuccessfully");
                }
            }
            return RedirectToAction("Index", "DishType");
        }
        [HttpDelete]
        public ActionResult Delete(short id)
        {
            new DishTypeDAO().Delete(id);
            return RedirectToAction("Index", "DishType");
        }
    }
}