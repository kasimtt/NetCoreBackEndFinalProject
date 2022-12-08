using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public IResult Added(Category category)
        {
            categoryDal.Add(category);
            return new SuccessResult(Messages.AddedCategory);
        }

        public IResult Deleted(Category category)
        {
            categoryDal.Delete(category);
            return new SuccessResult();  // burada kalmıştr8k
        }

        public IDataResult<List<Category>> GetAll()
        {
            // iş kodları
           return new SuccessDataResult<List<Category>>(categoryDal.GetAll()); // buraya olumsuzlar eklenecek
        }

        public IDataResult<Category> GetById(int category)
        {

            return new SuccessDataResult<Category>(categoryDal.Get(c => c.CategoryId == category));
        }
    }
}
