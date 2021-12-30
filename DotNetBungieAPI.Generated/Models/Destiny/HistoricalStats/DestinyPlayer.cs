using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPlayer
{

    [JsonPropertyName("destinyUserInfo")]
    public User.UserInfoCard DestinyUserInfo { get; init; }

    [JsonPropertyName("characterClass")]
    public string CharacterClass { get; init; }

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; }

    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; init; }

    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; init; }

    [JsonPropertyName("characterLevel")]
    public int CharacterLevel { get; init; }

    [JsonPropertyName("lightLevel")]
    public int LightLevel { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; init; }

    [JsonPropertyName("clanName")]
    public string ClanName { get; init; }

    [JsonPropertyName("clanTag")]
    public string ClanTag { get; init; }

    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; }
}
