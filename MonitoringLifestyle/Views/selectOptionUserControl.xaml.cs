using BE;
using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonitoringLifestyle.Views
{
    /// <summary>
    /// Interaction logic for selectOptionUserControl.xaml
    /// </summary>
    public partial class selectOptionUserControl : UserControl
    {
        public User currentUser;
        public selectOptionUserControl(DashboardVM dashboardVM,User aCurrentUser)
        {
            InitializeComponent();
            currentUser = aCurrentUser;
            selectOptionGrid.DataContext = new SelectOptionViewModel(dashboardVM,currentUser);
            
        }
    }
}
