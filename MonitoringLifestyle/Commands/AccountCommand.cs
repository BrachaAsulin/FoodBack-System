using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class AccountCommand : ICommand
    {
        public DashboardVM dashboardVM { get; set; }
        public event EventHandler CanExecuteChanged;

        public AccountCommand(DashboardVM dashboardVM)
        {
            this.dashboardVM = dashboardVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.dashboardVM.Operation(4);
        }
    }
}
