﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto
{
    public class ChuckJokeDto
    {
        [JsonPropertyName("categories")]
        public string[] Categories { get; set; }
        [JsonPropertyName("created_at")]
        public string Created_at { get; set; }
        [JsonPropertyName("icon_url")]
        public string Icon_url { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("updated_at")]
        public string Updated_at { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
