using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class MeatInfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public FoodInformationViewModel FoodInfoVM;
        public MeatInfoCommand(FoodInformationViewModel aFoodInfoVM)
        {
            FoodInfoVM = aFoodInfoVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FoodInfoVM.foodInfoOptions(4);
        }
    }
}
