using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Get the number of CPU cores
        int maxThreads = Environment.ProcessorCount;

        // Adjust maxThreads based on specific requirements or workload characteristics
        // maxThreads = Math.Max(maxThreads, desiredThreadCount);

        // Queue work items to the thread pool
        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), i);
        }

        // Wait for all work items to complete
        Console.WriteLine("All tasks queued. Press any key to exit.");
        Console.ReadKey();
    }

    static void DoWork(object state)
    {
        int taskId = (int)state;

        // Simulate work by sleeping for a random duration
        Random rnd = new Random();
        int sleepDuration = rnd.Next(1000, 5000); // Sleep for 1 to 5 seconds
        Thread.Sleep(sleepDuration);

        Console.WriteLine($"Task {taskId} completed after {sleepDuration} ms");
    }
}
