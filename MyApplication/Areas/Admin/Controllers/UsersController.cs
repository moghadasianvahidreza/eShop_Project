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
    //[System.Web.Mvc.Authorize(Roles = "Admin")]
    public class UsersController :Infrastructure.BaseController
    {
        //private DatabaseContext databaseContext = new DatabaseContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = DatabaseContext.Users.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(DatabaseContext.Roles, "Id", "RoleTitle");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,Username,EmailAddress,Password,ActiveCode,IsActive,RegisterData")] User user)
        {
            if (ModelState.IsValid)
            {
                user.RegisterDate = DateTime.Now;
                user.ActiveCode = System.Guid.NewGuid().ToString();
                DatabaseContext.Users.Add(user);
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(DatabaseContext.Roles, "Id", "RoleTitle", user.RoleId);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(DatabaseContext.Roles, "Id", "RoleTitle", user.RoleId);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,Username,EmailAddress,Password,ActiveCode,IsActive,RegisterData")] User user)
        {
            if (ModelState.IsValid)
            {
                DatabaseContext.Entry(user).State = EntityState.Modified;
                DatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(DatabaseContext.Roles, "Id", "RoleTitle", user.RoleId);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DatabaseContext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = DatabaseContext.Users.Find(id);
            DatabaseContext.Users.Remove(user);
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
