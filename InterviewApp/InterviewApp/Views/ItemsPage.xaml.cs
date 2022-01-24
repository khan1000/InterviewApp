using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewApp.Models;
using InterviewApp.ViewModels;
using InterviewApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsViewModel ViewModel => (ItemsViewModel) BindingContext;

        public ItemsPage()
        {
            BindingContext = new ItemsViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}