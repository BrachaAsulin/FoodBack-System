using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
