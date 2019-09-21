using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    public class NutritionalValuesCalcViewModel:DependencyObject
    {
        public NutritionalValuesCalcViewModel()
        {
            this.currentModel = new NutritionalValuesCalcModel();
            this.NutrionalValues = new NutrionalValuesCommand(this);
            Foods = new List<BE.Food>();
        }
        public ICommand NutrionalValues { get; set; }
        public BE.Food food { get; set; }
        private int foodIdSelected;
        public int FoodIdSelected
        {
            get { return foodIdSelected; }
            set
            {
                foodIdSelected = value;
            }
        }

        internal void setNutritionalValues()
        {
            if (this.FoodIdSelected == 0)
            {
                MessageBox.Show("You have to choose a food from search engine above");
                return;
            }
            food = this.currentModel.GetFoodById(FoodIdSelected.ToString());
            food.FoodID = FoodIdSelected;
            food.Name = GetNameById(FoodIdSelected.ToString());
            calories = food.Calories;
            fats = food.Fats;
            fibers = food.Fiber;
            sugar = food.Sugar;
            proteins = food.Proteins;
        }

        private NutritionalValuesCalcModel currentModel { get; set; }
        private List<BE.Food> Foods { get; set; }

        public string calories
        {
            get { return (string)GetValue(caloriesProperty); }
            set { SetValue(caloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty caloriesProperty =
            DependencyProperty.Register("calories", typeof(string), typeof(NutritionalValuesCalcViewModel));



        public string fats
        {
            get { return (string)GetValue(fatsProperty); }
            set { SetValue(fatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty fatsProperty =
            DependencyProperty.Register("fats", typeof(string), typeof(NutritionalValuesCalcViewModel));


        public string fibers
        {
            get { return (string)GetValue(fibersProperty); }
            set { SetValue(fibersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty fibersProperty =
            DependencyProperty.Register("fibers", typeof(string), typeof(NutritionalValuesCalcViewModel));

        public string proteins
        {
            get { return (string)GetValue(proteinsProperty); }
            set { SetValue(proteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty proteinsProperty =
            DependencyProperty.Register("proteins", typeof(string), typeof(NutritionalValuesCalcViewModel));


        public string sugar
        {
            get { return (string)GetValue(sugarProperty); }
            set { SetValue(sugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty sugarProperty =
            DependencyProperty.Register("sugar", typeof(string), typeof(NutritionalValuesCalcViewModel));


        private string GetNameById(string foodIdSelected)
        {
            foreach (BE.Food food in Foods)
            {
                if (food.FoodID.ToString().Equals(foodIdSelected))
                    return food.Name;
            }
            return null;
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


     
    }
}
