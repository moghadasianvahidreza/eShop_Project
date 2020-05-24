using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class VisitSiteViewModel : object
	{
		public VisitSiteViewModel() : base()
		{

		}

		public int VisitToday { get; set; }

		public int VisitYesterday { get; set; }

		public int VisitSum { get; set; }

		public int Online { get; set; }
	}
}
