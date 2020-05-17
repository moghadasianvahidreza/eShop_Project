using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Slider : object
	{
		public Slider() : base()
		{

		}

		// **********
		[Key]
		public int SlideId { get; set; }

		// **********
		[Display(Name = "عنوان")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Tiltle { get; set; }

		// **********
		[Display(Name = "تصویر")]
		public string ImageName { get; set; }

		// **********
		[Display(Name = "تاریخ شروع")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}" , ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }

		// **********
		[Display(Name = "تاریخ پایان")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
		public DateTime EndDate { get; set; }

		// **********
		[Display(Name = "وضعیت")]
		public bool IsActive { get; set; }

		// **********
		[Display(Name = "آدرس اینترنتی")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[Url(ErrorMessage = "آدرس اینترنتی وارد شده معتبر نمی باشد لطفا مجددا آدرس مورد نظر خود را وارد نمایید")]
		public string Url { get; set; }
	}
}
