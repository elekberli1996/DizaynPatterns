using System;
using System.Collections.Generic;

namespace M2.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //genel olarak kullanimi hierarsik nesnelerin
            //biri  uzerinden ayni metodun cagrilmasi surecidir,

            Manager engin = new Manager { Name = "engin", Salary = 1000 };
            Manager salih = new Manager { Name = "salih", Salary = 900 };

            Worker derin = new Worker { Name = "derin", Salary = 800 };
            Worker ali = new Worker { Name = "ali", Salary = 800 };

            engin.Subordinates.Add(salih);
            salih.Subordinates.Add(derin);
            salih.Subordinates.Add(ali);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(salih);

            PayrolVisitor payrolVisitor = new PayrolVisitor();

            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organizationalStructure.Accept(payrolVisitor);

            organizationalStructure.Accept(payriseVisitor);

            Console.ReadLine();
        }
        public class OrganizationalStructure
        {
            public EmployeeBase Employee;
            public OrganizationalStructure(EmployeeBase firstEmployee)
            {
                Employee = firstEmployee; 
            }
            public void Accept(VisitorBase visitor)
            {
                Employee.Accept(visitor);
            }
        }

        public abstract class EmployeeBase
        {

            public abstract void Accept(VisitorBase visitor);

            public string Name { get; set; }

            public decimal Salary { get; set; }
        }
        public class Manager : EmployeeBase
        {
            public List<EmployeeBase> Subordinates { get; set; }
            public Manager()
            {
                Subordinates = new List<EmployeeBase>();
            }
            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
                foreach (var employee in Subordinates)
                {
                    employee.Accept(visitor);

                }
            }
        }
        public class Worker : EmployeeBase
        {
            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
            }
        }



        public abstract class VisitorBase
        {
            public abstract void Visit(Manager manager);
            public abstract void Visit(Worker worker);
        }

        public class PayrolVisitor : VisitorBase
        {
            public override void Visit(Manager manager)
            {
                Console.WriteLine("{0} paid {1}", manager.Name,manager.Salary);
            }

            public override void Visit(Worker worker)
            {
                Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
            }
        }

        public class PayriseVisitor : VisitorBase
        {
            public override void Visit(Manager manager)
            {
                Console.WriteLine("{0} salary increased {1}", manager.Name, manager.Salary*(decimal)1.3);
            }

            public override void Visit(Worker worker)
            {
                Console.WriteLine("{0} salary increased {1}", worker.Name, worker.Salary * (decimal)1.1);
            }
        }

    }
}
