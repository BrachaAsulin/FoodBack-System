using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonitoringLifestyle.ViewModels
{
    public class GoalsViewModel:DependencyObject
    {
        public GoalsViewModel()
        {
            EnableGridGoal = false;
        }


        public bool EnableGridGoal
        {
            get { return (bool)GetValue(EnableGridGoalProperty); }
            set { SetValue(EnableGridGoalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnableGridGoal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableGridGoalProperty =
            DependencyProperty.Register("EnableGridGoal", typeof(bool), typeof(GoalsViewModel));





    }
}
