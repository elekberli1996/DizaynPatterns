using Ninject;
using System;

namespace M3.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<ProductDalEf>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
        interface IProductDal
        {
            void Save();
        }

        class ProductDalEf : IProductDal
        {
            public void Save()
            {
                Console.WriteLine("Saved with Ef");
            }
        }

        class ProductManager
        {
            private IProductDal _productDal;

            public ProductManager(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public void Save()
            {
                _productDal.Save();
            }
        }
    }
}
