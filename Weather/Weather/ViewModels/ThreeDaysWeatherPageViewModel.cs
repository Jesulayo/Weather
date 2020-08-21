using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Weather.Models;
using Weather.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class ThreeDaysWeatherPageViewModel : BaseViewModel
    {
        RemoteServices remoteServices;
        private DelegateCommand delegateCommand;
        public DelegateCommand SearchByCityWeather => delegateCommand ?? (delegateCommand = new DelegateCommand(SearchByCityNameForecastWeather));


        private long wind;
        public long Wind
        {
            get => wind;
            set
            {
                wind = value;
                OnPropertyChanged();
            }
        }

        private long humidity;
        public long Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged();
            }
        }

        private long pressure;
        public long Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                OnPropertyChanged();
            }
        }
        private long cloud;
        public long Cloud
        {
            get => cloud;
            set
            {
                cloud = value;
                OnPropertyChanged();
            }
        }
        private long sunrise;
        public long Sunrise
        {
            get => sunrise;
            set
            {
                sunrise = value;
                OnPropertyChanged();
            }
        }

        private long sunset;
        public long Sunset
        {
            get => sunset;
            set
            {
                sunset = value;
                OnPropertyChanged();
            }
        }

        private string cityName;
        public string CityName
        {
            get => cityName;
            set
            {
                cityName = value;
                OnPropertyChanged();
            }
        }

        private string weatherIcon;
        public string WeatherIcon
        {
            get => weatherIcon;
            set
            {
                weatherIcon = value;
                OnPropertyChanged();
            }
        }


        private double temperature;
        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged();
            }
        }
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        private double minimumTemperature;
        public double MinimumTemperature
        {
            get => minimumTemperature;
            set
            {
                minimumTemperature = value;
                OnPropertyChanged();
            }
        }
        private double maximumTemperature;
        public double MaximumTemperature
        {
            get => maximumTemperature;
            set
            {
                maximumTemperature = value;
                OnPropertyChanged();
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        private string searchEntry;
        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;
                OnPropertyChanged();
            }
        }

        public ThreeDaysWeatherPageViewModel()
        {
            remoteServices = new RemoteServices();
        }

        public List<WeatherClass> allList = new List<WeatherClass>();

        //async void SearchByCityNameWeather()
        //{
        //    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", "No internet access", "OK");
        //        return;
        //    }

        //    if (SearchEntry == null)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", "Input the necessary fields", "OK");
        //        return;
        //    }

        //    IsBusy = true;

        //    var data = await remoteServices.GetWeatherCityName(SearchEntry);
        //    IsBusy = false;
        //    if (!data.Error)
        //    {

        //        Temperature = data.Main.Temp;
        //        Pressure = data.Main.Pressure;
        //        Humidity = data.Main.Humidity;
        //        MinimumTemperature = data.Main.TempMin;
        //        MaximumTemperature = data.Main.TempMax;
        //        Description = data.Weather[0].Description;
        //        Wind = data.Wind.Speed;
        //        Cloud = data.Clouds.All;
        //        Sunrise = data.Sys.Sunrise;
        //        Sunset = data.Sys.Sunset;
        //        WeatherIcon = data.Weather[0].Icon;
        //        CityName = data.Name.ToUpper();
        //        SearchByCityNameForecastWeather();
        //    }
        //    else
        //    {
        //        Temperature = 273.15;
        //        Pressure = 0;
        //        Humidity = 0;
        //        MinimumTemperature = 0;
        //        MaximumTemperature = 0;
        //        Description = null;
        //        Wind = 0;
        //        Cloud = 0;
        //        Sunrise = 0;
        //        Sunset = 0;
        //        CityName = null;

        //    }
        //}

        async void SearchByCityNameForecastWeather()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No internet access", "OK");
                return;
            }

            if (SearchEntry == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Input the necessary fields", "OK");
                return;
            }

            IsBusy = true;

            var data = await remoteServices.WeatherForecast(SearchEntry);
            IsBusy = false;
            if (!data.Error)
            {

                foreach (var list in data.List)
                {
                    allList.Add(new WeatherClass
                    {
                        Temperatures = list.Main.Temp
                    });
                    //allList.Add(list.Main.Temp);


                    //var date = DateTime.ParseExact(list.dt_txt, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                    //var date = DateTime.Parse(list.dt_txt);

                    //if (date > DateTime.Now && date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                    //    allList.Add(list);
                }


                //Temperature = data.Main.Temp;
                //Pressure = data.Main.Pressure;
                //Humidity = data.Main.Humidity;
                //MinimumTemperature = data.Main.TempMin;
                //MaximumTemperature = data.Main.TempMax;
                //Description = data.Weather[0].Description;
                //Wind = data.Wind.Speed;
                //Cloud = data.Clouds.All;
                //Sunrise = data.Sys.Sunrise;
                //Sunset = data.Sys.Sunset;
                //WeatherIcon = data.Weather[0].Icon;
                //CityName = data.Name.ToUpper();
            }
            else
            {
                Temperature = 273.15;
                Pressure = 0;
                Humidity = 0;
                MinimumTemperature = 0;
                MaximumTemperature = 0;
                Description = null;
                Wind = 0;
                Cloud = 0;
                Sunrise = 0;
                Sunset = 0;
                CityName = null;

            }
        }
        
    }
}
