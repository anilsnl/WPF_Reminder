using ADSReminder.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ADSReminder.UI.UserControlls
{
    /// <summary>
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {
        private RegisterUserControlViewModel mModel;
        public RegisterUserControl()
        {
            InitializeComponent();
            mModel = new RegisterUserControlViewModel();
            DataContext = mModel;
        }

        private void pswConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            mModel.User.ConfirmPassword = pswConfirm.Password;
        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            mModel.User.Password = pswPassword.Password;
        }
    }
}
