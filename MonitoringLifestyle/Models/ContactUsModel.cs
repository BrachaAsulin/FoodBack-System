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
               // OnPropertyChanged();
            }
        }

        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
