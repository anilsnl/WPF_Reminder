using ADSReminder.UI.BaseClasses;
using System;

namespace ADSReminder.UI.Models
{
    public class ReminderItemModel : BaseModel
    {
        private int mId;
        private int mReminderGroupId;
        private string mTitle;
        private string mDetail;
        private bool mIsComplated;
        private DateTime mDueDate;
        private DateTime mCreateDate;
        private DateTime? mComplatedDate;
        public int Id
        {
            get => mId;
            set
            {
                mId = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int ReminderGroupId
        {
            get => mReminderGroupId;
            set
            {
                mReminderGroupId = value;
                OnPropertyChanged(nameof(ReminderGroupId));
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
                OnPropertyChanged(nameof(DateState));
                OnPropertyChanged(nameof(IconSrc));
            }
        }
        public DateTime DueDate 
        {
            get => mDueDate; 
            set
            {
                mDueDate = value;
                OnPropertyChanged(nameof(DueDate));
                OnPropertyChanged(nameof(IconSrc));
                OnPropertyChanged(nameof(DateState));
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
        public DateTime? ComplatedDate
        {
            get => mComplatedDate;
            set
            {
                mComplatedDate = value;
                OnPropertyChanged(nameof(ComplatedDate));
                OnPropertyChanged(nameof(DateState));
            }
        }
        public string DateState
        {
            get
            {
                var lcString = $"Due: {DueDate.ToString("dd MMMM, HH:mm")},Done: ";
                if (ComplatedDate != null)
                    lcString =lcString+ ComplatedDate.Value.ToString("dd,MMMM, HH:mm");
                else
                    lcString += "-";
                return lcString;
            }
        }
    }
}
