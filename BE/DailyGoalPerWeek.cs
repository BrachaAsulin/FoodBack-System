using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DailyGoalPerWeek
    {
        [Key]
        private int dailyId;
        private string sundayOfWeek;//the first date of the week
        private string calories;
        private string fats;
        private string carbs;
        private string proteins;
        private string sugar;
        private string[,] fullGoals;//matrix 4x5 that contains meals and their nutritional values

        public DailyGoalPerWeek(string aSundayOfWeek, string aCalories, string aFats, string aCarbs, string aProteins, string aSugar, string[,] aFullGoals)
        {
            this.Users = new HashSet<User>();
           
            // FullGoals = new string[4, 5];

            SundayOfWeek = aSundayOfWeek;
            Calories = aCalories;
            Fats = aFats;
            Carbs = aCarbs;
            Proteins = aProteins;
            Sugar = aSugar;
            FullGoals = aFullGoals;



        }

        public ICollection<User> Users { get; set; }

        public string Calories { get => calories; set => calories = value; }
        public string Fats { get => fats; set => fats = value; }
        public string Carbs { get => carbs; set => carbs = value; }
        public string Proteins { get => proteins; set => proteins = value; }
        public string Sugar { get => sugar; set => sugar = value; }
        public string SundayOfWeek { get => sundayOfWeek; set => sundayOfWeek = value; }
        public int DailyId { get => dailyId; set => dailyId = value; }
        public string[,] FullGoals { get => fullGoals; set => fullGoals = value; }
    }
}
