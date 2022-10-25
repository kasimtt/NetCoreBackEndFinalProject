using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;  //injection,  bağımlılığı azaltır.
        public ProductManager(IProductDal productDal)  //ilgili veri tabanı alınır.
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //iş kodları
            // yetki sorgulaması
            return _productDal.GetAll(); //verileri DataAccess katmanından çağırır.
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            return _productDal.GetAll(p => p.CategoryId == Id);
        }

        public List<Product> GetAllByPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min);
        }

        public List<ProductDetailsDto> getProductDetails()
        {
            return _productDal.getProductDetails();
        }
    }
}
