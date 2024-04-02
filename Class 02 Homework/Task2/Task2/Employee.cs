using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Employee

    {

    public string Title { get; set; }

        public abstract string CalculateSalary();

        public virtual string DisplayInfo()
        {
            return $"Salary of the {Title} is {CalculateSalary()}";
        }
    }
}
