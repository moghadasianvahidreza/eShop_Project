using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
public	class ProductTag : object
	{
		public ProductTag() : base()
		{
		}


		// **********
		[Key]
		public int ProductTagId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "نام محصول")]
		public int ProductId { get; set; }

		// **********

		public virtual Product Product { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "کلمه کلیدی")]
		[Required(AllowEmptyStrings = false,ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 250, MinimumLength = 1)]
		[Index(IsUnique = true)]
		public string Tag { get; set; }
	}
}
