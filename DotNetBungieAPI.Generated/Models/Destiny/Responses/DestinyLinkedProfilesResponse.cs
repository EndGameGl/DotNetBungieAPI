using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyLinkedProfilesResponse
{

    [JsonPropertyName("profiles")]
    public List<Destiny.Responses.DestinyProfileUserInfoCard> Profiles { get; init; }

    [JsonPropertyName("bnetMembership")]
    public User.UserInfoCard BnetMembership { get; init; }

    [JsonPropertyName("profilesWithErrors")]
    public List<Destiny.Responses.DestinyErrorProfile> ProfilesWithErrors { get; init; }
}
