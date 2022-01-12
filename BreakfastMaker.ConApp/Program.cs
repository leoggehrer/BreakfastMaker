using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BreakfastMaker.ConApp
{
	class Program
	{
		static async Task Main(/*string[] args*/)
        {
            //           RunWithProgress("Sync breakfast maker!", MakeSyncBreakfast);
            //MakeSyncBreakfast();
            //Console.WriteLine();
            await MakeAsyncBreakfast();
        }
        private static void RunWithProgress(string title, Action action)
        {
            Console.WriteLine(title);
            bool runBusyProgress = true;
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);
                while (runBusyProgress)
                {
                    Console.Write(".");
                    await Task.Delay(250);
                }
            });
            action?.Invoke();
            runBusyProgress = false;
        }
        private static void MakeSyncBreakfast()
        {
            Console.WriteLine("Make sync Breakfast");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            var dishes = SyncBreakfastMaker.Logic.Breakfast.Make();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"It took {sw.ElapsedMilliseconds / 1000} seconds to prepare breakfast!");
        }
        private static async Task MakeAsyncBreakfast()
        {
            Console.WriteLine("Make async Breakfast");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            var dishes = await AsyncBreakfastMaker.Logic.Breakfast.MakeAsync();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"It took {sw.ElapsedMilliseconds / 1000} seconds to prepare breakfast!");
        }
    }
}
