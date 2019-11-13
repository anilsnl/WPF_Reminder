using ADSReminder.Models.DBObjects;
using ADSReminder.UI.ViewModels;
using Microsoft.Windows.Controls;
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
    /// Interaction logic for HomePaage.xaml
    /// </summary>
    public partial class HomePaage : Window
    {
        private HomePageViewModel mViewModel;
        public HomePaage()
        {
            InitializeComponent();
            mViewModel = new HomePageViewModel();
            DataContext = mViewModel;
        }

        private void btnRollback_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
