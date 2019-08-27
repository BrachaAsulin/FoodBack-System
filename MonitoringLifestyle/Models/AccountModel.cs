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
            this.validProperties = new Dictionary<string, bool>();
            validProperties.Add("EmailAddress", false);
            validProperties.Add("Password", false);

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

        private bool allPropertiesValid = false;
        public bool AllPropertiesValid
        {
            get { return allPropertiesValid; }
            set
            {
                if (allPropertiesValid != value)
                {
                    allPropertiesValid = value;
                    OnPropertyChanged("AllPropertiesValid");
                }
            }
        }

        private Dictionary<string, bool> validProperties;

        private void ValidateProperties()
        {
            foreach (bool isValid in validProperties.Values)
            {
                if (isValid == false)
                {
                    this.AllPropertiesValid = false;
                    return;
                }
            }
            this.AllPropertiesValid = true;
        }


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
                        
                    }
                    else
                    {
                  
                        Error = null;
                        validProperties["EmailAddress"] = true;
                        ValidateProperties();




                    }

                }
                if (columnEmailAddress == "Password")
                {
                    if (String.IsNullOrWhiteSpace(EmailAddress))
                    {
                        Error = "Password Address can not be empty";
                      
                    }
                    else
                    {
                    
                            Error = null;
                        validProperties["Password"] = true;
                        ValidateProperties();


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
