namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPlayer
{
    /// <summary>
    ///     Details about the player as they are known in game (platform display name, Destiny emblem)
    /// </summary>
    [JsonPropertyName("destinyUserInfo")]
    public User.UserInfoCard? DestinyUserInfo { get; set; }

    /// <summary>
    ///     Class of the character if applicable and available.
    /// </summary>
    [JsonPropertyName("characterClass")]
    public string? CharacterClass { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyClassDefinition>("Destiny.Definitions.DestinyClassDefinition")]
    [JsonPropertyName("classHash")]
    public uint? ClassHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyRaceDefinition>("Destiny.Definitions.DestinyRaceDefinition")]
    [JsonPropertyName("raceHash")]
    public uint? RaceHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyGenderDefinition>("Destiny.Definitions.DestinyGenderDefinition")]
    [JsonPropertyName("genderHash")]
    public uint? GenderHash { get; set; }

    /// <summary>
    ///     Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("characterLevel")]
    public int? CharacterLevel { get; set; }

    /// <summary>
    ///     Light Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("lightLevel")]
    public int? LightLevel { get; set; }

    /// <summary>
    ///     Details about the player as they are known on BungieNet. This will be undefined if the player has marked their credential private, or does not have a BungieNet account.
    /// </summary>
    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; set; }

    /// <summary>
    ///     Current clan name for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanName")]
    public string? ClanName { get; set; }

    /// <summary>
    ///     Current clan tag for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanTag")]
    public string? ClanTag { get; set; }

    /// <summary>
    ///     If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("emblemHash")]
    public uint? EmblemHash { get; set; }
}
