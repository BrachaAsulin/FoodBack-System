using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public User()
        {
            this.UserMeals = new HashSet<Meal>();
            this.DailyGoals = new HashSet<DailyGoalPerWeek>();
        }
        [Key]
        private string id;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string password;
        private string birthDate;
        private string height;
        private string weight;
        public ICollection<Meal> UserMeals { get; set; }
        public ICollection< DailyGoalPerWeek> DailyGoals { get; set; }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public string Password { get => password; set => password = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string Height { get => height; set => height = value; }
        public string Weight { get => weight; set => weight = value; }
    }
}
