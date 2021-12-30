using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyInventoryBucketDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.BucketScope Scope { get; init; }

    [JsonPropertyName("category")]
    public Destiny.BucketCategory Category { get; init; }

    [JsonPropertyName("bucketOrder")]
    public int BucketOrder { get; init; }

    [JsonPropertyName("itemCount")]
    public int ItemCount { get; init; }

    [JsonPropertyName("location")]
    public Destiny.ItemLocation Location { get; init; }

    [JsonPropertyName("hasTransferDestination")]
    public bool HasTransferDestination { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("fifo")]
    public bool Fifo { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
