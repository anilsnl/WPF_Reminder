using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Models;
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

        public void OnRegister(object argParam)
        {

        }
    }
}
