using ADSReminder.UI.BaseClasses;
using System.Collections.ObjectModel;

namespace ADSReminder.UI.Models
{
    public class ReminderGroupModel : BaseModel
    {
        public ReminderGroupModel()
        {
            this.Items = new ObservableCollection<ReminderItemModel>();
        }
        private int mId;
        private string mTitle;
        private string mDetail;
        private ObservableCollection<ReminderItemModel> mItems;

        public int Id
        {
            get => mId;
            set
            {
                mId = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Title 
        {
            get => mTitle; 
            set
            {
                mTitle = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Detail
        {
            get => mDetail; 
            set
            {
                mDetail = value;
                OnPropertyChanged(nameof(Detail));
            }
        }

        public ObservableCollection<ReminderItemModel> Items 
        {
            get => mItems; 
            set
            {
                mItems = value;
                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(NumberOfItems));
            }
        }
        public int NumberOfItems
        {
            get
            {
                if (this.Items == null)
                    this.Items = new ObservableCollection<ReminderItemModel>();
                return this.Items.Count;
            }
        }
    }
}
