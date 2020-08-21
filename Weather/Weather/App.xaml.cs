using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.Services;
using Weather.Views;
using Prism;
using Prism.Ioc;
using Weather.ViewModels;

namespace Weather
{
    public partial class App
    {
        public static string BackendUrl = "http://api.openweathermap.org/data/2.5";
        public static string AppID = "1afc57c89c8af797c5b4bc27bbc35a42";
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            await NavigationService.NavigateAsync("AppShell");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AppShell>();
            containerRegistry.RegisterForNavigation<WeatherPage, WeatherPageViewModel>();
            containerRegistry.RegisterForNavigation<ThreeDaysWeatherPage, ThreeDaysWeatherPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchByCityPage, SearchByCityPageViewModel>();
        }

    }
}
