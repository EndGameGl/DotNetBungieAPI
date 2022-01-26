namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Items like Sacks or Boxes can have items that it shows in-game when you view details that represent the items you can obtain if you use or acquire the item.
/// <para />
///     This defines those categories, and gives some insights into that data's source.
/// </summary>
public class DestinyItemPreviewBlockDefinition : IDeepEquatable<DestinyItemPreviewBlockDefinition>
{
    /// <summary>
    ///     A string that the game UI uses as a hint for which detail screen to show for the item. You, too, can leverage this for your own custom screen detail views. Note, however, that these are arbitrarily defined by designers: there's no guarantees of a fixed, known number of these - so fall back to something reasonable if you don't recognize it.
    /// </summary>
    [JsonPropertyName("screenStyle")]
    public string ScreenStyle { get; set; }

    /// <summary>
    ///     If the preview data is derived from a fake "Preview" Vendor, this will be the hash identifier for the DestinyVendorDefinition of that fake vendor.
    /// </summary>
    [JsonPropertyName("previewVendorHash")]
    public uint PreviewVendorHash { get; set; }

    /// <summary>
    ///     If this item should show you Artifact information when you preview it, this is the hash identifier of the DestinyArtifactDefinition for the artifact whose data should be shown.
    /// </summary>
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
    public List<Destiny.Definitions.Items.DestinyDerivedItemCategoryDefinition> DerivedItemCategories { get; set; }

    public bool DeepEquals(DestinyItemPreviewBlockDefinition? other)
    {
        return other is not null &&
               ScreenStyle == other.ScreenStyle &&
               PreviewVendorHash == other.PreviewVendorHash &&
               ArtifactHash == other.ArtifactHash &&
               PreviewActionString == other.PreviewActionString &&
               DerivedItemCategories.DeepEqualsList(other.DerivedItemCategories);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemPreviewBlockDefinition? other)
    {
        if (other is null) return;
        if (ScreenStyle != other.ScreenStyle)
        {
            ScreenStyle = other.ScreenStyle;
            OnPropertyChanged(nameof(ScreenStyle));
        }
        if (PreviewVendorHash != other.PreviewVendorHash)
        {
            PreviewVendorHash = other.PreviewVendorHash;
            OnPropertyChanged(nameof(PreviewVendorHash));
        }
        if (ArtifactHash != other.ArtifactHash)
        {
            ArtifactHash = other.ArtifactHash;
            OnPropertyChanged(nameof(ArtifactHash));
        }
        if (PreviewActionString != other.PreviewActionString)
        {
            PreviewActionString = other.PreviewActionString;
            OnPropertyChanged(nameof(PreviewActionString));
        }
        if (!DerivedItemCategories.DeepEqualsList(other.DerivedItemCategories))
        {
            DerivedItemCategories = other.DerivedItemCategories;
            OnPropertyChanged(nameof(DerivedItemCategories));
        }
    }
}