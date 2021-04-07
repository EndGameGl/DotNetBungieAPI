using NetBungieAPI.Models.User;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Applications
{
    public sealed record ApplicationDeveloper
    {
        [JsonPropertyName("role")]
        public DeveloperRole Role { get; init; }

        [JsonPropertyName("apiEulaVersion")]
        public int ApiEulaVersion { get; init; }

        [JsonPropertyName("user")]
        public UserInfoCard User { get; init; }
    }
}
