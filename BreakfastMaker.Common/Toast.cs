using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakfastMaker.Common
{
	public class Toast : BreakfastDish
	{
		public bool Toasted { get; set; }
		public bool HasButter { get; set; }
		public bool HasJam { get; set; }
	}
}
