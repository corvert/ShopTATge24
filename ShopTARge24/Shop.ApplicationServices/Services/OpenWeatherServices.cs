using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shop.Core.Dto.OpenWeatherDtos;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class OpenWeatherServices: IOpenWeatherServices    
    {
        private readonly HttpClient _httpClient;
        public OpenWeatherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        string apiKey = "";
    public async Task<OpenWeatherRootDto> OpenWeatherResultWebClient(OpenWeatherResultDto dto)
    {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={dto.name}&appid={apiKey}");
            response.EnsureSuccessStatusCode();
            var json =  await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<OpenWeatherRootDto>(json, options);

            return result;
    }
}
}
