using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Implementations.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entity);
            ctx.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();   
                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                        // ctx.Products.Include("Category").Include... -->  // dbSet = ctx.Products = ctx.Set<TEntity>()
                        dbSet = dbSet.Include(include);
                }

                return dbSet.SingleOrDefault(predicate);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            // ctx.Products.Include("Category").Include("Employee")..Where(x=>x.Id >3).ToList();
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                // dbSet = ctx.Products

                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                        // ctx.Products.Include("Category").Include... -->  // dbSet = ctx.Products = ctx.Set<TEntity>()
                        dbSet = dbSet.Include(include);
                }
                // dbSet = ctx.Products.Include("Category")..

                if (predicate == null)
                    return dbSet.ToList();

                return dbSet.Where(predicate).ToList();
            }
        }

        public TEntity Insert(TEntity entity)
        {
            using var ctx = new TContext();

            var entityEntry =ctx.Set<TEntity>().Add(entity);
            
            ctx.SaveChanges();
            return entityEntry.Entity;
        }

        public void Update(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entity);
            ctx.SaveChanges();
        }
    }
}
