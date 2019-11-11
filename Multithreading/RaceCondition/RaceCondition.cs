using System;
using System.Collections.Generic;
using System.Threading;

namespace Multithreading.RaceCondition
{
    static class RaceCondition
    {
        public static void Run()
        {
            var initialQueue = new Queue<string>(new string[] { "Adam", "Eve", "Moses", "David", "Goliath" });
            var finalQueue = new Queue<string>(initialQueue.Count);
            List<Thread> threads = new List<Thread>(initialQueue.Count);

            for(int i = 0; i < initialQueue.Count; i++)
            {
                threads.Add(new Thread(data =>
                {
                    finalQueue.Enqueue(initialQueue.Dequeue());
                }));
            }

            Console.WriteLine($"Initial queue: {initialQueue.ToString(", ")}");

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Final queue: {finalQueue.ToString(", ")}");
        }
    }
}
