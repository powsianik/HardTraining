using System;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace HardTraining
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            var pathToCodeBase = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            AppDomain.CurrentDomain.SetData("DataDirectory", new Uri(pathToCodeBase).LocalPath);

            DispatcherHelper.Initialize();
        }
    }
}
