using NetBungieAPI.Models.Destiny.Definitions.Seasons;
using NetBungieAPI.Models.User;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyProfileComponent
    {
        [JsonPropertyName("userInfo")]
        public UserInfoCard UserInfo { get; init; }
        [JsonPropertyName("dateLastPlayed")]
        public DateTime DateLastPlayed { get; init; }
        [JsonPropertyName("versionsOwned")]
        public DestinyGameVersions VersionsOwned { get; init; }
        [JsonPropertyName("characterIds")]
        public ReadOnlyCollection<long> CharacterIds { get; init; } = Defaults.EmptyReadOnlyCollection<long>();
        [JsonPropertyName("seasonHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>>();
        [JsonPropertyName("currentSeasonHash")]
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; init; } = DefinitionHashPointer<DestinySeasonDefinition>.Empty;
        [JsonPropertyName("currentSeasonRewardPowerCap")]
        public int? CurrentSeasonRewardPowerCap { get; init; }
    }
}
