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
using MonitoringLifestyle.ViewModels;

namespace MonitoringLifestyle.Views
{
    /// <summary>
    /// Interaction logic for foodInfoSweets.xaml
    /// </summary>
    public partial class foodInfoSweetsUserControl : UserControl
    {
        private FoodInformationViewModel foodInformationViewModel;

        public foodInfoSweetsUserControl()
        {
            InitializeComponent();
        }

        public foodInfoSweetsUserControl(FoodInformationViewModel foodInformationViewModel)
        {
            InitializeComponent();
            this.foodInformationViewModel = foodInformationViewModel;
            this.DataContext = foodInformationViewModel;
        }
    }
}
