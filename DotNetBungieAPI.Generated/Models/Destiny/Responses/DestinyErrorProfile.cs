using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyErrorProfile
{

    [JsonPropertyName("errorCode")]
    public Exceptions.PlatformErrorCodes ErrorCode { get; init; }

    [JsonPropertyName("infoCard")]
    public User.UserInfoCard InfoCard { get; init; }
}
