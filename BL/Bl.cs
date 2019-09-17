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

        public KeyValuePair<DateTime, float>[] GetWeekEvaluation(User currentUser, DateTime sundayWeek, string v)
        {
            return dal.GetWeekEvaluation(currentUser, sundayWeek, v);
        }

        public KeyValuePair<DateTime, float>[] GetMonthEvaluation(User currentUser, string selectedMonth, string v)
        {
            return dal.GetMonthEvaluation(currentUser, selectedMonth, v);
        }

        public void RemoveUser(User userToRemove) { }
        public void UpdateUser(User userToUpdate) { }
        public void AddFood(Food newFood) { }
        public void RemoveFood(Food foodToRemove) { }
        public void UpdateFood(Food foodToUpdate) { }

        public void AddFoodForMealPerUser(string meal, User currentUser, Food food,DateTime date)
        {
            dal.AddFoodForMealPerUser(meal, currentUser, food,date);
        }

        public void AddMeal(Meal newMeal) { }

        public ObservableCollection<Food> GetMealPerUser(string v, User currentUser, DateTime date)
        {
            return dal.GetMealPerUser(v, currentUser, date);
        }

        public void RemoveFoodFromMeal(string meal, string id, User currentUser, DateTime date)
        {
            dal.RemoveFoodFromMeal(meal, id, currentUser, date);
        }

        public void RemoveMeal(Meal mealToRemove) { }

        public DailyGoalPerWeek GetDailyGoalForWeek(User currentUser, DateTime date)
        {
            return dal.GetDailyGoalForWeek(currentUser, date);
        }

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
            return dal.GetNutrientsForFood(foodId);
        }

        public bool emailCorrectToPassword(string emailAddress, string password)
        {
            return dal.emailCorrectToPassword(emailAddress, password);
        }
    }

}
