using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyApplication.Controllers
{
	public class AcountController : Infrastructure.BaseController
	{
		// GET: Acount
		public ActionResult Index()
		{
			return View();
		}

		[System.Web.Mvc.HttpGet]
		public ViewResult Register()
		{
			return View();
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public ViewResult Register(ViewModels.RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!databaseContext.Users.Any(current => current.EmailAddress == registerViewModel.EmailAddress.Trim().ToLower()))
				{
					Models.User user = new Models.User
					{
						EmailAddress = registerViewModel.EmailAddress.Trim().ToLower(),
						Password = FormsAuthentication.HashPasswordForStoringInConfigFile(password: registerViewModel.Password, passwordFormat: "MD5"),
						ActiveCode = System.Guid.NewGuid().ToString(),
						IsActive = true,
						RegisterData = System.DateTime.Now,
						RoleId = 1,
						Username = registerViewModel.Username,
					};

					databaseContext.Users.Add(user);

					databaseContext.SaveChanges();

					return View(viewName: "SuccessRegister", model: user);
				}

				else
				{
					ModelState.AddModelError(registerViewModel.EmailAddress, "ایمیل وارد شده تکراری می باشد");
				}
			}

			return View(model: registerViewModel);
		}

		public ViewResult Login()
		{
			return View();
		}

	}
}



