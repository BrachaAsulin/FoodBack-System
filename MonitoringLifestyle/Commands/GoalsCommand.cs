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
    class GoalsCommand : ICommand
    {
        public SelectOptionViewModel SelectOptionVM { get; set; }

        public GoalsCommand(SelectOptionViewModel selectOptionVM)
        {
            this.SelectOptionVM = selectOptionVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            SelectOptionVM.selectOperation(1);
        }

    }
}
