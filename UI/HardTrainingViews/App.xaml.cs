using System;
using System.Resources;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using HardTrainingViews.Views;

namespace HardTrainingViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            
            NLog.LogManager.GetCurrentClassLogger().Trace("App was started");

            var pathToCodeBase = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            AppDomain.CurrentDomain.SetData("DataDirectory", new Uri(pathToCodeBase).LocalPath);
            
            //Application.Current.MainWindow = new WindowForNavigation();

            DispatcherHelper.Initialize();
        }
    }
}
