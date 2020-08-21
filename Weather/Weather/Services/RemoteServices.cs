using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Models.Response;
using Xamarin.Forms;

namespace Weather.Services
{
    public class RemoteServices
    {
        HttpClient httpClient;
        public RemoteServices()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{App.BackendUrl}/");
        }

        public async Task<WeatherResponse> GetWeatherLatLong(string lat, string lon)
        {
            WeatherResponse weatherResponse = new WeatherResponse();
            var response = await httpClient.GetAsync($"weather?lat=" + lat + "&lon=" + lon + "&appid=" + App.AppID);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                weatherResponse.Error = false;
                return weatherResponse;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "City not found", "OK");
                weatherResponse.Error = true;
                return weatherResponse;
            }
        }

        public async Task<ForecastWeatherResponse> GetWeatherLatLongForecast(string lat, string lon)
        {
            ForecastWeatherResponse forecastWeatherResponse = new ForecastWeatherResponse();
            var response = await httpClient.GetAsync($"forecast?lat=" + lat + "&lon=" + lon + "&appid=" + App.AppID);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                forecastWeatherResponse = JsonConvert.DeserializeObject<ForecastWeatherResponse>(content);
                forecastWeatherResponse.Error = false;
                return forecastWeatherResponse;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "City not found", "OK");
                forecastWeatherResponse.Error = true;
                return forecastWeatherResponse;
            }
        }

        public async Task<WeatherResponse> GetWeatherCityName(string name)
        {
            WeatherResponse weatherResponse = new WeatherResponse();
            var response = await httpClient.GetAsync($"weather?q=" + name + "&appid=" + App.AppID);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);
                weatherResponse.Error = false;
                return weatherResponse;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "City not found", "OK");
                weatherResponse.Error = true;
                return weatherResponse;
            }
        }

        public async Task<ForecastWeatherResponse> WeatherForecast(string name)
        {
            ForecastWeatherResponse forecastWeatherResponse = new ForecastWeatherResponse();
            var response = await httpClient.GetAsync($"forecast?q=" + name + "&appid=" + App.AppID);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                forecastWeatherResponse = JsonConvert.DeserializeObject<ForecastWeatherResponse>(content);
                forecastWeatherResponse.Error = false;
                return forecastWeatherResponse;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "City not found", "OK");
                forecastWeatherResponse.Error = true;
                return forecastWeatherResponse;
            }
        }


    }
}
