using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringLifestyle.Models
{
    class AccountModel:INotifyPropertyChanged,INotifyDataErrorInfo
    {

        public AccountModel(string emailAddress,string password)
        {
            this.EmailAddress = emailAddress;
            this.Password = password;
        }
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
            }
        }
        #region IDatatErrorInfo Members
        public string Error
        {
            get;
            private set;
        }

        public bool HasErrors => throw new  ;

        public string this[string columnEmailAddress]
        {
            get
            {
                if(columnEmailAddress == "EmailAddress")
                {
                    if(String.IsNullOrWhiteSpace(EmailAddress))
                    {
                        Error = "Email Address can not be empty";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                return Error;
            }
        }
        #endregion

        #region INotifyPropertyCanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
