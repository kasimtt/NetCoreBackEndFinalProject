
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
// kor katmanı diğer katmanları referans almaz
namespace Core.DataAccess
{  //generic constrain
    public interface IEntityRepository<T> where T: class,IEntity,new() // IEntity'i implemente eden bi class olabilir.
    {  
        //butun varlıkların ortak database imzasını taşır
        List<T> GetAll(Expression<Func<T,bool>> filter = null);  //filtreleme için kullanılır
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      

    }
}
