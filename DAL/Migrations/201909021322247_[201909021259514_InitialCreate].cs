namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201909021259514_InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMeal", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.DailyGoalUser", "UserRefId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "EmailAddress", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "EmailAddress");
            AddForeignKey("dbo.UserMeal", "UserRefId", "dbo.Users", "EmailAddress", cascadeDelete: true);
            AddForeignKey("dbo.DailyGoalUser", "UserRefId", "dbo.Users", "EmailAddress", cascadeDelete: true);
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.DailyGoalUser", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.UserMeal", "UserRefId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "EmailAddress", c => c.String());
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.DailyGoalUser", "UserRefId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserMeal", "UserRefId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
