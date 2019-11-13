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
    }
}
