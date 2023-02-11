using System;

namespace Singlaton
{
    class Program
    {
        static void Main(string[] args)
        {
            //singlton dizayn patterni nesne orneyini bi kere uretib baska yerlerde onu kullanmakdir
            //nesnenin orneyinin deyerini bir cok kullanici tarafindan deisdiyi zaman ayni
            //sekilde kullanilmasini amaclar
            //bir nesnenin durumunun kontrol edilmesidir
            //bir nesne orneyini katmnlar arasina kecerken islem yapiyorsa deyer tutmuyorsa kullanmakda fayda yapar
            //manager katmani meselen newleme en pahali nesnedir 
            //ne zaman kullanilir, bellekde sabit kalir singilton
            var customer = CustomerManager.CreateSinglation();
            customer.Save();
        }


        class CustomerManager
        {
            private static CustomerManager _customerManager;

            static object _lockObject = new object();
            private CustomerManager()
            {

            }

            public static CustomerManager CreateSinglation()
            {
                lock (_lockObject)
                {
                    if (_customerManager==null)
                    {
                        _customerManager = new CustomerManager();
                    }

                }
                return _customerManager;

               
                //daha once olusturulmusa olusturulmamissa olustur dondur
                // burda orneyi olsturub is katmaninda newleme etmirik
            
            }
            public void Save()
            {
                Console.WriteLine("kayd edildi");
            }
        }
    }
}
