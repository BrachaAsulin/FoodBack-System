using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    public class AddFoodCommand : ICommand
    {
        public MyDailyDietViewModel currentViewModel { get; set; }
        public AddFoodCommand(MyDailyDietViewModel currentViewModel)
        {
            this.currentViewModel = currentViewModel;

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string meal = parameter.ToString();
            switch(meal)
            {
                case "Breakfast":
                    this.currentViewModel.AddFood("Breakfast");
                    break;
                case "Lunch":
                    this.currentViewModel.AddFood("Lunch");
                    break;
                case "Dinner":
                    this.currentViewModel.AddFood("Dinner");
                    break;
                case "Snacks":
                    this.currentViewModel.AddFood("Snacks");
                    break;
               
            }
        }
    }
}
