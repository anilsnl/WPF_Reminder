using ADSReminder.UI.BaseClasses;
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
        public void OnLogin(object arg)
        {

        }
    }
}
