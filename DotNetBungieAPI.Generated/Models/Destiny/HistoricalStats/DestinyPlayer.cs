namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPlayer
{

    /// <summary>
    ///     Details about the player as they are known in game (platform display name, Destiny emblem)
    /// </summary>
    [JsonPropertyName("destinyUserInfo")]
    public User.UserInfoCard DestinyUserInfo { get; init; }

    /// <summary>
    ///     Class of the character if applicable and available.
    /// </summary>
    [JsonPropertyName("characterClass")]
    public string CharacterClass { get; init; }

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; } // DestinyClassDefinition

    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; init; } // DestinyRaceDefinition

    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; init; } // DestinyGenderDefinition

    /// <summary>
    ///     Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("characterLevel")]
    public int CharacterLevel { get; init; }

    /// <summary>
    ///     Light Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("lightLevel")]
    public int LightLevel { get; init; }

    /// <summary>
    ///     Details about the player as they are known on BungieNet. This will be undefined if the player has marked their credential private, or does not have a BungieNet account.
    /// </summary>
    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; init; }

    /// <summary>
    ///     Current clan name for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanName")]
    public string ClanName { get; init; }

    /// <summary>
    ///     Current clan tag for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanTag")]
    public string ClanTag { get; init; }

    /// <summary>
    ///     If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).
    /// </summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; init; } // DestinyInventoryItemDefinition
}
