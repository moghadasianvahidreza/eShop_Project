using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
	public class CompareController : Infrastructure.BaseController
	{
		// GET: Compare
		public ActionResult Index()
		{
			List<ViewModels.CompareItemViewModel> list = new List<ViewModels.CompareItemViewModel>();

			if (Session["Compare"] != null)
			{
				list = Session["Compare"] as List<ViewModels.CompareItemViewModel>;
			}

			List<Models.Feature> features = new List<Models.Feature>();
			List<Models.ProductFeature> productFeature = new List<Models.ProductFeature>();

			foreach (var item in list)
			{
				features.AddRange(DatabaseContext.ProductFeatures
							.Where(current => current.ProductId == item.ProductId)
						.Select(p => p.Feature)
						.ToList())
						;

				productFeature.AddRange(DatabaseContext.ProductFeatures
								.Where(current => current.ProductId == item.ProductId)
								.ToList())
								;
			}

			ViewBag.features = features.Distinct().ToList();
			ViewBag.productFeatures = productFeature;

			return View(list);
		}

		// ******************************
		// ******************************

		public ActionResult AddToCompare(int id)
		{
			List<ViewModels.CompareItemViewModel> list = new List<ViewModels.CompareItemViewModel>();

			if (Session["Compare"] != null)
			{
				list = Session["Compare"] as List<ViewModels.CompareItemViewModel>;
			}

			if (!list.Any(current => current.ProductId == id))
			{
				var product = DatabaseContext.Products.Where(current => current.ProductId == id).Select(p => new
				{
					p.ProductTitle,
					p.ImageName,
				}).FirstOrDefault();

				list.Add(new ViewModels.CompareItemViewModel()
				{
					ProductId = id,
					Title = product.ProductTitle,
					ImageName = product.ImageName,
				});
			}

			Session["Compare"] = list;

			return PartialView("ListCompare", list);
		}

		// ******************************
		// ******************************

		public ActionResult ListCompare()
		{
			List<ViewModels.CompareItemViewModel> list = new List<ViewModels.CompareItemViewModel>();

			if (Session["Compare"] != null)
			{
				list = Session["Compare"] as List<ViewModels.CompareItemViewModel>;
			}

			return PartialView(list);
		}

		// ******************************
		// ******************************

		public ActionResult DeleteListCompare(int id)
		{
			List<ViewModels.CompareItemViewModel> list = new List<ViewModels.CompareItemViewModel>();

			if (Session["Compare"] != null)
			{
				list = Session["Compare"] as List<ViewModels.CompareItemViewModel>;
				int index = list.FindIndex(current => current.ProductId == id);
				list.RemoveAt(index);
				Session["Compare"] = list;
			}

			return PartialView("ListCompare", list);
		}
	}
}