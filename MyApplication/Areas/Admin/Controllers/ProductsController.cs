using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Models;

namespace MyApplication.Areas.Admin.Controllers
{
	public class ProductsController : Infrastructure.BaseController
	{

		// GET: Admin/Products
		public ActionResult Index()
		{
			return View(DatabaseContext.Products.ToList());
		}

		// GET: Admin/Products/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = DatabaseContext.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			return View(product);
		}

		// GET: Admin/Products/Create
		public ActionResult Create()
		{
			ViewBag.Groups = DatabaseContext.ProductGroups.ToList();

			return View();
		}

		// POST: Admin/Products/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName")] Product product, List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags)
		{
			if (ModelState.IsValid)
			{
				if (selectedGroups == null)
				{
					ViewBag.ErrorMessageSelectedGroups = true;

					ViewBag.Groups = DatabaseContext.ProductGroups.ToList();

					return View(product);
				}

				product.ImageName = "images.png";
				if (imageProduct != null && imageProduct.IsImage())
				{
					// How to Save new images
					product.ImageName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imageProduct.FileName);
					imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));

					// How to Resize images for show to Users
					ImageResizer imageResizer = new ImageResizer();
					imageResizer.Resize(
						Server.MapPath("/Images/ProductImages/" + product.ImageName),
						Server.MapPath("/Images/ProductImages/Thumbnail/" + product.ImageName));
				}

				product.CreateDate = System.DateTime.Now;
				DatabaseContext.Products.Add(product);

				// Add product select to tabel's ProductSelectedGroups
				foreach (int item in selectedGroups)
				{
					DatabaseContext.ProductSelectedGroups.Add(new ProductSelectedGroup()
					{
						ProductId = product.ProductId,
						GroupId = item,
					});
				}

				// Add key Words to table's ProductTags
				if (!string.IsNullOrEmpty(tags))
				{
					string[] tag = tags.Split(',');
					foreach (string item in tag)
					{
						DatabaseContext.ProductTags.Add(new ProductTag()
						{
							ProductId = product.ProductId,
							Tag = item.Trim(),
						});
					}

				}

				DatabaseContext.SaveChanges();

				return RedirectToAction("Index");
			}

			ViewBag.Groups = DatabaseContext.ProductGroups.ToList();

			return View(product);
		}

		// GET: Admin/Products/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = DatabaseContext.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			// Show Tick in CheckBoxes
			ViewBag.SelectedGroup = product.ProductSelectedGroups.ToList();

			// Show KeyWords
			ViewBag.Tags = string.Join(",", product.ProductTags.Select(current => current.Tag).ToList());

			ViewBag.Groups = DatabaseContext.ProductGroups.ToList();
			return View(product);
		}

		// POST: Admin/Products/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName")] Product product, List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags)
		{
			if (ModelState.IsValid)
			{
				if (imageProduct != null && imageProduct.IsImage())
				{
					if (product.ImageName != "images.png")
					{
						System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + product.ImageName));
						System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumbnail/" + product.ImageName));
					}

					// How to Save new images
					product.ImageName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imageProduct.FileName);
					imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));

					// How to Resize images for show to Users
					ImageResizer imageResizer = new ImageResizer();
					imageResizer.Resize(
						Server.MapPath("/Images/ProductImages/" + product.ImageName),
						Server.MapPath("/Images/ProductImages/Thumbnail/" + product.ImageName));
				}

				// Remove KeyWords
				DatabaseContext.ProductTags
					.Where(current => current.ProductId == product.ProductId)
					.ToList()
					.ForEach(current => DatabaseContext.ProductTags.Remove(current));

				// Add key Words to table's ProductTags
				if (!string.IsNullOrEmpty(tags))
				{
					string[] tag = tags.Split(',');
					foreach (string item in tag)
					{
						DatabaseContext.ProductTags.Add(new ProductTag()
						{
							ProductId = product.ProductId,
							Tag = item.Trim(),
						});
					}

				}

				// Remove Groups
				DatabaseContext.ProductSelectedGroups
					.Where(current => current.ProductId == product.ProductId)
					.ToList()
					.ForEach(current => DatabaseContext.ProductSelectedGroups.Remove(current));

				// Add product select to tabel's ProductSelectedGroups
				foreach (int item in selectedGroups)
				{
					DatabaseContext.ProductSelectedGroups.Add(new ProductSelectedGroup()
					{
						ProductId = product.ProductId,
						GroupId = item,
					});
				}

				DatabaseContext.Entry(product).State = EntityState.Modified;

				DatabaseContext.SaveChanges();

				return RedirectToAction("Index");
			}

			// Show Tick in CheckBoxes
			ViewBag.SelectedGroup = selectedGroups;

			// Show KeyWords
			ViewBag.Tags = string.Join(",", product.ProductTags.Select(current => current.Tag).ToList());

			ViewBag.Groups = tags;

			return View(product);
		}

		// GET: Admin/Products/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = DatabaseContext.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Admin/Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = DatabaseContext.Products.Find(id);
			DatabaseContext.Products.Remove(product);
			DatabaseContext.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Gallery(int id)
		{
			ViewBag.Gallery = DatabaseContext.productGalleries.Where(current => current.ProductId == id).ToList();

			return View(new ProductGallery()
			{
				ProductId = id,
			});
		}

		[HttpPost]
		public ActionResult Gallery(ProductGallery gallery, HttpPostedFileBase imgUp)
		{
			if (ModelState.IsValid)
			{
				if (imgUp != null && imgUp.IsImage())
				{
					// How to Save new images
					gallery.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
					imgUp.SaveAs(Server.MapPath("~/Images/ProductImages/" + gallery.ImageName));

					// How to Resize images for show to Users
					ImageResizer resizer = new ImageResizer();
					resizer.Resize(
						Server.MapPath("/Images/ProductImages/" + gallery.ImageName),
						Server.MapPath("/Images/ProductImages/Thumbnail/" + gallery.ImageName));

					DatabaseContext.productGalleries.Add(gallery);
					DatabaseContext.SaveChanges();
				}
			}

			return RedirectToAction("Gallery", new { id = gallery.ProductId });
		}

		public ActionResult DeleteGallery(int id)
		{
			var oGallery = DatabaseContext.productGalleries.Find(id);

			System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + oGallery.ImageName));
			System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumbnail/" + oGallery.ImageName));

			DatabaseContext.productGalleries.Remove(oGallery);
			DatabaseContext.SaveChanges();


			return RedirectToAction("Gallery", new { id = oGallery.ProductId });
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				DatabaseContext.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
