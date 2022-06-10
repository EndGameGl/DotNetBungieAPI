namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeRecordChildEntry
{
    [JsonPropertyName("recordHash")]
    public uint? RecordHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint? NodeDisplayPriority { get; set; }
}
