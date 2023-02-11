using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //genellikle ortaya nesne orneyi cikarmayi hedefler
            //bir biri arkasina atilan adimlarla sirasiyla islenmesi sonunda ortaya cikarilir
            //is katmanlarinda if le yazmak yerine ilgili nesneni enjekte edilmekleortaya nesne cikara biliriz
           ProductDirector productDirector = new ProductDirector();
            var bulder = new NewCustomerProductBulder();
          

            productDirector.GenerateProduct(bulder);
            var model = bulder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CatagoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.Discounted);

        }
        class ProductViewModel
        {
            public int Id { get; set; }
            public string CatagoryName { get; set; }

            public string ProductName { get; set; }

            public decimal UnitPrice { get; set; }

            public decimal Discounted { get; set; }

            public bool DiscountApplied { get; set; }
        }

        abstract class ProductBuilder
        {
            public abstract void GetProductData();
            public abstract void ApplyDiscount();

            public abstract ProductViewModel GetModel();
        }

        class NewCustomerProductBulder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
          

            public override void GetProductData()
            {
                model.Id = 1;
                model.CatagoryName = "chai";
                model.ProductName = "beverage";
                model.UnitPrice = 20;
      
            }
            public override void ApplyDiscount()
            {
                model.Discounted = model.UnitPrice * (decimal)0.5;
                model.DiscountApplied = true;
            }

            public override ProductViewModel GetModel()
            {
                return model;
            }
        }
        class OldCustomerProductBulder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void GetProductData()
            {
                model.Id = 1;
                model.CatagoryName = "chai";
                model.ProductName = "beverage";
                model.UnitPrice = 20;
            }
            public override void ApplyDiscount()
            {

                model.Discounted = model.UnitPrice;
                model.DiscountApplied = false;

            }

            public override ProductViewModel GetModel()
            {
                return model;
            }

           


        }
        class Dicconted20faizProduct : ProductBuilder
        {
            ProductViewModel product = new ProductViewModel();
            public override void ApplyDiscount()
            {
                product.DiscountApplied = true;
                product.Discounted = product.UnitPrice * (decimal)0.5;
                
            }

            public override ProductViewModel GetModel()
            {
                return product;
            }

            public override void GetProductData()
            {
                product.ProductName = "leptop";
                product.Id = 2;
                product.UnitPrice = 2000;
                product.CatagoryName = "elektronik";
            }
        }
        class ProductDirector
        {
            public void GenerateProduct(ProductBuilder productBuilder)
            {
                productBuilder.GetProductData();
                productBuilder.ApplyDiscount();
            }
        }




















    }
}
