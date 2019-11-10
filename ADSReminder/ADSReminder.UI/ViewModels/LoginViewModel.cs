using ADSReminder.UI.BaseClasses;

namespace ADSReminder.UI.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string mUsername;
        private string mPassword;
        private bool mSaveLogin;

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
    }
}
