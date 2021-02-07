using BungieNetCoreAPI.Destiny.Definitions.PlugSets;
using BungieNetCoreAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The definition information for a specific socket on an item. This will determine how the socket behaves in-game.
    /// </summary>
    public class InventoryItemSocketsBlockSocketEntry : IDeepEquatable<InventoryItemSocketsBlockSocketEntry>
    {
        public bool DefaultVisible { get; }
        public bool HidePerksInItemTooltip { get; }
        public bool OverridesUiAppearance { get; }
        public SocketPlugSources PlugSources { get; }
        public bool PreventInitializationOnVendorPurchase { get; }
        public bool PreventInitializationWhenVersioning { get; }
        public ReadOnlyCollection<InventoryItemSocketsBlockSocketEntryReusablePlugItem> ReusablePlugItems { get; }
        public DefinitionHashPointer<DestinyPlugSetDefinition> ReusablePlugSet { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleInitialItem { get; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }
        public DefinitionHashPointer<DestinyPlugSetDefinition> RandomizedPlugSet { get; }

        [JsonConstructor]
        internal InventoryItemSocketsBlockSocketEntry(bool defaultVisible, bool hidePerksInItemTooltip, bool overridesUiAppearance, SocketPlugSources plugSources,
            bool preventInitializationOnVendorPurchase, bool preventInitializationWhenVersioning, InventoryItemSocketsBlockSocketEntryReusablePlugItem[] reusablePlugItems,
            uint reusablePlugSetHash, uint singleInitialItemHash, uint socketTypeHash, uint? randomizedPlugSetHash)
        {
            DefaultVisible = defaultVisible;
            HidePerksInItemTooltip = hidePerksInItemTooltip;
            OverridesUiAppearance = overridesUiAppearance;
            PlugSources = plugSources;
            PreventInitializationOnVendorPurchase = preventInitializationOnVendorPurchase;
            PreventInitializationWhenVersioning = preventInitializationWhenVersioning;
            ReusablePlugItems = reusablePlugItems.AsReadOnlyOrEmpty();
            ReusablePlugSet = new DefinitionHashPointer<DestinyPlugSetDefinition>(reusablePlugSetHash, DefinitionsEnum.DestinyPlugSetDefinition);
            SingleInitialItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(singleInitialItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, DefinitionsEnum.DestinySocketTypeDefinition);
            RandomizedPlugSet = new DefinitionHashPointer<DestinyPlugSetDefinition>(randomizedPlugSetHash, DefinitionsEnum.DestinyPlugSetDefinition);
        }

        public bool DeepEquals(InventoryItemSocketsBlockSocketEntry other)
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
    }
}
