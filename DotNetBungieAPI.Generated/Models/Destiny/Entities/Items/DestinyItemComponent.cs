using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemComponent
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("bindStatus")]
    public Destiny.ItemBindStatus BindStatus { get; init; }

    [JsonPropertyName("location")]
    public Destiny.ItemLocation Location { get; init; }

    [JsonPropertyName("bucketHash")]
    public uint BucketHash { get; init; }

    [JsonPropertyName("transferStatus")]
    public Destiny.TransferStatuses TransferStatus { get; init; }

    [JsonPropertyName("lockable")]
    public bool Lockable { get; init; }

    [JsonPropertyName("state")]
    public Destiny.ItemState State { get; init; }

    [JsonPropertyName("overrideStyleItemHash")]
    public uint? OverrideStyleItemHash { get; init; }

    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; init; }

    [JsonPropertyName("isWrapper")]
    public bool IsWrapper { get; init; }

    [JsonPropertyName("tooltipNotificationIndexes")]
    public List<int> TooltipNotificationIndexes { get; init; }

    [JsonPropertyName("metricHash")]
    public uint? MetricHash { get; init; }

    [JsonPropertyName("metricObjective")]
    public Destiny.Quests.DestinyObjectiveProgress MetricObjective { get; init; }

    [JsonPropertyName("versionNumber")]
    public int? VersionNumber { get; init; }

    [JsonPropertyName("itemValueVisibility")]
    public List<bool> ItemValueVisibility { get; init; }
}
