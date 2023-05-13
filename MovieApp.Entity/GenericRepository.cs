using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entity
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        ApplicationEfContext context = new ApplicationEfContext();
        public bool Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool Delete(object key)
        {
            var entity = GetById(key);
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return true;
        }

        public TEntity GetById(object key)
        {
            return context.Set<TEntity>().Find(key);
        }

        public List<TEntity> List()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
