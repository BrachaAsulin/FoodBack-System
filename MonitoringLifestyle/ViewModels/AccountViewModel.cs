using BE;
using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Models;
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
        public AccountViewModel()
        {
            SignIn = new SignInCommand(this);
            User = new AccountModel("", "");
            //UserEmailAddress = "";
           // UserPassword = "";
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
        /* private string userEmailAddress;

         public string UserEmailAddress
         {
             get
             {
                 return User.EmailAddress;
             }
             set
             {
                 User.EmailAddress = value;
                 this.SignIn.CanExecute(null);
             }
         }
         private string userPassword;

         public string UserPassword
         {
             get
             {
                 return User.Password;
             }
             set
             {
                 User.Password = value;
                 this.SignIn.CanExecute(null);

             }
         }
         public ICommand SignIn
         {
             get;
             private set;
         }*/



        public ICommand SignIn
        {
            get { return (ICommand)GetValue(SignInProperty); }
            set { SetValue(SignInProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SignIn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignInProperty =
            DependencyProperty.Register("SignIn", typeof(ICommand), typeof(AccountViewModel));



        public void saveUser()
        {

        }
    }
}
