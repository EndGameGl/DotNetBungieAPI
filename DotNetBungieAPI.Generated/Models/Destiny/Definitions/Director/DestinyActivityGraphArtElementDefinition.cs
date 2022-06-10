namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     These Art Elements are meant to represent one-off visual effects overlaid on the map. Currently, we do not have a pipeline to import the assets for these overlays, so this info exists as a placeholder for when such a pipeline exists (if it ever will)
/// </summary>
public class DestinyActivityGraphArtElementDefinition
{
    /// <summary>
    ///     The position on the map of the art element.
    /// </summary>
    [JsonPropertyName("position")]
    public object Position { get; set; }
}
