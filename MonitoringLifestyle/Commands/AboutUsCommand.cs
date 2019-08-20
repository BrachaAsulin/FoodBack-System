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
    public class AboutUsCommand : ICommand
    {
        public DashboardVM DashboardVM { get; set; }

        public AboutUsCommand(DashboardVM dashboardVM)
        {
            this.DashboardVM = dashboardVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DashboardVM.Operation(1);
           
        }
    }
}
