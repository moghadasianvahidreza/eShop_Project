using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Create([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName")] Product product, List<int> selectedGroups,HttpPostedFileBase imageProduct, string tags)
        {
			if (selectedGroups == null)
			{
				ViewBag.ErrorMessageSelectedGroups = true;

				ViewBag.Groups = DatabaseContext.ProductGroups.ToList();					
				return View(product);
			}
			product.ImageName = "images.png";
			if (imageProduct != null && imageProduct.IsImage()	)
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
            if (ModelState.IsValid)
            {
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

            // Show KeyWords
            ViewBag.Tags = string.Join(",", product.ProductTags.Select(current => current.Tag).ToList());

            ViewBag.Groups = DatabaseContext.ProductGroups.ToList();
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName")] Product product)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(product).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
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
