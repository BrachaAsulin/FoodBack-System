﻿using MonitoringLifestyle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitoringLifestyle.Commands
{
    class NutrionalValuesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public NutritionalValuesCalcViewModel currentVN;

        public NutrionalValuesCommand(NutritionalValuesCalcViewModel currentVN)
        {
            this.currentVN = currentVN;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            currentVN.setNutritionalValues();
        }
    }
}
