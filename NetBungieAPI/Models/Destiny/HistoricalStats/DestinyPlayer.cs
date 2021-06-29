using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.User;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPlayer
    {
        /// <summary>
        ///     Details about the player as they are known in game (platform display name, Destiny emblem)
        /// </summary>
        [JsonPropertyName("destinyUserInfo")]
        public UserInfoCard DestinyUserInfo { get; init; }

        /// <summary>
        ///     Class of the character if applicable and available.
        /// </summary>
        [JsonPropertyName("characterClass")]
        public string CharacterClass { get; init; }

        [JsonPropertyName("classHash")]
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; } =
            DefinitionHashPointer<DestinyClassDefinition>.Empty;

        [JsonPropertyName("raceHash")]
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; } =
            DefinitionHashPointer<DestinyRaceDefinition>.Empty;

        [JsonPropertyName("genderHash")]
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; } =
            DefinitionHashPointer<DestinyGenderDefinition>.Empty;

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
        ///     Details about the player as they are known on BungieNet. This will be undefined if the player has marked their
        ///     credential private, or does not have a BungieNet account.
        /// </summary>
        [JsonPropertyName("bungieNetUserInfo")]
        public UserInfoCard BungieNetUserInfo { get; init; }

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
        ///     If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving
        ///     PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).
        /// </summary>
        [JsonPropertyName("emblemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
    }
}