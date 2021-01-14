using BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlockDye
    {
        public DefinitionHashPointer<DestinyArtDyeChannelDefinition> Channel { get; }
        public uint DyeHash { get; }

        [JsonConstructor]
        private InventoryItemTranslationBlockDye(uint channelHash, uint dyeHash)
        {
            Channel = new DefinitionHashPointer<DestinyArtDyeChannelDefinition>(channelHash, "DestinyArtDyeChannelDefinition");
            DyeHash = dyeHash;
        }
    }
}
