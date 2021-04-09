using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorInteractionReplyDefinition : IDeepEquatable<DestinyVendorInteractionReplyDefinition>
    {
        [JsonPropertyName("itemRewardsSelection")]
        public DestinyVendorInteractionRewardSelection ItemRewardsSelection { get; init; }
        [JsonPropertyName("reply")]
        public string Reply { get; init; }
        [JsonPropertyName("replyType")]
        public DestinyVendorReplyType ReplyType { get; init; }
        [JsonPropertyName("rewardSiteHash")]
        public uint RewardSiteHash { get; init; }

        public bool DeepEquals(DestinyVendorInteractionReplyDefinition other)
        {
            return other != null &&
                   ItemRewardsSelection == other.ItemRewardsSelection &&
                   Reply == other.Reply &&
                   ReplyType == other.ReplyType &&
                   RewardSiteHash == other.RewardSiteHash;
        }
    }
}
