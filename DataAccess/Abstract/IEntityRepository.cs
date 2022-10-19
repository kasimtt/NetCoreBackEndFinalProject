using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{  //generic constrain
    public interface IEntityRepository<T> where T: class,IEntity,new() // IEntity'i implemente eden bi class olabilir.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);  //filtreleme için kullanılır
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      

    }
}
