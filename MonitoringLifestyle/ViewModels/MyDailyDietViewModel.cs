using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MyDailyDietViewModel()
        {
            currentModel = new MyDailyDietModel();
            AddingFood = new AddFoodCommand(this);
            BreakfastFoods = new ObservableCollection<BE.Food>();
            Date = DateTime.Today;
        }
        public ICommand AddingFood { get; set; }



        public BE.Food food { get; set; }

        public MyDailyDietModel currentModel { get; set; }

        private string foodIdSelected;
        public string FoodIdSelected
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
            string id = f.FoodId;
            switch(type)
            {
                case "Breakfast":
                    RemoveFood(id, BreakfastFoods);
                    break;
                case "Lunch":
                    RemoveFood(id, LunchFoods);
                    break;
                case "Dinner":
                    RemoveFood(id, DinnerFoods);
                    break;
                case "Snacks":
                    RemoveFood(id, SnacksFoods);
                    break;

            }

        // ...
    }

        private void RemoveFood(string id,ObservableCollection<BE.Food> ListFoods)
        {
            foreach(BE.Food food in ListFoods)
            {
                if (food.FoodId.Equals(id))
                {
                    ListFoods.Remove(food);
                    return;
                }
            }
        }

        private List<BE.Food> Foods { get; set; }
        internal void AddFood(string v)
        {

            if (this.FoodIdSelected == null)
            {
                MessageBox.Show("You have to choose a food from search engine above");
                return;
            }
            food = this.currentModel.GetFoodById(FoodIdSelected);
            food.Name = GetNameById(FoodIdSelected);
            switch (v)
            {
                case "Breakfast":
                    BreakfastFoods.Add(food);
                    break;
                case "Lunch":
                    LunchFoods.Add(food);
                    break;
                case "Dinner":
                    DinnerFoods.Add(food);
                    break;
                case "Snacks":
                    SnacksFoods.Add(food);
                    break;
            }

        }

        private string GetNameById(string foodIdSelected)
        {
            foreach (BE.Food food in Foods)
            {
                if (food.FoodId.Equals(foodIdSelected))
                    return food.Name;
            }
            return null;
        }

    }
}

