using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots
{
    public class EquipmentSlotArtDyeChannelEntry : IDeepEquatable<EquipmentSlotArtDyeChannelEntry>
    {
        public uint ArtDyeChannelHash { get; }

        [JsonConstructor]
        internal EquipmentSlotArtDyeChannelEntry(uint artDyeChannelHash)
        {
            ArtDyeChannelHash = artDyeChannelHash;
        }

        public bool DeepEquals(EquipmentSlotArtDyeChannelEntry other)
        {
            return other != null && ArtDyeChannelHash == other.ArtDyeChannelHash;
        }
    }
}
