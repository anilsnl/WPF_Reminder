using ADSReminder.BUS.Abstraction;
using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Helpers.UI;
using Autofac;
using System.Windows.Input;

namespace ADSReminder.UI.ViewModels
{
    public class LoginUserControlViewModel:BaseViewModel
    {
        private string mUsername;
        private string mPassword;
        private bool mSaveLogin;
        private ICommand mLoginCommand;
        public string Username 
        { 
            get => mUsername; 
            set 
            {
                mUsername = value;
                OnPropertyChanged(nameof(Username));
            } 
        }
        public string Password 
        {
            get => mPassword; 
            set
            {
                mPassword = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool SaveLogin 
        {
            get => mSaveLogin;
            set 
            {
                mSaveLogin = value;
                OnPropertyChanged(nameof(SaveLogin));
            }
        }

        public ICommand LoginCommand
        {
            get 
            {
                if (mLoginCommand == null)
                    mLoginCommand = new CommandExcuter(OnLogin);
                return mLoginCommand;
            }
        }
        public async void OnLogin(object arg)
        {
            try
            {
                var lcUserManager = App.CenteralIOC.Resolve<IUserManager>();
                if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
                {
                    UserAlert.fnInformUser(UserInformType.Warning, "Required!", "Username and password could not be emty!");
                    return;
                }
                var lcUser = await lcUserManager.fnLoginAsync(this.Username, this.Password);
                if (lcUser==null)
                {
                    UserAlert.fnInformUser(UserInformType.Warning, "Invalid User!", "Username or password is invalid!");
                }
                else
                {

                }
            }
            catch (System.Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", $"{ex.Message}!");
            }
        }
    }
}
