using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            //business code
           
            if(product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);  // Messages sınıfından "geçersiz isimlendirme" uyarısı gelir
            }
           
            _productDal.Add(product);
           return  new SuccesResult(Messages.ProductAdded); // Messages sınıfından "proje eklendi" uyarısı gelir
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }

            return new SuccesDataResult<List<Product>>(_productDal.GetAll(),true,"ürünler listelendi"); //verileri DataAccess katmanından çağırır.
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

        public Product getProductId(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

       
    }
}
