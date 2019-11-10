using ADSReminder.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSReminder.BUS.Abstraction
{
    public interface IUserManager
    {
        /// <summary>
        /// Try to login into system if success returns the user.
        /// </summary>
        /// <param name="argUsername"></param>
        /// <param name="argPassword"></param>
        /// <returns></returns>
        Task<User> fnLoginAsync(string argUsername, string argPassword);
        /// <summary>
        /// Register the passing user in to system and return the regitered user model.
        /// </summary>
        /// <param name="argUser"></param>
        /// <param name="argPassword"></param>
        /// <param name="argSecretAnswer"></param>
        /// <returns></returns>
        Task<User> fnRegisterSystem(User argUser, string argPassword, string argSecretAnswer);
    }
}
