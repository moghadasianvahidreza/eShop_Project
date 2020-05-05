using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	
	public partial class ProductGroup : object
	{
		public ProductGroup() : base()
		{
		}

		public virtual IList<ProductSelectedGroup> ProductSelectedGroups { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Key]
		public int GroupId { get; set; }

		// **********

		[System.ComponentModel.DataAnnotations.Display(Name = "عنوان گروه")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string GroupTitle { get; set; }

		// **********

		public int? ParentId { get; set; }
	}
}
