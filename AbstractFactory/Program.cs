using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //toplu nesne kullaniminda kullanilir
            //is katmaninda loglama cash kullanilir
            //loglamanin cesitli yontemi var ceshin cesitli yontemi var
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.Save();
            ProductManager productManager1 = new ProductManager(new Factory2());
            Console.WriteLine("**************");
            productManager1.Save();
        
        }

        public abstract class Logging
        {
            public abstract void Log(string message);
        }

        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logging with log4net");
            }
        }

        public class NLoger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logging with nLogger");
            }
        }

        public abstract class Caching
        {
            public abstract void Cach(string data);
        }

        public class MemCache : Caching
        {
            public override void Cach(string data)
            {
                Console.WriteLine("cashing memcesh");
            }
        }

        public class RedisCache : Caching
        {
            public override void Cach(string data)
            {
                Console.WriteLine("cashing with rediscah");
            }
        }

        public abstract class CrosCuttingConcernsFactory
        {
            public abstract Logging CreateLogging();
            public abstract Caching CreateCahing();


        }

        public class Factory1 : CrosCuttingConcernsFactory
        {
            public override Caching CreateCahing()
            {
                return new RedisCache();
            }

            public override Logging CreateLogging()
            {
                return new Log4NetLogger();
            }
        }

        public class Factory2 : CrosCuttingConcernsFactory
        {
            public override Caching CreateCahing()
            {
                return new RedisCache();
            }

            public override Logging CreateLogging()
            {
                return new NLoger();
            }
        }

        public class ProductManager
        {
            private CrosCuttingConcernsFactory _crosCuttingConcernsFactory;
            private Logging _logging;
            private Caching _caching;
            public ProductManager(CrosCuttingConcernsFactory crosCuttingConcernsFactory)
            {
                _crosCuttingConcernsFactory = crosCuttingConcernsFactory;
                _caching = _crosCuttingConcernsFactory.CreateCahing();
                _logging = _crosCuttingConcernsFactory.CreateLogging();
            }
            public void Save()
            {
                Console.WriteLine("kayedildi");
             
                _logging.Log("");
                _caching.Cach("");
            }
        }
    }
}
