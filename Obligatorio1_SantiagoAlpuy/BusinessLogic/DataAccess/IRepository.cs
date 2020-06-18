using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.DataAccess
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        T Find(int id);
        T Find(Expression<Func<T, bool>> predicate);
        ICollection<T> GetEntitiesByPredicate(Expression<Func<T, bool>> predicate);
        ICollection<T> GetAll();
        ICollection<T> GetAllWithInclude(string entitiesToInclude);
        void Remove(T entity);
        void ClearAll();
    }
}
