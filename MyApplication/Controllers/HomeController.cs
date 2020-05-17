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
			DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
			var slider = DatabaseContext.Sliders.Where(current => current.IsActive && current.StartDate <= dt && current.EndDate >= dt);
			return PartialView(slider);
		}
	}
}