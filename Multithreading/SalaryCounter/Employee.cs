using System;
using System.Collections.Generic;
using System.Text;

namespace Multithreading.SalaryCounter
{
    class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Department { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public Employee(string csvString)
        {
            var properties = csvString.Split(",");
            FirstName = properties[0];
            LastName = properties[1];
            Department = properties[2];
            Age = int.Parse(properties[3]);
            Salary = int.Parse(properties[4]);
        }
    }
}
