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

		// ******************************
		// ******************************

		public ActionResult _ShowGroupsPartialView()
		{
			var products = DatabaseContext.ProductGroups.ToList();

			return PartialView(model: products);
		}

		// ******************************
		// ******************************

		public ActionResult _LastProduct()
		{
			var lastProducts = DatabaseContext.Products.OrderByDescending(current => current.CreateDate).Take(12);

			return PartialView(lastProducts);
		}

		// ******************************
		// ******************************

		[Route("ShowProduct/{id}")]
		public ActionResult ShowProduct(int id)
		{
			var product = DatabaseContext.Products.Find(id);

			ViewBag.ProductFeature = product.ProductFeatures
				.DistinctBy(current => current.FeatureId)
				.Select(current => new ViewModels.ProductFeaturesViewModel()
				{
					FeatureTitle = current.Feature.Title,
					Values = product.ProductFeatures
						.Where(value => value.FeatureId == current.FeatureId)
						.DistinctBy(value => value.Value)
						.Select(value => value.Value)
						.ToList(),
				})
				.ToList()
				;

			if (product == null)
			{
				return HttpNotFound();
			}

			return View(product);
		}

		// ******************************
		// ******************************

		public ActionResult _ShowComment(int id)
		{
			return PartialView(DatabaseContext.ProductComments.Where(current => current.ProductId == id).ToList());
		}

		// ******************************
		// ******************************

		[HttpGet]
		public ActionResult _CreateComment(int id)
		{
			return PartialView(new Models.ProductComment()
			{
				ProductId = id,
			});
		}

		// ******************************
		// ******************************

		[HttpPost]
		public ActionResult _CreateComment(Models.ProductComment productComment)
		{
			if (ModelState.IsValid)
			{
				productComment.CreateDate = System.DateTime.Now;
				DatabaseContext.ProductComments.Add(productComment);
				DatabaseContext.SaveChanges();

				return PartialView("_ShowComment", DatabaseContext.ProductComments.Where(current => current.ProductId == productComment.ProductId).ToList());
			}

			return PartialView(productComment);
		}
	}
}