using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Database.Repository.Interface
{
   public interface IGenericRepository<T>
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter,
            string includeProperties);
        T GetByID(object id);
        void Insert(T entity);
        void Delete(object id);
        void Update(T entityToUpdate);
    }
}
