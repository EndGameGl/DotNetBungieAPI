using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Records;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    public sealed record DestinyPresentationNodeRecordChildEntry
        : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
    {
        [JsonPropertyName("recordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> Record { get; init; } =
            DefinitionHashPointer<DestinyRecordDefinition>.Empty;

        public bool DeepEquals(DestinyPresentationNodeRecordChildEntry other)
        {
            return other != null && Record.DeepEquals(other.Record);
        }
    }
}