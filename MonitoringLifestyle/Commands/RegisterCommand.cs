using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class RegisterCommand : ICommand
    {
        public AccountViewModel CurrentViewModel;
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(AccountViewModel AccountViewModel)
        {
            CurrentViewModel = AccountViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.CurrentViewModel.openRegister();
        }
    }
}
