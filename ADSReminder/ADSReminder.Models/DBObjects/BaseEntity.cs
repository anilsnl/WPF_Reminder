using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSReminder.Models.DBObjects
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    public abstract class BaseEntity
    {
        #region Int Types
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Column("CreatedBy")]
        public int? CreatedBy { get; set; }
        [Column("ModifiedBy")]
        public int? ModifiedBy { get; set; }
        #endregion
        #region Bool Types
        [Column("IsActive")]
        [Required(ErrorMessage = "IsActive is required.")]
        public bool IsActive { get; set; }
        #endregion
        #region DateTime Types
        [Column("CreatedDate")]
        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; }
        [Column("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }
        #endregion
        #region Relation Objects
        #endregion
    }
}
