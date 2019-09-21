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
    class ContactUsViewModel
    {
        public ICommand ContactUs { get; set; }
        private ContactUsModel userToContact;
        public ContactUsModel UserToContact
        {
            get
            {
                return userToContact;
            }
            set
            {
                userToContact = value;
            }
        }

        public ContactUsViewModel()
        {
            this.UserToContact = new ContactUsModel("","","","") ;
            ContactUs = new ConfirmContactUsCommand(this);
        }

        internal void ConfirmMessage()
        {
            UserToContact.SendMessage();
        }
    }
}
