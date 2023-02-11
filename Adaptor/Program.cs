using System;

namespace Adaptor
{
    class Program
    {
        static void Main(string[] args)
        {
            // adapor deseni projemize baska bi sistem eklenen zaman projemiz kodalri deismemelidir
            //farkli sistenin kendi sistemimize entegre edildiyi zaman kendi sistemimizin bozulmadan farkli sistemi
            //kendi sistemimiz gibi kullanmasidir
            ProductManager product = new ProductManager(new log4NetAdaptor());
            product.Save();
            Console.ReadLine();
        }

        interface ILogger
        {
            void Log(string message);
        }
        class ProductManager
        {
            ILogger _logger;

            public ProductManager(ILogger logger)
            {
                _logger = logger;
            }
            public void Save()
            {
                Console.WriteLine("kaydedildi");
                _logger.Log("user eklendi");
            }

        }

        class EdLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logged: {0}", message);
            }
        }

        class log4Net
        {
            public void LogMessage(string message)
            {
                Console.WriteLine("Logged for net4: {0}", message);
            }

        }

        class log4NetAdaptor : ILogger
        {
            public void Log(string message)
            {
                log4Net log4Net = new log4Net();
                log4Net.LogMessage(message);
            }
        }

    }
}
