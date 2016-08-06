using System;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using HardTrainingViews.VMLocator;


namespace HardTrainingViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ViewsSwitcher switcher;
        private static WindowCreatorByMessage windowCreator;

        static App()
        {
            
            NLog.LogManager.GetCurrentClassLogger().Trace("App was started");

            var pathToCodeBase = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            AppDomain.CurrentDomain.SetData("DataDirectory", new Uri(pathToCodeBase).LocalPath);
            
            switcher = new ViewsSwitcher();
            windowCreator = new WindowCreatorByMessage();

            DispatcherHelper.Initialize();
        }
    }
}
