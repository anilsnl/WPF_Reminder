using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSReminder.Models.DBObjects
{
    /// <summary>
    /// Reminder table model.
    /// </summary>
    public class Reminder : BaseEntity
    {
        #region Ctor
        public Reminder() 
        { 
            Items = new HashSet<ReminderItem>();
        }
        #endregion
        #region String Types
        [Required(ErrorMessage ="Title is required.")]
        [Column("Title")]
        [MaxLength(100,ErrorMessage ="Title can contain max 100 charcter.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Details is required.")]
        [Column("Detail")]
        public string Detail { get; set; }
        #endregion
        #region Int Types
        [Required(ErrorMessage ="Owner id is required.")]
        [Column("OwnerId")]
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        [NotMapped]
        public int NumberOfItems { get => Items.Count; }
        #endregion
        #region Relation Objects
        public virtual User Owner { get; set; }
        [InverseProperty("Reminder")]
        public virtual ICollection<ReminderItem> Items { get; set; }
        #endregion
    }
}
