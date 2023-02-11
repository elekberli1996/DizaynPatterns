using System;
using System.Collections.Generic;

namespace M.Command
{
    class Program
    {
        static void Main(string[] args)
        {

            // bir metin dosyasinda bi seyer yazib arka planda bir listede tutyruz
            //istenen zaman geri ala biliyoruz
            // robota yuklenen komutlar gibi de dusune biliriz
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
         
            

            StockControl stockControl = new StockControl();
            stockControl.TakeOrder(buyStock);
            stockControl.TakeOrder(buyStock);
            stockControl.TakeOrder(sellStock);
            stockControl.PlaceOrders();
            Console.ReadLine();


        }

        class StockManager
        {
            private string _name = "Leptop";
            private int _quantity = 10;

            public void Buy()
            {

                Console.WriteLine("Stock : {0},{1} bought", _name, _quantity);
            }
            public void Sell()
            {

                Console.WriteLine("Stock : {0},{1} sold", _name, _quantity);
            }

        }
        interface IOrder
        {
            void Excute();
        }

        class BuyStock : IOrder
        {
            private StockManager _stockManager;

            public BuyStock(StockManager stockManager)
            {

                _stockManager = stockManager;
            }
            public void Excute()
            {
                _stockManager.Buy();
            }
        }
        class SellStock : IOrder
        {
            private StockManager _stockManager;

            public SellStock(StockManager stockManager)
            {

                _stockManager = stockManager;
            }
            public void Excute()
            {
                _stockManager.Sell();
            }
        }

        class StockControl
        {
            List<IOrder> _orders = new List<IOrder>();
            public void TakeOrder(IOrder order)
            {
                _orders.Add(order);
            }

            public void PlaceOrders()
            {
                foreach (var order in _orders)
                {
                    order.Excute();

                }

                _orders.Clear();
            }

        }

    }
}
