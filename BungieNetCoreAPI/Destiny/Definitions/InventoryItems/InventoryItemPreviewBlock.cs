using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemPreviewBlock
    {
        public string PreviewActionString { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> PreviewVendor { get; }
        public string ScreenStyle { get; }

        [JsonConstructor]
        private InventoryItemPreviewBlock(string previewActionString, uint previewVendorHash, string screenStyle)
        {
            PreviewActionString = previewActionString;
            PreviewVendor = new DefinitionHashPointer<DestinyVendorDefinition>(previewVendorHash, "DestinyVendorDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            ScreenStyle = screenStyle;
        }
    }
}
