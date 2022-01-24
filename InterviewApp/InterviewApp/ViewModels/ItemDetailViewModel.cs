using System;
using System.Diagnostics;
using System.Threading.Tasks;
using InterviewApp.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace InterviewApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _itemId = "";
        public string ItemId
        {
            get => _itemId;
            set => SetProperty(ref _itemId, value, onChanged: () => LoadAsync(value).SafeFireAndForget());
        }

        private string _id = "";
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string text = "";
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private string _description = "";
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public async Task LoadAsync(string itemId)
        {
            try
            {
                Item? item = await DataStore.Value.GetItemAsync(itemId);

                Id          = item?.Id          ?? "";
                Text        = item?.Text        ?? "";
                Description = item?.Description ?? "";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
