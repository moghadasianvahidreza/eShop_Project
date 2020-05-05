using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    [System.Web.Mvc.Authorize]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Test1()
        {
            return View();
        }

        [System.Web.Mvc.Authorize(Roles = "Admin")]
        public ActionResult Test2()
        {
            return View();
        }
    }
}