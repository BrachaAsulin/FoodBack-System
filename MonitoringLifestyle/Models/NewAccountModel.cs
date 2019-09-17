using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MonitoringLifestyle.Models
{
    class NewAccountModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public BL.Bl bl;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string password;
        private string dateOfBirth;
        private string height;
        private string weight;

        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged("FirstName"); } }

        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged("LastNAme"); } }
        public string EmailAddress { get => emailAddress; set { emailAddress = value; OnPropertyChanged("EmailAddress"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public string DateOfBirth { get => dateOfBirth; set { dateOfBirth = value; OnPropertyChanged("DateOfBirth"); } }
        public string Height { get => height; set { height = value; OnPropertyChanged("Height"); } }
        public string Weight { get => weight; set { weight = value; OnPropertyChanged("Weight"); } }

        public NewAccountModel(string newFirstName, string newLastName, string newEmailAddress, string newPassword, string newDateOfBirth, string newHeight, string newWeight)
        {
            bl = new BL.Bl();
            FirstName = newFirstName;
            LastName = newLastName;
            EmailAddress = newEmailAddress;
            Password = newPassword;
            DateOfBirth = newDateOfBirth;
            Height = newHeight;
            Weight = newWeight;
            this.validProperties = new Dictionary<string, bool>();
            validProperties.Add("EmailAddress", false);
            validProperties.Add("Password", false);
            validProperties.Add("FirstName", false);
            validProperties.Add("LastName", false);
            validProperties.Add("Height", false);
            validProperties.Add("Weight", false);
            validProperties.Add("DateOfBirth", false);

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
         public void SaveNewUser()
        {
            User u = new User(FirstName, LastName, EmailAddress, Password, DateOfBirth, Height, Weight);

          //  
            if (allPropertiesValid)
            {
    
                bl.AddUser(u);
                MessageBox.Show(u.ToString() + " " + "registered successfully");

            }
            else
                MessageBox.Show("error!!!");

        }

        #region IDataErrorInfo Members
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "FirstName":
                        Error = ValidateFirstName();
                        if(Error==null)
                            validProperties["FirstName"] = true;
                        break;
                    case "LastName":
                        Error = ValidateLastName();
                        if (Error == null)
                            validProperties["LastName"] = true;
                        break;
                    case "EmailAddress":
                        Error = ValidateEmailAddress();
                        if (Error == null)
                            validProperties["EmailAddress"] = true;
                        break;
                    case "Password":
                        Error = ValidatePassword();
                        if (Error == null)
                            validProperties["Password"] = true;
                        break;
                    case "DateOfBirth":
                        Error = ValidateDateOfBirth();
                        if (Error == null)
                            validProperties["DateOfBirth"] = true;
                        break;
                    case "Height":
                        Error = ValidateHeight();
                        validProperties["Height"] = true;
                        break;
                    case "Weight":
                        Error = ValidateWeight();
                        if (Error == null)
                            validProperties["Weight"] = true;
                        break;
                    default:
                        break;
                }
                if (Error == null)
                    ValidateProperties();
                return Error;
            }
        }
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private string ValidateWeight()
        {
            if (String.IsNullOrWhiteSpace(Weight))
                return "Weight can not be empty";
            else if (!IsDigitsOnly(Weight))
                return "Weight must contains digits only";
            else
                return null;
        }

        private string ValidateHeight()
        {
            if (String.IsNullOrWhiteSpace(Height))
                return "Height can not be empty";
            else if (!IsDigitsOnly(Height))
                return "Height must contains digits only";
            else
                return null;
        }

        private string ValidateDateOfBirth()
        {
            if (String.IsNullOrWhiteSpace(DateOfBirth))
                return "Date of birth can not be empty";

            else
            return null;
        }

        private string ValidatePassword()
        {
            if (String.IsNullOrWhiteSpace(Password))
                return "Password can not be empty";
            return null;
        }

        private string ValidateEmailAddress()
        {
            if (String.IsNullOrWhiteSpace(EmailAddress))
                return "EmailAddress can not be empty";
            else if (!AccountModel.EmailIsValid(EmailAddress))
                return "Email Address is not in correct form";
            else
                return null;
        }

        private string ValidateLastName()
        {
            if (String.IsNullOrWhiteSpace(LastName))
                return "LastName can not be empty";
            else if (!Regex.IsMatch(LastName, @"^[a-zA-Z]+$"))
                return "LastName can contain only letters";
            else
                return null;
        }

        private string ValidateFirstName()
        {
            if (String.IsNullOrWhiteSpace(FirstName))
                return "FirstName can not be empty";
            else if (!Regex.IsMatch(FirstName, @"^[a-zA-Z]+$"))
                return "FirstName can contain only letters";
            else
                return null;
        }

        public string Error
        {
            private set;
            get;
        }


    

        #endregion

        #region INotifyProperyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }

        #endregion
    }
}
