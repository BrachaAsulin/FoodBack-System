using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BL;
using BE;

namespace MonitoringLifestyle.Models
{
    public class GoalsModel
    {
        public BE.DailyGoalPerWeek dailyGoal;
        public BL.Bl bl;
        
        public GoalsModel()
        {
            //dailyGoal = new BE.DailyGoalPerWeek(null,"","","","","",null);
            bl = new BL.Bl();

        }
        public void UpdateGoalData(DateTime aSundayOfWeek, string aCalories, string aFats, string aCarbs, string aProteins, string aSugar, string[,] aFullGoals,User u)
        {

            dailyGoal = new BE.DailyGoalPerWeek(aSundayOfWeek, aCalories, aFats, aCarbs, aProteins, aSugar, aFullGoals);
            MessageBox.Show("current user" + u.ToString());
            MessageBox.Show("this week begins at " + aSundayOfWeek + " " + "good luck!");
            bl.AddDailyGoalsPerWeek(dailyGoal,u);
        }
    }
}
