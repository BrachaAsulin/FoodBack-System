using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonitoringLifestyle.ViewModels
{
    class SearchFoodComboBoxViewModel : DependencyObject, INotifyPropertyChanged
    {
        public SearchFoodComboBoxViewModel()
        {
            Foods = new ObservableCollection<BE.Food>();
            currentModel = new SearchFoodComboBoxModel();
        }
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

        public ObservableCollection<BE.Food> Foods
        {
            get { return (ObservableCollection<BE.Food>)GetValue(FoodsProperty); }
            set { SetValue(FoodsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FoodsProperty =
            DependencyProperty.Register("Foods", typeof(ObservableCollection<BE.Food>), typeof(SearchFoodComboBoxViewModel));

        public event PropertyChangedEventHandler PropertyChanged;

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
                Foods = currentModel.getResultList(foodToSearch);
                IsOpen = true;

            }
        }
        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}

       

    


  
