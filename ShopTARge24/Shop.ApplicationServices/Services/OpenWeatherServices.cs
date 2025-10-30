using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shop.Core.Dto.OpenWeatherDtos;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class OpenWeatherServices: IOpenWeatherServices    
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public OpenWeatherServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
    public async Task<OpenWeatherRootDto> OpenWeatherResult(OpenWeatherResultDto dto)
    {
            string apiKey = _configuration["OpenWeather:ApiKey"];
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={dto.name}&appid={apiKey}&units=metric");
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
