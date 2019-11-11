using System;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Atomicity:");
            Atomicity.Atomicity.Run();
            Console.WriteLine("*****************");
            Console.WriteLine("Race condition:");
            RaceCondition.RaceCondition.Run();
            Console.WriteLine("*****************");
            Console.WriteLine("Multithread prime numbers:");
            Console.WriteLine($"Primes: {Primes.GetPrimes(11).Count}");
        }
    }
}
