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
                if (lcUser==null)
                {
                    throw new Exception("User could not be found, Username of password is invalid.");
                }
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
                if (await mGenericRepository.fnExistAsync<User>(a=>a.Username.ToLower().Equals(argUser.Username.ToLower())))
                {
                    throw new Exception("User is already exist!");
                }
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
        public async Task<string> fnGetSecretQuestionAsync(string argUsername)
        {
            try
            {
                var lcUser = await mGenericRepository.fnGetFirstAsync<User>(a => a.Username.Equals(argUsername));
                if (lcUser == null)
                    throw new Exception("User could not be found!");
                return lcUser.SecretQuestion;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Resets the user password.
        /// </summary>
        /// <param name="argUsername"></param>
        /// <param name="argSecretAnswer"></param>
        /// <param name="argNewPassword"></param>
        /// <returns></returns>
        public async Task<User> fnResetPasswordAsync(string argUsername, string argSecretAnswer, string argNewPassword)
        {
            try
            {
                var lcHashedAnswer = Hasher.fnHashString(argSecretAnswer);
                var lcHasedPassword = Hasher.fnHashString(argNewPassword);
                var lcUser = await mGenericRepository.fnGetFirstAsync<User>(a => a.Username.Equals(argUsername) && a.SecretAnswer.Equals(lcHashedAnswer));
                if (lcUser == null)
                    throw new Exception("User could not be found!");
                lcUser.PasswordHash = lcHasedPassword;
                lcUser.ModifiedDate = DateTime.Now;
                lcUser.ModifiedBy = lcUser.Id;
                return await mGenericRepository.fnUpdateAsync<User>(lcUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
