using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Bl
    {
        public DAL.Dal dal;
        public Bl()
        {
            dal = new DAL.Dal();
        }
        public User saveUser(string emailAddress)
        {
            return dal.findUserByEmail(emailAddress);
        }
        public void AddUser(User newUser) { dal.AddUser(newUser); }
        public void RemoveUser(User userToRemove) { }
        public void UpdateUser(User userToUpdate) { }
        public void AddFood(Food newFood) { }
        public void RemoveFood(Food foodToRemove) { }
        public void UpdateFood(Food foodToUpdate) { }
        public void AddMeal(Meal newMeal) { }
        public void RemoveMeal(Meal mealToRemove) { }
        public void UpdateMeal(Meal mealToUpdate) { }
        public void AddDailyGoalsPerWeek(DailyGoalPerWeek newDailyGoal, User currentUser)
        {
            dal.AddDailyGoalsPerWeek(newDailyGoal, currentUser);
        }

        public Food GetNutrientsForFood(string foodId)
        {
            return dal.GetNutrientsForFood(foodId);
        }

        public void RemoveDailyGoal(DailyGoalPerWeek dailyGoalToRemove) { }
        public void UpdateDailyGoal(DailyGoalPerWeek dailyGoalToUpdate) { }
        public List<BE.Food> getListFoodItems(String textToSearch)
        {
           return dal.getListFoods(textToSearch);
        }
        public Food GetFoodById(string foodId)
        {
            List<Food> foodsList = dal.getFoodList();
            foreach(Food food in foodsList)
            {
                if (food.FoodId.Equals(foodId))
                    return food;
            }
            return null;
        }
    }

}
