using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class HomeController : Infrastructure.BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _SliderPartialView()
		{
			return PartialView();
		}
    }
}