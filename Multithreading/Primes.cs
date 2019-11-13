using System;
using System.Collections.Generic;
using System.Threading;

namespace Multithreading
{
    static class Primes
    {
        public static HashSet<int> GetPrimes(int threadCount)
        {
            const int UpToPrimes = 1_000_000_000;
            var primes = new HashSet<int>();
            var currentNumber = 2;
            var lockObject = new object();
            List<Thread> threads = new List<Thread>(threadCount);

            for(int i = 0; i < threadCount; i++)
            {
                threads.Add(new Thread(data =>
                {
                    int primeCandidate = 0;
                    while (true)
                    {
                        lock (lockObject)
                        {
                            primeCandidate = currentNumber++;
                            if (currentNumber > UpToPrimes)
                            {
                                break;
                            }
                        }
                        // for debugging purposes
                        if (primeCandidate % 1_000_000 == 0)
                        {
                            Console.WriteLine(primeCandidate / 1_000_000);
                        }
                        // for debugging purposes
                        if (IsPrime(primeCandidate))
                        {
                            lock (lockObject)
                            {
                                primes.Add(primeCandidate);
                            }
                        }
                    }
                }));
            }

            foreach(var thread in threads)
            {
                thread.Start();
            }

            foreach(var thread in threads)
            {
                thread.Join();
            }

            return primes;
        }

        private static bool IsPrime(int number)
        {
            int upToNumber = (int)Math.Sqrt(number);
            for(int i = 2; i <= upToNumber; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
