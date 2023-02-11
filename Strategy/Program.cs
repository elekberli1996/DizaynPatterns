using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //strategi berileyib o straterijiye gore metodu kullanmakdir
            CustomerManager customerManager = new CustomerManager(new after2010Caclator());
        
            customerManager.SaveCredit();
            Console.ReadLine();
        }

        abstract class KereditCacluatorBase
        {
            public abstract void Cacluate();
        }

        class before2010Caclator : KereditCacluatorBase
        {
            public override void Cacluate()
            {
                Console.WriteLine("Kredit 2010dan once icin hesaplandi");
            }
        }

        class after2010Caclator : KereditCacluatorBase
        {
            public override void Cacluate()
            {
                Console.WriteLine("Kredit 2010dan sonra icin hesaplandi");
            }
        }

        class CustomerManager
        {
            KereditCacluatorBase _kereditCacluatorBase;
            public CustomerManager(KereditCacluatorBase kereditCacluatorBase)
            {
                _kereditCacluatorBase = kereditCacluatorBase;
            }
            public void SaveCredit()
            {
                Console.WriteLine("Customer manager business");

                _kereditCacluatorBase.Cacluate();

            }
        }
    }
}
