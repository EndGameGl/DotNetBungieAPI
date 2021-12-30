using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Checklists;

public sealed class DestinyChecklistDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("viewActionString")]
    public string ViewActionString { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    [JsonPropertyName("entries")]
    public List<Destiny.Definitions.Checklists.DestinyChecklistEntryDefinition> Entries { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
