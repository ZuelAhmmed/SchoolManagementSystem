using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartupInstitute.Security;
using StartupInstitute.ViewModels;

namespace StartupInstitute.Controllers
{
    public class AccountController : Controller
    {
        private SecurityManager objManager = new SecurityManager();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel loginViewModel, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = objManager.SignIn(loginViewModel);
                if (cookie != null)
                {
                    Response.Cookies.Add(cookie);
                    if (returnUrl != String.Empty)
                    {
                        return Redirect(returnUrl);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.Remove("Password");
            return View();
        }

        //[HttpPost]
        [Authorize]
        public ActionResult SignOut()
        {
            objManager.SugnOut();
            return RedirectToAction("Index", "Home");
        }
    }
}