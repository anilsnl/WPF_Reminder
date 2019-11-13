using ADSReminder.UI.BaseClasses;
using System;

namespace ADSReminder.UI.Models
{
    public class ReminderItemModel : BaseModel
    {
        private int mId;
        private string mTitle;
        private string mDetail;
        private bool mIsComplated;
        private DateTime mDueDate;
        private DateTime mCreateDate;
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
                OnPropertyChanged(nameof(mDetail));
            }
        }
        public string IconSrc
        {
            get
            {
                if (this.IsComplated)
                    return "/Src/Icons/yes.png";
                else if (this.DueDate < DateTime.Now)
                    return "/Src/Icons/worm.png";
                else
                    return "/Src/Icons/inprocess.png";
            }
        }
        public bool IsComplated 
        {
            get => mIsComplated; 
            set
            {
                mIsComplated = value;
                OnPropertyChanged(nameof(IsComplated));
            }
        }
        public DateTime DueDate 
        {
            get => mDueDate; 
            set
            {
                mDueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public DateTime CreateDate 
        {
            get => mCreateDate;
            set
            {
                mCreateDate = value;
                OnPropertyChanged(nameof(CreateDate));
            }
        }
    }
}
