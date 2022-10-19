using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace consoleUI
{
    class Program
    {
        //Solid 
        //open-closed prencible
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByPrice(40,100))
            {
                Console.WriteLine(product.UnitPrice);
            }
        }
    }
}
