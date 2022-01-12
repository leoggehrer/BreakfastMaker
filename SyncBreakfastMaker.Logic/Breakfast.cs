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

			result.Add(PourCoffee());			// 1 sec
			var pan = HeatPan();				// 10 sec.
			result.AddRange(FryEggs(pan, 2));	// 20 sec.
			result.AddRange(FryBacons(pan, 2));	// 20 sec.
			var toasts = ToastBread(2);			// 20 sec.
			result.AddRange(toasts);
			ApplyButter(toasts);				// 2 sec.
			ApplyJam(toasts);					// 2 sec.
			result.Add(PourJuice());			// 1 sec.
			return result;						// -> 76 sec.
		}

		public static Coffee PourCoffee()
		{
            Console.WriteLine();
            Console.Write("Pouring coffee");
			Task.Delay(1000).Wait();
			Console.WriteLine();
			Console.Write("Coffee is already");

			return new Coffee();
		}
		public static Juice PourJuice()
		{
            Console.WriteLine();
			Console.Write("Pouring juice");
			Task.Delay(1000).Wait();
			Console.WriteLine();
			Console.Write("Juice is already");

			return new Juice();
		}
		public static Pan HeatPan()
		{
            Console.WriteLine();
			Console.Write("Heating pan");
			Task.Delay(1000 * 10).Wait();
			Console.WriteLine();
			Console.Write("Pan is already");

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
                    Console.WriteLine();
					Console.Write("Frying egg");
					Task.Delay(1000 * 10).Wait();

					result.Add(new Egg() { Fryed = true, });
				}
				pan.InUse = false;
			}
			Console.WriteLine();
			Console.Write("Eggs are already");
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
                    Console.WriteLine();
					Console.Write("Frying bacon");
					Task.Delay(1000 * 10).Wait();

					result.Add(new Bacon() { Fryed = true, });
				}
				pan.InUse = false;
			}
			Console.WriteLine();
			Console.Write("Bacons are ready");
			return result;
		}
		public static IEnumerable<Toast> ToastBread(int count)
		{
			var result = new List<Toast>();

			for (int i = 0; i < count; i++)
			{
                Console.WriteLine();
				Console.Write("Toasting bread");
				Task.Delay(1000 * 10).Wait();

				result.Add(new Toast() { Toasted = true, });
			}
			Console.WriteLine();
			Console.Write("Breads are already");
			return result;
		}
        public static void ApplyButter(IEnumerable<Toast> toasts)
        {
			if (toasts == null)
				throw new ArgumentNullException(nameof(toasts));

            foreach (var item in toasts)
            {
                Console.WriteLine();
				Console.Write("Brush bread with butter");
				Task.Delay(1000 * 1).Wait();

				item.HasButter = true;
			}
			Console.WriteLine();
			Console.Write("Breads have butter");
		}
		public static void ApplyJam(IEnumerable<Toast> toasts)
		{
			if (toasts == null)
				throw new ArgumentNullException(nameof(toasts));

			foreach (var item in toasts)
			{
                Console.WriteLine();
				Console.Write("Brush bread with jam");
				Task.Delay(1000 * 1).Wait();

				item.HasJam = true;
			}
			Console.WriteLine();
			Console.Write("Breads have jam");
		}
	}
}
