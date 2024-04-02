namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Write a program to create an abstract class Employee with abstract methods CalculateSalary() and DisplayInfo(). Create subclasses 
             * Manager and Programmer that extend the Employee class and implement the respective
             * methods to calculate salary and display information for each role.*/

            Programmer Jessica = new Programmer();
            Console.WriteLine(Jessica.CalculateSalary());
            Console.WriteLine(Jessica.DisplayInfo());

            Manager David = new Manager();
            Console.WriteLine(David.CalculateSalary());
            Console.WriteLine(David.DisplayInfo());
        }
    }
}
