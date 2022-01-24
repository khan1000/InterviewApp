using System;
using System.Collections.Generic;
using System.ComponentModel;
using InterviewApp.Models;
using InterviewApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            BindingContext = new NewItemViewModel();
            InitializeComponent();
        }
    }
}