using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModels;
using System.Web.Security;

namespace MyApplication.Controllers
{
	public class AccountController : Infrastructure.BaseController
	{
		public AccountController() : base()
		{

		}

		[System.Web.Mvc.HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		// ******************************
		// ******************************

		[System.Web.Mvc.HttpGet]
		[System.Web.Mvc.Route("Register")]
		public ViewResult Register()
		{
			return View();
		}

		// ******************************

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.Route("Register")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public ViewResult Register(ViewModels.RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!DatabaseContext.Users.Any(current => current.EmailAddress == registerViewModel.EmailAddress.Trim().ToLower()))
				{


					Models.User user = new Models.User
					{
						RoleId = 1,
						Username = registerViewModel.Username,
						EmailAddress = registerViewModel.EmailAddress.Trim().ToLower(),
						Password = registerViewModel.Password,
						ActiveCode = System.Guid.NewGuid().ToString(),
						IsActive = true,
						RegisterDate = System.DateTime.Now,
					};

					DatabaseContext.Users.Add(user);
					DatabaseContext.SaveChanges();

					#region Send Active EmailAddress
					string body = PartialToStringClass.RenderPartialView("ManageEmails", "_ActivationEmailPartialView", user);
					SendEmail.Send(user.EmailAddress, "ایمیل فعالسازی", body);
					#endregion

					return View("SuccessRegister", user);
				}
				else
				{
					ModelState.AddModelError(registerViewModel.EmailAddress, "ایمیل وارد شده تکراری می باشد");
				}
			}
			return View(registerViewModel);
		}

		// ******************************
		// ******************************

		[System.Web.Mvc.HttpGet]
		[System.Web.Mvc.Route("Login")]
		public ViewResult Login()
		{
			return View();
		}

		// ******************************

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.Route("Login")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public ActionResult Login(ViewModels.LoginViewModel loginViewModel, string ReturnUrl = "/")
		{
			if (ModelState.IsValid)
			{
				var user = DatabaseContext.Users
					.Where(current => current.EmailAddress == loginViewModel.EmailAddress)
					.Where(current => current.Password == loginViewModel.Password)
					.FirstOrDefault();

				if (user != null)
				{
					if (user.IsActive)
					{
						FormsAuthentication.SetAuthCookie(user.Username, loginViewModel.RememberMe);

						return Redirect(url: ReturnUrl);
					}
					else
					{
						ModelState.AddModelError(loginViewModel.EmailAddress, "حساب کاربری شما فعال نشده است");
					}
				}
				else
				{
					ModelState.AddModelError(loginViewModel.EmailAddress, "اطلاعات وارد شده صحیح نمی باشد لطفا مجددا تلاش نمایید");
				}
			}

			return View(loginViewModel);
		}

		// ******************************
		// ******************************

		[System.Web.Mvc.HttpGet]
		[System.Web.Mvc.Route("LogOut")]
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();

			string url = "/Login";

			return Redirect(url: url);
		}

		// ******************************
		// ******************************

		public ActionResult ActiveUser(string id)
		{


			var user = DatabaseContext.Users.Where(current => current.ActiveCode == id).FirstOrDefault();
			if (user == null)
			{
				return HttpNotFound();
			}

			user.IsActive = true;
			user.ActiveCode = System.Guid.NewGuid().ToString();
			ViewBag.Username = user.Username;
			DatabaseContext.SaveChanges();

			return View();
		}

		// ******************************
		// ******************************

		[System.Web.Mvc.HttpGet]
		[System.Web.Mvc.Route("ForgotPassword")]
		public ViewResult ForgotPassword()
		{
			return View();
		}

		// ******************************

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.Route("ForgotPassword")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public ViewResult ForgotPassword(ViewModels.ForgotPasswordViewModel forgotPasswordViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = DatabaseContext.Users.Where(current => current.EmailAddress == forgotPasswordViewModel.EmailAddress.Trim().ToLower()).First();
				if (user != null)
				{
					if (user.IsActive)
					{
						#region Send Recovery Password with EmailAddress
						string bodyEmailAddress = PartialToStringClass.RenderPartialView("ManageEmails", "_RecoveryPasswordPartialVeiw", user);
						SendEmail.Send(forgotPasswordViewModel.EmailAddress, "بازیابی کلمه رمز عبور", bodyEmailAddress);
						#endregion

						return View("SuccessSendEmailAddressForRecoveryPassword", user);
					}
					else
					{
						ModelState.AddModelError(forgotPasswordViewModel.EmailAddress, "حساب کاربری شما فعال نمی باشد");
					}

				}
				else
				{
					ModelState.AddModelError(forgotPasswordViewModel.EmailAddress, "ایمیلی با این آدرس موجود نمی باشد لطفا مجددا تلاش نمایید");
				}
			}

			return View(forgotPasswordViewModel);
		}

		// ******************************
		// ******************************

		[System.Web.Mvc.HttpGet]
		public ViewResult RecoveryPassword(string id)
		{
			return View();
		}

		// ******************************

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public ActionResult RecoveryPassword(string id, ViewModels.RecoveryPasswordViewModel recoveryPasswordViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = DatabaseContext.Users.Where(current => current.ActiveCode == id).FirstOrDefault();
				if (user == null)
				{
					return HttpNotFound();
				}

				user.Password = recoveryPasswordViewModel.Password;
				user.ActiveCode = System.Guid.NewGuid().ToString();
				DatabaseContext.SaveChanges();

				return Redirect("/Login?recovery=true");

			}

			return View();
		}

	}
}