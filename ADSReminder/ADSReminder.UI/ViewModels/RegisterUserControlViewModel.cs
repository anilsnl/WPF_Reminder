using ADSReminder.BUS.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Helpers.UI;
using ADSReminder.UI.Models;
using Autofac;
using System;
using System.Windows.Input;

namespace ADSReminder.UI.ViewModels
{
    public class RegisterUserControlViewModel : BaseViewModel
    {
        private RegisterModel mUser;
        private ICommand mRegisterCommand;
        public RegisterModel User
        {
            get
            {
                if (mUser==null)
                {
                    mUser = new RegisterModel();
                }
                return mUser;
            }
            set
            {
                mUser = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public ICommand RegisterCommand
        {
            get
            {
                if (mRegisterCommand == null)
                    mRegisterCommand = new CommandExcuter(OnRegister);
                return mRegisterCommand;
            }
        }

        public async void OnRegister(object argParam)
        {
            try
            {
                if (!this.User.Password.Equals(this.User.ConfirmPassword))
                {
                    throw new Exception("The password should be same!");
                }
                var lcManager = App.CenteralIOC.Resolve<IUserManager>();
                var lcUser = await lcManager.fnRegisterSystem(new User
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    NameSurname = this.User.NameSurname,
                    SecretQuestion = this.User.SecretQuestion,
                    Username = this.User.Username
                }, this.User.Password, this.User.SecretAnswer);
                if (lcUser!=null)
                {
                    App.CurrentUser = lcUser;
                    NavigationManger.fnNavigateHome();
                }
            }
            catch (System.Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
    }
}
