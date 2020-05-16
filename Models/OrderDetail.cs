using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class OrderDetail : object
	{
		public OrderDetail() : base()
		{

		}

		// **********
		[Key]
		public int DetailId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "فاکتور")]
		public int OrderId { get; set; }

		// **********

		[Display(Name = "فاکتور")]
		public virtual Order Order { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "کالا")]
		public int ProductId { get; set; }

		// **********

		[Display(Name = "کالا")]
		public virtual Product Products { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "قیمت")]
		public int Price { get; set; }

		// **********
		[Display(Name = "تعداد / وزن")]
		public int Count { get; set; }
	}
}
