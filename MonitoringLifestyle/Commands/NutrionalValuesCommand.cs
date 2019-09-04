using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class NutrionalValuesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public SearchFoodComboBoxViewModel searchFoodComboboxVM;

        public NutrionalValuesCommand(SearchFoodComboBoxViewModel aSearchFoodComboboxVM)
        {
            searchFoodComboboxVM = aSearchFoodComboboxVM;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            searchFoodComboboxVM.setNutritionalValues();
        }
    }
}
