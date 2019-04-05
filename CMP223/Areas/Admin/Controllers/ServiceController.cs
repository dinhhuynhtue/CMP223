using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        // GET: Admin/Service
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ServiceDAO();
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
            var service = new ServiceDAO().ViewDetail(id);
            return View(service);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                var dao = new ServiceDAO();
                short id = dao.Insert(service);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Service");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessed");
                }
            }
            return RedirectToAction("Create", "Service");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                var dao = new ServiceDAO();
                var result = dao.Update(service);
                if (result)
                {
                    SetAlert("Update successfully", "success");
                    return RedirectToAction("Index", "Service");
                }
                else
                {
                    ModelState.AddModelError("", "Update unsuccessfully");
                }
            }
            return RedirectToAction("Index", "Service");
        }
        [HttpDelete]
        public ActionResult Delete(short id)
        {
            new ServiceDAO().Delete(id);
            return RedirectToAction("Index", "Service");
        }
    }
}