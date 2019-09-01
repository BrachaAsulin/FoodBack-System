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
using BE;
using BL;
using System.Collections.ObjectModel;

namespace MonitoringLifestyle.Views
{
    /// <summary>
    /// Interaction logic for SearchFoodComboBox.xaml
    /// </summary>
    public partial class SearchFoodComboBox : UserControl
    {
       
        public static readonly DependencyProperty SearchList = DependencyProperty.Register("SearchListProperty", typeof(ObservableCollection<Food>), typeof(SearchFoodComboBox));
        public ObservableCollection<Food> SearchListProperty
        {
            get { return (ObservableCollection<Food>)GetValue(SearchList); }
            set { SetValue(SearchList, value); }
        }

        public static readonly DependencyProperty SearchText = DependencyProperty.Register("SearchTextProperty", typeof(string), typeof(SearchFoodComboBox), new UIPropertyMetadata(""));
        public string SearchTextProperty
        {
            get { return (string)GetValue(SearchText); }
            set { SetValue(SearchText, value); }
        }

        public static readonly DependencyProperty IsOpen = DependencyProperty.Register("IsOpenProperty", typeof(Boolean), typeof(SearchFoodComboBox));
        public Boolean IsOpenProperty
        {
            get { return (Boolean)GetValue(IsOpen); }
            set { SetValue(IsOpen, value); }
        }


        public static readonly DependencyProperty SelectedFoodItem = DependencyProperty.Register("SelectedFoodItemProperty", typeof(Food), typeof(SearchFoodComboBox),new PropertyMetadata(null));
        public Food SelectedFoodItemProperty
        {
            get { return (Food)GetValue(SelectedFoodItem); }
            set { SetValue(SelectedFoodItem, value); }
        }
        
        BL.Bl bl;
        public SearchFoodComboBox()
        {
            InitializeComponent();
            //LayoutRoot.DataContext = this;///////
            bl = new Bl();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String textToSearch = ((TextBox)sender).Text;
            if (textToSearch != null && textToSearch != "")
            {

               // MessageBox.Show("aaaa");
                SearchListProperty = new ObservableCollection<Food>( bl.getListFoodItems(textToSearch));
              //  SearchListProperty = new ObservableCollection<Food> {new Food("pizza","12","13","33","332","22"), new Food("lazanya", "12", "13", "33", "332", "22") , new Food("hamburger", "12", "13", "33", "332", "22") };
                IsOpenProperty = true;
            }
            //SelectedFoodItemProperty = new FoodItem() { Name = "Pizza", Key = "123" };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SearchTextProperty = comboBoxFood.SelectedItem.ToString();
            
        }
    }
}
