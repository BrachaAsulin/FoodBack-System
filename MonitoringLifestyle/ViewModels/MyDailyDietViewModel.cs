using BE;
using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    public class MyDailyDietViewModel : DependencyObject
    {
        User CurrentUser;
        public MyDailyDietViewModel(User currentUser)
        {
            CurrentUser = currentUser;
            currentModel = new MyDailyDietModel();
            AddingFood = new AddFoodCommand(this);
            Date = DateTime.Today;
            GetUserMealsAccordingDate();
            CalcToalNutrients();
            GetNutrientsGoal();
            CalcRemainingNutrient();
        }
        public ICommand AddingFood { get; set; }



        public BE.Food food { get; set; }

        public MyDailyDietModel currentModel { get; set; }

        private int foodIdSelected;
        public int FoodIdSelected
        {
            get { return foodIdSelected; }
            set
            {
                foodIdSelected = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                GetUserMealsAccordingDate();
                CalcToalNutrients();
                GetNutrientsGoal();
                CalcRemainingNutrient();
            }
        }

        public ObservableCollection<BE.Food> BreakfastFoods
        {
            get { return (ObservableCollection<BE.Food>)GetValue(BreakfastFoodsProperty); }
            set { SetValue(BreakfastFoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BreakfastFoods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BreakfastFoodsProperty =
            DependencyProperty.Register("BreakfastFoods", typeof(ObservableCollection<BE.Food>), typeof(MyDailyDietViewModel));

        public ObservableCollection<BE.Food> LunchFoods
        {
            get { return (ObservableCollection<BE.Food>)GetValue(LunchFoodsProperty); }
            set { SetValue(LunchFoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BreakfastFoods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LunchFoodsProperty =
            DependencyProperty.Register("LunchFoods", typeof(ObservableCollection<BE.Food>), typeof(MyDailyDietViewModel));

        public ObservableCollection<BE.Food> DinnerFoods
        {
            get { return (ObservableCollection<BE.Food>)GetValue(DinnerFoodsProperty); }
            set { SetValue(DinnerFoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BreakfastFoods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DinnerFoodsProperty =
            DependencyProperty.Register("DinnerFoods", typeof(ObservableCollection<BE.Food>), typeof(MyDailyDietViewModel));

        public ObservableCollection<BE.Food> SnacksFoods
        {
            get { return (ObservableCollection<BE.Food>)GetValue(SnacksFoodsProperty); }
            set { SetValue(SnacksFoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BreakfastFoods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnacksFoodsProperty =
            DependencyProperty.Register("SnacksFoods", typeof(ObservableCollection<BE.Food>), typeof(MyDailyDietViewModel));


        private void GetUserMealsAccordingDate()
        {
            BreakfastFoods = currentModel.GetMealPerUser("Breakfast", CurrentUser, date);
            LunchFoods = currentModel.GetMealPerUser("Lunch", CurrentUser, date);
            DinnerFoods = currentModel.GetMealPerUser("Dinner", CurrentUser, date);
            SnacksFoods = currentModel.GetMealPerUser("Snacks", CurrentUser, date);
        }

        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void autoFoods_PatternChanged(object sender, MonitoringLifestyle.Views.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = currentModel.Getfoods(args.Pattern);
                Foods = (List<BE.Food>)args.DataSource;
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string type = button.Tag.ToString();
            BE.Food f = button.DataContext as BE.Food;
            string id = f.FoodID.ToString();
            switch(type)
            {
                case "Breakfast":
                    RemoveFood(id, BreakfastFoods);
                    currentModel.RemoveFoodFromMeal("Breakfast", id, CurrentUser,date);
                    break;
                case "Lunch":
                    RemoveFood(id, LunchFoods);
                    currentModel.RemoveFoodFromMeal("Lunch", id, CurrentUser, date);
                    break;
                case "Dinner":
                    RemoveFood(id, DinnerFoods);
                    currentModel.RemoveFoodFromMeal("Dinner", id, CurrentUser, date);
                    break;
                case "Snacks":
                    RemoveFood(id, SnacksFoods);
                    currentModel.RemoveFoodFromMeal("Snacks", id, CurrentUser, date);
                    break;

            }
            CalcToalNutrients();
            CalcRemainingNutrient();
    }

        private void RemoveFood(string id,ObservableCollection<BE.Food> ListFoods)
        {
            foreach(BE.Food food in ListFoods)
            {
                if (food.FoodID.ToString().Equals(id))
                {
                    ListFoods.Remove(food);
                    return;
                }
            }
        }

        private List<BE.Food> Foods { get; set; }

        internal void AddFood(string v)
        {

            if (this.FoodIdSelected == 0)
            {
                MessageBox.Show("You have to choose a food from search engine above");
                return;
            }
            food = this.currentModel.GetFoodById(FoodIdSelected.ToString());
            food.FoodID = FoodIdSelected;
            food.Name = GetNameById(FoodIdSelected.ToString());
            switch (v)
            {
                case "Breakfast":
                    BreakfastFoods.Add(food);
                    currentModel.AddFoodForMealPerUser("Breakfast", CurrentUser, food,date);
                    break;
                case "Lunch":
                    LunchFoods.Add(food);
                    currentModel.AddFoodForMealPerUser("Lunch", CurrentUser, food, date);
                    break;
                case "Dinner":
                    DinnerFoods.Add(food);
                    currentModel.AddFoodForMealPerUser("Dinner", CurrentUser, food, date);
                    break;
                case "Snacks":
                    SnacksFoods.Add(food);
                    currentModel.AddFoodForMealPerUser("Snacks", CurrentUser, food, date);
                    break;
            }
            CalcToalNutrients();
            CalcRemainingNutrient();

        }

        private string GetNameById(string foodIdSelected)
        {
            foreach (BE.Food food in Foods)
            {
                if (food.FoodID.ToString().Equals(foodIdSelected))
                    return food.Name;
            }
            return null;
        }

        #region Total Nutrients



        public string TotalCalories
        {
            get { return (string)GetValue(TotalCaloriesProperty); }
            set { SetValue(TotalCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalCaloriesProperty =
            DependencyProperty.Register("TotalCalories", typeof(string), typeof(MyDailyDietViewModel));



        public string TotalFats
        {
            get { return (string)GetValue(TotalFatsProperty); }
            set { SetValue(TotalFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalFats.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalFatsProperty =
            DependencyProperty.Register("TotalFats", typeof(string), typeof(MyDailyDietViewModel));


        public string TotalFibers
        {
            get { return (string)GetValue(TotalFibersProperty); }
            set { SetValue(TotalFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalFibers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalFibersProperty =
            DependencyProperty.Register("TotalFibers", typeof(string), typeof(MyDailyDietViewModel));


        public string TotalProteins
        {
            get { return (string)GetValue(TotalProteinsProperty); }
            set { SetValue(TotalProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalProteins.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProteinsProperty =
            DependencyProperty.Register("TotalProteins", typeof(string), typeof(MyDailyDietViewModel));


        public string TotalSugars
        {
            get { return (string)GetValue(TotalSugarsProperty); }
            set { SetValue(TotalSugarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalSugars.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalSugarsProperty =
            DependencyProperty.Register("TotalSugars", typeof(string), typeof(MyDailyDietViewModel));

        private void CalcToalNutrients()
        {
            float calories = 0;
            float fats = 0;
            float fibers = 0;
            float proteins = 0;
            float sugars = 0;
            foreach (BE.Food food in BreakfastFoods)
            {
                calories += float.Parse(food.Calories);
                fats += float.Parse(food.Fats);
                fibers += float.Parse(food.Fiber);
                proteins += float.Parse(food.Proteins);
                sugars += float.Parse(food.Sugar);
            }
            foreach (BE.Food food in LunchFoods)
            {
                calories += float.Parse(food.Calories);
                fats += float.Parse(food.Fats);
                fibers += float.Parse(food.Fiber);
                proteins += float.Parse(food.Proteins);
                sugars += float.Parse(food.Sugar);
            }
            foreach (BE.Food food in DinnerFoods)
            {
                calories += float.Parse(food.Calories);
                fats += float.Parse(food.Fats);
                fibers += float.Parse(food.Fiber);
                proteins += float.Parse(food.Proteins);
                sugars += float.Parse(food.Sugar);
            }
            foreach (BE.Food food in SnacksFoods)
            {
                calories += float.Parse(food.Calories);
                fats += float.Parse(food.Fats);
                fibers += float.Parse(food.Fiber);
                proteins += float.Parse(food.Proteins);
                sugars += float.Parse(food.Sugar);
            }
            this.TotalCalories = calories.ToString();
            this.TotalFats = fats.ToString();
            this.TotalFibers = fibers.ToString();
            this.TotalProteins = proteins.ToString();
            this.TotalSugars = sugars.ToString();
        }
        #endregion

        #region Goals Nutrients

        public string GoalCalories
        {
            get { return (string)GetValue(GoalCaloriesProperty); }
            set { SetValue(GoalCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalCaloriesProperty =
            DependencyProperty.Register("GoalCalories", typeof(string), typeof(MyDailyDietViewModel));

        public string GoalFats
        {
            get { return (string)GetValue(GoalFatsProperty); }
            set { SetValue(GoalFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalFatsProperty =
            DependencyProperty.Register("GoalFats", typeof(string), typeof(MyDailyDietViewModel));

        public string GoalFibers
        {
            get { return (string)GetValue(GoalFibersProperty); }
            set { SetValue(GoalFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalFibersProperty =
            DependencyProperty.Register("GoalFibers", typeof(string), typeof(MyDailyDietViewModel));

        public string GoalProteins
        {
            get { return (string)GetValue(GoalProteinsProperty); }
            set { SetValue(GoalProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalProteinsProperty =
            DependencyProperty.Register("GoalProteins", typeof(string), typeof(MyDailyDietViewModel));

        public string GoalSugars
        {
            get { return (string)GetValue(GoalSugarsProperty); }
            set { SetValue(GoalSugarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalCalories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalSugarsProperty =
            DependencyProperty.Register("GoalSugars", typeof(string), typeof(MyDailyDietViewModel));

        private void GetNutrientsGoal()
        {
             BE.DailyGoalPerWeek d= currentModel.GetDailyGoalForWeek(CurrentUser, date);
            if(d!=null)
            {
                this.GoalCalories = d.Calories;
                this.GoalFats = d.Fats;
                this.GoalFibers = d.Fibers;
                this.GoalProteins = d.Proteins;
                this.GoalSugars = d.Sugars;
            }
            else
            {
                this.GoalCalories = "0";
                this.GoalFats = "0";
                this.GoalFibers = "0";
                this.GoalProteins = "0";
                this.GoalSugars = "0";
            }
        }

        #endregion

        #region Remaining Nutrients
        public string RemainingCalories
        {
            get { return (string)GetValue(RemainingCaloriesProperty); }
            set { SetValue(RemainingCaloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemainingCaloriesProperty =
            DependencyProperty.Register("RemainingCalories", typeof(string), typeof(MyDailyDietViewModel));

        public string RemainingFats
        {
            get { return (string)GetValue(RemainingFatsProperty); }
            set { SetValue(RemainingFatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemainingFats.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemainingFatsProperty =
            DependencyProperty.Register("RemainingFats", typeof(string), typeof(MyDailyDietViewModel));


        public string RemainingFibers
        { 
            get { return (string)GetValue(RemainingFibersProperty); }
            set { SetValue(RemainingFibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemainingFibers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemainingFibersProperty =
            DependencyProperty.Register("RemainingFibers", typeof(string), typeof(MyDailyDietViewModel));

        public string RemainingProteins
        {
            get { return (string)GetValue(RemainingProteinsProperty); }
            set { SetValue(RemainingProteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemainingProteins.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemainingProteinsProperty =
            DependencyProperty.Register("RemainingProteins", typeof(string), typeof(MyDailyDietViewModel));

        public string RemainingSugars
        {
            get { return (string)GetValue(RemainingSugarsProperty); }
            set { SetValue(RemainingSugarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemainingSugars.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemainingSugarsProperty =
            DependencyProperty.Register("RemainingSugars", typeof(string), typeof(MyDailyDietViewModel));

        private void CalcRemainingNutrient()
        {
            if (GoalCalories != null && TotalCalories != null)
                RemainingCalories = (float.Parse(GoalCalories) - float.Parse(TotalCalories)).ToString();
            if (GoalFats != null && TotalFats != null)
                RemainingFats = (float.Parse(GoalFats) - float.Parse(TotalFats)).ToString();
            if (GoalFibers != null && TotalFibers != null)
                RemainingFibers = (float.Parse(GoalFibers) - float.Parse(TotalFibers)).ToString();
            if (GoalProteins != null && TotalProteins != null)
                RemainingProteins = (float.Parse(GoalProteins) - float.Parse(TotalProteins)).ToString();
            if (GoalSugars != null && TotalSugars != null)
                RemainingSugars = (float.Parse(GoalSugars) - float.Parse(TotalSugars)).ToString();
        }


        #endregion
    }
}

