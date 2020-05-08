using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Feature : object
	{
		public Feature() : base()
		{

		}

		// **********
		public virtual IList<ProductFeature> ProductFeatures { get; set; }

		// **********
		[Key]
		public int FeatureId { get; set; }

		// **********
		[Display(Name = "عنوان ویژگی")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
		[StringLength(maximumLength: 150, MinimumLength = 3)]
		[Index(IsUnique = true)]
		public string Title { get; set; }

	}
}
