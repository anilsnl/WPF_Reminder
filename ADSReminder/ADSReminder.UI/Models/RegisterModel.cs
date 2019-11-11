using ADSReminder.UI.BaseClasses;

namespace ADSReminder.UI.Models
{
    public class RegisterModel:BaseModel
    {
        private string mNameSurname;
        private string mUsername;
        private string mPassword;
        private string mConfirmPassword;
        private string mSecretQuesiton;
        private string mSecretAnswer;

        public string NameSurname 
        {
            get => mNameSurname; 
            set
            {
                mNameSurname = value;
                OnPropertyChanged(nameof(NameSurname));
            }
        }
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
        public string ConfirmPassword 
        {
            get => mConfirmPassword; 
            set
            {
                mConfirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        public string SecretQuestion 
        {
            get => mSecretQuesiton;
            set
            {
                mSecretQuesiton = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string SecretAnswer 
        {
            get => mSecretAnswer;
            set
            {
                mSecretAnswer = value;
                OnPropertyChanged(nameof(SecretAnswer));
            }
        }
    }
}
