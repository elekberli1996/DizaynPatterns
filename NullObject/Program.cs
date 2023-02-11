using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {//meselen test islemi zamani ILoggere bagli kalir ve mutleq newleme edilmelidir

            CustomerManager customerManager = new CustomerManager(new Log4Net());
            //  customerManager.Save();
            CustomerManagerTest customerManagerTest = new CustomerManagerTest();
            customerManagerTest.Save();
            Console.ReadLine();
           
        }

        public interface ILogger
        {
            void Log();
        }
        public class Log4Net : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logger for4net logger");

            }
        }


        public class NLog : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logger Nlog logger");

            }
        }

        public class StubLogger : ILogger
        {
            private static StubLogger _stubLogger;

            static object _lockObject = new object();

            private StubLogger()
            {
                    
            }

            public static StubLogger CreateIntsance()
            {
                lock (_lockObject)
                {
                    if (_stubLogger==null)
                    {
                        _stubLogger = new StubLogger();
                    }

                }
                return _stubLogger;
            }
            public void Log()
            {
              

            }
        }

        public class CustomerManager
        {
            private ILogger _logger;
            public CustomerManager(ILogger logger)
            {

                _logger = logger;

            }

            public void Save()
            {
                Console.WriteLine("saved");
                _logger.Log();
            }
        }

         public class CustomerManagerTest
        {
            public void Save()
            {

                CustomerManager customerManager = new CustomerManager(StubLogger.CreateIntsance());
                customerManager.Save();
            }
        }
    }
}
