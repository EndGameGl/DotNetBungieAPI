﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalStatsPerCharacter
    {
        [JsonPropertyName("characterId")] public long CharacterId { get; init; }
        [JsonPropertyName("deleted")] public bool IsDeleted { get; init; }

        [JsonPropertyName("results")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod>();

        [JsonPropertyName("merged")] public DestinyHistoricalStatsByPeriod Merged { get; init; }
    }
}