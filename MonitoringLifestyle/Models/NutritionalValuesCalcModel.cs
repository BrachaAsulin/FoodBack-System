using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace MonitoringLifestyle.Models
{
    public class NutritionalValuesCalcModel
    {
        public BL.Bl BlObject { get; set; }
        public NutritionalValuesCalcModel()
        {
            BlObject = new BL.Bl();
        }
        internal IEnumerable Getfoods(string pattern)
        {
            return BlObject.getListFoodItems(pattern);
        }

        internal Food GetFoodById(string v)
        {
            return BlObject.GetFoodById(v);
        }
    }
}
