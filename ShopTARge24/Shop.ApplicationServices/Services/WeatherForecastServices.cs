using System.Text.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            var response = "https://api.weatherapi.com/v1/current.json";

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(response);
                string json = await httpResponse.Content.ReadAsStringAsync();

                //tallinn 127964
                List<AccuLocationRootDto> weatherData = JsonSerializer.Deserialize<List<AccuLocationRootDto>>(json);


            }
            return dto;
        }
}
