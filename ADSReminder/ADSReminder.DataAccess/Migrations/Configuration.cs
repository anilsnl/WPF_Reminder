namespace ADSReminder.DataAccess.Migrations
{
    using ADSReminder.Models.DBObjects;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ADSReminder.DataAccess.Concrete.EF.ADSReminderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ADSReminder.DataAccess.Concrete.EF.ADSReminderDBContext argContext)
        {

            if (!argContext.Users.Any())
            {
                var lcTestUser = new User
                {
                    CreatedBy = null,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    NameSurname = "Test User",
                    PasswordHash = ADSReminder.Utility.Security.Hasher.fnHashString("test"),
                    Username = "test",
                    SecretQuestion = "test",
                    SecretAnswer = ADSReminder.Utility.Security.Hasher.fnHashString("test"),
                };
                argContext.Users.Add(lcTestUser);
                argContext.SaveChanges();
                lcTestUser = argContext.Users.FirstOrDefault();
                var lcReminder = new Reminder
                {
                    CreatedDate = System.DateTime.Now,
                    OwnerId = lcTestUser.Id,
                    Title = "Test Group 1",
                    IsActive = true,
                    Detail = "Test Group Detail"
                };
                argContext.Reminders.Add(lcReminder);
                argContext.SaveChanges();
                lcReminder = argContext.Reminders.FirstOrDefault();
                argContext.ReminderItems.Add(new ReminderItem { ExpreDate = System.DateTime.Now.AddHours(20), Title = "Item 1", Detail = "Detail 1", IsComplated = false,ReminderId=lcReminder.Id });
                argContext.ReminderItems.Add(new ReminderItem { ExpreDate = System.DateTime.Now.AddHours(-20), Title = "Item 2", Detail = "Detail 2", IsComplated = false,ReminderId=lcReminder.Id });
                argContext.ReminderItems.Add(new ReminderItem { ExpreDate = System.DateTime.Now.AddHours(-20), Title = "Item 3", Detail = "Detail 3", IsComplated = true,ReminderId=lcReminder.Id });
                argContext.SaveChanges();
            }
        }
    }
}
