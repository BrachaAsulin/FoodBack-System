using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class UpdateGoalsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GoalsViewModel goalsVM;

        public UpdateGoalsCommand(GoalsViewModel myGoalsVM)
        {
            this.goalsVM = myGoalsVM;
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            goalsVM.updateGoalsDetails();          
        }
    }
}
