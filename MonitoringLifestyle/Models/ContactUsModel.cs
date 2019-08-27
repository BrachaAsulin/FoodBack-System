using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringLifestyle.Models
{
    class ContactUsModel : IDataErrorInfo, INotifyPropertyChanged
    {

       
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Nmae");
            }
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
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged("Message");
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

        public ContactUsModel(string name, string emailAddress, string phoneNumber, string message)
        {
            this.name = name;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.message = message;
            this.validProperties = new Dictionary<string, bool>();
            this.validProperties.Add("Name", false);
            this.validProperties.Add("PhoneNumber", false);
            this.validProperties.Add("EmailAddress", false);
            this.validProperties.Add("Message", false);

        }

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

        #region INotifyProperyChanged Members
        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region IDataErrorInfo Members

        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            Error = "Name field can't be empty";
                        else
                        {
                            validProperties["Name"] = true;
                            Error = null;
                        }
                        break;
                    case "PhoneNumber":
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            Error = "Phone number field can't be empty";
                        else
                        {
                            validProperties["PhoneNumber"] = true;
                            Error = null;
                        }
                        break;
                    case "EmailAddress":
                        if (string.IsNullOrWhiteSpace(EmailAddress))
                            Error = "Email address field can't be empty";
                        else
                        {
                            validProperties["EmailAddress"] = true;
                            Error = null;
                        }
                        break;
                    case "Message":
                        if (string.IsNullOrWhiteSpace(Message))
                            Error = "Message field can't be empty";
                        else
                        {
                            validProperties["Message"] = true;
                            Error = null;
                        }
                        break;
                    default:
                        break;

                }
                if (Error == null)
                    ValidateProperties();
                return Error;

                
            }
        }

        public string Error
        {
            private set;
            get;
        }
        #endregion

    }
}
