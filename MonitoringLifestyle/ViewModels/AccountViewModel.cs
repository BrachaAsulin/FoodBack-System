using BE;
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
    class AccountViewModel:DependencyObject
    {
        public AccountViewModel(DashboardVM dashboardViewModel)
        {
            SignIn = new SignInCommand(this);
            User = new AccountModel("", "");
            DashboardVM = dashboardViewModel;
            Register = new RegisterCommand(this);
       
        }

        public DashboardVM DashboardVM { get; set; }

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

        public ICommand Register { get; set; }
        public ICommand SignIn
        {
            get { return (ICommand)GetValue(SignInProperty); }
            set { SetValue(SignInProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SignIn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignInProperty =
            DependencyProperty.Register("SignIn", typeof(ICommand), typeof(AccountViewModel));


        internal void openRegister()
        {
            this.DashboardVM.ChildUserControl = new NewAccountUserControl(DashboardVM);

        }

        public void saveUser()// take the email and the password and check the input 
        {
            User u=user.saveUser();
            if (u != null)
            {
                DashboardVM.currentUser = u;
                DashboardVM.ChildUserControl = new selectOptionUserControl(DashboardVM,u);
            }

            else
                MessageBox.Show("This User does not exist!","System Message",MessageBoxButton.OK,MessageBoxImage.Information);

        }
    }
}
