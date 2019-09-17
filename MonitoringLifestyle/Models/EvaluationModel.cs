using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace MonitoringLifestyle.Models
{
    class EvaluationModel
    {
        public EvaluationModel()
        {
            BlObject = new BL.Bl();
        }
        public BL.Bl BlObject { get; set; }

        internal KeyValuePair<DateTime, float>[] GetWeekEvaluation(User currentUser, DateTime sundayWeek, string v)
        {
            return BlObject.GetWeekEvaluation(currentUser, sundayWeek, v);
        }

        internal KeyValuePair<DateTime, float>[] GetMonthEvaluation(User currentUser, string selectedMonth, string v)
        {
            return BlObject.GetMonthEvaluation(currentUser, selectedMonth, v);
        }
    }
}
