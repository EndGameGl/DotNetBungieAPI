using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

public sealed record DestinyObjectiveDisplayProperties : IDeepEquatable<DestinyObjectiveDisplayProperties>
{
    /// <summary>
    ///     The activity associated with this objective in the context of this item, if any.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     If true, the game shows this objective on item preview screens.
    /// </summary>
    [JsonPropertyName("displayOnItemPreviewScreen")]
    public bool DisplayOnItemPreviewScreen { get; init; }

    public bool DeepEquals(DestinyObjectiveDisplayProperties other)
    {
        return other != null &&
               Activity.DeepEquals(other.Activity) &&
               DisplayOnItemPreviewScreen == other.DisplayOnItemPreviewScreen;
    }
}