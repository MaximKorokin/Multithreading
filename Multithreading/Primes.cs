using System;
using System.Collections.Generic;
using System.Threading;

namespace Multithreading
{
    public class Primes
    {
        private HashSet<int> primes = new HashSet<int>();

        public HashSet<int> GetPrimes(int lowerBound, int upperBound, int threadsCount)
        {
            int numbersInThread = upperBound / threadsCount;
            Thread[] threads = new Thread[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                int localLowerBound = lowerBound + numbersInThread * i;
                threads[i] = new Thread(() =>
                {
                    FindPrimes(localLowerBound + (i > 0 ? 1 : 0), localLowerBound + numbersInThread);
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return primes;
        }

        private void FindPrimes(int lowerBound, int upperBound)
        {
            for (int prime = lowerBound; prime <= upperBound; prime++)
            {
                if (IsPrime(prime))
                {
                    lock (primes)
                    {
                        primes.Add(prime);
                    }
                }
            }
        }

        private bool IsPrime(int number)
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
