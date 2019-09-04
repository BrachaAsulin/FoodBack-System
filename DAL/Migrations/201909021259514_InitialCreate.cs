namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyGoalPerWeeks",
                c => new
                    {
                        DailyId = c.Int(nullable: false, identity: true),
                        Calories = c.String(),
                        Fats = c.String(),
                        Carbs = c.String(),
                        Proteins = c.String(),
                        Sugar = c.String(),
                        SundayOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.DailyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        BirthDate = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        MealDate = c.String(),
                    })
                .PrimaryKey(t => t.MealId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Calories = c.String(),
                        Fats = c.String(),
                        Carbs = c.String(),
                        Proteins = c.String(),
                        Sugar = c.String(),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.MealFood",
                c => new
                    {
                        MealRefId = c.Int(nullable: false),
                        FoodRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MealRefId, t.FoodRefId })
                .ForeignKey("dbo.Meals", t => t.MealRefId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodRefId, cascadeDelete: true)
                .Index(t => t.MealRefId)
                .Index(t => t.FoodRefId);
            
            CreateTable(
                "dbo.UserMeal",
                c => new
                    {
                        UserRefId = c.String(nullable: false, maxLength: 128),
                        MealRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRefId, t.MealRefId })
                .ForeignKey("dbo.Users", t => t.UserRefId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealRefId, cascadeDelete: true)
                .Index(t => t.UserRefId)
                .Index(t => t.MealRefId);
            
            CreateTable(
                "dbo.DailyGoalUser",
                c => new
                    {
                        DailyGoalRefId = c.Int(nullable: false),
                        UserRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DailyGoalRefId, t.UserRefId })
                .ForeignKey("dbo.DailyGoalPerWeeks", t => t.DailyGoalRefId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserRefId, cascadeDelete: true)
                .Index(t => t.DailyGoalRefId)
                .Index(t => t.UserRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyGoalUser", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.DailyGoalUser", "DailyGoalRefId", "dbo.DailyGoalPerWeeks");
            DropForeignKey("dbo.UserMeal", "MealRefId", "dbo.Meals");
            DropForeignKey("dbo.UserMeal", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.MealFood", "FoodRefId", "dbo.Foods");
            DropForeignKey("dbo.MealFood", "MealRefId", "dbo.Meals");
            DropIndex("dbo.DailyGoalUser", new[] { "UserRefId" });
            DropIndex("dbo.DailyGoalUser", new[] { "DailyGoalRefId" });
            DropIndex("dbo.UserMeal", new[] { "MealRefId" });
            DropIndex("dbo.UserMeal", new[] { "UserRefId" });
            DropIndex("dbo.MealFood", new[] { "FoodRefId" });
            DropIndex("dbo.MealFood", new[] { "MealRefId" });
            DropTable("dbo.DailyGoalUser");
            DropTable("dbo.UserMeal");
            DropTable("dbo.MealFood");
            DropTable("dbo.Foods");
            DropTable("dbo.Meals");
            DropTable("dbo.Users");
            DropTable("dbo.DailyGoalPerWeeks");
        }
    }
}
