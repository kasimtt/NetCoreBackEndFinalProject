using Business.Abstract;
using Business.BusinessAspect.Autofact;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;  //injection,  bağımlılığı azaltır.
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)  //ilgili veri tabanı alınır.
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
     
        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.add,admin")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName),
                CheckIfCategoryLimitExceeded());
           
            if(result !=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 2)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed); //verileri DataAccess katmanından çağırır.
        }

        public IDataResult<List<Product>>GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<List<Product>> GetAllByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            if(DateTime.Now.Hour==14)
            {
                return new ErrorDataResult<List<ProductDetailsDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.getProductDetails(),Messages.ProductListed);
        }
        [CacheAspect]
        public IDataResult<Product> GetProductById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.get")]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryExceed);
            }
            _productDal.Update(product);
            return new SuccessResult();
        }
       /************************************************************************************************************************************/
        private IResult CheckIfCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryExceed);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if(result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();
            
            if(result.Data.Count>=15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }
        //Test işlemidir
        [TransactionScopeAspect]
        public IResult AddTransactionTest(Product product)
        {
            Add(product);
            if(product.UnitPrice<10)
            { 
                throw new Exception("hatasız kul olmaz hatamla sev beni");
            }
           
            Add(product);
            return null;
        }
    }
}
