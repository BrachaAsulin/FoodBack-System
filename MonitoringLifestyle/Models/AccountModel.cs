//using BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Models
{
    class AccountModel : INotifyPropertyChanged, IDataErrorInfo
    {
    public AccountModel(string emailAddress,string password)
        {
            this.EmailAddress = emailAddress;
            this.Password = password;

        }
       // public BL.Bl bb = new Bl();
        private string emailAddress;
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
              
            }
        }


        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
       

            }
        }

        public bool flag = false;

        #region IDatatErrorInfo Members
        public string Error
        {
            get;
            private set;
        }
        
        public string this[string columnEmailAddress]
        {
            get
            {
                if (columnEmailAddress == "EmailAddress")
                {
                    if (String.IsNullOrWhiteSpace(EmailAddress))
                    {
                        Error = "Email Address can not be empty";
                        flag = false;
                    }
                    else
                    {
                        Error = null;
                        if (String.IsNullOrWhiteSpace(Password))
                            flag = true;
                    }

                }
                if (columnEmailAddress == "Password")
                {
                    if (String.IsNullOrWhiteSpace(EmailAddress))
                    {
                        Error = "Password Address can not be empty";
                        flag = false;
                    }
                    else
                    {
                        Error = null;
                        if (String.IsNullOrWhiteSpace(EmailAddress))
                            flag = true;
                    }

                }

                return Error;

            }
        }
        #endregion

        #region INotifyPropertyCanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
        #endregion

    }
}
