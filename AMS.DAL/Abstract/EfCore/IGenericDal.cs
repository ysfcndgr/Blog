using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Abstract.EfCore
{
    public interface IGenericDal<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null);
        TEntity? GetById(int id);
    }
}
