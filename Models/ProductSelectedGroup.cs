using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
public	class ProductSelectedGroup : object
	{
		public ProductSelectedGroup() : base()
		{
		}

		// **********
		[Key]
		public int ProductSelectedGroupId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "نام گروه")]
		public int GroupId { get; set; }

		// **********

		// **********

		[Display(Name = "نام گروه")]
		public virtual ProductGroup ProductGroup { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "نام محصول")]
		public int ProductId { get; set; }

		// **********

		// **********

		[Display(Name = "نام گروه")]
		public virtual Product Product { get; set; }
		// **********
		// **********
		// **********


	}
}
