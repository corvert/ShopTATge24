using System.Text.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string apiKey = "";
            var response = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={dto.CityName}";

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(response);
                string json = await httpResponse.Content.ReadAsStringAsync();

                //tallinn 127964
                List<AccuCityCodeRootDto> weatherData = JsonSerializer.Deserialize<List<AccuCityCodeRootDto>>(json);

                dto.CityName = weatherData[0].LocalizedName;
                dto.CityCode = weatherData[0].Key;


            }
            var weatherResponse = $"http://dataservice.accuweather.com/currentconditions/v1/{dto.CityCode}?apikey={apiKey}&metric=true";
            using (var clientWeather = new HttpClient())
            {
                var httpResponse = await clientWeather.GetAsync(weatherResponse);
                string jsonWeather = await httpResponse.Content.ReadAsStringAsync();
                List<AccuLocationRootDto> weatherConditionData = 
                    JsonSerializer.Deserialize<List<AccuLocationRootDto>>(jsonWeather);
                dto.TempMinCelsius = weatherConditionData[0].Temperature.Metric.Value;
                dto.TempMaxCelsius = weatherConditionData[0].Temperature.Metric.Value;
                dto.EffectiveDate = weatherConditionData[0].LocalObservationDateTime;
                dto.WeatherText = weatherConditionData[0].WeatherText;
                dto.Severity = weatherConditionData[0].WeatherIcon;

            }

                return dto;
        }
       
    }
}
