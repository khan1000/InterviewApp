using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InterviewApp.Models;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Xamarin.Forms;

namespace InterviewApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string _text = "";
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value, onChanged: ((AsyncCommand) SaveCommand).RaiseCanExecuteChanged);
        }

        private string _description = "";
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value, onChanged: ((AsyncCommand) SaveCommand).RaiseCanExecuteChanged);
        }

        public IAsyncCommand SaveCommand { get; }

        public IAsyncCommand CancelCommand { get; }

        public NewItemViewModel()
        {
            SaveCommand   = new AsyncCommand(SaveAsync, ValidateSave);
            CancelCommand = new AsyncCommand(CancelAsync);
        }

        private bool ValidateSave(object obj)
        {
            return !string.IsNullOrWhiteSpace(Text)
                && !string.IsNullOrWhiteSpace(Description);
        }

        private async Task CancelAsync()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task SaveAsync()
        {
            Item newItem = new Item()
            {
                Id          = Guid.NewGuid().ToString(),
                Text        = Text,
                Description = Description
            };

            await DataStore.Value.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
