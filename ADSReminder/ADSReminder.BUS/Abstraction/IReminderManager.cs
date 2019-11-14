using ADSReminder.Models.DBObjects;
using ADSReminder.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADSReminder.BUS.Abstraction
{
    public interface IReminderManager
    {
        /// <summary>
        /// Get reminder groups with sub items.
        /// </summary>
        /// <param name="argUserId"></param>
        /// <returns></returns>
        Task<List<ReminderGroupModel>> fnGetReminderGroupDeepAsync(int argUserId);
        Task<List<ReminderItemModel>> fnGetReminderItemAsync(int argReminderGroupId);
        /// <summary>
        /// inserts reminder group.
        /// </summary>
        /// <param name="argModel"></param>
        /// <returns></returns>
        Task<ReminderGroupModel> fnInsertGroupAsync(Reminder argModel);
        /// <summary>
        /// Insertes reminder item to reminder group.
        /// </summary>
        /// <param name="argModel"></param>
        /// <returns></returns>
        Task<ReminderItemModel> fnInsertIRemindertemAsync(ReminderItem argModel);
        /// <summary>
        /// Update reminder item and returns updated item.
        /// </summary>
        /// <param name="argModel"></param>
        /// <returns></returns>
        Task<ReminderItemModel> fnUpdateReminderItemAsync(ReminderItem argModel);
        /// <summary>
        /// Deletem reminder item.
        /// </summary>
        /// <param name="argId"></param>
        /// <returns></returns>
        Task<bool> fnDeleteReminderItemAsync(int argId);
        /// <summary>
        /// Deletes reminder groups with item.
        /// </summary>
        /// <param name="argId"></param>
        /// <returns></returns>
        Task<bool> fnDeleteReminderGroupAsync(int argId);

    }
}
