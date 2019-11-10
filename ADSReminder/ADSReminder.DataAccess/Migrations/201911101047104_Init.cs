namespace ADSReminder.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReminderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReminderId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Detail = c.String(nullable: false),
                        IsComplated = c.Boolean(nullable: false),
                        ExpreDate = c.DateTime(nullable: false),
                        ComplatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reminders", t => t.ReminderId, cascadeDelete: true)
                .Index(t => t.ReminderId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Detail = c.String(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false, maxLength: 200),
                        Username = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(),
                        SecretQuestion = c.String(nullable: false),
                        SecretAnswer = c.String(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reminders", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.ReminderItems", "ReminderId", "dbo.Reminders");
            DropIndex("dbo.Reminders", new[] { "OwnerId" });
            DropIndex("dbo.ReminderItems", new[] { "ReminderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reminders");
            DropTable("dbo.ReminderItems");
        }
    }
}
