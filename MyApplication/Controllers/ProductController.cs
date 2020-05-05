using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
	public class ProductController : Infrastructure.BaseController
	{
		public ProductController() : base()
		{

		}
		// GET: Product
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult _ShowGroupsPartialView()
		{
			var products = DatabaseContext.ProductGroups.ToList();

			return PartialView(model: products);
		}
	}
}