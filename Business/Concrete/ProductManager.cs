using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
