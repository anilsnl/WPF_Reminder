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
    }
}
