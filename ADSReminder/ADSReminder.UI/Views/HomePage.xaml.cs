using ADSReminder.Models.DBObjects;
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

        public HomePaage()
        {
            InitializeComponent();
            DataContext = new
            {
                Items = new[]
                {
                    new Reminder {Title ="Item 1",Detail="Detail 1"},
                    new Reminder {Title ="Item 1",Detail="Detail 2"},
                },
                ReminderItems = new[]
                {
                    new { Title = "Test Item 1", DueDate = DateTime.Now, Detail = "More Detail About Something.", StatuImage = "/Src/Icons/ınprocess.png" },
                    new { Title = "Test Item 1", DueDate = DateTime.Now, Detail = "More Detail About Something.", StatuImage = "/Src/Icons/yes.png" },
                    new { Title = "Test Item 1", DueDate = DateTime.Now.AddDays(-1), Detail = "More Detail About Something.", StatuImage = "/Src/Icons/worm.png" },
                },
                IsSelectedItem = Visibility.Visible,
                DueDate = DateTime.Now
            };
            DateTimePicker dateTimePicker = new DateTimePicker();

        }

        private void btnRollback_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
