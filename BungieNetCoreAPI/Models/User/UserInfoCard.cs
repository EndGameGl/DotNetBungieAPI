using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record UserInfoCard : CrossSaveUserMembership
    {
        [JsonPropertyName("supplementalDisplayName")]
        public string SupplementalDisplayName { get; init; }

        [JsonPropertyName("iconPath")]
        public string IconPath { get; init; }
    }
}
