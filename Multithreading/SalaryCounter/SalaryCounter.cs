using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Multithreading.SalaryCounter
{
    class SalaryCounter
    {
        private IEnumerable<Employee> ReadSalariesFile()
        {
            var lines = File.ReadAllLines($"SalaryCounter{Path.DirectorySeparatorChar}company.csv");
            var salaries = lines
                .Skip(1)
                .AsParallel()
                .Select(l => new Employee(l))
                .AsSequential();
            return salaries;
        }

        public Dictionary<string, double> CountAverageSalaries()
        {
            var averageSalaries = ReadSalariesFile()
                .AsParallel()
                .GroupBy(e => e.Department)
                .ToDictionary(g => g.Key, g => g.Average(e => e.Salary));
            return averageSalaries;
        }

        public Dictionary<string, int> CountMaxSalaries()
        {
            var maxSalaries = ReadSalariesFile()
                .AsParallel()
                .GroupBy(e =>
                    e.Age >= 17 && e.Age <= 30 ? "17-30" :
                    e.Age >= 31 && e.Age <= 45 ? "31-45" :
                    e.Age >= 46 ? "46+" : "Others")
                .ToDictionary(g => g.Key, g => g.Max(e => e.Salary));
            return maxSalaries;
        }
    }
}
