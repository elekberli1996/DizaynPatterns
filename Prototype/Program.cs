using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            // nesne uretim maliyetlerini minimize etmek ucundur
            //ilk ornek asil ornek
            Customer customer1 = new Customer
            { Id = 1, City = "istanbul", Name = "emin", Lastname = "elekberli" };
            Console.WriteLine(customer1.Name);
            Customer customer2 = (Customer)customer1.Clone();
            customer2.Name = "evez";
            Employee employee = new Employee();
            employee.Name = "yeni";
            Employee employee1 = (Employee)employee.Clone();
            employee1.Name = "djdjd";
            Console.WriteLine(employee1.Name);
            Console.WriteLine(customer2.Name); 
        }

        public abstract class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Lastname { get; set; }

            public abstract Person Clone();
        }

        public class Customer : Person
        {
            public string City { get; set; }

            public override Person Clone()
            {
                return (Person)MemberwiseClone();
            }
        }
        public class Employee : Person
        {
            public override Person Clone()
            {
                return (Person)MemberwiseClone();
            }
        }
    }
}
