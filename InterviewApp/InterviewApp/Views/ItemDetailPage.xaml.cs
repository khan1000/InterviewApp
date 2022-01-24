using System.ComponentModel;
using InterviewApp.ViewModels;
using Xamarin.Forms;

namespace InterviewApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            BindingContext = new ItemDetailViewModel();
            InitializeComponent();
        }
    }
}