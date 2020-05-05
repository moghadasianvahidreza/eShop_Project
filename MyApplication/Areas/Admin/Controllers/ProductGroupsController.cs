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
    public class ProductGroupsController : Infrastructure.BaseController
    {
        //private DatabaseContext DatabaseContext = new DatabaseContext();

        // GET: Admin/ProductGroups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var productGroupLeader = DatabaseContext.ProductGroups.ToList();
            return PartialView(productGroupLeader);
        }

        // GET: Admin/ProductGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = DatabaseContext.ProductGroups.Find(id);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Create
        public ActionResult Create(int? id)
        {
            ProductGroup productGroup = new ProductGroup
            {
                ParentId = id,
            };

            return PartialView(productGroup);
        }

        // POST: Admin/ProductGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle,ParentId")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.ProductGroups.Add(productGroup);
                DatabaseContext.SaveChanges();
                //return RedirectToAction("Index");
                return PartialView("List", DatabaseContext.ProductGroups.ToList());
            }

            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producrtId = DatabaseContext.ProductGroups.Find(id);
            if (producrtId == null)
            {
                return HttpNotFound();
            }
            return PartialView(producrtId);
        }

        // POST: Admin/ProductGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle,ParentId")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(productGroup).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return PartialView("List", DatabaseContext.ProductGroups.ToList());
            }
            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Delete/5
        public void Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var productId = DatabaseContext.ProductGroups.Find(id);
            foreach (var subGroup in DatabaseContext.ProductGroups.Where(current => current.ParentId == id))
            {
                DatabaseContext.Entry(subGroup).State = EntityState.Deleted;
            }
            DatabaseContext.ProductGroups.Remove(productId);
            DatabaseContext.SaveChanges();
            //if (productGroup == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(productGroup);
        }

        // POST: Admin/ProductGroups/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProductGroup productGroup = DatabaseContext.ProductGroups.Find(id);
        //    DatabaseContext.ProductGroups.Remove(productGroup);
        //    DatabaseContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
