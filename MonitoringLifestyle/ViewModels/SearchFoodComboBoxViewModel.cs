using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using System.Windows.Input;
using MonitoringLifestyle.Commands;

namespace MonitoringLifestyle.ViewModels
{
    public class SearchFoodComboBoxViewModel : DependencyObject, INotifyPropertyChanged
    {




        public string calories
        {
            get { return (string)GetValue(caloriesProperty); }
            set { SetValue(caloriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty caloriesProperty =
            DependencyProperty.Register("calories", typeof(string), typeof(SearchFoodComboBoxViewModel));



        public string fats
        {
            get { return (string)GetValue(fatsProperty); }
            set { SetValue(fatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty fatsProperty =
            DependencyProperty.Register("fats", typeof(string), typeof(SearchFoodComboBoxViewModel));


        public string carbs
        {
            get { return (string)GetValue(carbsProperty); }
            set { SetValue(carbsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty carbsProperty =
            DependencyProperty.Register("carbs", typeof(string), typeof(SearchFoodComboBoxViewModel));

        public string proteins
        {
            get { return (string)GetValue(proteinsProperty); }
            set { SetValue(proteinsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty proteinsProperty =
            DependencyProperty.Register("proteins", typeof(string), typeof(SearchFoodComboBoxViewModel));


        public string sugar
        {
            get { return (string)GetValue(sugarProperty); }
            set { SetValue(sugarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty sugarProperty =
            DependencyProperty.Register("sugar", typeof(string), typeof(SearchFoodComboBoxViewModel));




        public ICommand NutrionalValues { get; set; }
        //constructor 
        public SearchFoodComboBoxViewModel()
        {
            NutrionalValues = new NutrionalValuesCommand(this);
            SelectedFood = new BE.Food();
            SelectedFood = null;
            Foods = new ObservableCollection<string>();
            currentModel = new SearchFoodComboBoxModel();
        }
        //the food that the user selected 
        public BE.Food SelectedFood { get; set; }

        public SearchFoodComboBoxModel currentModel { get; set; }

        private Boolean isOpen;
        public Boolean IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }
        //the list that represented to the user 
        public ObservableCollection<string> Foods
        {
            get { return (ObservableCollection<string>)GetValue(FoodsProperty); }
            set { SetValue(FoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FoodsProperty =
            DependencyProperty.Register("Foods", typeof(ObservableCollection<string>), typeof(SearchFoodComboBoxViewModel));

        //the list of the foods represented to the user
        public List<BE.Food> ResultList { get; set; }

        //the string that the user is typing
        private string foodToSearch;
        public string FoodToSearch
        {
            get
            {
                return foodToSearch;
            }
            set
            {
                foodToSearch = value;
                OnPropertyChanged("FoodToSearch");
                ResultList = currentModel.getResultList(foodToSearch);
                Foods = GetNamesOfFoods(ResultList);
                IsOpen = true;
            }
        }

        private ObservableCollection<string> GetNamesOfFoods(List<Food> resultList)
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            foreach(BE.Food food in ResultList)
            {
                list.Add(food.Name);
            }
            return list;
        }

        //the food's name that the user selected
        private string selectedFoodName;
        public string SelectedFoodName
        {
            get
            {
                return selectedFoodName;
            }
            set
            {
                if (value != null)
                {
                    selectedFoodName = value;
                    string FoodId = getIdByName(selectedFoodName);
                    SelectedFood=currentModel.GetNutrientsForFood(FoodId);

                }
            }
        }

     
        //gets the ID of the selected food from the list of foods that represented
        private string getIdByName(string selectedFoodName)
        {
            foreach (BE.Food food in ResultList)
            {
                if (selectedFoodName.Equals(food.Name))
                    return food.FoodId;

            }
            return null;
        }

        #region INofifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
        #endregion

 
        
        public void setNutritionalValues()
        {
            calories = SelectedFood.Calories;
            fats = SelectedFood.Fats;
            carbs = SelectedFood.Fats;
            proteins = SelectedFood.Proteins;
            sugar = SelectedFood.Sugar;

        }


    }

}

       

    


  
