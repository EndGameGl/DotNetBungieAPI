namespace DotNetBungieAPI.Models.Destiny.Definitions.Director;

public sealed class DestinyLinkedGraphEntryDefinition
{
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; init; }
}
