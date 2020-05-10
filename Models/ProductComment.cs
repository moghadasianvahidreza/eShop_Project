using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
	public class ProductComment : object
	{
		public ProductComment() : base()
		{

		}
		
		// **********
		[Key]
		public int ProductCommentId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "نام محصول")]
		public int ProductId { get; set; }

		// **********

		// **********

		public virtual Product Product { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 150)]
		public string Name { get; set; }

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "آدرس ایمیل")]
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 250, MinimumLength = 6)]
		[System.ComponentModel.DataAnnotations.EmailAddress
			(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
		public string EmailAddress { get; set; }

		// **********
		[Display(Name = "وب سایت")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 350)]
		public string Website { get; set; }

		// **********
		[Display(Name = "متن نظر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 800, MinimumLength = 6)]
		public string Comment { get; set; }

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "تاریخ ثبت نام")]
		public DateTime CreateDate { get; set; }
		
		// **********
		public int? ParentId { get; set; }
	}
}
