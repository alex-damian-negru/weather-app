namespace WeatherInformer.Model
{
    internal interface IDataRetriever
    {
        CurrentWeather GetWeatherInformation(string city);
        
    }
}