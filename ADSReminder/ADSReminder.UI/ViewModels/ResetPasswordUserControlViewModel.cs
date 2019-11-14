using ADSReminder.BUS.Abstraction;
using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Helpers.UI;
using ADSReminder.UI.Models;
using Autofac;
using System;
using System.Windows.Input;

namespace ADSReminder.UI.ViewModels
{
    public class ResetPasswordUserControlViewModel : BaseViewModel
    {
        private ResetPasswordModel mModel;
        private ICommand mCheckUserCımmand;
        private ICommand mResetPasswordCommand;
        #region Binding Objects
        public ResetPasswordModel Model 
        {
            get
            {
                if (mModel == null)
                    mModel = new ResetPasswordModel();
                return mModel;
            }
            set
            {
                mModel = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public ICommand CheckUserCımmand
        {
            get
            {
                if (mCheckUserCımmand == null)
                    mCheckUserCımmand = new CommandExcuter(OnCheckUser);
                return mCheckUserCımmand;
            }
        }
        public ICommand ResetPasswordCommand
        {
            get
            {
                if (mResetPasswordCommand == null)
                    mResetPasswordCommand = new CommandExcuter(OnResetPassword);
                return mResetPasswordCommand;
            }
        }
        #endregion

        public async void OnCheckUser(object argParam)
        {
            try
            {
                var lcManager = App.CenteralIOC.Resolve<IUserManager>();
                var lcQuestionAnswer = await lcManager.fnGetSecretQuestionAsync(this.Model.Username);
                this.Model.SecretQuestion = lcQuestionAnswer;
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
        public async void OnResetPassword(object argParam)
        {
            try
            {
                if (!Model.Password.Equals(Model.ConfirmPassword))
                    throw new Exception("The password sould be same!");
                var lcManager = App.CenteralIOC.Resolve<IUserManager>();
                var lcUser = await lcManager.fnResetPasswordAsync(Model.Username, Model.SecretAnswer, Model.Password);
                if (lcUser == null)
                    throw new Exception("User could not be found!");
                App.CurrentUser = lcUser;
                NavigationManger.fnNavigateHome();
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
    }
}
