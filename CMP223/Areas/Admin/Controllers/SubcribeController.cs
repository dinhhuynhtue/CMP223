using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class SubcribeController : BaseController
    {
        // GET: Admin/Subcribe
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SubcribeDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Subcribe Subcribe)
        {
            if (ModelState.IsValid)
            {
                var dao = new SubcribeDAO();
                string id = dao.Insert(Subcribe);
                if (!string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Create", "Subcribe");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessed");
                }
            }
            return RedirectToAction("Create", "Subcribe");
        }
        [HttpDelete]
        public ActionResult Delete(string email)
        {
            new SubcribeDAO().Delete(email);
            return RedirectToAction("Index", "Subcribe");
        }
    }
}