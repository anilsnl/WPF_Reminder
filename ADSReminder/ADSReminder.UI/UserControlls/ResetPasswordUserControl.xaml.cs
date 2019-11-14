using ADSReminder.UI.Models;
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
    /// Interaction logic for ResetPasswordUserControl.xaml
    /// </summary>
    public partial class ResetPasswordUserControl : UserControl
    {
        private ResetPasswordUserControlViewModel mModel;
        public ResetPasswordUserControl()
        {
            InitializeComponent();
            mModel = new ResetPasswordUserControlViewModel();
            DataContext = mModel;
        }

        private void prxrPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            mModel.Model.Password = prxrPassword.Password;
        }

        private void ptxtConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            mModel.Model.ConfirmPassword = ptxtConfirm.Password;
        }
    }
}
