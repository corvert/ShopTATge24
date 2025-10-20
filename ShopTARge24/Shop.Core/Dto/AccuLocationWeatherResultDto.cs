using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dto
{
    public class AccuLocationWeatherResultDto
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public double TempMinCelsius { get; set; }
        public double TempMaxCelsius { get; set; }
        public string EffectiveDate { get; set; }
        public string WeatherText { get; set; }
        public int Severity { get; set; }


    }
}
