﻿using NetBungieAPI.Destiny.Definitions.Artifacts;
using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Destiny.Definitions.Progressions;
using NetBungieAPI.Destiny.Definitions.Seasons;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Common
{
    public sealed record Destiny2CoreSettings
    {
        [JsonPropertyName("collectionRootNode")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("badgesRootNode")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> BadgesRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("recordsRootNode")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("medalsRootNode")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("metricsRootNode")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("activeTriumphsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveTriumphsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("activeSealsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveSealsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("legacyTriumphsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacyTriumphsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("legacySealsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacySealsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("medalsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> MedalsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("exoticCatalystsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> ExoticCatalystsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("loreRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> LoreRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        [JsonPropertyName("currentRankProgressionHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyProgressionDefinition>> CurrentRankProgressions { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyProgressionDefinition>>();

        [JsonPropertyName("undiscoveredCollectibleImage")]
        public string UndiscoveredCollectibleImage { get; init; }

        [JsonPropertyName("ammoTypeHeavyIcon")]
        public string AmmoTypeHeavyIcon { get; init; }

        [JsonPropertyName("ammoTypeSpecialIcon")]
        public string AmmoTypeSpecialIcon { get; init; }

        [JsonPropertyName("ammoTypePrimaryIcon")]
        public string AmmoTypePrimaryIcon { get; init; }

        [JsonPropertyName("currentSeasonalArtifactHash")]
        public DefinitionHashPointer<DestinyArtifactDefinition> CurrentSeasonalArtifact { get; init; } = DefinitionHashPointer<DestinyArtifactDefinition>.Empty;

        [JsonPropertyName("currentSeasonHash")]
        public DefinitionHashPointer<DestinySeasonDefinition> СurrentSeason { get; init; } = DefinitionHashPointer<DestinySeasonDefinition>.Empty;

        [JsonPropertyName("futureSeasonHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> FutureSeasons { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>>();

        [JsonPropertyName("pastSeasonHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> PastSeasons { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>>();
    }
}
