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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {


        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new WeatherViewModel();
        }
    }
}