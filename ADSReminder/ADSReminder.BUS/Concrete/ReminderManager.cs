using ADSReminder.BUS.Abstraction;
using ADSReminder.DataAccess.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ADSReminder.BUS.Concrete
{
    public class ReminderManager : IReminderManager
    {
        private IGenericRepository mGenericRepository;

        public ReminderManager(IGenericRepository argGenericRepository)
        {
            this.mGenericRepository = argGenericRepository;
        }

        public async Task<bool> fnDeleteReminderGroupAsync(int argId)
        {
            try
            {
                var lcItemIds = mGenericRepository.fnGetQueryableObjects<ReminderItem>(a => a.ReminderId == argId)
                    .Select(a => a.Id).ToList();
                foreach (var lcItem in lcItemIds)
                {
                    mGenericRepository.fnDeleteAsync(new ReminderItem { Id = lcItem });
                }
                mGenericRepository.fnDeleteAsync(new Reminder { Id = argId });
                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> fnDeleteReminderItemAsync(int argId)
        {
            try
            {
                mGenericRepository.fnDeleteAsync(new ReminderItem { Id = argId });
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReminderGroupModel>> fnGetReminderGroupDeepAsync(int argUserId)
        {
            try
            {
                var lcReminderGroups = mGenericRepository
                    .fnGetQueryableObjects<Reminder>(a => a.OwnerId == argUserId && a.IsActive)
                    .Select(a => new ReminderGroupModel
                    {
                        Detail = a.Detail,
                        Id = a.Id,
                        Title = a.Title
                    }).OrderBy(a=>a.Title).ToList();
                foreach (var lcItem in lcReminderGroups)
                {
                    lcItem.Items.Clear();
                    lcItem.Items = new ObservableCollection<ReminderItemModel>
                        (mGenericRepository.fnGetQueryableObjects<ReminderItem>
                        (a => a.ReminderId == lcItem.Id).Select(a => new ReminderItemModel
                        {
                            Detail = a.Detail,
                            IsComplated = a.IsComplated,
                            DueDate = a.ExpreDate,
                            CreateDate = a.CreatedDate,
                            Id = a.Id,
                            Title = a.Title
                        }));
                }
                return await Task.FromResult(lcReminderGroups);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReminderItemModel>> fnGetReminderItemAsync(int argReminderGroupId)
        {
            try
            {
                var lcList = mGenericRepository.fnGetQueryableObjects<ReminderItem>(a => a.ReminderId == argReminderGroupId)
                    .Select(a => new ReminderItemModel
                    {
                        Id = a.Id,
                        CreateDate = a.CreatedDate,
                        Detail = a.Detail,
                        DueDate = a.ExpreDate,
                        IsComplated = a.IsComplated,
                        Title = a.Title
                    }).OrderBy(a => a.Title).ToList();
                return await Task.FromResult(lcList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReminderGroupModel> fnInsertGroupAsync(Reminder argModel)
        {
            try
            {
                var lcGroup = await mGenericRepository.fnInsertAsync<Reminder>(argModel);
                return await Task.FromResult(new ReminderGroupModel
                {
                    Id = lcGroup.Id,
                    Detail = lcGroup.Detail,
                    Title = lcGroup.Title
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReminderItemModel> fnInsertIRemindertemAsync(ReminderItem argModel)
        {
            try
            {
                var lcItem = await mGenericRepository.fnInsertAsync<ReminderItem>(argModel);
                return await Task.FromResult(new ReminderItemModel
                {
                    CreateDate = lcItem.CreatedDate,
                    Detail = lcItem.Detail,
                    DueDate = lcItem.ExpreDate,
                    Id = lcItem.Id,
                    IsComplated = lcItem.IsComplated,
                    Title = lcItem.Title
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReminderItemModel> fnUpdateReminderItemAsync(ReminderItem argModel)
        {
            try
            {
                var lcItem = await mGenericRepository.fnUpdateAsync<ReminderItem>(argModel);
                return await Task.FromResult(new ReminderItemModel
                {
                    CreateDate = lcItem.CreatedDate,
                    Detail = lcItem.Detail,
                    DueDate = lcItem.ExpreDate,
                    Id = lcItem.Id,
                    IsComplated = lcItem.IsComplated,
                    Title = lcItem.Title
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
