using BreakfastMaker.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfastMaker.Logic
{
    public class Breakfast
    {
        public static async Task<IEnumerable<BreakfastDish>> MakeAsync()
        {
            var result = new List<BreakfastDish>();
            var tasks = new List<Task>();

            tasks.Add(PourCoffeeAsync());
            tasks.Add(HeatPansFryEggsAndFryBacon());
            tasks.Add(ToastBreadApplyButterAndJam());
            tasks.Add(PourJuiceAsync());

            await Task.WhenAll(tasks);

            for (int i = 0; i < tasks.Count; i++)
            {
                if (i == 0)
                    result.Add(await (tasks[i] as Task<Coffee>));
                else if (i == tasks.Count - 1)
                    result.Add(await (tasks[i] as Task<Juice>));
                else
                    result.AddRange(await (tasks[i] as Task<IEnumerable<BreakfastDish>>));
            }
            return result;
        }

        public static async Task<IEnumerable<BreakfastDish>> HeatPanFryEggsAndFryBacon()
        {
            var result = new List<BreakfastDish>();

            var pan = await HeatPanAsync();

            result.AddRange(await FryEggsAsync(pan, 2));
            result.AddRange(await FryBaconsAsync(pan, 2));
            return result;
        }
        public static async Task<IEnumerable<BreakfastDish>> HeatPansFryEggsAndFryBacon()
        {
            var result = new List<BreakfastDish>();

            var pan1Task = HeatPanAsync();
            var pan2Task = HeatPanAsync();

            await Task.WhenAll(pan1Task, pan2Task);

            var eggsTask = FryEggsAsync(await pan1Task, 2);
            var baconsTask = FryBaconsAsync(await pan2Task, 2);

            await Task.WhenAll(eggsTask, baconsTask);

            result.AddRange(await eggsTask);
            result.AddRange(await baconsTask);
            return result;
        }
        public static async Task<IEnumerable<BreakfastDish>> ToastBreadApplyButterAndJam()
        {
            var result = new List<BreakfastDish>();

            var toasts = await ToastBreadAsync(2);

            await ApplyButterAsync(toasts);
            await ApplyJamAsync(toasts);
            result.AddRange(toasts);
            return result;
        }


        public static async Task<Coffee> PourCoffeeAsync()
        {
            Console.WriteLine();
            Console.Write("Pouring coffee");
            await Task.Delay(1000);
            Console.WriteLine();
            Console.Write("Coffee is already");

            return new Coffee();
        }
        public static async Task<Juice> PourJuiceAsync()
        {
            Console.WriteLine();
            Console.Write("Pouring juice");
            await Task.Delay(1000);
            Console.WriteLine();
            Console.Write("Juice is already");

            return new Juice();
        }
        public static async Task<Pan> HeatPanAsync()
        {
            Console.WriteLine();
            Console.Write("Heating pan");
            await Task.Delay(1000 * 10);
            Console.WriteLine();
            Console.Write("Pan is already");

            return new Pan()
            {
                Heated = true,
            };
        }
        public static async Task<IEnumerable<Egg>> FryEggsAsync(Pan pan, int count)
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
                    await Task.Delay(1000 * 10);

                    result.Add(new Egg() { Fryed = true, });
                }
                pan.InUse = false;
            }
            Console.WriteLine();
            Console.Write("Eggs are already");
            return result;
        }
        public static async Task<IEnumerable<Bacon>> FryBaconsAsync(Pan pan, int count)
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
                    await Task.Delay(1000 * 10);

                    result.Add(new Bacon() { Fryed = true, });
                }
                pan.InUse = false;
            }
            Console.WriteLine();
            Console.Write("Bacons are ready");
            return result;
        }
        public static async Task<IEnumerable<Toast>> ToastBreadAsync(int count)
        {
            var result = new List<Toast>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
                Console.Write("Toasting bread");
                await Task.Delay(1000 * 10);

                result.Add(new Toast() { Toasted = true, });
            }
            Console.WriteLine();
            Console.Write("Breads are already");
            return result;
        }
        public static Task ApplyButterAsync(IEnumerable<Toast> toasts)
        {
            if (toasts == null)
                throw new ArgumentNullException(nameof(toasts));

            return Task.Run(() =>
            {
                foreach (var item in toasts)
                {
                    Console.WriteLine();
                    Console.Write("Brush bread with butter");
                    Task.Delay(1000 * 1).Wait();

                    item.HasButter = true;
                }
                Console.WriteLine();
                Console.Write("Breads has butter");
            });
        }
        public static Task ApplyJamAsync(IEnumerable<Toast> toasts)
        {
            if (toasts == null)
                throw new ArgumentNullException(nameof(toasts));

            return Task.Run(() =>
            {
                foreach (var item in toasts)
                {
                    Console.WriteLine();
                    Console.Write("Brush bread with jam");
                    Task.Delay(1000 * 1).Wait();

                    item.HasJam = true;
                }
                Console.WriteLine();
                Console.Write("Breads has jam");
            });
        }
    }
}
