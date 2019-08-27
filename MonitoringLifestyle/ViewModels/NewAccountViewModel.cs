using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    class NewAccountViewModel:IVM
    {
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
        public NewAccountViewModel()
        {
            newAccount = new NewAccountModel("","","","","","","");
            registerNow = new NewAccountCommand(this);
        }

        internal void SaveNewUser()
        {
            throw new NotImplementedException();
        }
    }
}
