using ADSReminder.BUS.Abstraction;
using ADSReminder.Models.DBObjects;
using ADSReminder.UI.Helpers.IOC;
using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ADSReminder.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ContainerBuilder mBuider;
        private static IContainer mCenteralIOC;
        public static IContainer CenteralIOC
        {
            get
            {
                if (mCenteralIOC==null)
                {
                    mBuider = new ContainerBuilder();
                    mBuider.RegisterModule(new Helpers.IOC.CenteralIOCModule());
                    mCenteralIOC = mBuider.Build();
                }
                return mCenteralIOC;
            }
        }
        public User CuurentUser { get; set; }
        public App()
        {
            
        }
    }
}
