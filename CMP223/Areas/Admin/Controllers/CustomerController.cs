using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CustomerDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();
                long id = dao.Insert(customer);
                if (id > 0)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Create unsuccessfully");
                }
            }
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var customer = new CustomerDAO().ViewDetail(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();
                var result = dao.Update(customer);
                if (result)
                {
                    //SetAlert("Update successfully", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Update unsuccessfully");
                }
            }
            return RedirectToAction("Index", "Customer");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new CustomerDAO().Delete(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}