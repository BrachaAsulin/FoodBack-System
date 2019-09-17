using MonitoringLifestyle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonitoringLifestyle.ViewModels
{
    class EvaluationViewModel : DependencyObject
    {
        public EvaluationViewModel(BE.User currentUser)
        {
            ButtonChecked = false;
            this.CurrentUser = currentUser;
            this.FullName = CurrentUser.FirstName + " " + CurrentUser.LastName;
            this.CurrentModel = new EvaluationModel();
            

        }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string selectedMonth;
        public string SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                selectedMonth = value.Split(' ')[1];
                CaloriesEvaluation = CurrentModel.GetMonthEvaluation(CurrentUser, SelectedMonth,"Calories");
                FatsEvaluation = CurrentModel.GetMonthEvaluation(CurrentUser,SelectedMonth,"Fats");
                FibersEvaluation = CurrentModel.GetMonthEvaluation(CurrentUser,SelectedMonth,"Fibers");
                ProteinsEvaluation = CurrentModel.GetMonthEvaluation(CurrentUser, SelectedMonth,"Proteins");
                SugarsEvaluation = CurrentModel.GetMonthEvaluation(CurrentUser, SelectedMonth,"Sugars");
            }
        }
        public EvaluationModel CurrentModel { get; set; }


        public KeyValuePair<DateTime, float>[] CaloriesEvaluation
        {
            get { return (KeyValuePair<DateTime, float>[])GetValue(CaloriesEvaluationProperty); }
            set { SetValue(CaloriesEvaluationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WeekCaloriesEvaluation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaloriesEvaluationProperty =
            DependencyProperty.Register("CaloriesEvaluation", typeof(KeyValuePair<DateTime, float>[]), typeof(EvaluationViewModel));



        public KeyValuePair<DateTime, float>[] FatsEvaluation
        {
            get { return (KeyValuePair<DateTime, float>[])GetValue(FatsEvaluationProperty); }
            set { SetValue(FatsEvaluationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WeekFatsEvaluation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FatsEvaluationProperty =
            DependencyProperty.Register("FatsEvaluation", typeof(KeyValuePair<DateTime, float>[]), typeof(EvaluationViewModel));



        public KeyValuePair<DateTime, float>[] FibersEvaluation
        {
            get { return (KeyValuePair<DateTime, float>[])GetValue(FibersEvaluationProperty); }
            set { SetValue(FibersEvaluationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FibersEvaluationProperty =
            DependencyProperty.Register("FibersEvaluation", typeof(KeyValuePair<DateTime, float>[]), typeof(EvaluationViewModel));




        public KeyValuePair<DateTime, float>[] ProteinsEvaluation
        {
            get { return (KeyValuePair<DateTime, float>[])GetValue(ProteinsEvaluationProperty); }
            set { SetValue(ProteinsEvaluationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProteinsEvaluation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProteinsEvaluationProperty =
            DependencyProperty.Register("ProteinsEvaluation", typeof(KeyValuePair<DateTime, float>[]), typeof(EvaluationViewModel));



        public KeyValuePair<DateTime, float>[] SugarsEvaluation
        {
            get { return (KeyValuePair<DateTime, float>[])GetValue(SugarsEvaluationProperty); }
            set { SetValue(SugarsEvaluationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SugarsEvaluation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SugarsEvaluationProperty =
            DependencyProperty.Register("SugarsEvaluation", typeof(KeyValuePair<DateTime, float>[]), typeof(EvaluationViewModel));




        public BE.User CurrentUser { get; set; }
        private DateTime sundayWeek;
        public DateTime SundayWeek
        { get
            {
                return sundayWeek;
            }
            set
            {
                sundayWeek = value;
                DatesRange = sundayWeek.Day + "/" + sundayWeek.Month + "/" + sundayWeek.Year + " - " + (Int32.Parse(sundayWeek.Day.ToString()) + 6).ToString() + "/" + sundayWeek.Month + "/" + sundayWeek.Year;
                CaloriesEvaluation=CurrentModel.GetWeekEvaluation(CurrentUser,SundayWeek,"Calories");
                FatsEvaluation = CurrentModel.GetWeekEvaluation(CurrentUser, SundayWeek, "Fats");
                FibersEvaluation = CurrentModel.GetWeekEvaluation(CurrentUser, SundayWeek, "Fibers");
                ProteinsEvaluation = CurrentModel.GetWeekEvaluation(CurrentUser, SundayWeek, "Proteins");
                SugarsEvaluation = CurrentModel.GetWeekEvaluation(CurrentUser, SundayWeek, "Sugars");
            }
        }

        public Nullable<bool> ButtonChecked
        {
            get { return (Nullable<bool>)GetValue(ButtonCheckedProperty); }
            set { SetValue(ButtonCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCheckedProperty =
            DependencyProperty.Register("ButtonChecked", typeof(Nullable<bool>), typeof(EvaluationViewModel));
        public string DatesRange
        {
            get { return (string)GetValue(DatesRangeProperty); }
            set { SetValue(DatesRangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DatesRange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DatesRangeProperty =
            DependencyProperty.Register("DatesRange", typeof(string), typeof(EvaluationViewModel));
    }
}
