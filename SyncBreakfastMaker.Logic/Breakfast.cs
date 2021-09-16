using BreakfastMaker.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncBreakfastMaker.Logic
{
	public class Breakfast
	{
		public static IEnumerable<BreakfastDish> Make()
		{
			var result = new List<BreakfastDish>();

			result.Add(PourCoffee());
			var pan = HeatPan();
			result.AddRange(FryEggs(pan, 2));
			result.AddRange(FryBacons(pan, 2));
			var toasts = ToastBread(2);
			result.AddRange(toasts);

			return result;
		}

		public static Coffee PourCoffee()
		{
			Task.Delay(1000).Wait();

			return new Coffee();
		}

		public static Pan HeatPan()
		{
			Task.Delay(1000 * 10).Wait();

			return new Pan()
			{
				Heated = true,
			};
		}
		public static IEnumerable<Egg> FryEggs(Pan pan, int count)
		{
			if (pan == null)
				throw new ArgumentNullException(nameof(pan));

			var result = new List<Egg>();

			if (pan.InUse == false)
			{
				pan.InUse = true;
				for (int i = 0; i < count; i++)
				{
					Task.Delay(1000 * 10).Wait();

					result.Add(new Egg() { Fryed = true, });
				}
				pan.InUse = false;
			}
			return result;
		}
		public static IEnumerable<Bacon> FryBacons(Pan pan, int count)
		{
			if (pan == null)
				throw new ArgumentNullException(nameof(pan));

			var result = new List<Bacon>();

			if (pan.InUse == false)
			{
				pan.InUse = true;
				for (int i = 0; i < count; i++)
				{
					Task.Delay(1000 * 10).Wait();

					result.Add(new Bacon() { Fryed = true, });
				}
				pan.InUse = false;
			}
			return result;
		}
		public static IEnumerable<Toast> ToastBread(int count)
		{
			var result = new List<Toast>();

			for (int i = 0; i < count; i++)
			{
				Task.Delay(1000 * 10).Wait();

				result.Add(new Toast() { Toasted = true, });
			}
			return result;
		}
		//public static void ApplyButter(Toast toast)
		//{
		//	var result = new List<Toast>();

		//	for (int i = 0; i < count; i++)
		//	{
		//		Task.Delay(1000 * 10).Wait();

		//		result.Add(new Toast() { Toasted = true, });
		//	}
		//	return result;
		//}
	}
}
