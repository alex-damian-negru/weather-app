using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace WeatherInformer.Model
{
    internal class DataRetriever : IDataRetriever
    {
        private string url;
        private string appId;
        public DataRetriever()
        {
            url = System.Configuration.ConfigurationManager.AppSettings["url"];
            appId = System.Configuration.ConfigurationManager.AppSettings["appId"];

        }

        public CurrentWeather GetWeatherInformation(string city)
        {
          
            try
            {
                var path = ConstructUrl(city);
                var result = new HttpClient().GetStringAsync(path).Result;
                var data = JsonConvert.DeserializeObject<CurrentWeather>(result);

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
