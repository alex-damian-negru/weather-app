using WeatherInformer.Model;

namespace WeatherInformer.Services
{
    internal interface IWeatherService
    {
        WeatherForecast GetWeatherInformation(string city);
    }
}