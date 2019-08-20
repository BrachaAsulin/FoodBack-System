using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class ContactUsCommand : ICommand
    {
        public DashboardVM DashboardVM { get; }
        public event EventHandler CanExecuteChanged;

        public ContactUsCommand(DashboardVM dashboardVM)
        {
            this.DashboardVM = dashboardVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DashboardVM.Operation(2);
        }
    }
}
