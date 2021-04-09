using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Destiny.Progressions;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterComponent
    {
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; init; }
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }
        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }
        [JsonPropertyName("dateLastPlayed")]
        public DateTime DateLastPlayed { get; init; }
        [JsonPropertyName("minutesPlayedThisSession")]
        public long MinutesPlayedThisSession { get; init; }
        [JsonPropertyName("minutesPlayedTotal")]
        public long MinutesPlayedTotal { get; init; }
        [JsonPropertyName("light")]
        public int Light { get; init; }
        [JsonPropertyName("stats")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, int> Stats { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, int>();
        [JsonPropertyName("raceHash")]
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; init; } = DefinitionHashPointer<DestinyRaceDefinition>.Empty;
        [JsonPropertyName("genderHash")]
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; init; } = DefinitionHashPointer<DestinyGenderDefinition>.Empty;
        [JsonPropertyName("classHash")]
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; init; } = DefinitionHashPointer<DestinyClassDefinition>.Empty;
        [JsonPropertyName("raceType")]
        public DestinyRace RaceType { get; init; }
        [JsonPropertyName("classType")]
        public DestinyClass ClassType { get; init; }
        [JsonPropertyName("genderType")]
        public DestinyGender GenderType { get; init; }
        [JsonPropertyName("emblemPath")]
        public string EmblemPath { get; init; }
        [JsonPropertyName("emblemBackgroundPath")]
        public string EmblemBackgroundPath { get; init; }
        [JsonPropertyName("emblemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Emblem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("emblemColor")]
        public DestinyColor EmblemColor { get; init; }
        [JsonPropertyName("levelProgression")]
        public DestinyProgression LevelProgression { get; init; }
        [JsonPropertyName("baseCharacterLevel")]
        public int BaseCharacterLevel { get; init; }
        [JsonPropertyName("percentToNextLevel")]
        public double PercentToNextLevel { get; init; }
        [JsonPropertyName("titleRecordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> TitleRecord { get; init; } = DefinitionHashPointer<DestinyRecordDefinition>.Empty;
    }
}
