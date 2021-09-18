using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BreakfastMaker.ConApp
{
	class Program
	{
		static void Main(/*string[] args*/)
        {
           RunWithProgress("Sync breakfast maker!", MakeSyncBreakfast);
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
            Stopwatch sw = new Stopwatch();

            Console.WriteLine();
            sw.Start();
            var dishes = SyncBreakfastMaker.Logic.Breakfast.Make();
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"It took {sw.ElapsedMilliseconds / 1000} seconds to prepare breakfast!");
        }
    }
}
