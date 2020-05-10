namespace Models
{
	public class User : object
	{
		public User() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Key]
		public int Id { get; set; }

		// **********
		// **********
		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "نقش")]
		public int RoleId { get; set; }

		// **********

		// **********

		[System.ComponentModel.DataAnnotations.Display
			(Name = "نقش")]
		public virtual Role Role { get; set; }
		// **********
		// **********
		// **********
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
		[System.ComponentModel.DataAnnotations.Display
			(Name = "کد فعالیت")]
		public string ActiveCode { get; set; }

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Active")]
		public bool IsActive { get; set; }

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "تاریخ ثبت نام")]
		public System.DateTime RegisterDate { get; set; }
	}
}
