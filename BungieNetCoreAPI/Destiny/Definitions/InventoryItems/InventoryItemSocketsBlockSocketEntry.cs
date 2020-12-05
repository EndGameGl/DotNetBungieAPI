using BungieNetCoreAPI.Destiny.Definitions.PlugSets;
using BungieNetCoreAPI.Destiny.Definitions.SocketTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockSocketEntry
    {
        public bool DefaultVisible { get; }
        public bool HidePerksInItemTooltip { get; }
        public bool OverridesUiAppearance { get; }
        public int PlugSources { get; }
        public bool PreventInitializationOnVendorPurchase { get; }
        public bool PreventInitializationWhenVersioning { get; }
        public List<InventoryItemSocketsBlockSocketEntryReusablePlugItem> ReusablePlugItems { get; }
        public DefinitionHashPointer<DestinyPlugSetDefinition> ReusablePlugSet { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> SingleInitialItem { get; }
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; }

        [JsonConstructor]
        private InventoryItemSocketsBlockSocketEntry(bool defaultVisible, bool hidePerksInItemTooltip, bool overridesUiAppearance, int plugSources,
            bool preventInitializationOnVendorPurchase, bool preventInitializationWhenVersioning, List<InventoryItemSocketsBlockSocketEntryReusablePlugItem> reusablePlugItems,
            uint reusablePlugSetHash, uint singleInitialItemHash, uint socketTypeHash)
        {
            DefaultVisible = defaultVisible;
            HidePerksInItemTooltip = hidePerksInItemTooltip;
            OverridesUiAppearance = overridesUiAppearance;
            PlugSources = plugSources;
            PreventInitializationOnVendorPurchase = preventInitializationOnVendorPurchase;
            PreventInitializationWhenVersioning = preventInitializationWhenVersioning;
            ReusablePlugItems = reusablePlugItems;
            ReusablePlugSet = new DefinitionHashPointer<DestinyPlugSetDefinition>(reusablePlugSetHash, "DestinyPlugSetDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SingleInitialItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(singleInitialItemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SocketType = new DefinitionHashPointer<DestinySocketTypeDefinition>(socketTypeHash, "DestinySocketTypeDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
