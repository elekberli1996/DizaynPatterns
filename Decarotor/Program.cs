using System;

namespace Decarotor
{
    class Program
    {
        static void Main(string[] args)
        {
            //elimizde bir nesne mevcut iken bu nesneyi farkli kosullarda daha farkli anlamlar yuklemek ucun
            //kullandigimiz dizayn paternidir
            //susleyici
            PeronalCar peronalCar = new PeronalCar { Make = "hubday", Model = "accent", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(peronalCar);
            specialOffer.Disconted = 20;
            Console.WriteLine("Concretate {0}", peronalCar.HirePrice);
            Console.WriteLine("Speciral {0}", specialOffer.HirePrice);
        }

        abstract class CarBase
        {
            public abstract string Make { get; set; }
            public abstract string Model { get; set; }

            public abstract decimal HirePrice { get; set; }
        }

        class PeronalCar : CarBase
        {
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }

        class CommercialCar : CarBase
        {
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }

        abstract class DeceratorBase : CarBase
        {
            private CarBase _carBase;

            protected DeceratorBase(CarBase carBase)
            {
                _carBase = carBase;
            }
        }

        class SpecialOffer : DeceratorBase
        {
            private readonly CarBase _carbase;

            public int Disconted { get; set; }
            public SpecialOffer(CarBase carBase) : base(carBase)
            {
                _carbase = carBase;
            }
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice {
                get { return _carbase.HirePrice-   _carbase.HirePrice*Disconted/100; }
                set { }
            }
                
        }




    }
}
