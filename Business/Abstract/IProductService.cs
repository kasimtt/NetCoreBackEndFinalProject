using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();  // hem data doner hemde sonuc doner   
        IDataResult<List<Product>> GetAllByCategoryId(int id); //datamız generic olarak yazılandır
        IDataResult<List<Product>> GetAllByPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailsDto>> getProductDetails();
        IDataResult<Product>  getProductId(int productId);
        IDataResult<IResult> Add(Product product); //IResult voidler icin kullanıldı. işlem sonucunun başarı durumunu donderir ama data dönmez

    }
}
