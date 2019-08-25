using MonitoringLifestyle.ViewModels;
using System;
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

namespace MonitoringLifestyle.Views
{
    /// <summary>
    /// Interaction logic for weekPickerUserControl.xaml
    /// </summary>
    public partial class weekPickerUserControl : UserControl//,INotifyPropertyChanged//i changed
    {
        public GoalsViewModel currentViewModel;
        private bool flagOnUpdate;

        public DateTime sunday { get; set; }
        private string sundayOfWeek { get; set; }

        public weekPickerUserControl()
        {
            InitializeComponent();
            currentViewModel = new GoalsViewModel();
            this.DataContext = currentViewModel;
           
        }
        private void addSelectedDates()
        {
            flagOnUpdate = true;
            DateTime date = (DateTime)calendar.SelectedDate;
            calendar.SelectedDates.Clear();
            sunday = date.AddDays(0 - (int)date.DayOfWeek);//the sunday of the selected week
            sundayOfWeek = sunday.Day + "/" + sunday.Month + "/" + sunday.Year;
            this.currentViewModel.sundayWeek= sundayOfWeek;
            for (int i = (int)sunday.DayOfWeek; i < 7; i++)
                calendar.SelectedDates.Add(sunday.AddDays(i));

            flagOnUpdate = false;
        }
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (calendar.SelectedDate != null && flagOnUpdate == false)
            {
                addSelectedDates();

                currentViewModel.EnableGridGoal = true;
            }
        }

       
    }
}
