using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class BackCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public IVM currentVM;
        public BackCommand(IVM currentVM)
        {
            this.currentVM = currentVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            currentVM.BackWindow();
        }
    }
}
