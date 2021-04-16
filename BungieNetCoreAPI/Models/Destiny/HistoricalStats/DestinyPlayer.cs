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
        [JsonPropertyName("destinyUserInfo")]
        public UserInfoCard DestinyUserInfo { get; init; }
        [JsonPropertyName("characterClass")]
        public string CharacterClass { get; init; }
        [JsonPropertyName("classHash")]
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; } = DefinitionHashPointer<DestinyClassDefinition>.Empty;
        [JsonPropertyName("raceHash")]
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; } = DefinitionHashPointer<DestinyRaceDefinition>.Empty;
        [JsonPropertyName("genderHash")]
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; } = DefinitionHashPointer<DestinyGenderDefinition>.Empty;
        [JsonPropertyName("characterLevel")]
        public int CharacterLevel { get; init; }
        [JsonPropertyName("lightLevel")]
        public int LightLevel { get; init; }
        [JsonPropertyName("bungieNetUserInfo")]
        public UserInfoCard BungieNetUserInfo { get; init; }
        [JsonPropertyName("clanName")]
        public string ClanName { get; init; }
        [JsonPropertyName("clanTag")]
        public string ClanTag { get; init; }
        [JsonPropertyName("emblemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
    }
}
