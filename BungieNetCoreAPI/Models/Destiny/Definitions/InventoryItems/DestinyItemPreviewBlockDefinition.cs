using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items like Sacks or Boxes can have items that it shows in-game when you view details that represent the items you can obtain if you use or acquire the item.
    /// <para/>
    /// This defines those categories, and gives some insights into that data's source.
    /// </summary>
    public sealed record DestinyItemPreviewBlockDefinition : IDeepEquatable<DestinyItemPreviewBlockDefinition>
    {
        /// <summary>
        /// If the preview has an associated action (like "Open"), this will be the localized string for that action.
        /// </summary>
        [JsonPropertyName("previewActionString")]
        public string PreviewActionString { get; init; }
        /// <summary>
        /// If the preview data is derived from a fake "Preview" Vendor, this will be DestinyVendorDefinition of that fake vendor.
        /// </summary>
        [JsonPropertyName("previewVendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> PreviewVendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;
        /// <summary>
        /// A string that the game UI uses as a hint for which detail screen to show for the item. You, too, can leverage this for your own custom screen detail views. Note, however, that these are arbitrarily defined by designers: there's no guarantees of a fixed, known number of these - so fall back to something reasonable if you don't recognize it.
        /// </summary>
        [JsonPropertyName("screenStyle")]
        public string ScreenStyle { get; init; }
        /// <summary>
        /// If this item should show you Artifact information when you preview it, this is the DestinyArtifactDefinition for the artifact whose data should be shown.
        /// </summary>
        [JsonPropertyName("artifactHash")]
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; } = DefinitionHashPointer<DestinyArtifactDefinition>.Empty;
        /// <summary>
        /// This is a list of the items being previewed, categorized in the same way as they are in the preview UI
        /// </summary>
        [JsonPropertyName("derivedItemCategories")]
        public ReadOnlyCollection<DestinyDerivedItemCategoryDefinition> DerivedItemCategories { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyDerivedItemCategoryDefinition>();

        public bool DeepEquals(DestinyItemPreviewBlockDefinition other)
        {
            return other != null &&
                   PreviewActionString == other.PreviewActionString &&
                   PreviewVendor.DeepEquals(other.PreviewVendor) &&
                   ScreenStyle == other.ScreenStyle &&
                   Artifact.DeepEquals(other.Artifact) &&
                   DerivedItemCategories.DeepEqualsReadOnlyCollections(other.DerivedItemCategories);
        }
    }
}
