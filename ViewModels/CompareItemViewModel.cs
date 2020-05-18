using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class CompareItemViewModel : object
	{
		public CompareItemViewModel() : base()
		{

		}

		public int ProductId { get; set; }

		public string Title { get; set; }

		public string ImageName { get; set; }
	}
}
