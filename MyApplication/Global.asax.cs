﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;


namespace MyApplication
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			HttpContext.Current.Application["Online"] = 0;
		}

		// ******************************
		// ******************************

		//Add using System.Threading To namespace
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			var persianCulture = new PersianCulture();
			Thread.CurrentThread.CurrentCulture = persianCulture;
			Thread.CurrentThread.CurrentUICulture = persianCulture;
		}

		// ******************************
		// ******************************

		// Add Session Object to Web Api
		protected void Application_PostAuthorizeRequest()
		{
			System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
		}

		// ******************************
		// ******************************

		protected void Session_Start()
		{
			int online = int.Parse(HttpContext.Current.Application["Online"].ToString());
			online += 1;
			HttpContext.Current.Application["Online"] = online;

			string ip = Request.UserHostAddress;

			System.DateTime date = DateTime.Now;
			string dateWithoutTime = date.ToShamsiWithoutTime();

			using (Models.DatabaseContext databaseContext = new Models.DatabaseContext())
			{
				if (!databaseContext.SiteVisits.Any(current => current.Ip == ip && current.Date == dateWithoutTime))
				{
					databaseContext.SiteVisits.Add(new Models.SiteVisit()
					{
						Ip = ip,
						Date = dateWithoutTime,
					});

					databaseContext.SaveChanges();
				}
			}
		}

		protected void Session_End()
		{
			int online = int.Parse(HttpContext.Current.Application["Online"].ToString());
			online -= 1;
			HttpContext.Current.Application["Online"] = online;
		}
	}
}
