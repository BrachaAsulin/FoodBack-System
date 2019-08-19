using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DailyReport
    {
        [Key]
        private string userId;
        [Key]
        private string date;
        private Meal breakfast;
        private Meal lunch;
        private Meal dinner;
        private Meal snacks;


        internal Meal Breakfast { get => breakfast; set => breakfast = value; }
        internal Meal Lunch { get => lunch; set => lunch = value; }
        internal Meal Dinner { get => dinner; set => dinner = value; }
        internal Meal Snacks { get => snacks; set => snacks = value; }

     
        
    }
}
