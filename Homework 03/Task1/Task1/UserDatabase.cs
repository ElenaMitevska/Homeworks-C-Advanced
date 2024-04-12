using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class UserDatabase 
    {

        public static List<User> Users { get; set; } = new List<User>();


        public static void SearchUser(int id, string name, int age)
        {
            if (Users.Contains(x => x.Name)) { return "The name exist."}

        }
    }
}
