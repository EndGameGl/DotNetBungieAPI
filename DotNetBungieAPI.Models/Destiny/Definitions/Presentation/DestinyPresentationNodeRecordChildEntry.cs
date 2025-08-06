namespace DotNetBungieAPI.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeRecordChildEntry
{
    [JsonPropertyName("recordHash")]
    public DefinitionHashPointer<Destiny.Definitions.Records.DestinyRecordDefinition> RecordHash { get; init; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }
}
