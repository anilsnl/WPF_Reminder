using ADSReminder.BUS.Abstraction;
using ADSReminder.DataAccess.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.Utility.Security;
using System;
using System.Threading.Tasks;

namespace ADSReminder.BUS.Concrete
{
    public class UserManager : IUserManager
    {
        #region Ctor and Defination Section
        private IGenericRepository mGenericRepository;

        public UserManager(IGenericRepository argGenericRepository)
        {
            this.mGenericRepository = argGenericRepository;
        }
        #endregion
        #region Interface Method Section
        /// <summary>
        /// Try to login user according to the passsing parameters. If secuuss returns the user.
        /// </summary>
        /// <param name="argUsername"></param>
        /// <param name="argPassword"></param>
        /// <returns></returns>
        public async Task<User> fnLoginAsync(string argUsername, string argPassword)
        {
            try
            {
                var lcHashedPassword = Hasher.fnHashString(argPassword);
                var lcUser = await mGenericRepository
                    .fnGetFirstAsync<User>(a => a.Username.Equals(argUsername) && a.PasswordHash.Equals(lcHashedPassword));
                if (!lcUser.IsActive)
                {
                    throw new Exception("User is not active to login.");
                }
                return lcUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Register givin user into system. Returns the registerd user.
        /// </summary>
        /// <param name="argUser"></param>
        /// <param name="argPassword"></param>
        /// <param name="argSecretAnswer"></param>
        /// <returns></returns>

        public async Task<User> fnRegisterSystem(User argUser, string argPassword, string argSecretAnswer)
        {
            try
            {
                argUser.CreatedBy = null;
                argUser.CreatedDate = DateTime.UtcNow;
                argUser.ModifiedBy = null;
                argUser.ModifiedDate = null;
                argUser.PasswordHash = Hasher.fnHashString(argPassword);
                argUser.SecretAnswer = Hasher.fnHashString(argSecretAnswer);
                argUser.IsActive = true;
                var lcUser = await mGenericRepository.fnInsertAsync(argUser);
                return lcUser;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
