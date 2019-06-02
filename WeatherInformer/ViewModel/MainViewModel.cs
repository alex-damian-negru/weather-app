using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using WeatherInformer.Model;

namespace WeatherInformer.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        private IDataRetriever dataRetriever;
        public MainViewModel()
        {
            dataRetriever = new DataRetriever();
        }

        private CurrentWeather weather;

        public CurrentWeather Weather
        {
            get
            {
                return weather;
            }
            set
            {
               
                weather = value;
                RaisePropertyChanged();
            }
        }

        private string city;

        public string City
        {
            get
            {
                return city;
            }
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
                    getWeatherInformationCommand = new RelayCommand(()=> Weather = dataRetriever.GetWeatherInformation(City), ()=>!string.IsNullOrEmpty(City));
                }
                return getWeatherInformationCommand;
            }
        }
    }
}
