using BE;
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
    class AccountViewModel
    {
        public AccountViewModel()
        {
            SignIn = new SignInCommand(this);
            User = new AccountModel(null,null);
        }
       
        private AccountModel user;
        
        public AccountModel User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        public ICommand SignIn
        {
            get;
            private set;
        }

        public void saveUser()
        {

        }
    }
}
