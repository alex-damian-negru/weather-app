using System;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherInformer.Model;

namespace WeatherInformer.Services
{
    internal class WeatherService : IWeatherService
    {
        private string url;
        private string appId;
        public WeatherService()
        {
            url = System.Configuration.ConfigurationManager.AppSettings["url"];
            appId = System.Configuration.ConfigurationManager.AppSettings["appId"];

        }

        public WeatherForecast GetWeatherInformation(string city)
        {
          
            try
            {
                var path = ConstructUrl(city);
                var result = new HttpClient().GetStringAsync(path).Result;
                var data = JsonConvert.DeserializeObject<WeatherForecast>(result);

                return data;

            }
            catch (Exception)
            {
                return null;
            }
        }

        private string ConstructUrl(string city)
        {
            return string.Concat(url, city, appId, "&units=metric");
        }
    }
}
