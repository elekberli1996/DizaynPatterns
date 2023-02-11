using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            //uygulamasi en basit tasarim desenidir
            //uygulamasi kolaydir
            //kelime anlami cephe demekedir
            //amac su cesitli siniflarimiz var ve her seferinde ortak amaclar icin kullaniyoruz
            //burda her bir sinifa tek tek ulasmakdans abulari
            //bir cephede toplayib bunlara erismeyi kolaylastiryoruz
            CustumerManager custumerManager = new CustumerManager();
            custumerManager.Save();
            Console.ReadLine();
        }

     

    }
    class Logging : Ilogger
    {
        public void log()
        {
            Console.WriteLine("logged");
        }
    }

    interface Ilogger
    {
        void log();
    }
    class Cashing : ICashing
    {
        public void Cash()
        {
            Console.WriteLine("cashed");
        }
    }
    interface ICashing
    {
        void Cash();
    }
    class Autorize : IAutorize
    {
        public void Checked()
        {
            Console.WriteLine("checked");
        }
    }

    interface IAutorize
    {
        void Checked();
    }
    class Validate : IValidate
    {
        void IValidate.Validate()
        {
            Console.WriteLine("Validate");
        
    }

       
       
    }

    interface IValidate
    {
        void Validate();
    }

    class CustumerManager
    {
        CrossCuttingConcernFacade _concern;
        public CustumerManager()
        {
            _concern = new CrossCuttingConcernFacade();
        }

        public void Save()
        {
            _concern.logger.log();
            _concern.cashing.Cash();
            _concern.autorize.Checked();
            _concern.validate.Validate();
            Console.WriteLine("keydedildi");
        }

    }

    class CrossCuttingConcernFacade
    {
        public Ilogger logger;
        public ICashing cashing;
        public IAutorize autorize;
        public IValidate validate;

        public CrossCuttingConcernFacade()
        {
            cashing = new Cashing();
            logger = new Logging();
            autorize = new Autorize();
            validate = new Validate();
        }
    }
}
