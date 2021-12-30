using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyDestinationDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("placeHash")]
    public uint PlaceHash { get; init; }

    [JsonPropertyName("defaultFreeroamActivityHash")]
    public uint DefaultFreeroamActivityHash { get; init; }

    [JsonPropertyName("activityGraphEntries")]
    public List<Destiny.Definitions.DestinyActivityGraphListEntryDefinition> ActivityGraphEntries { get; init; }

    [JsonPropertyName("bubbleSettings")]
    public List<Destiny.Definitions.DestinyDestinationBubbleSettingDefinition> BubbleSettings { get; init; }

    [JsonPropertyName("bubbles")]
    public List<Destiny.Definitions.DestinyBubbleDefinition> Bubbles { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
