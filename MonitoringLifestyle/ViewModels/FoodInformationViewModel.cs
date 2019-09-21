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
    public class FoodInformationViewModel : IVM
    {
        public ICommand Calculator { get; set; }
        public ICommand SweetsInfo { get; set; }
        public ICommand SaltyInfo { get; set; }
        public ICommand MeatInfo { get; set; }
        public ICommand DairyInfo { get; set; }
        public ICommand BackWindowCommand { get; set; }
        public DashboardVM dashboardVM { get; set; }

        public FoodInformationViewModel(DashboardVM aDashboardVM)
        {
            Calculator = new NutritionalValuesCalculatorCommand(this);
            SweetsInfo = new SweetsInfoCommand(this);
            SaltyInfo = new SaltyInfoCommand(this);
            MeatInfo = new MeatInfoCommand(this);
            DairyInfo = new DairyInfoCommand(this);
            BackWindowCommand = new BackCommand(this);
            dashboardVM = aDashboardVM;
        }
     
        public void foodInfoOptions(int i)
        {
            
            switch (i)
            {
                case 1:dashboardVM.ChildUserControl = new NutritionalValuesCalculatorUC();
                    break;
                case 2:
                   
                    dashboardVM.ChildUserControl = new foodInfoSweetsUserControl(this);
                    break;
                case 3:dashboardVM.ChildUserControl = new foodInfoSaltyUserControl(this);
                    break;
                case 4:
                    dashboardVM.ChildUserControl = new foodInfoMeatUserControl(this);
                    break;
                case 5:dashboardVM.ChildUserControl = new foodInfoDairyUserControl(this);
                    break;
                default:break;

            }
        }

        public void BackWindow()
        {
            this.dashboardVM.ChildUserControl = new foodInformationUserControl(dashboardVM);
        }
    }
}
