using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        //caslama sistemine benzete biliriz
        // bir sinif dusunun sinifin cagirdigi bi islem var ilk kez o islemi yapar ikinci kere cagirilinda
        //daha once cagrilmissa onu kullanma uzerinde bir yapidir
        //yeniden cagirmama adina hizlendirma mexanizmidir
        static void Main(string[] args)
        {
            CrediBase credi = new CrediManagerProcy();
            Console.WriteLine(credi.Cacluator());
            Console.WriteLine(credi.Cacluator());
         
        }

        public abstract class CrediBase
        {
            public abstract int Cacluator();
        }

        class CrediManager : CrediBase
        {
            public override int Cacluator()
            {
                int result = 1;
                for (int i = 0; i < 5; i++)
                {
                    result += i;
                    Thread.Sleep(1000);

                }
                return result;
            }
        }

        class CrediManagerProcy : CrediBase
        {
            CrediManager _crediManager;
            int _cashedValued;
            public override int Cacluator()
            {
                if (_crediManager == null)
                {
                    _crediManager = new CrediManager();
                    _cashedValued = _crediManager.Cacluator();
                }
                return _cashedValued;
            }
        }




    }
}
