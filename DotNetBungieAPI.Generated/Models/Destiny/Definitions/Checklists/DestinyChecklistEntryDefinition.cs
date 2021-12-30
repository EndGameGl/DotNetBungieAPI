using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Checklists;

public sealed class DestinyChecklistEntryDefinition
{

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; init; }

    [JsonPropertyName("locationHash")]
    public uint? LocationHash { get; init; }

    [JsonPropertyName("bubbleHash")]
    public uint? BubbleHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }

    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; init; }

    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; init; }

    [JsonPropertyName("vendorInteractionIndex")]
    public int? VendorInteractionIndex { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }
}
