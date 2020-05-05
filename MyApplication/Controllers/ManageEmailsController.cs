using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class ManageEmailsController : Infrastructure.BaseController
    {
        // GET: ManageEmails
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ActivationEmail()
		{
			return PartialView();
		}

        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }


    }
}