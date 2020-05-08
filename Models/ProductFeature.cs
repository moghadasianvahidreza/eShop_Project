using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class ProductFeature : object
	{
		public ProductFeature() : base()
		{

		}

		// **********
		[Key]
		public int ProductFeatureId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "عنوان محصول")]
		public int ProductId { get; set; }

		// **********

		public virtual Product Product { get; set; }
		// **********
		// **********
		// **********

		// **********
		// **********
		// **********
		[Display(Name = "ویژگی محصول")]
		public int FeatureId { get; set; }

		// **********

		public virtual Feature Feature { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "مقدار")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Value { get; set; }
	}
}
