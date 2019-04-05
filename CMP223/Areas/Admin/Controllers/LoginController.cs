using System.Web.Mvc;
using Model.Data_Adapter_Object;
using CMP223.Common;
using CMP223.Areas.Admin.Models;

namespace CMP223.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUserID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.User_ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "User");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Account is not exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account has been shutdown");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password isn't correct");
                }
                else
                {
                    ModelState.AddModelError("", "Login unsuccessful");
                }

            }
            return View("Login");
        }
    }
}