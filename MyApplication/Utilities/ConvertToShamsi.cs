using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication
{
	public static class ConvertToShamsi : object
	{
		public static string ToShamsi(this DateTime dateTime)
		{
			System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

			var ShamsiDate = 
				persianCalendar.GetYear(dateTime) + "/" +
				persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
				persianCalendar.GetDayOfMonth(dateTime).ToString("00") + "-" +
				persianCalendar.GetHour(dateTime).ToString("00") + ":" + 
				persianCalendar.GetMinute(dateTime).ToString("00") + ":" + 
				persianCalendar.GetMinute(dateTime).ToString("00")
				;

			return ShamsiDate;
		}
	}
}