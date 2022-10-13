using AMS.DAL.Abstract.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Concrete.EfCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().AsNoTrackingWithIdentityResolution().ToList();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null ? context.Set<TEntity>().AsNoTrackingWithIdentityResolution().ToList()
                    : context.Set<TEntity>().Where(filter).AsNoTrackingWithIdentityResolution().ToList();
            }
        }

        public TEntity? GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
