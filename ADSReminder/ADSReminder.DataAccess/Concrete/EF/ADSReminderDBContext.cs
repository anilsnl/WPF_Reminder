using ADSReminder.DataAccess.Migrations;
using ADSReminder.Models.DBObjects;
using System.Data.Entity;
using System.Linq;

namespace ADSReminder.DataAccess.Concrete.EF
{
    public class ADSReminderDBContext : DbContext
    {
        public ADSReminderDBContext():base("ADSDefault")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ADSReminderDBContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //Tables
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<ReminderItem> ReminderItems { get; set; }
    }
}
