using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots
{
    public class EquipmentSlotArtDyeChannelEntry
    {
        public uint ArtDyeChannelHash { get; }

        [JsonConstructor]
        private EquipmentSlotArtDyeChannelEntry(uint artDyeChannelHash)
        {
            ArtDyeChannelHash = artDyeChannelHash;
        }
    }
}
