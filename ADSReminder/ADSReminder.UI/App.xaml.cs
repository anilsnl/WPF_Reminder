using ADSReminder.BUS.Abstraction;
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
        private static IContainer mCenteralIOCModule;
        public static IContainer CenteralIOCModule
        {
            get
            {
                if (mCenteralIOCModule==null)
                {
                    mBuider = new ContainerBuilder();
                    mBuider.RegisterModule(new Helpers.IOC.CenteralIOCModule());
                    mCenteralIOCModule = mBuider.Build();
                }
                return mCenteralIOCModule;
            }
        } 
        public App()
        {
            var manager = App.CenteralIOCModule.Resolve<IUserManager>();
            var list = manager.fnLoginAsync("test", "test").Result;
        }
    }
}
