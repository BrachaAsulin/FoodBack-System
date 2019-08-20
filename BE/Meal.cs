using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Meal
    {
        public Meal()
        {
            this.Foods = new HashSet<Food>();
            this.Users = new HashSet<User>();
        }
        public enum TYPE { BREAKFAST,LUNCH,DINNER,SNACKS}
        [Key]
        private int mealId;
        [Key]
        private string mealDate;
        private TYPE type;
        public ICollection<Food> Foods { get; set; }
        public ICollection<User> Users { get; set; }

        public TYPE Type { get => type; set => type = value; }
        public int MealId { get => mealId; set => mealId = value; }
        public string MealDate { get => mealDate; set => mealDate = value; }
    }
}
