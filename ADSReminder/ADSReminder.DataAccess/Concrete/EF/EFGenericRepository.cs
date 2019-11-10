using ADSReminder.DataAccess.Abstraction;
using ADSReminder.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADSReminder.DataAccess.Concrete.EF
{
    public class EFGenericRepository:IGenericRepository
    {
        private ADSReminderDBContext mContext;
        private ADSReminderDBContext Context
        {
            get
            {
                if (mContext==null)
                {
                    mContext = new ADSReminderDBContext();
                }
                return mContext;
            }
        }

        public async void fnDeleteAsync(BaseEntity argObject)
        {
            await Task.Run(() =>
            {
                Context.Entry(argObject).State = EntityState.Deleted;
                Context.SaveChangesAsync();
            });
        }

        public async Task<T> fnGetFirstAsync<T>(Expression<Func<T, bool>> argFiter) where T : BaseEntity, new()
        {
            return await Context.Set<T>().FirstOrDefaultAsync(argFiter);
        }

        public async Task<List<T>> fnGetListAsync<T>(Expression<Func<T, bool>> argFilter = null) where T : BaseEntity, new()
        {
            if (argFilter == null)
                return await Context.Set<T>().ToListAsync();
            return await Context.Set<T>().Where(argFilter).ToListAsync();
        }

        public IQueryable<T> fnGetQueryableObjects<T>(Expression<Func<T, bool>> argFiter = null) where T : BaseEntity, new()
        {
            return Context.Set<T>();
        }

        public async Task<T> fnInsertAsync<T>(T argObject) where T : BaseEntity, new()
        {
            Context.Set<T>().Add(argObject);
            await Context.SaveChangesAsync();
            return argObject;
        }

        public async Task<T> fnUpdateAsync<T>(T argObject) where T : BaseEntity, new()
        {
            Context.Entry(argObject).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return argObject;
        }
    }
}
