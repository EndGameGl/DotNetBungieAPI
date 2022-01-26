namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeRecordChildEntry : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
{
    [JsonPropertyName("recordHash")]
    public uint RecordHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeRecordChildEntry? other)
    {
        return other is not null &&
               RecordHash == other.RecordHash;
    }
}