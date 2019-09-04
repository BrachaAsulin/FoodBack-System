using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class SignInCommand : ICommand
    {
       
        public AccountViewModel accountViewModel { get; set; }
        public SignInCommand(AccountViewModel accountViewModel)
        {
            this.accountViewModel = accountViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(accountViewModel.User.Error); 
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            accountViewModel.saveUser();//save the user in our system
        }
    }
}
