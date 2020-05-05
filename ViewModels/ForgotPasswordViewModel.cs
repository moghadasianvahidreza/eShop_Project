using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class ForgotPasswordViewModel : object
	{
		public ForgotPasswordViewModel() : base()
		{
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DataAnnotations.Display
			(Name = "آدرس ایمیل")]
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 250, MinimumLength = 6)]
		[System.ComponentModel.DataAnnotations.EmailAddress
			(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
		public string EmailAddress { get; set; }
	}
}
