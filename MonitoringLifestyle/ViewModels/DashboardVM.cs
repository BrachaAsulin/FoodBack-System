﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MonitoringLifestyle.ViewModels;
using MonitoringLifestyle.Commands;
using MonitoringLifestyle.Views;
using System.Windows.Controls;
using BE;

namespace MonitoringLifestyle.ViewModels
{
    public class DashboardVM:DependencyObject
    {
        public User currentUser=null;
        public DashboardModel CurrentModel { get; set; }
        public ICommand AboutUs { get; set; }
        public ICommand ContactUs { get; set; }
        public ICommand Home { get; set; }
        public ICommand Account { get; set; }
        public ICommand ShutDown { get; set; }



        public UserControl ChildUserControl
        {
            get { return (UserControl)GetValue(ChildUserControlProperty); } 
            set { SetValue(ChildUserControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChildUserControlProperty =
            DependencyProperty.Register("ChildUserControl", typeof(UserControl), typeof(DashboardVM));


         



        public DashboardVM()
        {
            CurrentModel = new DashboardModel();
            ChildUserControl = new selectOptionUserControl(this,currentUser);
            AboutUs = new AboutUsCommand(this);
            ContactUs = new ContactUsCommand(this);
            Home = new HomeCommand(this);
            Account = new AccountCommand(this);
            ShutDown = new ShutDownCommand(this);
        }

        public void Operation(int i)
        {
            switch(i)
            {
                case 1: ChildUserControl = new aboutUsUserControl();
                    break;
                case 2: ChildUserControl = new contactUsUserControl();
                    break;
                case 3: if (currentUser != null)
                        ChildUserControl = new selectOptionUserControl(this, currentUser);
                    else
                    {
                        
                        ChildUserControl = new AccountUserControl(this);
                    }
                    break;
                   
                case 4:
                    ChildUserControl = new AccountUserControl(this);
                    break;
                case 5:
                    System.Windows.Application.Current.Shutdown();
                    break;
            }
        }
    }
}
