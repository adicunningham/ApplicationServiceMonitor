using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApplicationStatusMonitor.Data.Extensions;

namespace ApplicationStatusMonitor.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationServiceDb _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(ApplicationServiceDb context)
        {
            _context = context; 
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Returns a list of type TEntity which can be filtered or orderby specified parameters.
        /// </summary>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderby">Order by criteria</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>,
                                        IOrderedQueryable<TEntity>> orderby = null,
                                        string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>,
                                        IOrderedQueryable<TEntity>> orderby = null,
                                        params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = query.IncludeMultiple(includes);
            }

            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }


        /// <summary>
        /// Returns entity by Id value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Insert entity to database context.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Delete entity by Id value.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entityToDelete"></param>
        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
