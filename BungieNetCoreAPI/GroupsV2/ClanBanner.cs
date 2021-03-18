using Newtonsoft.Json;

namespace NetBungieAPI.GroupsV2
{
    public class ClanBanner
    {
        public uint DecalId { get; }
        public uint DecalColorId { get; }
        public uint DecalBackgroundColorId { get; }
        public uint GonfalonId { get; }
        public uint GonfalonColorId { get; }
        public uint GonfalonDetailId { get; }
        public uint GonfalonDetailColorId { get; }

        [JsonConstructor]
        internal ClanBanner(uint decalId, uint decalColorId, uint decalBackgroundColorId, uint gonfalonId, uint gonfalonColorId, uint gonfalonDetailId,
            uint gonfalonDetailColorId)
        {
            DecalId = decalId;
            DecalColorId = decalColorId;
            DecalBackgroundColorId = decalBackgroundColorId;
            GonfalonId = gonfalonId;
            GonfalonColorId = gonfalonColorId;
            GonfalonDetailId = gonfalonDetailId;
            GonfalonDetailColorId = gonfalonDetailColorId;
        }
    }
}
