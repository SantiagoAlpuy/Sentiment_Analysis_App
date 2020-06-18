using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BusinessLogic.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> contextEntity;

        public void Add(T entity)
        {
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                contextEntity.Attach(entity);
                contextEntity.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                contextEntity.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public T Find(int id)
        {
            T element = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                element = contextEntity.Find(id);
            }
            return element;
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            T element = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                element = contextEntity.FirstOrDefault(predicate);
            }
            return element;
        }

        public ICollection<T> GetEntitiesByPredicate(Expression<Func<T, bool>> predicate)
        {
            ICollection<T> collection = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                collection = contextEntity.Where(predicate).ToList();
            }
            return collection;
        }

        public ICollection<T> GetAll()
        {
            ICollection<T> collection = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                collection = contextEntity.ToList();
            }
            return collection;
        }

        public ICollection<T> GetAllWithInclude(string entitiesToInclude)
        {
            ICollection<T> collection = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                collection = contextEntity.Include(entitiesToInclude).ToList();
            }
            return collection;
        }

        public void Remove(T entity)
        {
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                contextEntity.Attach(entity);
                contextEntity.Remove(entity);
                context.SaveChanges();
            }
        }

        public void ClearAll()
        {
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                contextEntity.RemoveRange(contextEntity);
                context.SaveChanges();
            }
        }
    }
}
