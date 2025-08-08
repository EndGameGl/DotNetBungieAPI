namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyObjectiveDisplayProperties
{
    /// <summary>
    ///     The activity associated with this objective in the context of this item, if any.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }

    /// <summary>
    ///     If true, the game shows this objective on item preview screens.
    /// </summary>
    [JsonPropertyName("displayOnItemPreviewScreen")]
    public bool DisplayOnItemPreviewScreen { get; init; }
}
