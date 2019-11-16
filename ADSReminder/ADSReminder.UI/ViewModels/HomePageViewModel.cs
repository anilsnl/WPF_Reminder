using ADSReminder.BUS.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.UI.BaseClasses;
using ADSReminder.UI.Helpers.Messager;
using ADSReminder.UI.Helpers.UI;
using ADSReminder.UI.Models;
using ADSReminder.UI.Views;
using Autofac;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ADSReminder.UI.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Ctor And Injection
        private IReminderManager ReminderManager
        {
            get => App.CenteralIOC.Resolve<IReminderManager>();
        }
        public HomePageViewModel()
        {
            try
            {
                var lcList = ReminderManager.fnGetReminderGroupDeepAsync(CurrentUser.Id).Result;
                this.Reminders = new ObservableCollection<ReminderGroupModel>(lcList);
            }
            catch (System.Exception e)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", e.Message);
            }
        }
        #endregion
        #region Binding Object
        private ObservableCollection<ReminderGroupModel> mReminders;
        private ObservableCollection<ReminderItemModel> mFilteredItem;
        private ReminderGroupModel mSelectedGroup;
        private ReminderItemModel mSelectedItem;
        private int mOrderIndex;
        private int mFilterIndex;
        private string mSearchedText;
        private Visibility mIsGroupSelectedForList = Visibility.Hidden;
        private ICommand mNewItemCommand;
        private ICommand mMarkAsComplatedCommand;
        private ICommand mDeleteItemCommand;
        private ICommand mUpdateItemCommand;
        //Class Objects.
        public User CurrentUser
        {
            get => App.CurrentUser;
        }
        public ObservableCollection<ReminderGroupModel> Reminders
        {
            get
            {
                if (mReminders == null)
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
                OnPropertyChanged(nameof(SelectedGroup));
                OnPropertyChanged(nameof(FilteredItem));
                OnPropertyChanged(nameof(IsGroupSelected));
                OnPropertyChanged(nameof(IsGroupSelectedForList));
            }
        }
        public ReminderItemModel SelectedItem
        {
            get => mSelectedItem;
            set
            {
                mSelectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                OnPropertyChanged(nameof(FilteredItem));
                OnPropertyChanged(nameof(IsItemSelected));
                OnPropertyChanged(nameof(ItemIsNotComplated));
            }
        }
        
        //Bool Types
        public bool IsGroupSelected
        {
            get
            {
                if (SelectedGroup == null)
                    return false;
                return true;
            }
        }
        public bool IsItemSelected
        {
            get
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }
        }
        public bool ItemIsNotComplated
        {
            get
            {
                if (SelectedItem != null&&!SelectedItem.IsComplated)
                    return true;
                return false;
            }
            
        }
        //Int 
        public int OrderIndex
        {
            set
            {
                mOrderIndex = value;
                OnPropertyChanged(nameof(OrderIndex));
            }
            get => mOrderIndex;
        }
        public int FilterIndex
        {
            set
            {
                mFilterIndex = value;
                OnPropertyChanged(nameof(FilterIndex));
            }
            get => mFilterIndex;
        }
        //String
        public string SearchedText
        {
            set
            {
                mSearchedText = value;
                OnPropertyChanged(nameof(SearchedText));
            }
            get => mSearchedText;
        }
        //Other
        public Visibility IsGroupSelectedForList
        {
            get
            {
                if (SelectedGroup==null)
                {
                    mIsGroupSelectedForList=  Visibility.Hidden;
                }
                else
                {
                    mIsGroupSelectedForList = Visibility.Visible;
                }
                return mIsGroupSelectedForList;
            }
        }
        //Commands
        public ICommand NewItemCommand
        {
            get
            {
                if (mNewItemCommand == null)
                    mNewItemCommand = new CommandExcuter(OnAddNewItem);
                return mNewItemCommand;
            }
        }
        public ICommand MarkAsComplatedCommand
        {
            get
            {
                if (mMarkAsComplatedCommand==null)
                {
                    mMarkAsComplatedCommand = new CommandExcuter(OnMarkedAsComplated);
                }
                return mMarkAsComplatedCommand;
            }
        }
        public ICommand DeleteItemCommand
        {
            get
            {
                if (mDeleteItemCommand == null)
                    mDeleteItemCommand = new CommandExcuter(OnDeleteItem);
                return mDeleteItemCommand;
            }
        }
        public ICommand UpdateItemCommand
        {
            get
            {
                if (mUpdateItemCommand == null)
                    mUpdateItemCommand = new CommandExcuter(OnUpdateItem);
                return mUpdateItemCommand;
            }
        }

        public ObservableCollection<ReminderItemModel> FilteredItem 
        {
            get => mFilteredItem;
            set
            {
                mFilteredItem = value;
                OnPropertyChanged(nameof(FilteredItem));
            }
        }
        #endregion
        #region Reminder Group Methods
        public async void fnAddGroupAsync(string argTitle, string argDetail)
        {
            try
            {
                var lcManger = App.CenteralIOC.Resolve<IReminderManager>();
                var lcIten = await lcManger.fnInsertGroupAsync(new Reminder
                {
                    Detail = argDetail,
                    Title = argTitle,
                    IsActive = true,
                    OwnerId = App.CurrentUser.Id,
                    CreatedBy = App.CurrentUser.Id,
                    CreatedDate = DateTime.Now
                });
                this.Reminders.Add(lcIten);
            }
            catch (System.Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
        public async void fnDeleteReminderGroupAsync()
        {
            try
            {
                if (this.SelectedGroup != null)
                {
                    var lcResult = UserAlert.fnAskToConfirmUser(UserInformType.Info, "Delete", $"Are you sure, you want to delete {SelectedGroup.Title}?");
                    if (lcResult == UserConfirmResult.Confirmed)
                    {
                        var lcManeger = App.CenteralIOC.Resolve<IReminderManager>();
                        var lc = await lcManeger.fnDeleteReminderGroupAsync(SelectedGroup.Id);
                        if (lc)
                        {
                            this.Reminders.Remove(this.mSelectedGroup);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
        #endregion
        #region Reminder List Methods

        #endregion
        #region Reminder Iten Operation Methods
        public void OnAddNewItem(object argParam)
        {
            try
            {
                Messager.gDefault.fnRegister<ReminderItemModel>(this, async (argModel) =>
                {
                    try
                    {
                        var lcRItem = new ReminderItem
                        {
                            CreatedBy = CurrentUser.Id,
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                            IsComplated = argModel.IsComplated,
                            ExpreDate = argModel.DueDate,
                            Detail = argModel.Detail,
                            ReminderId = SelectedGroup.Id,
                            Title = argModel.Title,
                            ComplatedDate=argModel.ComplatedDate
                        };
                        var lcReminder = await ReminderManager
                            .fnInsertIRemindertemAsync(lcRItem);
                        await fnLoadData();
                        Messager.gDefault.fnUnregister(this);
                    }
                    catch (Exception ex)
                    {
                        UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
                    }

                });
                NavigationManger.fnOpenWindow(new AddReminderItem());

            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
        public async void OnMarkedAsComplated(object argParam)
        {
            try
            {
                var lcReminder = await ReminderManager
                    .fnUpdateReminderItemAsync(new ReminderItem
                    {
                        ExpreDate = SelectedItem.DueDate,
                        Id = SelectedItem.Id,
                        CreatedDate = SelectedItem.CreateDate,
                        ComplatedDate = DateTime.Now,
                        CreatedBy = CurrentUser.Id,
                        IsComplated = true,
                        IsActive = true,
                        Detail = SelectedItem.Detail,
                        ReminderId = SelectedItem.ReminderGroupId,
                        Title = SelectedItem.Title,
                    });
                await fnLoadData();
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", $"Update Error: {ex.Message}");
            }
        }
        public async void OnDeleteItem(object argParam)
        {
            try
            {
                var lcBuf = SelectedItem;
                var lcUserResponse = UserAlert.fnAskToConfirmUser(UserInformType.Info,"Delete Item", "Are you sure, you want to delete the selected item?");
                if (lcUserResponse == UserConfirmResult.Rejected)
                    return;
                SelectedGroup.Items.Remove(lcBuf);
                FilteredItem.Remove(lcBuf);
                var lcResult = await ReminderManager.fnDeleteReminderItemAsync(lcBuf.Id);
                await Task.Delay(50);
                await fnLoadData();
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", $"Delete Item Error:{ex.Message}");
            }
        }
        public void OnUpdateItem(object argParam)
        {
            try
            {
                Messager.gDefault.fnRegister<ReminderItemModel>(this, async (argModel) =>
                {

                    try
                    {
                        var lcRItem = new ReminderItem
                        {
                            Id = argModel.Id,
                            CreatedBy = CurrentUser.Id,
                            CreatedDate = argModel.CreateDate,
                            IsActive = true,
                            IsComplated = argModel.IsComplated,
                            ExpreDate = argModel.DueDate,
                            Detail = argModel.Detail,
                            ReminderId = SelectedGroup.Id,
                            Title = argModel.Title,
                        };
                        if (argModel.IsComplated)
                            lcRItem.ComplatedDate = DateTime.Now;
                        else
                            lcRItem.ComplatedDate = null;
                        var lcReminder = await ReminderManager
                            .fnUpdateReminderItemAsync(lcRItem);
                        Messager.gDefault.fnUnregister(this);
                        await fnLoadData();
                    }
                    catch (Exception ex)
                    {
                        UserAlert.fnInformUser(UserInformType.Error, "Error", $"Update Error: {ex.Message}");
                    }

                });
                NavigationManger.fnOpenWindow(new AddReminderItem(SelectedItem));

            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", ex.Message);
            }
        }
        public async Task fnLoadData()
        {
            try
            {
                if (mSelectedGroup==null)
                {
                    return;
                }
                SelectedItem = null;
                var lcItems = await ReminderManager.fnGetReminderItemAsync(SelectedGroup.Id);
                mSelectedGroup.Items = new ObservableCollection<ReminderItemModel>(lcItems);
                switch (FilterIndex)
                {
                    case 1:
                        lcItems = lcItems.Where(a => a.IsComplated).ToList();
                        break;
                    case 2:
                        lcItems = lcItems.Where(a => !a.IsComplated).ToList();
                        break;
                    case 3:
                        lcItems = lcItems.Where(a => !a.IsComplated && a.DueDate < DateTime.Now).ToList();
                        break;
                    default:
                        break;
                }
                switch (OrderIndex)
                {
                    case 0:
                        lcItems = lcItems.OrderBy(a => a.Title).ToList();
                        break;
                    case 1:
                        lcItems = lcItems.OrderBy(a => a.IsComplated).ToList();
                        break;
                    case 2:
                        lcItems = lcItems.OrderBy(a => a.DueDate).ToList();
                        break;
                    case 3:
                        lcItems = lcItems.OrderBy(a => a.CreateDate).ToList();
                        break;
                }
                if (!string.IsNullOrEmpty(SearchedText))
                {
                    lcItems = lcItems
                    .Where(a => a.Title.ToLower().Contains(SearchedText.ToLower())
                    && a.Title.ToLower().Contains(SearchedText.ToLower())).ToList();
                }
                this.FilteredItem = new ObservableCollection<ReminderItemModel>(lcItems);
            }
            catch (Exception ex)
            {
                UserAlert.fnInformUser(UserInformType.Error, "Error", $"Load data error: {ex.Message}");
            }
        }
        #endregion
    }
}
