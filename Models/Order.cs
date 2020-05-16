using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Order : object
	{
		public Order() : base()
		{

		}

		// **********
		public virtual IList<OrderDetail> OrderDetails { get; set; }

		// **********
		[Key]
		public int OrderId { get; set; }

		// **********
		// **********
		// **********
		[Display(Name = "نام کاربری")]
		public int UserId { get; set; }

		// **********
		[Display(Name = "نام کاربری")]
		public virtual User User { get; set; }
		// **********
		// **********
		// **********
		[Display(Name = "تاریخ")]
		public DateTime Date { get; set; }

		// **********
		[Display(Name = "وضعیت فاکتور")]
		public bool IsFinaly { get; set; }
	}
}
