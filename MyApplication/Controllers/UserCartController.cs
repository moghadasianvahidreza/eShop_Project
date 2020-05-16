using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
	public class UserCartController : Infrastructure.BaseController
	{
		// GET: UserCart
		public ActionResult _ShowCart()
		{
			List<ViewModels.ShopCartItemViewModel> list = new List<ViewModels.ShopCartItemViewModel>();

			if (Session["ShopCart"] != null)
			{
				List<ViewModels.ShopCartViewModel> listShop = (List<ViewModels.ShopCartViewModel>)Session["ShopCart"];

				foreach (var item in listShop)
				{
					var product = DatabaseContext.Products.Where(current => current.ProductId == item.ProductId).Select(p => new
					{
						p.ImageName,
						p.ProductTitle,
					}).FirstOrDefault();

					list.Add(new ViewModels.ShopCartItemViewModel()
					{
						ProductId = item.ProductId,
						ImageName = product.ImageName,
						ProductTitle = product.ProductTitle,
						Count = item.Count,
					});
				}
			}

			return PartialView(list);
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult _ListOrder()
		{
			List<ViewModels.ShowOrderViewModel> list = new List<ViewModels.ShowOrderViewModel>();

			if (Session["ShopCart"] != null)
			{
				List<ViewModels.ShopCartViewModel> listShop = Session["ShopCart"] as List<ViewModels.ShopCartViewModel>;

				foreach (var item in listShop)
				{
					var product = DatabaseContext.Products.Where(current => current.ProductId == item.ProductId).Select(p => new
					{
						p.ImageName,
						p.ProductTitle,
						p.Price,
					}).FirstOrDefault();

					list.Add(new ViewModels.ShowOrderViewModel()
					{
						Count = item.Count,
						ProductId = item.ProductId,
						ImageName = product.ImageName,
						ProductTitle = product.ProductTitle,
						Price = product.Price,
						Sum = item.Count * product.Price,
					});
				}
			}

			return PartialView(GetListOrder());
		}

		// Clean Code => Build a Method
		List<ViewModels.ShowOrderViewModel> GetListOrder()
		{
			List<ViewModels.ShowOrderViewModel> list = new List<ViewModels.ShowOrderViewModel>();

			if (Session["ShopCart"] != null)
			{
				List<ViewModels.ShopCartViewModel> listShop = Session["ShopCart"] as List<ViewModels.ShopCartViewModel>;

				foreach (var item in listShop)
				{
					var product = DatabaseContext.Products.Where(current => current.ProductId == item.ProductId).Select(p => new
					{
						p.ImageName,
						p.ProductTitle,
						p.Price,
					}).FirstOrDefault();

					list.Add(new ViewModels.ShowOrderViewModel()
					{
						Count = item.Count,
						ProductId = item.ProductId,
						ImageName = product.ImageName,
						ProductTitle = product.ProductTitle,
						Price = product.Price,
						Sum = item.Count * product.Price,
					});
				}
			}

			return list;
		}

		public ActionResult CommandOrder(int id, int count)
		{
			List<ViewModels.ShopCartViewModel> listShop = Session["ShopCart"] as List<ViewModels.ShopCartViewModel>;

			int index = listShop.FindIndex(current => current.ProductId == id);
			if (count == 0)
			{
				listShop.RemoveAt(index);
			}
			else
			{
				listShop[index].Count = count;
			}
			Session["ShopCart"] = listShop;


			return PartialView(" _ListOrder", GetListOrder());
		}
	}
}