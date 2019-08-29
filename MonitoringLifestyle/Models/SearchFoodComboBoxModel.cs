using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringLifestyle.Models
{
    class SearchFoodComboBoxModel
    {
        BL.Bl BlObject;
        public SearchFoodComboBoxModel()
        {
            BlObject = new BL.Bl();
        }
        internal ObservableCollection<BE.Food> getResultList(string foodToSearch)
        {
            return BlObject.getListFoodItems(foodToSearch);
        }
    }
}
