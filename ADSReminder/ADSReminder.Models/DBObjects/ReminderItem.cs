using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSReminder.Models.DBObjects
{
    /// <summary>
    /// Reminder Item table model..
    /// </summary>
    public class ReminderItem : BaseEntity
    {
        #region Int Types
        [Required(ErrorMessage = "ReminderId is required.")]
        [Column("ReminderId")]
        [ForeignKey(nameof(Reminder))]
        public int ReminderId { get; set; }
        #endregion
        #region String Types
        [Required(ErrorMessage ="Title is required.")]
        [Column("Title")]
        [MaxLength(100,ErrorMessage ="Title can contains max 100 chacters.")]
        public string Title { get; set; }
        [Required]
        [Column("Detail")]
        public string Detail { get; set; }
        #endregion
        #region Bool Types
        [Required(ErrorMessage ="IsComplated is required.")]
        [Column("IsComplated")]
        public bool IsComplated { get; set; }
        #endregion
        #region DateTime Objects
        [Column("ExpreDate")]
        public DateTime ExpreDate { get; set; }
        [Column("ComplatedDate")]
        public DateTime? ComplatedDate { get; set; }
        #endregion
        #region Relation Objects
        public Reminder Reminder { get; set; }
        #endregion
    }
}
