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
            if (u != null)
            {
                if ((u.Password).Equals(password))
                    return true;
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Function that gets a user, type of meal and food to add to user's meal in a specific date and type of meal
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
        /// Fuction that gets a meal and a user and add the meal to the user
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
        /// Function that returns meal of a user on specific date 
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
     
        /// <summary>
        /// Returns the nutrient list of a specific food according to its id
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
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
            if(food.Calories==null)
            {
                food.Calories = "0";
            }
            if (food.Fats == null)
            {
                food.Fats = "0";
            }
            if (food.Fiber == null)
            {
                food.Fiber = "0";
            }
            if (food.Proteins == null)
            {
                food.Proteins = "0";
            }
            if(food.Sugar==null)
            {
                food.Sugar = "0";
            }
            return food;
        }

        /// <summary>
        /// Function that gets a food to remove from User's meal in specific date
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <param name="date"></param>
        public void RemoveFoodFromMeal(string meal, string id, User currentUser, DateTime date)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                var food = FBContext.Foods.Single(d => d.FoodID.ToString().Equals(id));
                foreach(Meal m in user.Meals)
                {
                    if(m.MealDate.Equals(date)&&m.Type.Equals(meal))
                    {
                        m.Foods.Remove(food);
                        FBContext.SaveChanges();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DailyGoalPerWeek GetDailyGoalForWeek(User currentUser, DateTime date)
        {
            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                foreach(DailyGoalPerWeek d in user.DailyGoalPerWeeks)
                {
                  
                    if(date.Month==d.SundayOfWeek.Value.Month && date.Year==d.SundayOfWeek.Value.Year && date.Day>=d.SundayOfWeek.Value.Day && date.Day<d.SundayOfWeek.Value.Day+7)
                    {
                        return d;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Function that retuns the week evaluation
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="sundayWeek"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public KeyValuePair<DateTime, float>[] GetWeekEvaluation(User currentUser, DateTime sundayWeek, string v)
        {

            float[] calories=new float[7] { 0, 0, 0, 0, 0, 0, 0 };
            float[] fats = new float[7] { 0, 0, 0, 0, 0, 0, 0 };
            float[] fibers = new float[7] { 0, 0, 0, 0, 0, 0, 0 };
            float[] proteins = new float[7] { 0, 0, 0, 0, 0, 0, 0 };
            float[] sugars = new float[7] { 0, 0, 0, 0, 0, 0, 0 };

            using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
            {
                var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                foreach (Meal meal in user.Meals )
                {
                    
                    if(meal.MealDate<=sundayWeek.AddDays(6))
                    {
                        if (meal.MealDate == sundayWeek)
                            foreach (Food food in meal.Foods)
                            {
                                calories[0] += float.Parse(food.Calories);
                                fats[0] += float.Parse(food.Fats);
                                fibers[0] += float.Parse(food.Fiber);
                                proteins[0] += float.Parse(food.Proteins);
                                sugars[0] += float.Parse(food.Sugar);
                            }
                        else if (meal.MealDate == sundayWeek.AddDays(1))
                            foreach (Food food in meal.Foods)
                            {
                                calories[1] += float.Parse(food.Calories);
                                fats[1] += float.Parse(food.Fats);
                                fibers[1] += float.Parse(food.Fiber);
                                proteins[1] += float.Parse(food.Proteins);
                                sugars[1] += float.Parse(food.Sugar);

                            }
                        else if (meal.MealDate == sundayWeek.AddDays(2))
                            foreach (Food food in meal.Foods)
                            {
                                calories[2] += float.Parse(food.Calories);
                                fats[2] += float.Parse(food.Fats);
                                fibers[2] += float.Parse(food.Fiber);
                                proteins[2] += float.Parse(food.Proteins);
                                sugars[2] += float.Parse(food.Sugar);

                            }
                        else if (meal.MealDate == sundayWeek.AddDays(3))
                            foreach (Food food in meal.Foods)
                            {
                                calories[3] += float.Parse(food.Calories);
                                fats[3] += float.Parse(food.Fats);
                                fibers[3] += float.Parse(food.Fiber);
                                proteins[3] += float.Parse(food.Proteins);
                                sugars[3] += float.Parse(food.Sugar);

                            }
                        else if (meal.MealDate == sundayWeek.AddDays(4))
                            foreach (Food food in meal.Foods)
                            {
                                calories[4] += float.Parse(food.Calories);
                                fats[4] += float.Parse(food.Fats);
                                fibers[4] += float.Parse(food.Fiber);
                                proteins[4] += float.Parse(food.Proteins);
                                sugars[4] += float.Parse(food.Sugar);

                            }
                        else if (meal.MealDate == sundayWeek.AddDays(5))
                            foreach (Food food in meal.Foods)
                            {
                                calories[5] += float.Parse(food.Calories);
                                fats[5] += float.Parse(food.Fats);
                                fibers[5] += float.Parse(food.Fiber);
                                proteins[5] += float.Parse(food.Proteins);
                                sugars[5] += float.Parse(food.Sugar);

                            }
                        else if (meal.MealDate == sundayWeek.AddDays(6))
                            foreach (Food food in meal.Foods)
                            {
                                calories[6] += float.Parse(food.Calories);
                                fats[6] += float.Parse(food.Fats);
                                fibers[6] += float.Parse(food.Fiber);
                                proteins[6] += float.Parse(food.Proteins);
                                sugars[6] += float.Parse(food.Sugar);

                            }
                    }
                }


            }
            if (v.Equals("Calories"))
            {
                KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(sundayWeek.Date,calories[0] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(1).Date,calories[1] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(2).Date,calories[2] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(3).Date,calories[3] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(4).Date,calories[4] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(5).Date,calories[5] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(6).Date,calories[6] ),
                };
                return result;
            }
            else if(v.Equals("Fats"))
            {
                KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(sundayWeek.Date,fats[0] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(1).Date,fats[1] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(2).Date,fats[2] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(3).Date,fats[3] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(4).Date,fats[4] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(5).Date,fats[5] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(6).Date,fats[6] ),
                };
                return result;
            }
            else if (v.Equals("Fibers"))
            {
                KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(sundayWeek.Date,fibers[0] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(1).Date,fibers[1] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(2).Date,fibers[2] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(3).Date,fibers[3] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(4).Date,fibers[4] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(5).Date,fibers[5] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(6).Date,fibers[6] ),
                };
                return result;
            }
            else if (v.Equals("Proteins"))
            {
                KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(sundayWeek.Date,proteins[0] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(1).Date,proteins[1] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(2).Date,proteins[2] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(3).Date,proteins[3] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(4).Date,proteins[4] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(5).Date,proteins[5] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(6).Date,proteins[6] ),
                };
                return result;
            }
            else if (v.Equals("Sugars"))
            {
                KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(sundayWeek.Date,sugars[0] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(1).Date,sugars[1] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(2).Date,sugars[2] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(3).Date,sugars[3] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(4).Date,sugars[4] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(5).Date,sugars[5] ),
                new KeyValuePair<DateTime,float>(sundayWeek.AddDays(6).Date,sugars[6] ),
                };
                return result;
            }
            return null;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="selectedMonth"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public KeyValuePair<DateTime, float>[] GetMonthEvaluation(User currentUser, string selectedMonth, string v)
        {
            float[] calories = new float[5] { 0, 0, 0, 0, 0 };
            float[] fats = new float[5] { 0, 0, 0, 0, 0 };
            float[] fibers = new float[5] { 0, 0, 0, 0, 0};
            float[] proteins = new float[5] { 0, 0, 0, 0, 0 };
            float[] sugars = new float[5] { 0, 0, 0, 0, 0};
            int month = Int32.Parse(selectedMonth);
            
                    using (FoodBackDBEntities FBContext = new FoodBackDBEntities())
                    {
                        var user = FBContext.Users.Single(u => u.EmailAddress.Equals(currentUser.EmailAddress));
                        foreach(Meal meal in user.Meals)
                        {
                            if(meal.MealDate.Month==month)
                            {
                                if (meal.MealDate.Day>=1 && meal.MealDate.Day<=7)//first week
                                    foreach (Food food in meal.Foods)
                                    {
                                        calories[0] += float.Parse(food.Calories);
                                        fats[0] += float.Parse(food.Fats);
                                        fibers[0] += float.Parse(food.Fiber);
                                        proteins[0] += float.Parse(food.Proteins);
                                        sugars[0] += float.Parse(food.Sugar);
                                    }
                                else if (meal.MealDate.Day>=8 && meal.MealDate.Day<=14)
                                    foreach (Food food in meal.Foods)
                                    {
                                        calories[1] += float.Parse(food.Calories);
                                        fats[1] += float.Parse(food.Fats);
                                        fibers[1] += float.Parse(food.Fiber);
                                        proteins[1] += float.Parse(food.Proteins);
                                        sugars[1] += float.Parse(food.Sugar);

                                    }
                                else if (meal.MealDate.Day >= 15 && meal.MealDate.Day <= 21)
                                    foreach (Food food in meal.Foods)
                                    {
                                        calories[2] += float.Parse(food.Calories);
                                        fats[2] += float.Parse(food.Fats);
                                        fibers[2] += float.Parse(food.Fiber);
                                        proteins[2] += float.Parse(food.Proteins);
                                        sugars[2] += float.Parse(food.Sugar);

                                    }
                                else if (meal.MealDate.Day >= 22 && meal.MealDate.Day <= 28)
                                    foreach (Food food in meal.Foods)
                                    {
                                        calories[3] += float.Parse(food.Calories);
                                        fats[3] += float.Parse(food.Fats);
                                        fibers[3] += float.Parse(food.Fiber);
                                        proteins[3] += float.Parse(food.Proteins);
                                        sugars[3] += float.Parse(food.Sugar);

                                    }
                                else if (meal.MealDate.Day >= 29 && meal.MealDate.Day <= 31)
                                    foreach (Food food in meal.Foods)
                                    {
                                        calories[4] += float.Parse(food.Calories);
                                        fats[4] += float.Parse(food.Fats);
                                        fibers[4] += float.Parse(food.Fiber);
                                        proteins[4] += float.Parse(food.Proteins);
                                        sugars[4] += float.Parse(food.Sugar);

                                    }
                            }
                        }

                    }
            if (v.Equals("Calories"))
            {
                if (month == 2)
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),calories[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,8),calories[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),calories[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),calories[3] )
                };
                    return result;
                }
                else
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),calories[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,8),calories[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),calories[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),calories[3] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,29),calories[4] )
                };
                    return result;
                }
                
            }
            else if (v.Equals("Fats"))
            {
                if (month == 2)
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),fats[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),fats[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),fats[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),fats[3] )
                };
                    return result;
                }
                else
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),fats[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),fats[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),fats[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),fats[3] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,29),fats[4] ),
                };
                    return result;
                }
            }
            else if (v.Equals("Fibers"))
            {
                if(month == 2)
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),fibers[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),fibers[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),fibers[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),fibers[3] )
                };
                    return result;
                }
                else
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),fibers[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),fibers[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),fibers[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),fibers[3] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,29),fibers[4] ),
                };
                    return result;
                }
            }
            else if (v.Equals("Proteins"))
            {
                if (month == 2)
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),proteins[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),proteins[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),proteins[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),proteins[3] )
                };
                    return result;
                }
                else
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),proteins[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),proteins[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),proteins[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),proteins[3] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,29),proteins[4] ),
                };
                    return result;
                }
            }
            else if (v.Equals("Sugars"))
            {

                if (month == 2)
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),sugars[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),sugars[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),sugars[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),sugars[3] )
                };
                    return result;
                }
                else
                {
                    KeyValuePair<DateTime, float>[] result = new KeyValuePair<DateTime, float>[] {
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,1),sugars[0] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019, month, 8),sugars[1] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,15),sugars[2] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,22),sugars[3] ),
                new KeyValuePair<DateTime,float>(new DateTime(2019,month,29),sugars[4] ),
                };
                    return result;
                }
            }

            return null;
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
