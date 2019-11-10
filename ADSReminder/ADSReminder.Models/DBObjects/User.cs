using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSReminder.Models.DBObjects
{
    /// <summary>
    /// User table object.
    /// </summary>
    public class User : BaseEntity
    {
        #region Ctor
        public User()
        {
            OwnerReminders = new HashSet<Reminder>();
        }
        #endregion
        #region String Types
        [Column("NameSurname")]
        [Required(ErrorMessage = "NameSurname isrequired.")]
        [MaxLength(200, ErrorMessage = "NameSurname can contain 200 charcters.")]
        public string NameSurname { get; set; }
        [Column("Username")]
        [Required(ErrorMessage = "Username isrequired.")]
        [MaxLength(100, ErrorMessage = "Username can contain 200 charcters.")]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Secret Question is required.")]
        [Column("SecretQuestion")]
        public string SecretQuestion { get; set; }
        [Column("SecretAnswer")]
        [Required(ErrorMessage = "Secret Answer is required.")]
        public string SecretAnswer { get; set; }
        #endregion
        #region Relation Objects
        [InverseProperty("Owner")]
        public virtual ICollection<Reminder> OwnerReminders { get; set; }
        #endregion
    }
}
