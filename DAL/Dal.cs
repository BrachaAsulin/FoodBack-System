using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Dal:DbContext
    {
       
        //Add functions
        public void AddUser(User user)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                FBContext.Users.Add(user);
                FBContext.SaveChanges();
            }
         
        }
        public void AddDailyGoalsPerWeek(DailyGoalPerWeek dailyGoalsPerWeek,User currentUser)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                dailyGoalsPerWeek.Users.Add(currentUser);
                //checking if there is already goals for the accepted week
                var existsGoal= currentUser.DailyGoals.FirstOrDefault(d => d.SundayOfWeek.Equals(dailyGoalsPerWeek.SundayOfWeek)); 
                if(existsGoal!=null)
                {
                    currentUser.DailyGoals.Remove(existsGoal);
                }
                currentUser.DailyGoals.Add(dailyGoalsPerWeek);
                FBContext.DailyGoalsPerWeek.Add(dailyGoalsPerWeek);
                FBContext.SaveChanges();

            }
            
        }
        /**
         * this function called in the first that the user add a food to a meal
         * */
        public void AddMeal(Meal meal,User currentUser)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                FBContext.Meals.Add(meal);
                currentUser.UserMeals.Add(meal);
                FBContext.SaveChanges();
            }

        }
        //
        public void AddFood(Food food,Meal currentMeal)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                FBContext.Foods.Add(food);
                currentMeal.Foods.Add(food);
                FBContext.SaveChanges();
            }
        }

        

        public void UpdateUser(User userToUpdate)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var userToReplace = FBContext.Users.FirstOrDefault(u => u.Id == userToUpdate.Id);
                FBContext.Users.Remove(userToReplace);
                FBContext.Users.Add(userToUpdate);
                FBContext.SaveChanges();
            }
        }


        public void UpdateMeal(Meal mealToUpdate)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
            }
        }

        public void UpdateFood(Food foodToUpdate)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var foodToReplace = FBContext.Foods.FirstOrDefault(f => f.FoodId == foodToUpdate.FoodId);
                FBContext.Foods.Remove(foodToReplace);
                FBContext.Foods.Add(foodToUpdate);
                FBContext.SaveChanges();
            }
        }

        public void UpdateDailyGoalPerWeek(DailyGoalPerWeek dailyGoalToUpdate)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var dailyGoalToReplace = FBContext.DailyGoalsPerWeek.FirstOrDefault(d => d.DailyId == dailyGoalToUpdate.DailyId);
                FBContext.DailyGoalsPerWeek.Remove(dailyGoalToReplace);
                FBContext.DailyGoalsPerWeek.Add(dailyGoalToUpdate);
                FBContext.SaveChanges();
            }
        }

        public void RemoveUser(User userToRemove)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var userTodelete = FBContext.Users.FirstOrDefault(u => u.Id == userToRemove.Id);
                FBContext.Users.Remove(userTodelete);
                FBContext.SaveChanges();
            }
        }

        public void RemoveMeal(Meal mealToRemove)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var usersWithThisMeal = from user in FBContext.Users
                                        where user.UserMeals.FirstOrDefault(m => m.MealId == mealToRemove.MealId) != null
                                        select user;
                foreach(User user in usersWithThisMeal)
                {
                    user.UserMeals.Remove(mealToRemove);
                }
                FBContext.Meals.Remove(mealToRemove);
                FBContext.SaveChanges();
            }
        }
        //remove a food from a specific meal
        public void RemoveFood(Food foodToRemove,Meal meal)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                var food = FBContext.Foods.FirstOrDefault(f=>f.FoodId==foodToRemove.FoodId);
                meal.Foods.Remove(food);
                var meals = from meal1 in FBContext.Meals
                                        where meal1.Foods.FirstOrDefault(f => f.FoodId == foodToRemove.FoodId) != null
                                        select meal1;
                if(meals==null)//if this food does not exist in any meal
                {
                    FBContext.Foods.Remove(food);
                }
                FBContext.SaveChanges();
            }
        }

        public void RemoveDailyGoal(DailyGoalPerWeek dailyGoalToRemove,User currentUser)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                currentUser.DailyGoals.Remove(dailyGoalToRemove);
                FBContext.SaveChanges();
            }

        }
    }
}
