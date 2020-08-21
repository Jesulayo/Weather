using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models.AnotherResponse
{
    public class ForecastWeatherResponse
    {
            public bool Error;

            [JsonProperty("cod")]
            public long Cod { get; set; }

            [JsonProperty("message")]
            public long Message { get; set; }

            [JsonProperty("cnt")]
            public long Cnt { get; set; }

            [JsonProperty("list")]
            public List<ForecastData> List { get; set; }

            [JsonProperty("city")]
            public City City { get; set; }
        }

        public partial class City
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("coord")]
            public Coord Coord { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("population")]
            public long Population { get; set; }

            [JsonProperty("timezone")]
            public long Timezone { get; set; }

            [JsonProperty("sunrise")]
            public long Sunrise { get; set; }

            [JsonProperty("sunset")]
            public long Sunset { get; set; }
        }

        public partial class Coord
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lon")]
            public double Lon { get; set; }
        }

        public partial class ForecastData
    {
            [JsonProperty("dt")]
            public long Dt { get; set; }

            [JsonProperty("main")]
            public MainClass Main { get; set; }

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; }

            [JsonProperty("clouds")]
            public Clouds Clouds { get; set; }

            [JsonProperty("wind")]
            public Wind Wind { get; set; }

            [JsonProperty("sys")]
            public Sys Sys { get; set; }

            [JsonProperty("dt_txt")]
            public DateTimeOffset DtTxt { get; set; }

            [JsonProperty("rain", NullValueHandling = NullValueHandling.Ignore)]
            public Rain Rain { get; set; }
        }

        public partial class Clouds
        {
            [JsonProperty("all")]
            public long Alll { get; set; }
        }

        public partial class MainClass
        {
            [JsonProperty("temp")]
            public double Temp { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }

            [JsonProperty("pressure")]
            public long Pressure { get; set; }

            [JsonProperty("sea_level")]
            public long SeaLevel { get; set; }

            [JsonProperty("grnd_level")]
            public long GrndLevel { get; set; }

            [JsonProperty("humidity")]
            public long Humidity { get; set; }

            [JsonProperty("temp_kf")]
            public long TempKf { get; set; }
        }

        public partial class Rain
        {
            [JsonProperty("3h")]
            public double The3H { get; set; }
        }

        public partial class Sys
        {
            [JsonProperty("pod")]
            public string Pod { get; set; }
        }

        public partial class Weather
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("main")]
            public string Main { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon{ get; set; }
        }

        public partial class Wind
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public long Deg { get; set; }
        }

    }
