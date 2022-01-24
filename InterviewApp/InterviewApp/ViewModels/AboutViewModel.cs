using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmHelpers.Interfaces;
using MvvmHelpers.Commands;
using Xamarin.Essentials;
using InterviewApp.Models;
using InterviewApp.Interfaces;
using Xamarin.Forms;

namespace InterviewApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {


        public Lazy<IPlatformService> PlatformService => new Lazy<IPlatformService>(() => DependencyService.Get<IPlatformService>());

        //public IPlatformService PlatformService => DependencyService.Get<IPlatformService>();

        private string _platformString = "";
        public string PlatformString
        {
            get => _platformString;
            set => SetProperty(ref _platformString, value);
        }

        public IAsyncCommand<string> OpenWebCommand { get; }

        public AboutViewModel()
        {
          
            Title          = "About";
            OpenWebCommand = new AsyncCommand<string>(Browser.OpenAsync);
            PlatformString = PlatformService.Value.GetPlatformSpecificString();
        }
    }
}