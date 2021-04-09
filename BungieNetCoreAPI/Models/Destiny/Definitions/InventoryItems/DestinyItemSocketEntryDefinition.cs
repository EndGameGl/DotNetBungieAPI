using NetBungieAPI.Models.Destiny.Definitions.PlugSets;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition information for a specific socket on an item. This will determine how the socket behaves in-game.
    /// </summary>
    public sealed record DestinyItemSocketEntryDefinition : IDeepEquatable<DestinyItemSocketEntryDefinition>
    {
        [JsonPropertyName("defaultVisible")]
        public bool DefaultVisible { get; init; }
        [JsonPropertyName("hidePerksInItemTooltip")]
        public bool HidePerksInItemTooltip { get; init; }
        [JsonPropertyName("overridesUiAppearance")]
        public bool OverridesUiAppearance { get; init; }
        [JsonPropertyName("detail")]
        public SocketPlugSources PlugSources { get; init; }
        [JsonPropertyName("preventInitializationOnVendorPurchase")]
        public bool PreventInitializationOnVendorPurchase { get; init; }
        [JsonPropertyName("preventInitializationWhenVersioning")]
        public bool PreventInitializationWhenVersioning { get; init; }
        [JsonPropertyName("reusablePlugItems")]
        public ReadOnlyCollection<DestinyItemSocketEntryPlugItemDefinition> ReusablePlugItems { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemSocketEntryPlugItemDefinition>();
        [JsonPropertyName("reusablePlugSetHash")]
        public DefinitionHashPointer<DestinyPlugSetDefinition> ReusablePlugSet { get; init; } = DefinitionHashPointer<DestinyPlugSetDefinition>.Empty;
        [JsonPropertyName("singleInitialItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleInitialItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("socketTypeHash")]
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } = DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;
        [JsonPropertyName("randomizedPlugSetHash")]
        public DefinitionHashPointer<DestinyPlugSetDefinition> RandomizedPlugSet { get; init; } = DefinitionHashPointer<DestinyPlugSetDefinition>.Empty;

        public bool DeepEquals(DestinyItemSocketEntryDefinition other)
        {
            return other != null &&
                   DefaultVisible == other.DefaultVisible &&
                   HidePerksInItemTooltip == other.HidePerksInItemTooltip &&
                   OverridesUiAppearance == other.OverridesUiAppearance &&
                   PlugSources == other.PlugSources &&
                   PreventInitializationOnVendorPurchase == other.PreventInitializationOnVendorPurchase &&
                   PreventInitializationWhenVersioning == other.PreventInitializationWhenVersioning &&
                   ReusablePlugItems.DeepEqualsReadOnlyCollections(other.ReusablePlugItems) &&
                   ReusablePlugSet.DeepEquals(other.ReusablePlugSet) &&
                   SingleInitialItem.DeepEquals(other.SingleInitialItem) &&
                   SocketType.DeepEquals(other.SocketType) &&
                   RandomizedPlugSet.DeepEquals(other.RandomizedPlugSet);
        }

        public override string ToString()
        {
            return $"{PlugSources}";
        }
    }
}
