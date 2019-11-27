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
            Console.WriteLine($"Primes: {new Primes().GetPrimes(1, 1_000_000, 11).Count}");
            Console.WriteLine("*****************");
            Console.WriteLine("Salary:");
            Console.WriteLine("Average salaries");
            foreach(var keyValue in new SalaryCounter.SalaryCounter().CountAverageSalaries())
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
            Console.WriteLine("*****************");
            Console.WriteLine("Max salaries");
            foreach (var keyValue in new SalaryCounter.SalaryCounter().CountMaxSalaries())
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
        }
    }
}
