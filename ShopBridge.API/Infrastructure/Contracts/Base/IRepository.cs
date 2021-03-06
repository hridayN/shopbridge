using ShopBridge.API.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.API.Infrastructure.Contracts.Base
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Get All records
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Add records to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update Table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete data from table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Return all records in Queryable
        /// </summary>
        public IQueryable<T> GetAllData();

        /// <summary>
        /// Get records by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Return all records with order by
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsyncWithOrder(Expression<Func<T, bool>> spec, string orderByColumn, bool isOrderBy);

        /// <summary>
        /// Return one record with order by
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        Task<T> GetOneAsyncWithOrder(Expression<Func<T, bool>> spec, string orderByColumn, bool isOrderBy);
    }
}
