using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class RegisterViewModel : object
	{
		public RegisterViewModel() : base()
		{
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DataAnnotations.Display
			(Name = "نام کاربری")]
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 250, MinimumLength = 6)]
		[System.ComponentModel.DataAnnotations.Schema.Index
			(IsUnique = true)]
		public string Username { get; set; }

		// **********

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

		// **********

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DataAnnotations.Display
			(Name = "گذر واژه")]
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 40, MinimumLength = 4)]
		[System.ComponentModel.DataAnnotations.DataType
			(System.ComponentModel.DataAnnotations.DataType.Password)]
		public string Password { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DataAnnotations.Display
			(Name = "تکرار گذر واژه")]
		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.DataType
			(System.ComponentModel.DataAnnotations.DataType.Password)]
		[System.ComponentModel.DataAnnotations.Compare
			("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
		public string RePassword { get; set; }
	}
}
