using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Globalization;

namespace MainProject.Data
{
    public class RecipeDetailModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
