using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using WeatherInformer.Model;
using WeatherInformer.Services;

namespace WeatherInformer.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        private readonly IWeatherService dataRetriever;
        public MainViewModel() { dataRetriever = new WeatherService(); }

        private WeatherForecast weatherForecast;
        public WeatherForecast WeatherForecast
        {
            get { return weatherForecast; }
            set
            {
                weatherForecast = value;
                RaisePropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged();
                (GetWeatherInformation as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        private ICommand getWeatherInformationCommand;
        public ICommand GetWeatherInformation
        {
            get
            {
                if (getWeatherInformationCommand == null)
                {
                    getWeatherInformationCommand = new RelayCommand(
                        ()=> WeatherForecast = dataRetriever.GetWeatherInformation(City),
                        ()=>!string.IsNullOrEmpty(City)
                        );
                }
                return getWeatherInformationCommand;
            }
        }
    }
}
