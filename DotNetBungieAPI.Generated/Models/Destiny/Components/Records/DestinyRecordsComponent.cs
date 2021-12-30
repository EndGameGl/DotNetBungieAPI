using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public sealed class DestinyRecordsComponent
{

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; init; }
}
