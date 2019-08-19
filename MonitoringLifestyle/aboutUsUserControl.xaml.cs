﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MonitoringLifestyle
{
    /// <summary>
    /// Interaction logic for aboutUsUserControl.xaml
    /// </summary>
    public partial class aboutUsUserControl : UserControl
    {
        public aboutUsUserControl()
        {
            InitializeComponent();
            DashboardVM dashboard = new DashboardVM();
            dashboard.PropertyChanged += ShowUC;
        }

        private void ShowUC(object sender, PropertyChangedEventArgs e)
        {
            this.Visibility = Visibility.Visible;

        }
    }
}
