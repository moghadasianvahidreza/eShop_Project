using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
	public class SearchController : Infrastructure.BaseController
	{
		public SearchController() : base()
		{

		}

		// GET: Search
		public ActionResult Index(string text)
		{
			List<Models.Product> list = new List<Models.Product>();

			list.AddRange(DatabaseContext.ProductTags
				.Where(current => current.Tag == text)
				.Select(current => current.Product)
				.ToList()
				);

			list.AddRange(DatabaseContext.Products.Where(
				current => current.ProductTitle.Contains(text) || 
				current.ShortDescription.Contains(text) || 
				current.Text.Contains(text))
				.ToList()
				);

			ViewBag.search = text;

			return View(list.Distinct());
		}
	}
}