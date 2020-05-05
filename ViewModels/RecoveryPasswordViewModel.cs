using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class RecoveryPasswordViewModel : object
	{
		public RecoveryPasswordViewModel() : base()
		{
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DataAnnotations.Display
			(Name = "گذر واژه جدید")]
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
			(Name = "تکرار گذر واژه جدید")]
		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessage = "لطفا {0} را وارد کنید")]
		[System.ComponentModel.DataAnnotations.DataType
			(System.ComponentModel.DataAnnotations.DataType.Password)]
		[System.ComponentModel.DataAnnotations.Compare
			("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
		public string RePassword { get; set; }
	}
}
