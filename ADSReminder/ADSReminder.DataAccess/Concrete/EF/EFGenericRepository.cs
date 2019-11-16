using ADSReminder.DataAccess.Abstraction;
using ADSReminder.Models.DBObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADSReminder.DataAccess.Concrete.EF
{
    public class EFGenericRepository : IGenericRepository
    {
        public async Task fnDeleteAsync<T>(T argObject) where T : BaseEntity, new()
        {
            try
            {
                using (var lcContext=new ADSReminderDBContext())
                {
                    var lcItem = await lcContext.Set<T>().Where(a => a.Id == argObject.Id).DeleteAsync(); 
                    //if (lcItem == null)
                    //    return;
                    //lcContext.Entry<T>(lcItem).State = EntityState.Deleted;
                    //await lcContext.Set<T>().RemoveAsync
                    await lcContext.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> fnExistAsync<T>(Expression<Func<T, bool>> argFiter) where T : BaseEntity, new()
        {
            try
            {
                using (var lcContext=new ADSReminderDBContext())
                {
                    return await lcContext.Set<T>().AnyAsync(argFiter);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> fnGetFirstAsync<T>(Expression<Func<T, bool>> argFiter) where T : BaseEntity, new()
        {
            try
            {
                using (var lcContext = new ADSReminderDBContext())
                {
                    return await lcContext.Set<T>().FirstOrDefaultAsync(argFiter);
                }
            }
            catch (DbEntityValidationException ex)
            {
                var lcErrorStr = string.Join(",", ex.EntityValidationErrors.SelectMany(a => a.ValidationErrors).Select(a => a.PropertyName + ":" + a.ErrorMessage));
                throw new Exception(lcErrorStr);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<T>> fnGetListAsync<T>(Expression<Func<T, bool>> argFilter = null) where T : BaseEntity, new()
        {
            try
            {
                var lcContext = new ADSReminderDBContext();
                if (argFilter == null)
                    return await lcContext.Set<T>().ToListAsync();
                return await lcContext.Set<T>().Where(argFilter).ToListAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw fnValidateException(ex);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IQueryable<T> fnGetQueryableObjects<T>(Expression<Func<T, bool>> argFiter = null) where T : BaseEntity, new()
        {
            try
            {
                var lcContext = new ADSReminderDBContext();
                if (argFiter == null)
                    return lcContext.Set<T>();
                return lcContext.Set<T>().Where(argFiter);

            }
            catch(DbEntityValidationException ex)
            {
                throw fnValidateException(ex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> fnInsertAsync<T>(T argObject) where T : BaseEntity, new()
        {
            try
            {
                using (var lcContext = new ADSReminderDBContext())
                {
                    lcContext.Set<T>().Add(argObject);
                    await lcContext.SaveChangesAsync();
                    return argObject;
                }
            }
            catch(DbEntityValidationException ex)
            {
                throw fnValidateException(ex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> fnUpdateAsync<T>(T argObject) where T : BaseEntity, new()
        {
            try
            {
                using (var lcContext = new ADSReminderDBContext())
                {
                    lcContext.Entry(argObject).State = EntityState.Modified;
                    await lcContext.SaveChangesAsync();
                    return argObject;
                }
                
            }
            catch(DbEntityValidationException ex)
            {

                throw fnValidateException(ex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Exception fnValidateException(DbEntityValidationException argExcp)
        {
            var lcErrorStr = string.Join(",", argExcp.EntityValidationErrors.SelectMany(a => a.ValidationErrors).Select(a => a.PropertyName + ":" + a.ErrorMessage));
            return new Exception(lcErrorStr);
        }
    }
}
