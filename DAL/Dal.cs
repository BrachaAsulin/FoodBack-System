using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class Dal:DbContext
    {
        /// <summary>
        /// according to a specific string returs a list of food that it's names conatains the string 
        /// </summary>
        /// <param name="searchFood"></param>
        /// <returns></returns>
        public List<BE.Food> getListFoods(string searchFood)
        {
            WebRequest request = WebRequest.Create("https://api.nal.usda.gov/ndb/search/?format=xml&q="+ searchFood + "&max=25&offset=0&nutrients=208&api_key=UUNpokCpdL8XQE6v7yf4rKqVj01tsQmJ6t2axPz2");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sReader = new StreamReader(dataStream);
            string output = sReader.ReadToEnd();
            //xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(output);
            XmlNodeList itemList = xmlDoc.SelectNodes("/list/item");
            List<BE.Food> resultList = new List<BE.Food>();
            foreach(XmlNode xmlItem in itemList)
            {
                resultList.Add(new Food { Name = xmlItem["name"].InnerText,FoodId=xmlItem["ndbno"].InnerText});
            }
            return resultList;

        }

        public Food GetNutrientsForFood(string foodId)
        {
            WebRequest request = WebRequest.Create("https://api.nal.usda.gov/ndb/reports/?ndbno=" + foodId + "&type=b&format=xml&api_key=UUNpokCpdL8XQE6v7yf4rKqVj01tsQmJ6t2axPz2");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sReader = new StreamReader(dataStream);
            string output = sReader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(output);
            XmlNodeList itemList = xmlDoc.SelectNodes("/report/food/nutrients/nutrient");
            Food food = new Food();
            //float vitamins = 0;
            string name = "";
            string value = "";
            for (int i = 0; i < itemList.Count; i++)
            {


                foreach (var item in (itemList[i]).Attributes)
                {
                    if ((((XmlAttribute)item).Name).Equals("name"))
                    {
                        name = (((XmlAttribute)item).Value);

                    }
                    else if ((((XmlAttribute)item).Name).Equals("value"))
                    {
                        value = (((XmlAttribute)item).Value);
                    }
                    else if ((((XmlAttribute)item).Name).Equals("group") && (((XmlAttribute)item).Value).Equals("Vitamins"))
                    {
                        name = "Vitamins";
                    }
                }
                switch (name)
                {
                    case "Energy":
                        food.Calories = value;
                        break;
                    // case "Water":
                    // foodDetails.Water = float.Parse(value);
                    //  break;
                    ///case "Sodium, Na":
                    // foodDetails.Sodium = float.Parse(value);
                    //  break;
                    case "Protein":
                        food.Proteins = value;
                        break;
                    case "Total lipid (fat)":
                        food.Fats = value;
                        break;
                    //case "Fiber, total dietary":
                    // foodDetails.Fiber = float.Parse(value);
                    //  break;
                    // case "Carbohydrate, by difference":
                    //   foodDetails.Carbohydrate = float.Parse(value);
                    //     break;
                    case "Sugars, total":
                        food.Sugar = value;
                        break;
                    // case "Vitamins":
                    // vitamins += float.Parse(value);
                    // break;
                    default:
                        break;
                }
            }
             return food;
        }

        public List<Food> getFoodList()
        {
            return null;
        }



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
                var userToReplace = FBContext.Users.FirstOrDefault(u => u.EmailAddress == userToUpdate.EmailAddress);
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
                var userTodelete = FBContext.Users.FirstOrDefault(u => u.EmailAddress == userToRemove.EmailAddress);
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

        public User findUserByEmail(string email)
        {
            using (FoodBackContext FBContext = new FoodBackContext())
            {
                User user = FBContext.Users.FirstOrDefault(u => u.EmailAddress.Equals(email));
                return user;
            }
        }

    }



}
