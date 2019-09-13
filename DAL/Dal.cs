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
    public class Dal
    {
        /// <summary>
        /// Add function for User entity 
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(BE.User user)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                FBContext.Users.Add(user);
                FBContext.SaveChanges();
            }

        }
        /// <summary>
        /// This function returs a user according to his ID - his email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User findUserByEmail(string email)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                User user = FBContext.Users.FirstOrDefault(u => u.EmailAddress.Equals(email));
                return user;
            }
        }
        /// <summary>
        /// This function add to an User a daily goals for specific week
        /// </summary>
        /// <param name="dailyGoalsPerWeek"></param>
        /// <param name="currentUser"></param>
        public void AddDailyGoalsPerWeek(BE.DailyGoalPerWeek dailyGoalsPerWeek, User currentUser)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                DailyGoalPerWeek dailyInThisWeek=null;
                foreach(DailyGoalPerWeek d in user.DailyGoalPerWeeks)
                {
                    if(d.SundayOfWeek==dailyGoalsPerWeek.SundayOfWeek)
                    {
                        dailyInThisWeek = d;
                        break;
                    }
                }
                if(dailyInThisWeek!=null)
                {
                    user.DailyGoalPerWeeks.Remove(dailyInThisWeek);
                }
                user.DailyGoalPerWeeks.Add(dailyGoalsPerWeek);
                dailyGoalsPerWeek.Users.Add(user);
                FBContext.SaveChanges();
            }

        }

        public bool emailCorrectToPassword(string emailAddress, string password)
        {
            User u = findUserByEmail(emailAddress);
            if ((u.Password).Equals(password))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="currentUser"></param>
        /// <param name="food"></param>
        public void AddFoodForMealPerUser(string meal, User currentUser, Food food,DateTime date)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                foreach(Meal m in user.Meals)
                {
                    if(m.MealDate.Equals(date)&& m.Type.Equals(meal))
                    {
                        m.Foods.Add(food);
                        food.Meals.Add(m);
                        FBContext.SaveChanges();
                        return;
                    }
                }
                Meal m1 = new BE.Meal { Type = meal, MealDate = date };
                m1.Foods.Add(food);
                AddMeal(m1, user);
                

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="currentUser"></param>
        public void AddMeal(BE.Meal meal, BE.User currentUser)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                FBContext.Meals.Add(meal);
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                user.Meals.Add(meal);
                meal.Users.Add(user);
                FBContext.SaveChanges();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="currentUser"></param>
        /// <param name="date"></param>
        public ObservableCollection<Food> GetMealPerUser(string v, User currentUser, DateTime date)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                foreach(Meal m in user.Meals)
                {
                    if(m.MealDate.Equals(date)&&m.Type.Equals(v))
                    {
                        return new ObservableCollection<Food>(m.Foods);
                    }
                }
                return new ObservableCollection<Food>();
            }
        }

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
                resultList.Add(new Food { Name = xmlItem["name"].InnerText, FoodID =Int32.Parse(xmlItem["ndbno"].InnerText)});
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
            food.FoodID = Int32.Parse(foodId);
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
                    //case "Water":
                    // food.Water =value;
                      //break;
                    ///case "Sodium, Na":
                    // foodDetails.Sodium = float.Parse(value);
                    //  break;
                    case "Protein":
                        food.Proteins = value;
                        break;
                    case "Total lipid (fat)":
                        food.Fats = value;
                        break;
                    case "Fiber, total dietary":
                     food.Fiber = value;
                      break;
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

        



   
        //
        public void AddFood(Food food,Meal currentMeal)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                FBContext.Foods.Add(food);
                currentMeal.Foods.Add(food);
                FBContext.SaveChanges();
            }
        }

        

        public void UpdateUser(User userToUpdate)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var userToReplace = FBContext.Users.FirstOrDefault(u => u.EmailAddress == userToUpdate.EmailAddress);
                FBContext.Users.Remove(userToReplace);
                FBContext.Users.Add(userToUpdate);
                FBContext.SaveChanges();
            }
        }


        public void UpdateMeal(Meal mealToUpdate)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
            }
        }

        public void UpdateFood(Food foodToUpdate)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var foodToReplace = FBContext.Foods.FirstOrDefault(f => f.FoodID == foodToUpdate.FoodID);
                FBContext.Foods.Remove(foodToReplace);
                FBContext.Foods.Add(foodToUpdate);
                FBContext.SaveChanges();
            }
        }

        public void UpdateDailyGoalPerWeek(DailyGoalPerWeek dailyGoalToUpdate)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var dailyGoalToReplace = FBContext.DailyGoalPerWeeks.FirstOrDefault(d => d.DailyId == dailyGoalToUpdate.DailyId);
                FBContext.DailyGoalPerWeeks.Remove(dailyGoalToReplace);
                FBContext.DailyGoalPerWeeks.Add(dailyGoalToUpdate);
                FBContext.SaveChanges();
            }
        }

        public void RemoveUser(User userToRemove)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var userTodelete = FBContext.Users.FirstOrDefault(u => u.EmailAddress == userToRemove.EmailAddress);
                FBContext.Users.Remove(userTodelete);
                FBContext.SaveChanges();
            }
        }

        public void RemoveMeal(Meal mealToRemove)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var usersWithThisMeal = from user in FBContext.Users
                                        where user.Meals.FirstOrDefault(m => m.Type == mealToRemove.Type && m.MealDate.Equals(mealToRemove.MealDate)) != null
                                        select user;
                foreach(BE.User user in usersWithThisMeal)
                {
                    user.Meals.Remove(mealToRemove);
                }
                FBContext.Meals.Remove(mealToRemove);
                FBContext.SaveChanges();
            }
        }
        //remove a food from a specific meal
        public void RemoveFood(Food foodToRemove,Meal meal)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var food = FBContext.Foods.FirstOrDefault(f=>f.FoodID == foodToRemove.FoodID);
                meal.Foods.Remove(food);
                var meals = from meal1 in FBContext.Meals
                                        where meal1.Foods.FirstOrDefault(f => f.FoodID == foodToRemove.FoodID) != null
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
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                currentUser.DailyGoalPerWeeks.Remove(dailyGoalToRemove);
                FBContext.SaveChanges();
            }

        }

       

    }



}
