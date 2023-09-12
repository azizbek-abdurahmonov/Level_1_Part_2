using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T2.Models
{
    public static class WeatherData
    {
        public static (double Temperature, double Humidity, double WindSpeed) CreateWeatherData(double temperature, double humidity, double windSpeed)
        {
            return (temperature, humidity, windSpeed);
        }
    }
}
