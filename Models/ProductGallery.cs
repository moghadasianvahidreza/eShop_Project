using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class ProductGallery : object
	{
		public ProductGallery() : base()
		{
		}

		// **********
		[Key]
		public int GalleryId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "کالا")]
		public int ProductId { get; set; }

		// **********

		[Display(Name = "کالا")]
		public virtual Product Product { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "تصویر")]
		public int ImageName { get; set; }

		// **********
		[Display(Name = "عنوان")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Title { get; set; }
	}
}
