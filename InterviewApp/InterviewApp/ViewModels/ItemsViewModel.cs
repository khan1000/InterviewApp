using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using InterviewApp.Models;
using InterviewApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Xamarin.Forms;

namespace InterviewApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item? _selectedItem;
        public Item? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value, onChanged: () => SelectAsync(value).SafeFireAndForget());
        }

        private ObservableRangeCollection<Item> _items = new ObservableRangeCollection<Item>();
        public ObservableRangeCollection<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public IAsyncCommand       LoadItemsCommand { get; }
        public IAsyncCommand       AddItemCommand { get; }
        public IAsyncCommand<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";

            LoadItemsCommand = new AsyncCommand      (LoadAsync  );
            ItemTapped       = new AsyncCommand<Item>(SelectAsync);
            AddItemCommand   = new AsyncCommand      (AddAsync   );
        }

        public void OnAppearing()
        {
            IsBusy       = true;
            SelectedItem = null;
        }

        private async Task LoadAsync()
        {
            IsBusy = true;

            try
            {
                IEnumerable<Item> items = await DataStore.Value.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task AddAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async Task SelectAsync(Item? item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}