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
	public class SlidersController : Controller
	{
		private DatabaseContext db = new DatabaseContext();

		// GET: Admin/Sliders
		public ActionResult Index()
		{
			return View(db.Sliders.ToList());
		}

		// ******************************
		// ******************************

		// GET: Admin/Sliders/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Slider slider = db.Sliders.Find(id);
			if (slider == null)
			{
				return HttpNotFound();
			}
			return View(slider);
		}

		// ******************************
		// ******************************

		// GET: Admin/Sliders/Create
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SlideId,Tiltle,ImageName,StartDate,EndDate,IsActive,Url")] Slider slider, HttpPostedFileBase imgUp)
		{
			if (ModelState.IsValid)
			{
				if (imgUp == null && !imgUp.IsImage())
				{
					ModelState.AddModelError("ImageName", "لطفا تصویر را انتخاب کنید.");

					return View(slider);
				}

				slider.ImageName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imgUp.FileName);
				imgUp.SaveAs(Server.MapPath("~/Images/SliderImages/" + slider.ImageName));
				db.Sliders.Add(slider);

				db.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(slider);
		}

		// ******************************
		// ******************************

		// GET: Admin/Sliders/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Slider slider = db.Sliders.Find(id);
			if (slider == null)
			{
				return HttpNotFound();
			}
			return View(slider);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "SlideId,Tiltle,ImageName,StartDate,EndDate,IsActive,Url")] Slider slider, HttpPostedFileBase imgUp)
		{
			if (ModelState.IsValid)
			{
				if (imgUp != null)
				{
					System.IO.File.Delete(Server.MapPath("~/Images/SliderImages/" + slider.ImageName));
					slider.ImageName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imgUp.FileName);
					imgUp.SaveAs(Server.MapPath("~/Images/SliderImages/" + slider.ImageName));

				}
				db.Entry(slider).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(slider);
		}

		// ******************************
		// ******************************

		// GET: Admin/Sliders/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Slider slider = db.Sliders.Find(id);
			if (slider == null)
			{
				return HttpNotFound();
			}
			return View(slider);
		}

		// POST: Admin/Sliders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Slider slider = db.Sliders.Find(id);
			System.IO.File.Delete(Server.MapPath("~/Images/SliderImages/" + slider.ImageName));
			db.Sliders.Remove(slider);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// ******************************
		// ******************************

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
