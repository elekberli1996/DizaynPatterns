using System;
using System.Collections;
using System.Collections.Generic;

namespace compozite
{
    class Program
    {
        static void Main(string[] args)
        {
            //nesneler arasi hiararsi ve bulara istenilezn zaman ulasmak akla gelmelidir
            //agac yapisi
            //bilesim

            Employee engin = new Employee { name="engin"};
            Employee salih = new Employee { name = "salih" };
            Employee derin = new Employee { name = "derin" };
            Employee ahmet = new Employee { name = "ahmet" };
            Contractor emin = new Contractor { name = "emin" };

            engin.AddSubordiny(salih);
            engin.AddSubordiny(derin);
            salih.AddSubordiny(ahmet);
            derin.AddSubordiny(emin);
            
            Console.WriteLine(derin.GetEnumerator());
            Console.WriteLine(engin.name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine("  {0}", manager.name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("        {0}", employee.name);

                }

            }

            Console.ReadLine();

        }

        interface IPerson
        {
            string name { get; set; }
        }

        class Contractor : IPerson
        {
            public string name { get ; set; }
        }

        class Employee : IPerson, IEnumerable<IPerson>
        {
            List<IPerson> _subordinary = new List<IPerson>();

            public void AddSubordiny(IPerson person)
            {
                _subordinary.Add(person);
            }

            public void RemoveSubordinary(IPerson person)
            {
                _subordinary.Remove(person);
            }

            public IPerson getSeubordines(int index)
            {
                return _subordinary[index];
            }
            public string name { get; set; }

            public IEnumerator<IPerson> GetEnumerator()
            {
                foreach (var subordinary in _subordinary)
                {
                   yield return subordinary;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
