using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BdMarketWebApp.Gateway.IRepositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        bool IsExists(Expression<Func<TEntity, bool>> expression);
    }
}
