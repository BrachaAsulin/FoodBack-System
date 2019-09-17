//using BL;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonitoringLifestyle.Models
{
    class AccountModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public BL.Bl bl;
        public AccountModel(string emailAddress,string password)
        {
            this.EmailAddress = emailAddress;
            this.Password = password;
            this.validProperties = new Dictionary<string, bool>();
            validProperties.Add("EmailAddress", false);
            validProperties.Add("Password", false);
            bl = new BL.Bl();
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

        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
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
                    else if(!EmailIsValid(EmailAddress))
                    {
                       
                            Error = "Email Address is not in correct form";
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
                    if (String.IsNullOrWhiteSpace(Password))
                    {
                        Error = "Passwod can not be empty";
                      
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




        public User saveUser()
        {

            if (bl.emailCorrectToPassword(    emailAddress, password))
            {
                MessageBox.Show("your details:" + " " + (bl.saveUser(emailAddress)).ToString());
                return bl.saveUser(emailAddress);
            }
            else
            {
               // MessageBox.Show("user is not exist");
                return null;
            }
            
        }

    }
}
