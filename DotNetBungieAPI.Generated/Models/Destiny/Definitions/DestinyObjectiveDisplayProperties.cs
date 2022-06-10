namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyObjectiveDisplayProperties
{
    /// <summary>
    ///     The activity associated with this objective in the context of this item, if any.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     If true, the game shows this objective on item preview screens.
    /// </summary>
    [JsonPropertyName("displayOnItemPreviewScreen")]
    public bool DisplayOnItemPreviewScreen { get; set; }
}
