using System;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherInformer.Model;

namespace WeatherInformer.Services
{
    internal class WeatherService : IWeatherService
    {
        private readonly string _url = ConfigurationManager.AppSettings["url"];
        private readonly string _appId = ConfigurationManager.AppSettings["appId"];

        public WeatherForecast GetWeatherInformation(string city)
        {
            try
            {
                var path = ConstructUrl(city);
                var result = new HttpClient().GetStringAsync(path).Result;
                var data = JsonConvert.DeserializeObject<WeatherForecast>(result);
                data.Wind.Speed *= 3.6; // turns m/s to km/h

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string ConstructUrl(string city)
        {
            return string.Concat(_url, city, _appId, "&units=metric");
        }
    }
}
