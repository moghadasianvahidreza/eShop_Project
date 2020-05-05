using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Areas.UserPanel.Controllers
{
    public class AccountController : Infrastructure.BaseController
    {
        public AccountController() : base()
        {

        }
        // GET: UserPanel/Account
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult ChangePasswordUser()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public ActionResult ChangePasswordUser(ViewModels.ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = DatabaseContext.Users.Where(current => current.Password == changePasswordViewModel.OldPassword).FirstOrDefault();
                if (user != null)
                {
                    user.Password = changePasswordViewModel.Password;
                    DatabaseContext.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError(changePasswordViewModel.OldPassword, "رمز عبور وارد شده صحیح نمی باشد مجددا رمز عبور خود را وارد کنید.");
                }

            }
            return View();
        }
    }
}