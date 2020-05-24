using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
	public class SiteVisit : object
	{
		public SiteVisit() : base()
		{

		}

		// **********
		[Key]
		public int VisitId { get; set; }

		// **********
		[Display(Name = "IP کاربر")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 3)]
		public string Ip { get; set; }

		// **********
		[Display(Name = "تاریخ بازدید کاربر")]
		public string Date { get; set; }
	}
}
