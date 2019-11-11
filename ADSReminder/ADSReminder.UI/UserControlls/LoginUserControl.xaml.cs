using ADSReminder.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADSReminder.UI.UserControlls
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private LoginUserControlViewModel mLoginViewModel;
        public LoginUserControl()
        {
            InitializeComponent();
            mLoginViewModel = new LoginUserControlViewModel();
            DataContext = mLoginViewModel;
        }

        private void psPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender != null && mLoginViewModel != null)
                mLoginViewModel.Password = (sender as PasswordBox).Password;
        }
    }
}
