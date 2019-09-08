using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BdMarketWebApp.Gateway.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private DbContext context;

        public Repository(DbContext _context)
        {
            this.context = _context;
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public bool IsExists(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Any(expression);
        }
    }
}
