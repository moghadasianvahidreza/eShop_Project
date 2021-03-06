﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class ShopCartViewModel : object
	{
		public ShopCartViewModel() : base()
		{

		}

		public int ProductId { get; set; }

		public int Count { get; set; }
	}

	public class ShopCartItemViewModel : object
	{
		public ShopCartItemViewModel() : base()
		{

		}

		public int ProductId { get; set; }

		public string ProductTitle { get; set; }

		public string ImageName { get; set; }

		public int Count { get; set; }
	}

	public class ShowOrderViewModel : Object
	{
		public ShowOrderViewModel() : base()
		{

		}

		public int ProductId { get; set; }

		public string ProductTitle { get; set; }

		public string ImageName { get; set; }

		public int Count { get; set; }

		public int Price { get; set; }

		public int Sum { get; set; }
	}
}
