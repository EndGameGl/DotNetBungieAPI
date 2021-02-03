using BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlockDye : IDeepEquatable<InventoryItemTranslationBlockDye>
    {
        public DefinitionHashPointer<DestinyArtDyeChannelDefinition> Channel { get; }
        public uint DyeHash { get; }

        [JsonConstructor]
        internal InventoryItemTranslationBlockDye(uint channelHash, uint dyeHash)
        {
            Channel = new DefinitionHashPointer<DestinyArtDyeChannelDefinition>(channelHash, DefinitionsEnum.DestinyArtDyeChannelDefinition);
            DyeHash = dyeHash;
        }

        public bool DeepEquals(InventoryItemTranslationBlockDye other)
        {
            return other != null &&
                   Channel.DeepEquals(other.Channel) &&
                   DyeHash == other.DyeHash;
        }
    }
}
