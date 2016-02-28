using System;
using System.Security.Cryptography.X509Certificates;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HardTraining.Views.CommonModule;

namespace HardTraining.ViewModel.CommonModule
{
    public class CommonModuleViewModel : ViewModelBase
    {
        public CommonModuleViewModel()
        {
            
        }

        public string Name => "CommonModule";
    }
}