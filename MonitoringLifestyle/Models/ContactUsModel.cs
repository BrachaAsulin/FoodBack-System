using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MonitoringLifestyle.Models
{
    class ContactUsModel : IDataErrorInfo, INotifyPropertyChanged
    {

        public ContactUsModel()
        {
            BlObject = new BL.Bl();
        }

        public BL.Bl BlObject { get; set; }

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
                OnPropertyChanged("Name");
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

        internal void SendMessage()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("foodbacksystem@gmail.com");
                mail.To.Add(EmailAddress);
                mail.Subject = "FoodBack-Thank You For Your Message";
                mail.Body = "Hello " + Name + ",\n" + "Our system has received your message and we will respond to you as soon as possible.\n Thank you,\n FoodBack - Care Yourself";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("foodbacksystem@gmail.com", "1q2a3z770");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                EmailAddress = null;
                Name = null;
                PhoneNumber = null;
                Message = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                        else if(!ValidatePhoneNumber())
                        {
                            Error = "Invalid phone number";
                        }
                        else
                        {
                            validProperties["PhoneNumber"] = true;
                            Error = null;
                        }
                        break;
                    case "EmailAddress":
                        if (string.IsNullOrWhiteSpace(EmailAddress))
                            Error = "Email address field can't be empty";
                        else if (!ValidateEmail())
                        {
                            Error = "Invalid email address";
                        }
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

        private bool ValidatePhoneNumber()
        {
            if (PhoneNumber.Length == 10)
            {

                string areaCode = (PhoneNumber[0] - 48).ToString() + (PhoneNumber[1] - 48).ToString() + (PhoneNumber[2] - 48).ToString();
                if (areaCode.Equals("058") || areaCode.Equals("054") || areaCode.Equals("052") || areaCode.Equals("055") || areaCode.Equals("053") || areaCode.Equals("050"))
                {
                    return true;

                }
                else return false;
            }
            else return false;
        }

        private bool ValidateEmail()
        {

               string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

               if (Regex.IsMatch(EmailAddress, expression))
               {
                   if (Regex.Replace(EmailAddress, expression, string.Empty).Length == 0)
                   {
                       return true;
                   }
               }
               return false;
            return true;
        }

        public string Error
        {
            private set;
            get;
        }
        #endregion

    }
}
