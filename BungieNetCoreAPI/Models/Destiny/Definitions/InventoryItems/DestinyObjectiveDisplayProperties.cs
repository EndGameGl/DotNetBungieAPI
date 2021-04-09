using NetBungieAPI.Models.Destiny.Definitions.Activities;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyObjectiveDisplayProperties : IDeepEquatable<DestinyObjectiveDisplayProperties>
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("displayOnItemPreviewScreen")]
        public bool DisplayOnItemPreviewScreen { get; init; }

        public bool DeepEquals(DestinyObjectiveDisplayProperties other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   DisplayOnItemPreviewScreen == other.DisplayOnItemPreviewScreen;
        }
    }
}
