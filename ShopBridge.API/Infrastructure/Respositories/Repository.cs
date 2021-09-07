using Common.Utility.Contracts;
using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Infrastructure.Contracts.Base;
using ShopBridge.API.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.API.Infrastructure.Respositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        /// Db Context
        /// </summary>
        protected readonly ShopBridgeProductDbContext _dbContext;

        protected readonly IExpressionFilter _expressionFilter;

        public Repository(ShopBridgeProductDbContext dbContext, IExpressionFilter expressionFilter)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _expressionFilter = expressionFilter;
        }

        /// <summary>
        /// Add Record to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Delete from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Return all records with order by
        /// </summary>
        public IQueryable<T> GetAllData()
        {
            IQueryable<T> record = _dbContext.Set<T>();
            return record;
        }

        /// <summary>
        /// Get records by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Update an entry in table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        /// <summary>
        /// Return all records with order by
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAllAsyncWithOrder(Expression<Func<T, bool>> spec, string orderByColumn, bool isOrderBy)
        {
            IQueryable<T> record = _dbContext.Set<T>().Where(spec);
            if (!string.IsNullOrEmpty(orderByColumn))
            {
                record = _expressionFilter.OrderByDynamic<T>(record, orderByColumn, out bool isValid, isOrderBy);
            }
            return await record.ToListAsync();
        }

        /// <summary>
        /// Return one record with order by
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        public async Task<T> GetOneAsyncWithOrder(Expression<Func<T, bool>> spec, string orderByColumn, bool isOrderBy)
        {
            IQueryable<T> record = _dbContext.Set<T>().Where(spec);
            if (!string.IsNullOrEmpty(orderByColumn))
            {
                record = _expressionFilter.OrderByDynamic<T>(record, orderByColumn, out bool isValid, isOrderBy);
            }
            return await record.FirstOrDefaultAsync();
        }
    }
}
