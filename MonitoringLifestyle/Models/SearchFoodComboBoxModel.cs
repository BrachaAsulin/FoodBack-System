using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringLifestyle.Models
{
    public class SearchFoodComboBoxModel
    {
        BL.Bl BlObject;
        BE.Food CurrentFood;
        /// <summary>
        /// 
        /// constructor
        /// </summary>
        public SearchFoodComboBoxModel()
        {
            BlObject = new BL.Bl();
            
        }

        

        internal List<BE.Food> getResultList(string foodToSearch)
        {
            return BlObject.getListFoodItems(foodToSearch);
         
        }

        internal BE.Food GetNutrientsForFood(string foodId)
        {
            return BlObject.GetNutrientsForFood(foodId);
        }
    }
}
