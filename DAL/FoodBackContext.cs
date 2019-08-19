using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodBackContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }
        //public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<DailyGoalPerWeek> DailyGoalsPerWeek { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
               .HasMany<Food>(m => m.Foods)
               .WithMany(f => f.Meals)
               .Map(mf =>
               {
                   mf.MapLeftKey("MealRefId");
                   mf.MapRightKey("FoodRefId");
                   mf.ToTable("MealFood");
               });

            modelBuilder.Entity<User>()
              .HasMany<Meal>(u => u.UserMeals)
              .WithMany(m => m.Users)
              .Map(um =>
              {
                  um.MapLeftKey("UserRefId");
                  um.MapRightKey("MealRefId");
                  um.ToTable("UserMeal");
              });
            modelBuilder.Entity<DailyGoalPerWeek>()
             .HasMany<User>(d => d.Users)
             .WithMany(u => u.DailyGoals)
             .Map(um =>
             {
                 um.MapLeftKey("DailyGoalRefId");
                 um.MapRightKey("UserRefId");
                 um.ToTable("DailyGoalUser");
             });

        }
    }
}
