using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //gozlemci
            //observer design patern kendisine abune olan sistemleri bir islem
            //oldugunda devreye girmesini saglayan
            //tasarim desenidir
            ProductManager product = new ProductManager();
            product.Attach(new EmployeerObserver());
            CustomerObserver customer = new CustomerObserver();
            product.Attach(customer);
           // product.Detach(customer);
            product.UpdatePrice();
            
        }

        class ProductManager
        {
            List<Observer> _observer = new List<Observer>();
            public void UpdatePrice()
            {
                Console.WriteLine("ProductPrice Changed");
                Notify();
            }

            public void Attach(Observer observer)
            {
                _observer.Add(observer);
            }

            public void Detach(Observer observer)
            {
                _observer.Remove(observer);
            }


            private void Notify()
            {
                foreach (var observer in _observer)
                {
                    observer.Update();
                }
            }


        }

        abstract class Observer
        {
            public abstract void Update();
        }

        class CustomerObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Product pRice Changed Message to Customers");
            }
        }


        class EmployeerObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Product pRice Changed Message to Employee");
            }
        }
    }
}
