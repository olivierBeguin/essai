using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo5.Model
{
    public class Forecast
    {
        public string CityName { get; set; }
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }
    }
}
