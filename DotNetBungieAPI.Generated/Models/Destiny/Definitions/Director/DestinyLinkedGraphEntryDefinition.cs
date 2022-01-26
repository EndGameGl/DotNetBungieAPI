namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public class DestinyLinkedGraphEntryDefinition : IDeepEquatable<DestinyLinkedGraphEntryDefinition>
{
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    public bool DeepEquals(DestinyLinkedGraphEntryDefinition? other)
    {
        return other is not null &&
               ActivityGraphHash == other.ActivityGraphHash;
    }
}