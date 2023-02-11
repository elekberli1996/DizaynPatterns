using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //gunumuzde en sik kullanilan dizayn paternidir
            //amac yazilimda deisimi kontrol altinda tutmakdir
            //deiskenlik gostericek bir yapiyi barindirir
            //bir klass ciplak duruyorsa korkun
            CustomerManager customer = new CustomerManager(new LoggerFactory2());
            customer.save();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new log4netLogger();
        }

    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();

    }
    public interface ILogger
    {
        void log();
    }

    public class EdLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("logged with ed");

        }
    }

    public class log4netLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("logged with 4net");

        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void save()
        {
            Console.WriteLine("saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.log();
        }
    }
}
