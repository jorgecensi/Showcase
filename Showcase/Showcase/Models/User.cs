using Newtonsoft.Json;

namespace Showcase.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
