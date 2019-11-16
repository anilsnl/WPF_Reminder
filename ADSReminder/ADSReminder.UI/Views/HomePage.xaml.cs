using ADSReminder.Models.DBObjects;
using ADSReminder.UI.Helpers.UI;
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

        protected override void OnClosed(EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void imgAddGroup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var lcTitle = UserAlert.fnGetInputFromUser("Insert Reminder Group", "Type group name.");
            if (string.IsNullOrEmpty(lcTitle))
            {
                return;
            }
            var lcDetail = UserAlert.fnGetInputFromUser("Insert Reminder Group", "Type group detail.");
            if (string.IsNullOrEmpty(lcDetail)||string.IsNullOrEmpty(lcTitle))
            {
                return;
            }
            this.mViewModel.fnAddGroupAsync(lcTitle, lcDetail);
        }

        private void btnGroupDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.mViewModel.fnDeleteReminderGroupAsync();
        }

        private async void cmbOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await mViewModel.fnLoadData();
        }

        private async void txtReminderSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            mViewModel.SearchedText = txtReminderSearch.Text;
            await mViewModel.fnLoadData();
        }
    }
}
