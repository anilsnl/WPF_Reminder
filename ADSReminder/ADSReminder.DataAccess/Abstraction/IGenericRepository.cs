using ADSReminder.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADSReminder.DataAccess.Abstraction
{
    public interface IGenericRepository
    {
        /// <summary>
        /// Get first item according to the passing filter.
        /// </summary>
        /// <typeparam name="T">DB Object type.</typeparam>
        /// <param name="argFiter"></param>
        /// <returns></returns>
        Task<T> fnGetFirstAsync<T>(Expression<Func<T, bool>> argFiter) where T:BaseEntity,new();
        /// <summary>
        /// Get DB object list according to the passing fiter.
        /// </summary>
        /// <typeparam name="T">DB Object type.</typeparam>
        /// <param name="argFilter"></param>
        /// <returns></returns>
        Task<List<T>> fnGetListAsync<T>(Expression<Func<T, bool>> argFilter = null) where T : BaseEntity, new();
        /// <summary>
        /// Get queryable object.
        /// </summary>
        /// <typeparam name="T">DB Object type</typeparam>
        /// <param name="argFiter"></param>
        /// <returns></returns>
        IQueryable<T> fnGetQueryableObjects<T>(Expression<Func<T, bool>> argFiter = null) where T : BaseEntity, new();
        /// <summary>
        /// Inserts the passing item to the DB and retuns the inserted item.
        /// </summary>
        /// <typeparam name="T">Type of inserted object.</typeparam>
        /// <param name="argObject"></param>
        /// <returns></returns>
        Task<T> fnInsertAsync<T>(T argObject) where T : BaseEntity, new();
        /// <summary>
        /// Update the passing item to the DB and retuns the inserted item.
        /// </summary>
        /// <typeparam name="T">Type of updated object.</typeparam>
        /// <param name="argObject"></param>
        /// <returns></returns>
        Task<T> fnUpdateAsync<T>(T argObject) where T : BaseEntity, new();
        /// <summary>
        /// Deletes the passing objects from the databse.
        /// </summary>
        /// <param name="argObject"></param>
        void fnDeleteAsync(BaseEntity argObject);
    }
}
