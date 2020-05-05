using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.Infrastructure
{
	public class BaseController : System.Web.Mvc.Controller
	{
		public BaseController() : base()
		{

		}

		private Models.DatabaseContext databaseContext { get; set; }

		public Models.DatabaseContext DatabaseContext
		{
			get
			{
				if (databaseContext == null)
				{
					databaseContext = new Models.DatabaseContext();
				}
				return databaseContext;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}

			base.Dispose(disposing);
		}
	}
}