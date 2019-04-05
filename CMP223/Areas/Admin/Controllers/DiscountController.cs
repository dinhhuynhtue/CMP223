using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class DiscountController : BaseController
    {
        // GET: Admin/Discount
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DiscountDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var discount = new DiscountDAO().ViewDetail(id);
            return View(discount);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Discount discount)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiscountDAO();
                string id = dao.Insert(discount);
                if (!string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Create", "Discount");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessed");
                }
            }
            return RedirectToAction("Create", "Discount");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Discount discount)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiscountDAO();
                var result = dao.Update(discount);
                if (result)
                {
                    SetAlert("Update successfully", "success");
                    return RedirectToAction("Index", "Discount");
                }
                else
                {
                    ModelState.AddModelError("", "Update unsuccessfully");
                }
            }
            return RedirectToAction("Index", "Discount");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DiscountDAO().Delete(id);
            return RedirectToAction("Index", "Discount");
        }
    }
}