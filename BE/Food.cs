using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Food
    {
        public Food()
        {
            this.Meals = new HashSet<Meal>();
        }
        public Food(string aName,string aCalories, string aFiber,string aWater, string aProteins,string aSugar)
        {
           // foodId = aFoodId;
            name = aName;
            calories = aCalories;
            fats = aFiber;
            Fiber = aWater;
            proteins = aProteins;
            sugar = aSugar;




            this.Meals = new HashSet<Meal>();
        }
        [Key]
        private string foodId;
        private string name;
        private string calories;
        private string fats;
        private string fiber;
        private string proteins;
        private string sugar;
        public ICollection <Meal> Meals { get; set; }

        public string Name { get => name; set => name = value; }
        public string Calories { get => calories; set => calories = value; }
        public string Fats { get => fats; set => fats = value; }
        public string Fiber { get => fiber; set => fiber = value; }
        public string Proteins { get => proteins; set => proteins = value; }
        public string FoodId { get => foodId; set => foodId = value; }
        public string Sugar { get => sugar; set => sugar = value; }
        public override String ToString()
        {
            return Name;
        }
    }
}
