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
			ApplyButter(toasts);
			ApplyJam(toasts);
			result.Add(PourJuice());
			return result;
		}

		public static Coffee PourCoffee()
		{
            Console.WriteLine();
            Console.Write("Pouring coffee");
			Task.Delay(1000).Wait();

			return new Coffee();
		}
		public static Juice PourJuice()
		{
            Console.WriteLine();
			Console.Write("Pouring juice");
			Task.Delay(1000).Wait();

			return new Juice();
		}
		public static Pan HeatPan()
		{
            Console.WriteLine();
			Console.Write("Heating pan");
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
                    Console.WriteLine();
					Console.Write("Frying egg");
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
                    Console.WriteLine();
					Console.Write("Frying bacon");
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
                Console.WriteLine();
				Console.Write("Toasting bread");
				Task.Delay(1000 * 10).Wait();

				result.Add(new Toast() { Toasted = true, });
			}
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
		}
	}
}
