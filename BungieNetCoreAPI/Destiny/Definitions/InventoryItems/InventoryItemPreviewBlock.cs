using NetBungieApi.Destiny.Definitions.Artifacts;
using NetBungieApi.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items like Sacks or Boxes can have items that it shows in-game when you view details that represent the items you can obtain if you use or acquire the item.
    /// <para/>
    /// This defines those categories, and gives some insights into that data's source.
    /// </summary>
    public class InventoryItemPreviewBlock : IDeepEquatable<InventoryItemPreviewBlock>
    {
        /// <summary>
        /// If the preview has an associated action (like "Open"), this will be the localized string for that action.
        /// </summary>
        public string PreviewActionString { get; }
        /// <summary>
        /// If the preview data is derived from a fake "Preview" Vendor, this will be DestinyVendorDefinition of that fake vendor.
        /// </summary>
        public DefinitionHashPointer<DestinyVendorDefinition> PreviewVendor { get; }
        /// <summary>
        /// A string that the game UI uses as a hint for which detail screen to show for the item. You, too, can leverage this for your own custom screen detail views. Note, however, that these are arbitrarily defined by designers: there's no guarantees of a fixed, known number of these - so fall back to something reasonable if you don't recognize it.
        /// </summary>
        public string ScreenStyle { get; }
        /// <summary>
        /// If this item should show you Artifact information when you preview it, this is the DestinyArtifactDefinition for the artifact whose data should be shown.
        /// </summary>
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; }
        /// <summary>
        /// This is a list of the items being previewed, categorized in the same way as they are in the preview UI
        /// </summary>
        public ReadOnlyCollection<InventoryItemPreviewBlockDerivedItemCategory> DerivedItemCategories { get; }

        [JsonConstructor]
        internal InventoryItemPreviewBlock(string previewActionString, uint previewVendorHash, string screenStyle, uint? artifactHash,
            InventoryItemPreviewBlockDerivedItemCategory[] derivedItemCategories)
        {
            PreviewActionString = previewActionString;
            PreviewVendor = new DefinitionHashPointer<DestinyVendorDefinition>(previewVendorHash, DefinitionsEnum.DestinyVendorDefinition);
            ScreenStyle = screenStyle;
            Artifact = new DefinitionHashPointer<DestinyArtifactDefinition>(artifactHash, DefinitionsEnum.DestinyArtifactDefinition);
            DerivedItemCategories = derivedItemCategories.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemPreviewBlock other)
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
