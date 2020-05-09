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

		public ActionResult _LastProduct()
		{
			var lastProducts = DatabaseContext.Products.OrderByDescending(current => current.CreateDate).Take(12);

			return PartialView(lastProducts);
		}

		[Route("ShowProduct/{id}")]
		public ActionResult ShowProduct(int id)
		{
			var product = DatabaseContext.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			return View(product);
		}
	}
}