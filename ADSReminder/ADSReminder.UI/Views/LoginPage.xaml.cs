using ADSReminder.UI.UserControlls;
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
using System.Windows.Shapes;

namespace ADSReminder.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private LoginUserControl mLoginUserControl;
        private RegisterUserControl mRegisterUserControl;
        private ResetPasswordUserControl mResetPasswordUserControl;

        private LoginUserControl LoginUserControl 
        {
            get
            {
                if (mLoginUserControl == null)
                    mLoginUserControl = new LoginUserControl();
                return mLoginUserControl;
            }
        }
        private RegisterUserControl RegisterUserControl
        {
            get
            {
                if (mRegisterUserControl == null)
                    mRegisterUserControl = new RegisterUserControl();
                return mRegisterUserControl;
            }
        }
        private ResetPasswordUserControl ResetPasswordUserControl
        {
            get
            {
                if (mResetPasswordUserControl == null)
                    mResetPasswordUserControl = new ResetPasswordUserControl();
                return mResetPasswordUserControl;
            }
        }
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnMenuLogin_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(this.LoginUserControl);
        }

        private void btnMenuRegister_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(this.RegisterUserControl);
        }

        private void btnMenuResetPassword_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(this.ResetPasswordUserControl);
        }
    }
}
