using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Product : object
	{
		public Product() : base()
		{
		}

		public virtual IList<ProductSelectedGroup> ProductSelectedGroups { get; set; }

		public virtual IList<ProductTag> ProductTags { get; set; }

		public virtual IList<ProductGallery> ProductGalleries { get; set; }

		public virtual IList<ProductFeature> ProductFeatures { get; set; }

		public virtual IList<ProductComment> ProductComments { get; set; }

		// **********
		[Key]
		public int ProductId { get; set; }

		// **********
		[Display(Name = "عنوان")]
		[Required(AllowEmptyStrings = false,ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 350, MinimumLength = 3)]
		[Index(IsUnique = true)]
		public string ProductTitle { get; set; }

		// **********
		[Display(Name = "توضیح مختصر")]
		[Required(AllowEmptyStrings = false,ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 500, MinimumLength = 5)]
		[DataType(DataType.MultilineText)]
		public string ShortDescription { get; set; }

		// **********
		[System.Web.Mvc.AllowHtml]
		[Display(Name = "متن")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[DataType(DataType.MultilineText)]
		public string Text { get; set; }

		// **********
		[Display(Name = "قیمت")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int Price { get; set; }

		// **********
		[Display(Name = "تاریخ ایجاد")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
		public System.DateTime CreateDate { get; set; }

		// **********
		[Display(Name = "تصویر")]
		public string ImageName { get; set; }
	}
}
