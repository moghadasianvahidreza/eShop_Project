using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class ProductFeaturesViewModel : object
	{
		public ProductFeaturesViewModel() : base()
		{
		}

		public string FeatureTitle { get; set; }

		public List<string> Values { get; set; }
	}
}
