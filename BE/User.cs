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
        protected string FirstName { get => firstName; set => firstName = value; }
        protected string LastName { get => lastName; set => lastName = value; }
        protected string EmailAddress { get => emailAddress; set => emailAddress = value; }
        protected string Password { get => password; set => password = value; }
        protected string BirthDate { get => birthDate; set => birthDate = value; }
        protected string Height { get => height; set => height = value; }
        protected string Weight { get => weight; set => weight = value; }
    }
}
