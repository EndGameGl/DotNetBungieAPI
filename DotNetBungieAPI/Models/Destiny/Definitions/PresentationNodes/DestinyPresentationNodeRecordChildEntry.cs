using DotNetBungieAPI.Models.Destiny.Definitions.Records;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

public sealed record DestinyPresentationNodeRecordChildEntry
    : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
{
    [JsonPropertyName("recordHash")]
    public DefinitionHashPointer<DestinyRecordDefinition> Record { get; init; } =
        DefinitionHashPointer<DestinyRecordDefinition>.Empty;
    
    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }

    public bool DeepEquals(DestinyPresentationNodeRecordChildEntry other)
    {
        return other != null && 
               Record.DeepEquals(other.Record) &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }
}