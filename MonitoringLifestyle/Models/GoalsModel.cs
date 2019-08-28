using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BL;

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
        public void UpdateGoalData(string aSundayOfWeek, string aCalories, string aFats, string aCarbs, string aProteins, string aSugar, string[,] aFullGoals)
        {
            dailyGoal = new BE.DailyGoalPerWeek(aSundayOfWeek, aCalories, aFats, aCarbs, aProteins, aSugar, aFullGoals);

            bl.AddDailyGoal(dailyGoal);

            //
            MessageBox.Show(aSundayOfWeek);
            //




        }
    }
}
