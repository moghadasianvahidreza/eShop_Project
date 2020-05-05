namespace Models
{
	public class Role : object
	{
		public Role() : base()
		{

		}

		public virtual System.Collections.Generic.IList<User> Users { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Key]
		public int Id { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Display
			(Name = "عنوان نقش")]
		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string RoleTitle { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Display
			(Name = "عنوان سیستمی نقش")]
		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string RoleName { get; set; }
	}
}
