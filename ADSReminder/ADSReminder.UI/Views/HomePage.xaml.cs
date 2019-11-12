using ADSReminder.Models.DBObjects;
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
                    new { Title = "Test Item 1", DueDate = DateTime.Now, Detail = "More Detail About Something.", StatuImage = "/Src/Icons/add.png" },
                    new { Title = "Test Item 1", DueDate = DateTime.Now, Detail = "More Detail About Something.", StatuImage = "/Src/Icons/add.png" },
                }
            };
        }
    }
}
