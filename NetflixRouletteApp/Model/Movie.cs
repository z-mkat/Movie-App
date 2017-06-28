using System;
using Newtonsoft.Json;

namespace NetflixRouletteApp
{
    public class Movie
    {
        [JsonProperty("show_id")]
        public string Id { get; set; }

        [JsonProperty("show_title")]
        public string Title { get; set; }

        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonProperty("rating")]
        public float Rating { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
