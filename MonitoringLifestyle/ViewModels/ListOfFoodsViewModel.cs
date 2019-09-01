using MonitoringLifestyle.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.ViewModels
{
    class ListOfFoodsViewModel
    {
        ICommand AddFood { get; set; }

        public ListOfFoodsViewModel()
        {
            AddFood = new AddFoodCommand(this);
        }
    }
}
