using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class RepositoryA<T>  where T : class
    {
        DbSet<T> contextEntity;

        public void Add(T entity)
        {
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
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
                var query = from row in contextEntity
                            select row;
                collection = query.ToList<T>();
                context.SaveChanges();
            }
            return collection;
        }

        public ICollection<T> GetAllWithInclude(string entityToInclude)
        {
            ICollection<T> collection = null;
            using (Context context = new Context())
            {
                contextEntity = context.Set<T>();
                var query = from row in contextEntity.Include(entityToInclude)
                            select row;
                collection = query.ToList<T>();
                context.SaveChanges();
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
    }
}
