using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Profiles;

public sealed class DestinyProfileComponent
{

    [JsonPropertyName("userInfo")]
    public User.UserInfoCard UserInfo { get; init; }

    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; init; }

    [JsonPropertyName("versionsOwned")]
    public Destiny.DestinyGameVersions VersionsOwned { get; init; }

    [JsonPropertyName("characterIds")]
    public List<long> CharacterIds { get; init; }

    [JsonPropertyName("seasonHashes")]
    public List<uint> SeasonHashes { get; init; }

    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; init; }

    [JsonPropertyName("currentSeasonRewardPowerCap")]
    public int? CurrentSeasonRewardPowerCap { get; init; }
}
