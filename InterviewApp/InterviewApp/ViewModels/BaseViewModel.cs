using System;
using Xamarin.Forms;
using MvvmHelpers;
using InterviewApp.Models;
using InterviewApp.Services;
using InterviewApp.Interfaces;

namespace InterviewApp.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public Lazy<IDataStore<Item>> DataStore => new Lazy<IDataStore<Item>>(() => DependencyService.Get<IDataStore<Item>>());

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
