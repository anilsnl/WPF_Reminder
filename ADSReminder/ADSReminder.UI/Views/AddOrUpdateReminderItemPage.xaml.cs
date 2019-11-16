using ADSReminder.UI.Helpers.Messager;
using ADSReminder.UI.Models;
using System.Windows;

namespace ADSReminder.UI.Views
{
    /// <summary>
    /// Interaction logic for AddReminderItem.xaml
    /// </summary>
    public partial class AddReminderItem : Window
    {
        private ReminderItemModel mModel;
        public AddReminderItem()
        {
            InitializeComponent();
            mModel = new ReminderItemModel();
            mModel.DueDate = System.DateTime.Now;

            DataContext = mModel;
        }
        public AddReminderItem(ReminderItemModel argObject)
        {
            InitializeComponent();
            mModel = argObject;
            DataContext = mModel;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Messager.gDefault.fnSend<ReminderItemModel>(mModel);
            this.Close();
        }
    }
}
