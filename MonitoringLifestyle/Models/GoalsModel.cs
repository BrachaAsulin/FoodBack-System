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
        public BL.Bl b = new BL.Bl();
        
        public GoalsModel()
        {
           // dailyGoal = new BE.DailyGoalPerWeek(); 
        }
        public void UpdateGoalData(string aSundayOfWeek, string aCalories, string aFats, string aCarbs, string aProteins, string aSugar, string[,] aFullGoals)
        {
            dailyGoal = new BE.DailyGoalPerWeek(aSundayOfWeek, aCalories, aFats, aCarbs, aProteins, aSugar, aFullGoals);


            // BL.Bl bl = new BL.Bl();
            //bl.AddDailyGoal(dailyGoal);

            // סתם כדי לבדוק

            // for(int i=0;i<4;i++)
            //    for(int j=0;j<5;j++)
            MessageBox.Show(aSundayOfWeek);

            // nice it is working!!




        }
    }
}
