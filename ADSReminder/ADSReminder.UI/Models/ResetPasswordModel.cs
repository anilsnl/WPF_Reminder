using ADSReminder.UI.BaseClasses;

namespace ADSReminder.UI.Models
{
    public class ResetPasswordModel : BaseModel
    {
        private string mUsername;
        private string mPassword;
        private string mConfirmPassword;
        private string mSecretQuestion;
        private string mSecretAnswer;

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
            get => mSecretQuestion;
            set
            {
                mSecretQuestion = value;
                OnPropertyChanged(nameof(SecretQuestion));
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
