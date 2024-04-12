using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public User(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
