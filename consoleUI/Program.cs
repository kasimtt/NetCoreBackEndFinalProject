using Business.Concrete;
using DataAccess.Abstract;
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
            ProductTest();
           // CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var categories = categoryManager.GetAll();

            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.getProductDetails())
            {
                Console.WriteLine(product.ProductName + "---" + product.CategoryName);
            }
        }
    }
}
