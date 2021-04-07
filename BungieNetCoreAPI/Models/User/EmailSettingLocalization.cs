using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record EmailSettingLocalization
    {
        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }
    }
}
