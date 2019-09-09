using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BL;
using BE;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace MonitoringLifestyle.Models
{
    public class GoalsModel
    {
        public BE.DailyGoalPerWeek dailyGoal;
        public BL.Bl bl;
        
        public GoalsModel()
        {
            dailyGoal = new BE.DailyGoalPerWeek("","","","","","",null);
            bl = new BL.Bl();

        }
        public void UpdateGoalData(string aSundayOfWeek, string aCalories, string aFats, string aCarbs, string aProteins, string aSugar, string[,] aFullGoals,User u)
        {
            dailyGoal = new BE.DailyGoalPerWeek(aSundayOfWeek, aCalories, aFats, aCarbs, aProteins, aSugar, aFullGoals);

            ////////////////////////////////////////// problema
            MessageBox.Show("current user" + u.ToString());
            MessageBox.Show("this week begins at " + aSundayOfWeek + " " + "good luck!");
           


            bl.AddDailyGoalsPerWeek(dailyGoal,u);
            MessageBox.Show(dailyGoal.ToString());

            //

            //




        }
    }
}
