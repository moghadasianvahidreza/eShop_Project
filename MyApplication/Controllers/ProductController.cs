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

		// ******************************
		// ******************************

		[Route("Archive")]
		public ActionResult Archive(int pageId = 1, string productTitle = "", int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null)
		{
			ViewBag.productGroups = DatabaseContext.ProductGroups.ToList();

			ViewBag.productTitle = productTitle;
			ViewBag.pageId = pageId;
			ViewBag.minPrice = minPrice;
			ViewBag.maxPrice = maxPrice;
			ViewBag.selectedGroups = selectedGroups;

			List<Models.Product> list = new List<Models.Product>();

			if (selectedGroups != null && selectedGroups.Any())
			{
				foreach (int group in selectedGroups)
				{
					list.AddRange(DatabaseContext.ProductSelectedGroups.Where(current => current.GroupId == group).Select(s => s.Product).ToList());
				}

				list = list.Distinct().ToList();
			}
			else
			{
				list.AddRange(DatabaseContext.Products.ToList());
			}

			if (productTitle != null)
			{
				list = list.Where(current => current.ProductTitle.Contains(productTitle)).ToList();
			}
			if (minPrice > 0)
			{
				list = list.Where(current => current.Price >= minPrice).ToList();
			}
			if (maxPrice > 0)
			{
				list = list.Where(current => current.Price <= maxPrice).ToList();
			}

			return View(list.ToList());
		}
	}
}