using Model.Data_Adapter_Object;
using Model.Entity_Framework;
using CMP223.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMP223.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encryptedMD5Password = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5Password;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Create", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Create successed");
                }
            }
            return View("Index");
        }
    }
}