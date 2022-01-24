using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel();
            InitializeComponent();
        }
    }
}