using ADSReminder.UI.UserControlls;
using System.Windows;

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
            grdMain.Children.Add(this.LoginUserControl);
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
