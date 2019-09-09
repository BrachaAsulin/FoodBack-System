using BE;
using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    public class GoalsViewModel:DependencyObject,IVM
    {
        
       // public DashboardVM dashboardVM;
        public GoalsModel CurrentModel { get; set; }
        public ICommand UpdateGoals { get; set; }
         public User currentUser;
        public DateTime sundayWeek { get; set; }

        public void updateGoalsDetails()
        {
          string[,] arr = new string[4, 5] { { BreakfastCalories, BreakfastFats, BreakfastFibers, BreakfastProteins, BreakfastSugar },
                                            {LunchCalories,LunchFats,LunchFibers,LunchProteins,LunchSugar },
                                            {DinnerCalories,DinnerFats,DinnerFibers,DinnerProteins,DinnerSugar },
                                            { SnacksCalories,SnacksFats,SnacksFibers,SnacksProteins,SnacksSugar} };
            int aSumCalories = int.Parse(BreakfastCalories) +int.Parse(LunchCalories)+int.Parse(DinnerCalories)+int.Parse(SnacksCalories);
            int aSumFats = int.Parse(BreakfastFats) + int.Parse(LunchFats) + int.Parse(DinnerFats) + int.Parse(SnacksFats);
            int aSumFibers = int.Parse(BreakfastFibers) + int.Parse(LunchFibers) + int.Parse(DinnerFibers) + int.Parse(SnacksFibers);
            int aSumProteins = int.Parse(BreakfastProteins) + int.Parse(LunchProteins) + int.Parse(DinnerProteins) + int.Parse(SnacksProteins);
            int aSumSugar = int.Parse(BreakfastSugar) + int.Parse(LunchSugar) + int.Parse(DinnerSugar) + int.Parse(SnacksSugar);
            
            //put the sum of the nutritional values in the last row in the table
            SumCalories = aSumCalories.ToString();
            SumFats = aSumFats.ToString();
            SumFibers = aSumFibers.ToString();
            SumProteins = aSumProteins.ToString();
            SumSugar = aSumSugar.ToString();    
            CurrentModel.UpdateGoalData(sundayWeek, SumCalories,SumFats, SumFibers, SumProteins, SumSugar,arr, currentUser);
        }

        public GoalsViewModel(User aCurrentUser)
        {
          
            EnableGridGoal = false;
            currentUser = aCurrentUser;
            CurrentModel = new GoalsModel();
            UpdateGoals = new UpdateGoalsCommand(this);
           
        }


        public bool EnableGridGoal
        {
            get { return (bool)GetValue(EnableGridGoalProperty); }
            set { SetValue(EnableGridGoalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnableGridGoal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableGridGoalProperty =
            DependencyProperty.Register("EnableGridGoal", typeof(bool), typeof(GoalsViewModel));



        public string BreakfastCalories
        {
            get { return (string)GetValue(BreakfastCaloriesProperty); }
            set { SetValue(BreakfastCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastCaloriesProperty =
            DependencyProperty.Register("BreakfastCalories", typeof(string), typeof(GoalsViewModel));


        //////



        public string BreakfastFats
        {
            get { return (string)GetValue(BreakfastFatsProperty); }
            set { SetValue(BreakfastFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastFatsProperty =
            DependencyProperty.Register("BreakfastFats", typeof(string), typeof(GoalsViewModel));

        public string BreakfastFibers
        {
            get { return (string)GetValue(BreakfastFibersProperty); }
            set { SetValue(BreakfastFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastFibersProperty =
            DependencyProperty.Register("BreakfastFibers", typeof(string), typeof(GoalsViewModel));
        public string BreakfastProteins
        {
            get { return (string)GetValue(BreakfastProteinsProperty); }
            set { SetValue(BreakfastProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastProteinsProperty =
            DependencyProperty.Register("BreakfastProteins", typeof(string), typeof(GoalsViewModel));

        public string BreakfastSugar
        {
            get { return (string)GetValue(BreakfastSugarProperty); }
            set { SetValue(BreakfastSugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastSugarProperty =
            DependencyProperty.Register("BreakfastSugar", typeof(string), typeof(GoalsViewModel));

        //
        public string LunchCalories
        {
            get { return (string)GetValue(LunchCaloriesProperty); }
            set { SetValue(LunchCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchCaloriesProperty =
            DependencyProperty.Register("LunchCalories", typeof(string), typeof(GoalsViewModel));


        //////



        public string LunchFats
        {
            get { return (string)GetValue(LunchFatsProperty); }
            set { SetValue(LunchFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchFatsProperty =
            DependencyProperty.Register("LunchFats", typeof(string), typeof(GoalsViewModel));

        public string LunchFibers
        {
            get { return (string)GetValue(LunchFibersProperty); }
            set { SetValue(LunchFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchFibersProperty =
            DependencyProperty.Register("LunchFibers", typeof(string), typeof(GoalsViewModel));
        public string LunchProteins
        {
            get { return (string)GetValue(LunchProteinsProperty); }
            set { SetValue(LunchProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchProteinsProperty =
            DependencyProperty.Register("LunchProteins", typeof(string), typeof(GoalsViewModel));

        public string LunchSugar
        {
            get { return (string)GetValue(LunchSugarProperty); }
            set { SetValue(LunchSugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchSugarProperty =
            DependencyProperty.Register("LunchSugar", typeof(string), typeof(GoalsViewModel));

        //

        public string DinnerCalories
        {
            get { return (string)GetValue(DinnerCaloriesProperty); }
            set { SetValue(DinnerCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerCaloriesProperty =
            DependencyProperty.Register("DinnerCalories", typeof(string), typeof(GoalsViewModel));


        //////



        public string DinnerFats
        {
            get { return (string)GetValue(DinnerFatsProperty); }
            set { SetValue(DinnerFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerFatsProperty =
            DependencyProperty.Register("DinnerFats", typeof(string), typeof(GoalsViewModel));

        public string DinnerFibers
        {
            get { return (string)GetValue(DinnerFibersProperty); }
            set { SetValue(DinnerFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerFibersProperty =
            DependencyProperty.Register("DinnerFibers", typeof(string), typeof(GoalsViewModel));
        public string DinnerProteins
        {
            get { return (string)GetValue(DinnerProteinsProperty); }
            set { SetValue(DinnerProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerProteinsProperty =
            DependencyProperty.Register("DinnerProteins", typeof(string), typeof(GoalsViewModel));

        public string DinnerSugar
        {
            get { return (string)GetValue(DinnerSugarProperty); }
            set { SetValue(DinnerSugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerSugarProperty =
            DependencyProperty.Register("DinnerSugar", typeof(string), typeof(GoalsViewModel));

        //

        public string SnacksCalories
        {
            get { return (string)GetValue(SnacksCaloriesProperty); }
            set { SetValue(SnacksCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksCaloriesProperty =
            DependencyProperty.Register("SnacksCalories", typeof(string), typeof(GoalsViewModel));


        //////



        public string SnacksFats
        {
            get { return (string)GetValue(SnacksFatsProperty); }
            set { SetValue(SnacksFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksFatsProperty =
            DependencyProperty.Register("SnacksFats", typeof(string), typeof(GoalsViewModel));

        public string SnacksFibers
        {
            get { return (string)GetValue(SnacksFibersProperty); }
            set { SetValue(SnacksFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksFibersProperty =
            DependencyProperty.Register("SnacksFibers", typeof(string), typeof(GoalsViewModel));
        public string SnacksProteins
        {
            get { return (string)GetValue(SnacksProteinsProperty); }
            set { SetValue(SnacksProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksProteinsProperty =
            DependencyProperty.Register("SnacksProteins", typeof(string), typeof(GoalsViewModel));

        public string SnacksSugar
        {
            get { return (string)GetValue(SnacksSugarProperty); }
            set { SetValue(SnacksSugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksSugarProperty =
            DependencyProperty.Register("SnacksSugar", typeof(string), typeof(GoalsViewModel));

        //

        public string SumCalories
        {
            get { return (string)GetValue(SumCaloriesProperty); }
            set { SetValue(SumCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumCaloriesProperty =
            DependencyProperty.Register("SumCalories", typeof(string), typeof(GoalsViewModel));
        public string SumFats
        {
            get { return (string)GetValue(SumFatsProperty); }
            set { SetValue(SumFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumFatsProperty =
            DependencyProperty.Register("SumFats", typeof(string), typeof(GoalsViewModel));
        public string SumFibers
        {
            get { return (string)GetValue(SumFibersProperty); }
            set { SetValue(SumFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumFibersProperty =
            DependencyProperty.Register("SumFibers", typeof(string), typeof(GoalsViewModel));


        public string SumProteins
        {
            get { return (string)GetValue(SumProteinsProperty); }
            set { SetValue(SumProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumProteinsProperty =
            DependencyProperty.Register("SumProteins", typeof(string), typeof(GoalsViewModel));
        public string SumSugar
        {
            get { return (string)GetValue(SumSugarProperty); }
            set { SetValue(SumSugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumSugarProperty =
            DependencyProperty.Register("SumSugar", typeof(string), typeof(GoalsViewModel));

    }
}
