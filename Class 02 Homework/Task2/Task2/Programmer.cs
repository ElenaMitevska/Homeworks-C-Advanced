using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Programmer : Employee
    {
        private string  Salary { get; set; }
        public Programmer()
        {
            Salary = "90000";
            Title = "Programmer";
        }
      public override string CalculateSalary()
        {
            return Salary;
        }
    }
}
