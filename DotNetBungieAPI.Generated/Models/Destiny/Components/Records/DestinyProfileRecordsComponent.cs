using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public sealed class DestinyProfileRecordsComponent
{

    [JsonPropertyName("score")]
    public int Score { get; init; }

    [JsonPropertyName("activeScore")]
    public int ActiveScore { get; init; }

    [JsonPropertyName("legacyScore")]
    public int LegacyScore { get; init; }

    [JsonPropertyName("lifetimeScore")]
    public int LifetimeScore { get; init; }

    [JsonPropertyName("trackedRecordHash")]
    public uint? TrackedRecordHash { get; init; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; init; }

    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; init; }

    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; init; }
}
