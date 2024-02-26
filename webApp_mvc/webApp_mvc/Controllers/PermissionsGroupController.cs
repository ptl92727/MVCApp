using TMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApp_mvc.Controllers
{
    public class PermissionsGroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Permissions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateGroup()
        {
            return View();
        }
     }     
}
