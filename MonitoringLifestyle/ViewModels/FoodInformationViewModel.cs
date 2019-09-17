using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MonitoringLifestyle.ViewModels
{
    class FoodInformationViewModel : IVM
    {
        public ICommand Calculator { get; set; }
        public ICommand SweetsInfo { get; set; }
        public ICommand SaltyInfo { get; set; }
        public ICommand MeatInfo { get; set; }
        public ICommand DairyInfo { get; set; }
        public DashboardVM dashboardVM { get; set; }

        public FoodInformationViewModel(DashboardVM aDashboardVM)
        {
            Calculator = new NutritionalValuesCalculatorCommand(this);
            SweetsInfo = new SweetsInfoCommand(this);
            SaltyInfo = new SaltyInfoCommand(this);
            MeatInfo = new MeatInfoCommand(this);
            DairyInfo = new DairyInfoCommand(this);
            dashboardVM = aDashboardVM;
        }
     
        public void foodInfoOptions(int i)
        {
            
            switch (i)
            {
                case 1:dashboardVM.ChildUserControl = new NutritionalValuesCalculatorUC();
                    break;
                case 2:
                   // MessageBox.Show("aaa");
                    dashboardVM.ChildUserControl = new foodInfoSweetsUserControl();
                    break;
                case 3:dashboardVM.ChildUserControl = new foodInfoSaltyUserControl();
                    break;
                case 4:
                    dashboardVM.ChildUserControl = new foodInfoMeatUserControl();
                    break;
                case 5:dashboardVM.ChildUserControl = new foodInfoDairyUserControl();
                    break;
                default:break;

            }
        }
    }
}
