namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Items like Sacks or Boxes can have items that it shows in-game when you view details that represent the items you can obtain if you use or acquire the item.
/// <para />
///     This defines those categories, and gives some insights into that data's source.
/// </summary>
public class DestinyItemPreviewBlockDefinition
{
    /// <summary>
    ///     A string that the game UI uses as a hint for which detail screen to show for the item. You, too, can leverage this for your own custom screen detail views. Note, however, that these are arbitrarily defined by designers: there's no guarantees of a fixed, known number of these - so fall back to something reasonable if you don't recognize it.
    /// </summary>
    [JsonPropertyName("screenStyle")]
    public string ScreenStyle { get; set; }

    /// <summary>
    ///     If the preview data is derived from a fake "Preview" Vendor, this will be the hash identifier for the DestinyVendorDefinition of that fake vendor.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyVendorDefinition>("Destiny.Definitions.DestinyVendorDefinition")]
    [JsonPropertyName("previewVendorHash")]
    public uint PreviewVendorHash { get; set; }

    /// <summary>
    ///     If this item should show you Artifact information when you preview it, this is the hash identifier of the DestinyArtifactDefinition for the artifact whose data should be shown.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Artifacts.DestinyArtifactDefinition>("Destiny.Definitions.Artifacts.DestinyArtifactDefinition")]
    [JsonPropertyName("artifactHash")]
    public uint? ArtifactHash { get; set; }

    /// <summary>
    ///     If the preview has an associated action (like "Open"), this will be the localized string for that action.
    /// </summary>
    [JsonPropertyName("previewActionString")]
    public string PreviewActionString { get; set; }

    /// <summary>
    ///     This is a list of the items being previewed, categorized in the same way as they are in the preview UI.
    /// </summary>
    [JsonPropertyName("derivedItemCategories")]
    public Destiny.Definitions.Items.DestinyDerivedItemCategoryDefinition[]? DerivedItemCategories { get; set; }
}
