using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;




namespace MonitoringLifestyle
{
    public class DashboardVM:INotifyPropertyChanged
    {
        public DashboardModel CurrentModel { get; set; }
        public AboutUsCommand AboutUs { get; set; }
        public DashboardVM()
        {
            CurrentModel = new DashboardModel();
            AboutUs = new AboutUsCommand();
            AboutUs.AboutUsEvent += Operation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Operation(int i)
        {
            switch(i)
            {
                case 1:
                    PropertyChanged(this,new PropertyChangedEventArgs(""));
                    break;
            }
        }
    }
}
