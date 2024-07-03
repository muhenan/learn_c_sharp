using System.Diagnostics;

namespace Src.Async
{

    public class MySync
    {
        public static void Run()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            PerformTask("Task 1", 2000); // 2 seconds
            PerformTask("Task 2", 3000); // 3 seconds
            PerformTask("Task 3", 1000); // 1 second

            stopwatch.Stop();
            Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void PerformTask(string taskName, int delay)
        {
            Console.WriteLine($"{taskName} started.");
            Thread.Sleep(delay); // Simulate a delay
            Console.WriteLine($"{taskName} completed.");
        }

    }

    public class MyAsync
    {
        public static async Task Run()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Task task1 = PerformTaskAsync("Task 1", 2000); // 2 seconds
            Task task2 = PerformTaskAsync("Task 2", 3000); // 3 seconds
            Task task3 = PerformTaskAsync("Task 3", 1000); // 1 second

            await Task.WhenAll(task1, task2, task3);

            stopwatch.Stop();
            Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task PerformTaskAsync(string taskName, int delay)
        {
            Console.WriteLine($"{taskName} started.");
            await Task.Delay(delay); // Simulate a delay
            Console.WriteLine($"{taskName} completed.");
        }
    }
}