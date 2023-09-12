using Newtonsoft.Json;

namespace MainProject.Data
{
    public class RecipeModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
