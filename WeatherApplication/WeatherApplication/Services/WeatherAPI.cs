using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using weatherapp.Models;

namespace weatherapp.Services
{
    class WeatherAPI
    {
        public const string OPENWEATHERMAP_API_KEY = "a40d252836a516be3ad2d2a6caaf0cd1";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/onecall?lat=-33.918861&lon=18.423300&units=metric&appid=a40d252836a516be3ad2d2a6caaf0cd1";
        public static async Task<OneCallAPI> GetOneCallAPIAsync(double lat, double lon, string units)
        {
            OneCallAPI weather = new OneCallAPI();
            string url = String.Format(BASE_URL, lat, lon, units, OPENWEATHERMAP_API_KEY);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<OneCallAPI>(content);
                weather = post;
            }
            return weather;
        }

    }
}
