using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using MonitoringLifestyle.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    class NewAccountViewModel
    {
        public DashboardVM DashboardVM { get; set; }
        private NewAccountModel newAccount;
        public NewAccountModel NewAccount
        {
            get
            {
                return newAccount;
            }
            set
            {
                newAccount = value;
            }
               
        }
        public ICommand registerNow { get; set; }
        public NewAccountViewModel(DashboardVM aDashboardVM)
        {
            DashboardVM = aDashboardVM;
            newAccount = new NewAccountModel("","","","","","","");
            registerNow = new NewAccountCommand(this);
        }

        internal void SaveNewUser()
        {
            
            NewAccount.SaveNewUser();
            DashboardVM.ChildUserControl = new AccountUserControl(DashboardVM);
            
        }
    }
}
