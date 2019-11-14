using ADSReminder.UI.Views;
using System.Windows;

namespace ADSReminder.UI.Helpers.UI
{
    public class NavigationManger
    {
        public static void fnNavigateHome()
        {
            if (App.CurrentUser!=null)
            {
                App.Current.MainWindow.Hide();

                App.Current.MainWindow = new HomePaage();
                App.Current.MainWindow.Show();
            }
        }
        public static void fnOpenWindow(Window argWindow)
        {
            argWindow.ShowDialog();
        }
    }
}
