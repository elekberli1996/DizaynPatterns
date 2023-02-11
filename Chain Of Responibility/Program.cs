using System;

namespace Chain_Of_Responibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //bu desen belli sarta gore bizim hangi nesyneyi devreye koyucagmizi  saglar
            //bir sirketde eyer harcama 100 lira altindaysa mudur harcamaya onay verir
            //harcamma 1000 lirqaya yakinsa baskan yardimcisi onay vere bilir
            //harcamam 1000den yukariysa baskan onaylar
            //sorumluluk zinciri
            Manager manager = new Manager();
            VisePrexident vise = new VisePrexident();
            Prezident prezident = new Prezident();
            manager.SetSuccesor(vise);
            vise.SetSuccesor(prezident);
            Expense expense = new Expense { Amount = 71, Detail = "j" };
            manager.HandleExpence(expense);
        }
        class Expense
        {
            public string Detail { get; set; }
            public decimal Amount { get; set; }
        }

        abstract class ExpenseHandleBase
        {
            protected ExpenseHandleBase Successor;
            public abstract void HandleExpence(Expense expense);

            public void SetSuccesor(ExpenseHandleBase successor)
            {
                Successor = successor;
            }

        }

        class Manager : ExpenseHandleBase
        {
            public override void HandleExpence(Expense expense)
            {
               if (expense.Amount < 100)
                {
                    Console.WriteLine("handle by manager");

                }
               else if (Successor !=null)
                {
                    Successor.HandleExpence(expense);
                }
            }
        }
        class VisePrexident : ExpenseHandleBase
        {
            public override void HandleExpence(Expense expense)
            {
               if (expense.Amount>100 && expense.Amount < 1000)
                {
                    Console.WriteLine("handle by visePrezdent");
                }

               else if (Successor != null)
                {
                    Successor.HandleExpence(expense);
                }
            }
        }

        class Prezident : ExpenseHandleBase
        {
            public override void HandleExpence(Expense expense)
            {
                if (expense.Amount > 1000)
                {
                    Console.WriteLine("handle by Prezdent");
                }

               
            }

        }

    }
}
