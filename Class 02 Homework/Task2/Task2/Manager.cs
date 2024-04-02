using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Manager : Employee
    {
        public string Salary { get; set; }
        public Manager()
        {
            Title = "Manager";
            Salary = "100000";
        }

        public override string CalculateSalary()
        {
            return Salary;
        }

    }
}
