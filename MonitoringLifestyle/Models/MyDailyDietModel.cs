using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace MonitoringLifestyle.Models
{
    public class MyDailyDietModel
    {
        public MyDailyDietModel()
        {
            BlObject = new BL.Bl();
        }

        public BL.Bl BlObject { get; set; }

        internal IEnumerable Getfoods(string pattern)
        {
           return BlObject.getListFoodItems(pattern);
        }

        internal Food GetFoodById(string foodIdSelected)
        {
            return BlObject.GetFoodById(foodIdSelected);
        }

        internal void AddFoodForMealPerUser(string meal, User currentUser, Food food,DateTime date)
        {
            BlObject.AddFoodForMealPerUser(meal, currentUser, food,date);
        }

        internal ObservableCollection<Food> GetMealPerUser(string v, User currentUser, DateTime date)
        {
            return BlObject.GetMealPerUser(v, currentUser, date);
        }
    }
}
