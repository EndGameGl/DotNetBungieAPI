using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Metrics;
using NetBungieAPI.Models.Destiny.Quests;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemComponent : DestinyItemQuantity
    {
        [JsonPropertyName("bindStatus")]
        public ItemBindStatus BindStatus { get; init; }
        [JsonPropertyName("location")]
        public ItemLocation Location { get; init; }
        [JsonPropertyName("bucketHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; init; } = DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;
        [JsonPropertyName("transferStatus")]
        public TransferStatuses TransferStatus { get; init; }
        [JsonPropertyName("lockable")]
        public bool IsLockable { get; init; }
        [JsonPropertyName("state")]
        public ItemState State { get; init; }
        [JsonPropertyName("overrideStyleItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("expirationDate")]
        public DateTime? ExpirationDate { get; init; }
        [JsonPropertyName("isWrapper")]
        public bool IsWrapper { get; init; }
        [JsonPropertyName("tooltipNotificationIndexes")]
        public ReadOnlyCollection<int> TooltipNotificationIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("metricHash")]
        public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; init; } = DefinitionHashPointer<DestinyMetricDefinition>.Empty;
        [JsonPropertyName("metricObjective")]
        public DestinyObjectiveProgress MetricObjective { get; init; }
        [JsonPropertyName("versionNumber")]
        public int? VersionNumber { get; init; }
    }
}
