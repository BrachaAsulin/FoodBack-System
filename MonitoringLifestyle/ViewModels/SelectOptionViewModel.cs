using BE;
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

namespace MonitoringLifestyle.ViewModels
{
    public class SelectOptionViewModel: DependencyObject
    {
        public DashboardVM DashboardVM { get; set;}
        public ICommand Goals { get; set; }
        public ICommand Daily { get; set; }
        public ICommand FoodInfo { get; set; }
        public ICommand Evaluation { get; set; }

        public User currentUser { get; set; }

        public UserControl MyProperty
        {
            get { return (UserControl)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(SelectOptionViewModel), new PropertyMetadata(0));



        public SelectOptionViewModel(DashboardVM dashboardVM,User aCurrentUser)
        {
            Goals = new GoalsCommand(this);
            Daily = new DailyCommand(this);
            FoodInfo = new FoodInformationCommand(this);
            Evaluation = new EvaluationCommand(this);
            DashboardVM = dashboardVM;
            currentUser = aCurrentUser;
        }
        public void selectOperation(int i)
        {
            switch(i)
            {
                case 1:
                    if (currentUser != null)
                    {

                        DashboardVM.ChildUserControl = new GoalsUserControl(currentUser );

                    }
                    else
                    {
                        MessageBox.Show("You have to sign in first or create a new account","System Message",MessageBoxButton.OK,MessageBoxImage.Information);
                        DashboardVM.ChildUserControl = new AccountUserControl(DashboardVM);
                    }
                    break;
                case 2:
                    if (currentUser != null)
                        DashboardVM.ChildUserControl = new MyDailyDietUserControl1(currentUser);
                    else
                    {
                        MessageBox.Show("You have to sign in first or create a new account","System Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        DashboardVM.ChildUserControl = new AccountUserControl(DashboardVM);
                    }
                    break;
                case 3:
                    if (currentUser != null)
                        DashboardVM.ChildUserControl = new EvaluationUserControl1(currentUser);
                    else
                    {
                        MessageBox.Show("You have to sign in first or create a new account","System Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        DashboardVM.ChildUserControl = new AccountUserControl(DashboardVM);
                    }
                    break;
                case 4:
                    if (currentUser != null)
                        DashboardVM.ChildUserControl = new foodInformationUserControl(DashboardVM);
                    else
                    {
                        MessageBox.Show("You have to sign in first or create a new account","System Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        DashboardVM.ChildUserControl = new AccountUserControl(DashboardVM);
                    }
                    break;

            }
        }

    }
}
