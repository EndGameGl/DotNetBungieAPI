using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyLocationReleaseDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; init; }

    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; init; }

    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; init; }

    [JsonPropertyName("spawnPoint")]
    public uint SpawnPoint { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; init; }

    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; init; }

    [JsonPropertyName("activityBubbleName")]
    public uint ActivityBubbleName { get; init; }

    [JsonPropertyName("activityPathBundle")]
    public uint ActivityPathBundle { get; init; }

    [JsonPropertyName("activityPathDestination")]
    public uint ActivityPathDestination { get; init; }

    [JsonPropertyName("navPointType")]
    public Destiny.DestinyActivityNavPointType NavPointType { get; init; }

    [JsonPropertyName("worldPosition")]
    public List<int> WorldPosition { get; init; }
}
