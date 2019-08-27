using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class NewAccountCommand : ICommand
    {
        public NewAccountViewModel currentViewModel { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public NewAccountCommand(NewAccountViewModel newAccountViewModel)
        {
            currentViewModel = newAccountViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(currentViewModel.NewAccount.Error);
        }

        public void Execute(object parameter)
        {
            currentViewModel.SaveNewUser();
        }
    }
}
