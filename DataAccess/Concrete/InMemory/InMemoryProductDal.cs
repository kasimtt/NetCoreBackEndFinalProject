using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _product;

        public InMemoryProductDal()
        { //kod içinde yapılan işlemlerdir. Daha sonra sql kullanılacak
            _product = new List<Product> {
            new Product {CategoryId = 1, ProductId = 1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock = 15},
            new Product {CategoryId = 2, ProductId = 2,ProductName = "Kamera",UnitPrice = 5000,UnitsInStock = 30},
            new Product {CategoryId = 3, ProductId = 3,ProductName = "Telefon",UnitPrice = 4500,UnitsInStock = 14},
            new Product {CategoryId = 4, ProductId = 4,ProductName = "Laptop",UnitPrice = 17000,UnitsInStock = 45},
            new Product {CategoryId = 5, ProductId = 5,ProductName = "Fare",UnitPrice = 500,UnitsInStock = 19},
            };
        }
        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            //Linq --> Language integrated query
            Product productToDelete =_product.SingleOrDefault(p=>p.ProductId == product.ProductId); //her p icin p'nin ProductId'sini verilen productId ile karşılaştırır.
            _product.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _product;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _product.Where(p => p.CategoryId == categoryId).ToList(); // categoryId' ye eşitse listeler
        }

        public void Update(Product product)
        {
            Product productToUpdate = _product.SingleOrDefault(p => p.ProductId == product.ProductId);
          
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
