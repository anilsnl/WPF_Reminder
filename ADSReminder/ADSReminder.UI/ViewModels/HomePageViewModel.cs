using ADSReminder.BUS.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Helpers.UI;
using ADSReminder.UI.Models;
using Autofac;
using System.Collections.ObjectModel;
using System.Windows;

namespace ADSReminder.UI.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private IReminderManager ReminderManager
        {
            get => App.CenteralIOC.Resolve<IReminderManager>();
        }
        
        public HomePageViewModel()
        {
            try
            {
                var lcList = ReminderManager.fnGetReminderGroupDeepAsync(App.CurrentUser.Id).Result;
                this.Reminders = new ObservableCollection<ReminderGroupModel>(lcList);
            }
            catch (System.Exception e)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", e.Message);
            }
        }
        #region Binding Object
        private ObservableCollection<ReminderGroupModel> mReminders;
        private ReminderGroupModel mSelectedGroup;
        private ReminderItemModel mSelectedItem;
        private Visibility mEditVisibility;
        public User CurrentUser
        {
            get => App.CurrentUser;
        }
        public ObservableCollection<ReminderGroupModel> Reminders 
        {
            get
            {
                if (mReminders==null)
                {
                    mReminders = new ObservableCollection<ReminderGroupModel>();
                }
                return mReminders;
            }
            set
            {
                mReminders = value;
                OnPropertyChanged(nameof(Reminders));
            }
        }
        public ReminderGroupModel SelectedGroup
        {
            get => mSelectedGroup;
            set
            {
                mSelectedGroup = value;
                fnCheckVisablity();
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        public ReminderItemModel SelectedItem 
        {
            get => mSelectedItem; 
            set
            {
                mSelectedItem = value;
                fnCheckVisablity();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public Visibility EditVisibility
        {
            get => mEditVisibility; 
            set
            {
                mEditVisibility = value;
                fnCheckVisablity();
                OnPropertyChanged(nameof(EditVisibility));
            }
        }
        #endregion
        #region Helper Methods
        private void fnCheckVisablity()
        {
            if (SelectedGroup==null)
            {
                SelectedItem = null;
                EditVisibility = Visibility.Hidden;
            }
            if (SelectedItem==null)
            {
                EditVisibility = Visibility.Hidden;
            }
        }
        #endregion
    }
}
