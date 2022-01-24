using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Xamarin.Forms;
using WeatherAPITest.WeatherData.DataHandling;
using WeatherAPITest.WeatherData.HTTPManger;
using WeatherAPITest.WeatherData;
using WeatherAPITest.WeatherData.DataHandling;
using System.Threading.Tasks;

namespace InterviewApp.ViewModels
{
    class WeatherViewModel : BaseViewModel
    {
        private CurrentWeatherService _weather;

        private int _temp;
        private int _feels_like;
        private int _temp_max;
        private int _temp_min;


        public CurrentWeatherService Weather
        {
            get => _weather;
            set => SetProperty(ref _weather, value);
        }
        public int temp
        {
            get => _temp;
            set => SetProperty(ref _temp, value);
        }
        public int feelsLike
        {
            get => _feels_like;
            set => SetProperty(ref _feels_like, value);
        }
        public int tempMax
        {
            get => _temp_max;
            set => SetProperty(ref _temp_max, value);
        }


        public int tempMin
        {
            get => _temp_min ;
            set => SetProperty(ref _temp_min, value);
        }

        public int getFeelsLike() { return (int)_weather.weatherDTO.CurrentWeatherRootobject.main.feels_like; }
        public int getTemp() { return (int)_weather.weatherDTO.CurrentWeatherRootobject.main.temp; }
        public int getTempMax() { return (int)_weather.weatherDTO.CurrentWeatherRootobject.main.temp_max; }

        public int getTempMin() { return (int)_weather.weatherDTO.CurrentWeatherRootobject.main.temp_min; }


        public CurrentWeatherService getWeather(String city) 
        {
            return  new CurrentWeatherService($"{city}");
        }


        public WeatherViewModel() 
        {
            Title = "Weather";
            
            _weather = getWeather("London");

            Weather = _weather;

            feelsLike = getFeelsLike();

            temp = getTemp();

            tempMax = getTempMax();

            tempMin = getTempMin();

            

        }


    }
}
