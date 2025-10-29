using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shop.Core.Dto.OpenWeatherDtos
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Clouds
    {
        [JsonProperty("all", NullValueHandling = NullValueHandling.Ignore)]
        public int all { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public double lon { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double lat { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp", NullValueHandling = NullValueHandling.Ignore)]
        public double temp { get; set; }

        [JsonProperty("feels_like", NullValueHandling = NullValueHandling.Ignore)]
        public double feels_like { get; set; }

        [JsonProperty("temp_min", NullValueHandling = NullValueHandling.Ignore)]
        public double temp_min { get; set; }

        [JsonProperty("temp_max", NullValueHandling = NullValueHandling.Ignore)]
        public double temp_max { get; set; }

        [JsonProperty("pressure", NullValueHandling = NullValueHandling.Ignore)]
        public int pressure { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public int humidity { get; set; }

        [JsonProperty("sea_level", NullValueHandling = NullValueHandling.Ignore)]
        public int sea_level { get; set; }

        [JsonProperty("grnd_level", NullValueHandling = NullValueHandling.Ignore)]
        public int grnd_level { get; set; }
    }

    public class OpenWeatherRootDto
    {
        [JsonProperty("coord", NullValueHandling = NullValueHandling.Ignore)]
        public Coord coord { get; set; }

        [JsonProperty("weather", NullValueHandling = NullValueHandling.Ignore)]
        public List<Weather> weather { get; set; }

        [JsonProperty("base", NullValueHandling = NullValueHandling.Ignore)]
        public string @base { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        public Main main { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public int visibility { get; set; }

        [JsonProperty("wind", NullValueHandling = NullValueHandling.Ignore)]
        public Wind wind { get; set; }

        [JsonProperty("clouds", NullValueHandling = NullValueHandling.Ignore)]
        public Clouds clouds { get; set; }

        [JsonProperty("dt", NullValueHandling = NullValueHandling.Ignore)]
        public int dt { get; set; }

        [JsonProperty("sys", NullValueHandling = NullValueHandling.Ignore)]
        public Sys sys { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public int timezone { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty("cod", NullValueHandling = NullValueHandling.Ignore)]
        public int cod { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int type { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string country { get; set; }

        [JsonProperty("sunrise", NullValueHandling = NullValueHandling.Ignore)]
        public int sunrise { get; set; }

        [JsonProperty("sunset", NullValueHandling = NullValueHandling.Ignore)]
        public int sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        public string main { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed", NullValueHandling = NullValueHandling.Ignore)]
        public double speed { get; set; }

        [JsonProperty("deg", NullValueHandling = NullValueHandling.Ignore)]
        public int deg { get; set; }
    }



}