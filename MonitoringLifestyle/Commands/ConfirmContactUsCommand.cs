using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class ConfirmContactUsCommand : ICommand
    {
        public ContactUsViewModel ContactUsViewModel { get; set; }
       


        public ConfirmContactUsCommand(ContactUsViewModel ContactUsViewModel)
        {
            this.ContactUsViewModel = ContactUsViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(this.ContactUsViewModel.UserToContact.Error);
        }

        public void Execute(object parameter)
        {
            this.ContactUsViewModel.ConfirmMessage();
            MessageBox.Show("aaa");
        }
    }
}
