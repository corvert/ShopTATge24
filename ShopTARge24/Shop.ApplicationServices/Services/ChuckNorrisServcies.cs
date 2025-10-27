using System.Net;
using System.Text.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
namespace Shop.ApplicationServices.Services
{
    public class ChuckNorrisServcies : IChuckNorrisServcies
    {
        public async Task<ChuckJokeDto> FetchRandomJoke()
        {
            string jokeUrl = "https://api.chucknorris.io/jokes/random";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(jokeUrl);
                ChuckJokeDto jokeDto = JsonSerializer.Deserialize<ChuckJokeDto>(json);
                return jokeDto;
            }
        }
    }
}