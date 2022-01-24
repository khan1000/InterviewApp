using Xamarin.Forms;
using InterviewApp.Services;
//using InterviewApp.Droid.Services;
using WeatherAPITest.WeatherData;
using InterviewApp.Interfaces;

[assembly: Dependency(typeof(SqliteDataStore))]
[assembly: Dependency(typeof(PlatformService))]
[assembly: Dependency(typeof(CurrentWeatherService))]
namespace InterviewApp
{
    public partial class App : Application
    {
        public static string Title = "Interview App";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
