using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    public class ListOfFoodsViewModel:INotifyPropertyChanged
    {
        public ICommand AddFoodButtton { get; set; }

        public ListOfFoodsViewModel()
        {
           // AddFoodButtton = new AddFoodCommand(this);
        }
        private UserControl addingFood;


        public UserControl AddingFood
        {
            get
            {
                return addingFood;
            }
            set
            {
                addingFood = value;
                OnPropertyChanged("AddingFood");
            }
        }


        internal void GetAFood()
        {
            AddingFood= new AddFoodUserControl();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
