using ADSReminder.DataAccess.Abstraction;
using ADSReminder.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADSReminder.DataAccess.Concrete.Mock
{
    public class MosckGenericRepositıry : IGenericRepository
    {
        List<object> mList;
        public MosckGenericRepositıry(List<object> argList)
        {
            mList = argList;
        }
        public async Task fnDeleteAsync<T>(T argObject) where T : BaseEntity, new()
        {
            await Task.Run(() => mList.Remove(argObject));
        }

        public async Task<bool> fnExistAsync<T>(Expression<Func<T, bool>> argFiter) where T : BaseEntity, new()
        {
            var lcResult = mList.OfType<T>().AsQueryable().Any(argFiter);
            return await Task.FromResult(lcResult);
        }

        public async Task<T> fnGetFirstAsync<T>(Expression<Func<T, bool>> argFiter) where T : BaseEntity, new()
        {
            var lcResult = mList.OfType<T>().AsQueryable().FirstOrDefault(argFiter);
            return await Task.FromResult(lcResult);
        }

        public async Task<List<T>> fnGetListAsync<T>(Expression<Func<T, bool>> argFilter = null) where T : BaseEntity, new()
        {
            if (argFilter==null)
            {
                return await Task.FromResult(mList.OfType<T>().ToList());
            }
            else
            {
                var lcResult = mList.OfType<T>().AsQueryable().Where(argFilter).ToList();
                return await Task.FromResult(lcResult);
            }
        }

        public IQueryable<T> fnGetQueryableObjects<T>(Expression<Func<T, bool>> argFiter = null) where T : BaseEntity, new()
        {
            return mList.OfType<T>().AsQueryable();
        }

        public async Task<T> fnInsertAsync<T>(T argObject) where T : BaseEntity, new()
        {
            argObject.Id = mList.Count;
            mList.Add(argObject);
            return await Task.FromResult(argObject);
        }

        public async Task<T> fnUpdateAsync<T>(T argObject) where T : BaseEntity, new()
        {
            var lcFirst = mList.OfType<T>().FirstOrDefault(a => a.Id == argObject.Id);
            mList.Remove(lcFirst);
            mList.Add(argObject);
            return await Task.FromResult(argObject);
        }
    }
}
