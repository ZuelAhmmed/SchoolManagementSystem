using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using StartupInstitute.Manager;
using StartupInstitute.Models.DbModels;
using StartupInstitute.Security;

namespace StartupInstitute.Controllers
{
    public class HomeController : Controller
    {
        private InstituteDbContext db = new InstituteDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}