using Business.Abstract;
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

        public List<Category> GetAll()
        {
            // iş kodları
           return categoryDal.GetAll();
        }

        public Category GetById(int category)
        {
            return categoryDal.Get(c => c.CategoryId == category);
        }
    }
}
