using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Weather.Models.AnotherResponse;
using Weather.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class WeatherPageViewModel : BaseViewModel
    {
        RemoteServices remoteServices;
        public ObservableCollection<ForecastData> HourlyForecast { get; set; }

        private DelegateCommand delegateCommand;
        public DelegateCommand DeviceWeather => delegateCommand ?? (delegateCommand = new DelegateCommand(LocationWeather));

        string latitude, longitude;


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


        public WeatherPageViewModel()
        {
            remoteServices = new RemoteServices();
            HourlyForecast = new ObservableCollection<ForecastData>();
            LocationWeather();
        }

        async void LocationWeather()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No internet access", "OK");
                return;
            }

            IsBusy = true;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    latitude = location.Latitude.ToString();
                    longitude = location.Longitude.ToString();
               
                    var data = await remoteServices.GetWeatherLatLong(latitude, longitude);
                    IsBusy = false;
                    if (!data.Error)
                    {
                        Temperature = data.Main.Temp;
                        Pressure = data.Main.Pressure;
                        Humidity = data.Main.Humidity;
                        MinimumTemperature = data.Main.TempMin;
                        MaximumTemperature = data.Main.TempMax;
                        Description = data.Weather[0].Description;
                        Wind = data.Wind.Speed;
                        Cloud = data.Clouds.All;
                        Sunrise = data.Sys.Sunrise;
                        Sunset = data.Sys.Sunset;
                        WeatherIcon = data.Weather[0].Icon;
                        CityName = data.Name.ToUpper();
                        SearchByCityNameForecastWeather();
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
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Device Location Unknown", "OK");
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error Occured", "", "OK");
            }
        }

        async void SearchByCityNameForecastWeather()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No internet access", "OK");
                return;
            }

            IsBusy = true;
            
            var data = await remoteServices.GetWeatherLatLongForecast(latitude,longitude);
            IsBusy = false;
            if (!data.Error)
            {
                HourlyForecast.Clear();

                foreach (var item in data.List)
                {
                    HourlyForecast.Add(item);
                }
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
